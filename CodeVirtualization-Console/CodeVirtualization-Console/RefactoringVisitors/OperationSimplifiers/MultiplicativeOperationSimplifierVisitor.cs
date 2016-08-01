using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.RefactoringVisitors
{
    /// <summary>
    /// transforms sum = a * b * c * d; into
    /// v1 = a * b; v2 = v1 * c; sum = v2 * d;
    /// Applied for * / %
    /// </summary>
    class MultiplicativeOperationSimplifierVisitor : CSharpSyntaxRewriter
    {
        private VirtualizationContext virtualizationContext;
        private static int VAR_COUNTER = 0;
        private static string VAR_NAME = "mulTemp_";

        private int bottomUp = 0;

        private readonly List<SyntaxNode> markedNodes = new List<SyntaxNode>();

        private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, SyntaxNode>> replacementNodes =
            new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, SyntaxNode>>();

        public MultiplicativeOperationSimplifierVisitor(VirtualizationContext virtualizationContext)
        {
            this.virtualizationContext = virtualizationContext;
        }

        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            node = (BinaryExpressionSyntax) base.VisitBinaryExpression(node);

            if ((node.Kind() != SyntaxKind.MultiplyExpression) && 
                (node.Kind() != SyntaxKind.DivideExpression) &&
                (node.Kind() != SyntaxKind.ModuloExpression)
                )
            {
                return node;
            }
            if (node.Parent.Kind() == SyntaxKind.SimpleAssignmentExpression)
            {
                bottomUp = 0;
                return node;
            }
            if (node.Parent.Kind() == SyntaxKind.EqualsValueClause)
            {
                bottomUp = 0;
                return node;
            }

            int markedNodesCount = markedNodes.Count();
            if (markedNodesCount > 0)
            {
                bottomUp++;
                return node;
            }

            if (bottomUp + 2 < VirtualizationContext.MAX_OPERANDS)
            {
                bottomUp++;
//                return node;
            }

            string tempName = VAR_NAME + VAR_COUNTER++;

            var tempVar = SyntaxFactoryExtensions.LocalVariableDeclaration(tempName, node);
            var tempIdentifier = SyntaxFactory.IdentifierName(tempName);
            var tuple = new Tuple<ExpressionSyntax, IdentifierNameSyntax, SyntaxNode>(node, tempIdentifier, tempVar);
            var parent = GetParentExpression(node);
            markedNodes.Add(parent);
            replacementNodes.Add(tuple);

            bottomUp++;

            return node;
        }
        
        /// <summary>
        /// parent must be a block node.
        /// 
        /// IF, WHILE, FOR, SWITCH conditions are assumed to be extracted before operations are simplified.
        /// see order in MethodRefactoringVisitor.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private SyntaxNode GetParentExpression(SyntaxNode node)
        {
            if (node == null)
                return node;
            if ((node.Kind() == SyntaxKind.ExpressionStatement) || (node.Kind() == SyntaxKind.LocalDeclarationStatement)
                    || (node.Kind() == SyntaxKind.ReturnStatement) )
                if(node.Parent!=null)
                    if (node.Parent.Kind() == SyntaxKind.Block) 
                        return node;

            return GetParentExpression(node.Parent);
        }

        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            var markedNodesCount = markedNodes.Count;
            while (markedNodesCount > 0)
            {
                var firstExpression = replacementNodes[0];
                var firstParent = markedNodes[0];
                oldBody = oldBody.TrackNodes(new List<SyntaxNode>() { firstExpression.Item1, firstParent });
                var currentParent = oldBody.GetCurrentNode(firstParent);
                oldBody = oldBody.InsertNodesBefore(currentParent, new List<SyntaxNode>() { firstExpression.Item3 });
                var currentExpression = oldBody.GetCurrentNode(firstExpression.Item1);
                oldBody = oldBody.ReplaceNode(currentExpression, firstExpression.Item2);

                oldBody = this.Refactor(oldBody);

                markedNodesCount = markedNodes.Count;
            }

            return oldBody;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            markedNodes.Clear();
            replacementNodes.Clear();
            bottomUp = 0;
            oldBody = (BlockSyntax)this.Visit(oldBody);
            oldBody = this.ReplaceNodes(oldBody);
            return oldBody;
        }
    }
}
