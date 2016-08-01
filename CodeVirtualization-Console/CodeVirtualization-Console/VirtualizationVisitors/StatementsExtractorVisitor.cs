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
    class StatementsExtractorVisitor : CSharpSyntaxRewriter
    {
        private readonly List<SyntaxNode> statements = new List<SyntaxNode>();
        private readonly List<SyntaxNode> toRemoveStatements = new List<SyntaxNode>();
        private bool freshStatements = false;
        private bool freshToRemove = false;

        public override SyntaxNode Visit(SyntaxNode node)
        {
            freshStatements = true;
            freshToRemove = true;
            return base.Visit(node);
        }

        private List<SyntaxNode> statementsCopy = new List<SyntaxNode>();
        public List<SyntaxNode> Statements
        {
            get
            {
                if (freshStatements)
                {
                    statementsCopy = new List<SyntaxNode>(statements);
                    statements.Clear();
                    freshStatements = false;
                }
                return statementsCopy;
            }
        }

        private List<SyntaxNode> toRemoveCopy = new List<SyntaxNode>();
        public List<SyntaxNode> StatementsToRemove
        {
            get
            {
                if (freshToRemove)
                {
                    toRemoveCopy = new List<SyntaxNode>(toRemoveStatements);
                    toRemoveStatements.Clear();
                    freshToRemove = false;
                }
                return toRemoveCopy;
            }
        }

        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            statements.Add(node);
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            statements.Add(node);
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            statements.Add(node);
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            statements.Add(node);
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitTryStatement(TryStatementSyntax node)
        {
            //TODO: try/catch not supported!!!
            statements.Add(node);
            toRemoveStatements.Add(node);
            return node;
        }

        public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            //cut child traversal
            return node;
        }

        public override SyntaxNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            //cut child traversal
            return node;
        }

        public override SyntaxNode VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            //cut child traversal
            return node;
        }

    }
}
