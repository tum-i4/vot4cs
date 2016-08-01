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
    class SwitchSectionRefactoringVisitor : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitSwitchSection(SwitchSectionSyntax node)
        {
            node = (SwitchSectionSyntax) base.VisitSwitchSection(node);
            
            var oldStatements = node.Statements;
            if (oldStatements.Count == 0) //empty case - used for fall-through
                return node;

            var caseTrailing = node.GetTrailingTrivia();
            var caseLeading = node.GetLeadingTrivia();
            var trueBlock = ToBlockSyntax(oldStatements, caseLeading, caseTrailing);
            node = node.WithStatements(trueBlock);

            return node;
        }

        private SyntaxList<StatementSyntax> ToBlockSyntax(SyntaxList<StatementSyntax> body, SyntaxTriviaList leading, SyntaxTriviaList trailing)
        {
            if (body.Count == 1)
            {
                var firstStatement = body[0];
                if (firstStatement.Kind() == SyntaxKind.Block)
                    return body;
            }
                     
            BlockSyntax block = SyntaxFactory.Block(body);
            var bracketLeadingTrivia = leading.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));

            block = block.WithOpenBraceToken(
                SyntaxFactory.Token(SyntaxKind.OpenBraceToken)
                    .WithLeadingTrivia(bracketLeadingTrivia)
//                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                    );
            block = block.WithCloseBraceToken(SyntaxFactory.Token(SyntaxKind.CloseBraceToken).
                WithLeadingTrivia(bracketLeadingTrivia)
//                .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                );

            SyntaxList<StatementSyntax> list = new SyntaxList<StatementSyntax>();
            list = list.Add(block);

            return list;
        }


        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            oldBody = (BlockSyntax)this.Visit(oldBody);

            return oldBody;
        }

    }
}
