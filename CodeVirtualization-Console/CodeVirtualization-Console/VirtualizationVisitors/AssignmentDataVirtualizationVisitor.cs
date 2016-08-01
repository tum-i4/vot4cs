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
    class AssignmentDataVirtualizationVisitor : CSharpSyntaxRewriter
    {

        private VirtualizationContext _virtualizationContext;
        private LocalVariableUsageDataVirtVisitor leftLocalVariableUsageVisitor;
        private LocalVariableUsageDataVirtVisitor rightLocalVariableVisitor;

        public AssignmentDataVirtualizationVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
            leftLocalVariableUsageVisitor = new LocalVariableUsageDataVirtVisitor(_virtualizationContext);
            leftLocalVariableUsageVisitor.CastEnabled = true;
            rightLocalVariableVisitor = new LocalVariableUsageDataVirtVisitor(_virtualizationContext);
        }

        public override SyntaxNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            var node1 =  base.VisitAssignmentExpression(node);
            if (node1 == null)
                return node;
            if (!(node1 is AssignmentExpressionSyntax))
                return node;
            node = node1 as AssignmentExpressionSyntax;

            var newNode = node;
            var left = newNode.Left;
            var newLeft = leftLocalVariableUsageVisitor.Visit(left);
            newNode = newNode.ReplaceNode(left, newLeft);

            var right = newNode.Right;
            var newRight = rightLocalVariableVisitor.Visit(right);
            newNode = newNode.ReplaceNode(right, newRight);

            SyntaxAnnotation operationMarker = new SyntaxAnnotation("operation", "assignment1");
            newNode = newNode.WithAdditionalAnnotations(operationMarker);

            return newNode;
        }

        

    }
}
