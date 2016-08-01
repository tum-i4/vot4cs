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
    class SwitchBreakRefactoringVisitor : CSharpSyntaxRewriter
    {

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            node = (BreakStatementSyntax) base.VisitBreakStatement(node);
            if (node == null)
                return node;

            bool inSwitch = IsSwitchParent(node);
            if (inSwitch)
                return null;

            return node;
        }


        public SyntaxNode GetParentExpression(SyntaxNode node)
        {
            if (node == null)
                return node;
            if ((node.Kind() == SyntaxKind.ExpressionStatement) || (node.Kind() == SyntaxKind.LocalDeclarationStatement)
                    || (node.Kind() == SyntaxKind.ReturnStatement))
                if (node.Parent != null)
                    if (node.Parent.Kind() == SyntaxKind.Block)
                        return node;

            return GetParentExpression(node.Parent);
        }

        public bool IsSwitchParent(SyntaxNode node)
        {
            if (node == null)
                return false;
            if ((node.Kind() == SyntaxKind.SwitchSection))
                return true;
            if ((node.Kind() == SyntaxKind.WhileStatement))
                return false;
            if ((node.Kind() == SyntaxKind.ForEachStatement))
                return false;
            if ((node.Kind() == SyntaxKind.ForStatement))
                return false;
            if ((node.Kind() == SyntaxKind.DoStatement))
                return false;
            return IsSwitchParent(node.Parent);
        }

    
    }
}
