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
    class SwitchConditionRefactoringVisitor : CSharpSyntaxRewriter
    {
        private static int INDEX_VAR_COUNTER = 0;
        private static string INDEX_VAR = "switchCondition_";

        private static string ConditionIdentifier
        {
            get { return INDEX_VAR + INDEX_VAR_COUNTER++; }
        }

        private readonly List<ExpressionSyntax> markedNodes = new List<ExpressionSyntax>();

        private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>> replacementNodes =
            new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>>();



        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            node = (SwitchStatementSyntax) base.VisitSwitchStatement(node);

            var condition = node.Expression;

            if (condition.Kind() == SyntaxKind.IdentifierName)
                return node;

            string conditionVarIdentifier = ConditionIdentifier;
            var newConditionVar = SyntaxFactoryExtensions.LocalVariableDeclaration(conditionVarIdentifier,
                condition).NormalizeWhitespace().WithTriviaFrom(node);
            var newCondition = SyntaxFactory.IdentifierName(conditionVarIdentifier).WithTriviaFrom(condition);

            markedNodes.Add(condition);
            replacementNodes.Add(new Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>(condition, newCondition, newConditionVar));

            return node;
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
