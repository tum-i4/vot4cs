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
    class FormatInsertTabRightVisitor : CSharpSyntaxRewriter
    {

        //        public override SyntaxNode Visit(SyntaxNode node)
        //        {
        //            SyntaxNode newNode = base.Visit(node);
        //            if (newNode == null)
        //                return node;
        ////            newNode = node.WithLeadingTrivia(node.GetLeadingTrivia().Add(SyntaxFactory.Tab));
        //            return newNode;
        //        }

//        public override SyntaxToken VisitToken(SyntaxToken token)
//        {
//            var visitedToken =  base.VisitToken(token);
//            visitedToken = AddTab(visitedToken);
//            return visitedToken;
//        }

        public override SyntaxNode VisitSwitchSection(SwitchSectionSyntax node)
        {
            SyntaxNode newNode = base.VisitSwitchSection(node);
            newNode = AddTab(newNode);
            return newNode;
        }

        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitIfStatement(node);
            newNode = AddTab(newNode);
            var newIfStatement = newNode as IfStatementSyntax;

            var trueBranch = (StatementSyntax) this.Visit(node.Statement);
            var falseBranch = (ElseClauseSyntax) this.Visit(node.Else);
            newIfStatement = newIfStatement.WithStatement(trueBranch).WithElse(falseBranch);

            return newIfStatement;
        }

        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitSwitchStatement(node);
            newNode = AddTab(newNode);
            var newSwitch = newNode as SwitchStatementSyntax;
            var openLeadingTrivia = newSwitch.OpenBraceToken.LeadingTrivia;
            openLeadingTrivia = openLeadingTrivia.Add(SyntaxFactory.Tab);
            newSwitch = newSwitch.WithOpenBraceToken(
                newSwitch.OpenBraceToken.WithLeadingTrivia(openLeadingTrivia));
            var closeLeadingTrivia = newSwitch.CloseBraceToken.LeadingTrivia;
            closeLeadingTrivia = closeLeadingTrivia.Add(SyntaxFactory.Tab);
            newSwitch = newSwitch.WithCloseBraceToken(
                newSwitch.CloseBraceToken.WithLeadingTrivia(closeLeadingTrivia));

            return newSwitch;
        }

        public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitExpressionStatement(node);
            newNode = AddTab(newNode);
            return newNode;
        }

        public override SyntaxNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitContinueStatement(node);
            newNode = AddTab(newNode);
            return newNode;
        }

        public override SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitReturnStatement(node);
            newNode = AddTab(newNode);
            return newNode;
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            SyntaxNode newNode = base.VisitBreakStatement(node);
            newNode = AddTab(newNode);
            return newNode;
        }

        private SyntaxNode AddTab(SyntaxNode node)
        {
            SyntaxNode newNode = node;
            if (newNode == null)
                return node;
            var leadingTriviaList = node.GetLeadingTrivia();
            var trailingTriviaList = node.GetTrailingTrivia();
            leadingTriviaList = leadingTriviaList.Add(SyntaxFactory.Tab);//.Add(SyntaxFactory.Space).Add(SyntaxFactory.Space).Add(SyntaxFactory.Space).Add(SyntaxFactory.Space);
            newNode = node.WithLeadingTrivia(leadingTriviaList)
                .WithTrailingTrivia(trailingTriviaList);

            return newNode;
        }

        private SyntaxToken AddTab(SyntaxToken node)
        {
            SyntaxToken newNode = node;
            if (newNode == null)
                return node;
            var leadingTriviaList = node.LeadingTrivia;
            var trailingTriviaList = node.TrailingTrivia;
            leadingTriviaList = leadingTriviaList.Add(SyntaxFactory.Tab);//.Add(SyntaxFactory.Space).Add(SyntaxFactory.Space).Add(SyntaxFactory.Space).Add(SyntaxFactory.Space);
            newNode = node.WithLeadingTrivia(leadingTriviaList)
                .WithTrailingTrivia(trailingTriviaList);

            return newNode;
        }

        public static readonly FormatInsertTabRightVisitor Instance = new FormatInsertTabRightVisitor();

    }
}
