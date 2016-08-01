using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.Visitors
{
    internal class PrePostOperationVisitor : CSharpSyntaxRewriter
    {
        private static int VAR_COUNTER = 0;
        private static string VAR_NAME = "prePostTemp_";

        private static string TemporaryVarIdentifier
        {
            get { return VAR_NAME + VAR_COUNTER++; }
        }

        private readonly List<SyntaxNode> markedNodes = new List<SyntaxNode>();

        private readonly List<Tuple<SyntaxNode, IdentifierNameSyntax, int, SyntaxNode, SyntaxNode>> replacementNodes =
            new List<Tuple<SyntaxNode, IdentifierNameSyntax, int, SyntaxNode, SyntaxNode>>();

        public override SyntaxNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            node = (PrefixUnaryExpressionSyntax)base.VisitPrefixUnaryExpression(node);

            return VisitPrePostExpression(node, null);
        }

        public override SyntaxNode VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            node = (PostfixUnaryExpressionSyntax) base.VisitPostfixUnaryExpression(node);

            return VisitPrePostExpression(null, node);
        }

        public SyntaxNode VisitPrePostExpression(PrefixUnaryExpressionSyntax pre, PostfixUnaryExpressionSyntax post)
        {
            SyntaxNode node = null;
            if (pre == null)
                node = post;
            if (post == null)
                node = pre;
            if (node == null)
                return node;

            bool postDecr = (node.Kind() == SyntaxKind.PostDecrementExpression);
            bool postIncr = (node.Kind() == SyntaxKind.PostIncrementExpression);
            bool preDecr = (node.Kind() == SyntaxKind.PreDecrementExpression);
            bool preIncr = (node.Kind() == SyntaxKind.PreIncrementExpression);

            bool condition = postDecr || postIncr || preDecr || preIncr;
            if (!condition) 
                return node;
            
            int markedNodesCount = markedNodes.Count();
            if (markedNodesCount > 0)
                return node;
            ExpressionSyntax operand = null;
            int operationType = 0; // 0 - pre, 1 - post
            if (postDecr || postIncr)
            {
                operationType = 1;
                operand = ((PostfixUnaryExpressionSyntax) node).Operand;
            }
            else
            {
                operand = ((PrefixUnaryExpressionSyntax)node).Operand;
            }
                

            string tempName = TemporaryVarIdentifier + "_" + operationType;

            StatementSyntax indexUpdate = null;
            if (postIncr || preIncr)
                indexUpdate = IncrementIndex(operand);
            else if (postDecr || preDecr)
                indexUpdate = DecrementIndex(operand);

            var tempVar = SyntaxFactoryExtensions.LocalVariableDeclaration(tempName, operand);
            var tempIdentifier = SyntaxFactory.IdentifierName(tempName);
            var tuple = new Tuple<SyntaxNode, IdentifierNameSyntax, int, SyntaxNode, SyntaxNode>(node, tempIdentifier, operationType, tempVar, indexUpdate);
            var parent = GetParentExpression(node);
            markedNodes.Add(parent);
            replacementNodes.Add(tuple);

            return node;
        }

        /// <summary>
        /// index = index + 1
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private ExpressionStatementSyntax IncrementIndex(ExpressionSyntax operand)
        {
            //create incremented variable
            var rightExpression = SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, operand, SyntaxFactoryExtensions.NumericLiteralExpression(1));
            var incrementedVariable = SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, operand, rightExpression));
            return incrementedVariable;
        }

        /// <summary>
        /// index = index - 1;
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private ExpressionStatementSyntax DecrementIndex(ExpressionSyntax operand)
        {            
            var rightExpression = SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, operand, SyntaxFactoryExtensions.NumericLiteralExpression(1));
            var incrementedVariable = SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, operand, rightExpression));
            return incrementedVariable;
        }



        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            var markedNodesCount = markedNodes.Count;
            while (markedNodesCount > 0)
            {
                var firstExpression = replacementNodes[0];
                var firstParent = markedNodes[0];
                oldBody = oldBody.TrackNodes(new List<SyntaxNode>() { firstExpression.Item1, firstParent });
                
                //simple increment: index++; --index;
                if (firstExpression.Item1.Parent.Kind() == SyntaxKind.ExpressionStatement)
                {
                    var currentOperation = oldBody.GetCurrentNode(firstExpression.Item1);
                    var indexUpdate = ((ExpressionStatementSyntax) firstExpression.Item5).Expression;
                    oldBody = oldBody.ReplaceNode(currentOperation, indexUpdate);
                    oldBody = this.Refactor(oldBody);
                    markedNodesCount = markedNodes.Count;
                    continue;
                }

                if (firstExpression.Item3 == 0) //pre operation type
                {
                    var currentParent = oldBody.GetCurrentNode(firstParent);
                    oldBody = oldBody.InsertNodesBefore(currentParent, new List<SyntaxNode>() { firstExpression.Item5 });
                    currentParent = oldBody.GetCurrentNode(firstParent);
                    oldBody = oldBody.InsertNodesBefore(currentParent, new List<SyntaxNode>() { firstExpression.Item4 });                    
                }
                else //post opertion type
                {
                    var currentParent = oldBody.GetCurrentNode(firstParent);
                    oldBody = oldBody.InsertNodesBefore(currentParent, new List<SyntaxNode>() { firstExpression.Item4 });
                    currentParent = oldBody.GetCurrentNode(firstParent);
                    oldBody = oldBody.InsertNodesBefore(currentParent, new List<SyntaxNode>() { firstExpression.Item5 });
                }

                var updatedOperation = oldBody.GetCurrentNode(firstExpression.Item1);
                oldBody = oldBody.ReplaceNode(updatedOperation, firstExpression.Item2);
                oldBody = this.Refactor(oldBody);
                markedNodesCount = markedNodes.Count;
            }

            return oldBody;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            markedNodes.Clear();
            replacementNodes.Clear();

            oldBody = (BlockSyntax)this.Visit(oldBody);
            oldBody = this.ReplaceNodes(oldBody);

            return oldBody;
        }

        public SyntaxNode GetParentExpression(SyntaxNode node)
        {
            if (node == null)
                return node;
            if ((node.Kind() == SyntaxKind.ExpressionStatement) || (node.Kind() == SyntaxKind.LocalDeclarationStatement)
                || (node.Kind() == SyntaxKind.ReturnStatement)                
                )
                if (node.Parent != null)
                    if (node.Parent.Kind() == SyntaxKind.Block)
                        return node;

            return GetParentExpression(node.Parent);
        }


        public SyntaxNode template(SyntaxNode node)
        {

            //TODO: PostDecrementExpression
            //TODO: PostIncrementExpression
            int a = 0;
            int b = 0;
            int[] c = new int[30];

            a++;
            //becomes
            a = a + 1;

            b = a++;
           //becomes
            int a1 = a;
            a = a + 1;
            b = a1;

            b = c[a++];
            //becomes
            a1 = a;
            a = a + 1;
            b = c[a];

            b = c[a++] + c[a++];
            //becomes
            a1 = a;
            a = a + 1;
            int a2 = a + 1;
            a = a + 1;
            b = c[a1] + c[a2];

            //TODO: PreDecrementExpression
            //TODO: PreIncrementExpression
            b = ++a;
            //becomes
            a = a + 1;
            a1 = a;
            b = a1;

            b = c[++a] + c[++a];
            //becomes
            a = a + 1;
            a1 = a;
            a = a + 1;
            a2 = a;
            b = c[a1] + c[a2];

            return node;

        }
    }
}
