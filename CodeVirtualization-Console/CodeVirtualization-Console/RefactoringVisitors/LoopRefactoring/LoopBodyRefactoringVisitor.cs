using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.RefactoringVisitors.LoopRefactoring
{
    /// <summary>
    /// Adds parenthesis to body if only one statement in the loop
    /// </summary>
    class LoopBodyRefactoringVisitor : CSharpSyntaxRewriter
    {


        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            var body = node.Statement;
            var bodyBlock = ToBlockSyntax(body);
            if (!bodyBlock.Equals(body))
                node = node.WithStatement(bodyBlock);
            return node;
        }

        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {            
            var body = node.Statement;
            var bodyBlock = ToBlockSyntax(body);
            if (!bodyBlock.Equals(body))
                node = node.WithStatement(bodyBlock);
            return node;
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            var body = node.Statement;
            var bodyBlock = ToBlockSyntax(body);
            if (!bodyBlock.Equals(body))
                node = node.WithStatement(bodyBlock);
            return node;
        }

        public override SyntaxNode VisitDoStatement(DoStatementSyntax node)
        {
            var body = node.Statement;
            var bodyBlock = ToBlockSyntax(body);
            if (!bodyBlock.Equals(body))
                node = node.WithStatement(bodyBlock);
            return node;
        }

        private BlockSyntax ToBlockSyntax(StatementSyntax body)
        {
            List<StatementSyntax> statements = new List<StatementSyntax>();
            if (body.Kind() == SyntaxKind.Block)
            {
                body = (StatementSyntax)Visit(body);
                return (BlockSyntax)body;
            }
            else
            {
                var leadingTrivia = body.GetLeadingTrivia();
                body = (StatementSyntax)Visit(body);
                statements.Add(body);
            }

            BlockSyntax block = SyntaxFactory.Block(statements);

            block = block.WithOpenBraceToken(
                SyntaxFactory.Token(SyntaxKind.OpenBraceToken)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                    );
            block = block.WithCloseBraceToken(SyntaxFactory.Token(SyntaxKind.CloseBraceToken).
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
