using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.VirtualizationVisitors
{
    class ConditionalExpressionVisitor : CSharpSyntaxRewriter
    {
        private static int CONDITION_COUNTER = 0;
        private static string CONDITION_VAR = "var_conditional_";

        private static string ConditionIdentifier
        {
            get { return CONDITION_VAR + CONDITION_COUNTER++; }
        }

        private readonly List<ExpressionSyntax> markedNodes = new List<ExpressionSyntax>();

        private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>> replacementNodes =
            new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>>();


        public override SyntaxNode VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            //             throw new NotImplementedException("Virtualization: conditional expression - a ? true : false not supported");
            //TODO: this is a naive implementation, i.e. it treats only simple cases, not recursive ones



            var conditionExpression = node.Condition;

            string conditionVarIdentifier = ConditionIdentifier;
            var newConditionVar = SyntaxFactoryExtensions.LocalVariableDeclaration(conditionVarIdentifier,
                conditionExpression, SyntaxKind.BoolKeyword).NormalizeWhitespace().WithTriviaFrom(node);
            var newCondition = SyntaxFactory.IdentifierName(conditionVarIdentifier).WithTriviaFrom(conditionExpression);

            ExpressionStatementSyntax parentExpression = (ExpressionStatementSyntax) GetParentExpression(node);
            markedNodes.Add(parentExpression.Expression);
//            p
//
//            var trueBranch = node.WhenTrue;
//            var falseBranch = node.WhenFalse;
//                        
//            var statement = SyntaxFactory.IfStatement(newCondition, SyntaxFactory.ExpressionStatement(trueBranch), SyntaxFactory.ElseClause(SyntaxFactory.ExpressionStatement(falseBranch)));
//
//            replacementNodes.Add(new Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>(condition, newCondition, newConditionVar));

            return node;
        }

        private SyntaxNode GetParentExpression(SyntaxNode node)
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

        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            oldBody = oldBody.TrackNodes(this.markedNodes);
            foreach (var tuple in this.replacementNodes)
            {
                var currentA = oldBody.GetCurrentNode(tuple.Item1);
                if (currentA != null)
                {
                    var ifStatement = currentA.Parent;
                    oldBody = oldBody.InsertNodesBefore(ifStatement, new List<SyntaxNode>() { tuple.Item3 });
                    var currentB = oldBody.GetCurrentNode(tuple.Item1);
                    oldBody = oldBody.ReplaceNode(currentB, tuple.Item2);
                }
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
    }
}
