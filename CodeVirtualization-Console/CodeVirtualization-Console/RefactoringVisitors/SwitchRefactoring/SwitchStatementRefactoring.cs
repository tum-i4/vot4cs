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
    class SwitchStatementRefactoringVisitor : CSharpSyntaxRewriter
    {

        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            var visitedNode = base.VisitSwitchStatement(node);
            if (visitedNode.Kind() != SyntaxKind.SwitchStatement)
                return visitedNode;

            node = visitedNode as SwitchStatementSyntax;

            var condition = node.Expression;
            var sections = node.Sections;

            var ifStatement = ChainIf(condition, sections);

            return ifStatement;
        }


        private IfStatementSyntax ChainIf(ExpressionSyntax condition, SyntaxList<SwitchSectionSyntax> sections)
        {
            List<StatementSyntax> transformedSections = new List<StatementSyntax>();

            //add default as the last section
            StatementSyntax defaultIf = null;
            foreach (var section in sections)
            {
                if (IsDefault(section))
                {
                    defaultIf = SectionToIf(condition, section);
                    continue;
                }
                var ifStatement = SectionToIf(condition, section);
                transformedSections.Add(ifStatement);
            }

            if(defaultIf != null)
                transformedSections.Add(defaultIf);

            if (transformedSections.Count == 1)
                return (IfStatementSyntax) transformedSections[0];

            IfStatementSyntax chainedIfStatement = null;
            for (int i = transformedSections.Count - 1; i >= 0; i--)
            {
                if (chainedIfStatement == null)
                {
                    var previousIfStatement = (IfStatementSyntax) transformedSections[i - 1];
                    var elseStatement = transformedSections[i];
                    chainedIfStatement = previousIfStatement.WithElse(SyntaxFactory.ElseClause(elseStatement));
                    i = i - 1;
                    continue;
                }
                var currentIfStatement = (IfStatementSyntax) transformedSections[i];
                chainedIfStatement = currentIfStatement.WithElse(SyntaxFactory.ElseClause(chainedIfStatement));
            }

            return chainedIfStatement;
        }

        private bool IsDefault(SwitchSectionSyntax section)
        {
            foreach (var label in section.Labels)
            {
                if (label.Keyword.Kind() == SyntaxKind.DefaultKeyword)
                {
                    return true;
                }
            }
            return false;
        }

        private StatementSyntax SectionToIf(ExpressionSyntax condition, SwitchSectionSyntax section)
        {
            SwitchBreakRefactoringVisitor breakRefactoring = new SwitchBreakRefactoringVisitor();
            var bodyList = section.Statements.First();
            bodyList = (StatementSyntax) breakRefactoring.Visit(bodyList);

            bool hasDefault = false;
            List<ExpressionSyntax> labelExpressions = new List<ExpressionSyntax>();
            
            foreach (var label in section.Labels)
            {
                if (label.Keyword.Kind() == SyntaxKind.DefaultKeyword)
                {
                    hasDefault = true;                    
                }
                    
                foreach (var child in label.ChildNodes())
                {                    
                    var labelCondition = (ExpressionSyntax) child;
                    if ((labelCondition.Kind() != SyntaxKind.NumericLiteralExpression) ||
                        (labelCondition.Kind() != SyntaxKind.StringLiteralExpression) ||
                        (labelCondition.Kind() != SyntaxKind.CharacterLiteralExpression) ||
                        (labelCondition.Kind() != SyntaxKind.SimpleMemberAccessExpression)
                        )
                    {
                        labelCondition = SyntaxFactory.ParenthesizedExpression(labelCondition).WithTriviaFrom(labelCondition);
                    }
                    labelExpressions.Add(labelCondition);
                    break;
                }
            }

            List<ExpressionSyntax> flagConditions = new List<ExpressionSyntax>();
            foreach (var expression in labelExpressions)
            {                
                var memberAccess = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, condition,
                    SyntaxFactory.IdentifierName("Equals"));
                var arg = SyntaxFactory.Argument(expression);
                var argList = SyntaxFactory.SeparatedList<ArgumentSyntax>(new List<ArgumentSyntax>() {arg});
                
                var invocation = SyntaxFactory.InvocationExpression(memberAccess, SyntaxFactory.ArgumentList(argList));

                flagConditions.Add(invocation);
            }

            ExpressionSyntax ifCondition = SyntaxFactoryExtensions.BooleanLiteralExpression(true);            
            if (flagConditions.Count == 1)
                ifCondition = flagConditions[0];

            BinaryExpressionSyntax boolCondition = null;
            for (int i = 1; i < flagConditions.Count; i++)
            {
                var right = flagConditions[i];
                if (boolCondition == null)
                {
                    boolCondition = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalOrExpression, flagConditions[0], right);
                }
                else
                    boolCondition = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalOrExpression, boolCondition, right);
                ifCondition = boolCondition;
            }

            if (hasDefault)
            {
//                ifCondition = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalOrExpression, ifCondition, SyntaxFactoryExtensions.BooleanLiteralExpression(true));
                return bodyList;
            }

            var ifStatement = SyntaxFactory.IfStatement(ifCondition, bodyList);
            return ifStatement;
        }


        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            oldBody = (BlockSyntax)this.Visit(oldBody);

            return oldBody;
        }

    }
}
