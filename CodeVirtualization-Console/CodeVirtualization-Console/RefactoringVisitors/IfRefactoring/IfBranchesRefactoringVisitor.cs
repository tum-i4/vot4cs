using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace CodeVirtualization_Console.RefactoringVisitors
{
    /// <summary>
    /// Adds block paranthesis to body if only one statement in either branches
    /// </summary>
    class IfBranchesRefactoringVisitor : CSharpSyntaxRewriter
    {
        
        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            var nodeVisited = node;
            var trueTrailing = nodeVisited.GetTrailingTrivia();
            var trueLeading = nodeVisited.GetLeadingTrivia();
            var trueBranch = nodeVisited.Statement;
            var trueBlock = ToBlockSyntax(trueBranch, trueLeading, trueTrailing);
            if (!trueBranch.Equals(trueBlock))
                nodeVisited = nodeVisited.WithStatement(trueBlock);

            var falseBranch = nodeVisited.Else;
            if (falseBranch == null)
                return nodeVisited;

            var falseLeading = falseBranch.GetLeadingTrivia();
            var falseTrailing = falseBranch.GetTrailingTrivia();
            var falseStatement = falseBranch.Statement ;
            var falseBlock = ToBlockSyntax(falseStatement, falseLeading, falseTrailing);
            if (!falseStatement.Equals(falseBlock))
            {
                falseBranch = falseBranch.WithStatement(falseBlock);
                nodeVisited = nodeVisited.WithElse(falseBranch);
            }

            return nodeVisited;
        }


        private BlockSyntax ToBlockSyntax(StatementSyntax body, SyntaxTriviaList leading, SyntaxTriviaList trailing)
        {

            //TODO: fix trivia
            var bracketLeadingTrivia = leading.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));
            List<StatementSyntax> statements = new List<StatementSyntax>();
            if (body.Kind() == SyntaxKind.Block)
            {
                body = (StatementSyntax)Visit(body);
                return (BlockSyntax) body;
            }
            else
            {
                var leadingTrivia = body.GetLeadingTrivia();
                body = (StatementSyntax) Visit(body);
                statements.Add(body);   
            }
            
            BlockSyntax block = SyntaxFactory.Block(statements);
            
            block = block.WithOpenBraceToken(
                SyntaxFactory.Token(SyntaxKind.OpenBraceToken)
                    .WithLeadingTrivia(bracketLeadingTrivia)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                    );
            block = block.WithCloseBraceToken(SyntaxFactory.Token(SyntaxKind.CloseBraceToken).
                WithLeadingTrivia(bracketLeadingTrivia).
                WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)));

            return block;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            oldBody = (BlockSyntax)this.Visit(oldBody);

            return oldBody;
        }

    }
}
