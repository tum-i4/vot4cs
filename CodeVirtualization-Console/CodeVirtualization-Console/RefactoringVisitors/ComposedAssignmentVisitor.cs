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
    /// <summary>
    /// Transforms
    /// a += b to a = a + b;
    /// Does the same for:  *=, -=, &=, |=, /=, >>=, 
    /// <<=, ^=, %=
    /// </summary>
    class ComposedAssignmentVisitor : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            var expressionCheck = node.Expression;
            bool and = (expressionCheck.Kind() == SyntaxKind.AndAssignmentExpression);
            bool or = (expressionCheck.Kind() == SyntaxKind.OrAssignmentExpression);
            bool sub = (expressionCheck.Kind() == SyntaxKind.SubtractAssignmentExpression);
            bool add = (expressionCheck.Kind() == SyntaxKind.AddAssignmentExpression);
            bool mult = (expressionCheck.Kind() == SyntaxKind.MultiplyAssignmentExpression);
            bool div = (expressionCheck.Kind() == SyntaxKind.DivideAssignmentExpression);
            bool rightShift = (expressionCheck.Kind() == SyntaxKind.RightShiftAssignmentExpression);
            bool leftShift = (expressionCheck.Kind() == SyntaxKind.LeftShiftAssignmentExpression);
            bool xor = (expressionCheck.Kind() == SyntaxKind.ExclusiveOrAssignmentExpression);
            bool modulo = (expressionCheck.Kind() == SyntaxKind.ModuloAssignmentExpression);

            bool condition = and || or || sub || add || mult || div || rightShift || leftShift || xor || modulo;
            if (!condition)
                return node;

            SyntaxKind newOperation = SyntaxKind.AddExpression;
            if (and)
                newOperation = SyntaxKind.BitwiseAndExpression; 
            else if (or)
                newOperation = SyntaxKind.BitwiseOrExpression;
            else if (sub)
                newOperation = SyntaxKind.SubtractExpression;
            else if (add)
                newOperation = SyntaxKind.AddExpression;
            else if (mult)
                newOperation = SyntaxKind.MultiplyExpression;
            else if (div)
                newOperation = SyntaxKind.DivideExpression;
            else if (leftShift)
                newOperation = SyntaxKind.LeftShiftExpression;
            else if (rightShift)
                newOperation = SyntaxKind.RightShiftExpression;
            else if (xor)
                newOperation = SyntaxKind.ExclusiveOrExpression;
            else if (modulo)
                newOperation = SyntaxKind.ModuloExpression;

            var expression = expressionCheck as AssignmentExpressionSyntax;
            var left = expression.Left.WithoutTrivia();
            var right = expression.Right.WithoutTrivia();
            var newRight = SyntaxFactory.BinaryExpression(newOperation, left, right);
            var assignment = SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, left, newRight);
            var newExpression = SyntaxFactory.ExpressionStatement(assignment)
                .NormalizeWhitespace().WithTriviaFrom(node);
            return newExpression;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            oldBody = (BlockSyntax)this.Visit(oldBody);

            return oldBody;
        }

    }
}
