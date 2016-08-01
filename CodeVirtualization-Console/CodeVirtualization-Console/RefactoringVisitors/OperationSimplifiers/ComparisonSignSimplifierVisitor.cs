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
    class ComparisonSignSimplifierVisitor : CSharpSyntaxRewriter
    {


        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            node = (BinaryExpressionSyntax) base.VisitBinaryExpression(node);

            var comparisonKind = node.Kind();
            if (comparisonKind == SyntaxKind.GreaterThanExpression)
            {
                comparisonKind = SyntaxKind.LessThanExpression;
            }
            else if (comparisonKind == SyntaxKind.GreaterThanOrEqualExpression)
            {
                comparisonKind = SyntaxKind.LessThanOrEqualExpression;
            }
            else
                return node;

            var left = node.Left;
            var right = node.Right;

            var inverted = SyntaxFactory.BinaryExpression(comparisonKind, right, left);
            node = inverted;

            return node;
        }



    }
}
