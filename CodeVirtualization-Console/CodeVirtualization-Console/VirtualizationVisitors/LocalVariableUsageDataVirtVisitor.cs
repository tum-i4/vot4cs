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
    class LocalVariableUsageDataVirtVisitor : CSharpSyntaxRewriter
    {

        private VirtualizationContext _virtualizationContext;

        public LocalVariableUsageDataVirtVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public bool CastEnabled { get; set; } = true;

        public bool ParenthesizeEnabled { get; set; } = true;

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            CheckCastContex(node);
            CheckParenthesizeContex(node);

            var newNode = SyntaxFactoryExtensions.DataCodeVirtualAccess();
                
            string name = node.Identifier.Text;
            string typeText = "";
            bool found = false;
            VirtualData virtualData = null;
            foreach (var data in _virtualizationContext.data)
            {
                if (data.Name.Equals(name))
                {
                    typeText = data.Type;
                    found = true;
                    virtualData = data;
                    break;
                }
            }
            if (!found)
                return node;

            newNode = newNode.WithAdditionalAnnotations(virtualData.Annotations);

            var newExpression = newNode;
            if (CastEnabled)
            {
                newExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName
                                                        (
                                                            @"" + typeText
                                                        ),
                                                           newNode
                                                       );
                
            }
            if(ParenthesizeEnabled)
                newExpression = SyntaxFactory.ParenthesizedExpression(newExpression);

            newExpression = newExpression.WithLeadingTrivia(node.GetLeadingTrivia())
                .WithTrailingTrivia(node.GetTrailingTrivia())
                ;

            return newExpression;
        }

        private void CheckCastContex(IdentifierNameSyntax node)
        {
            var parentCheck = node.Parent;
            if (parentCheck is AssignmentExpressionSyntax)
            {
                var parent = parentCheck as AssignmentExpressionSyntax;
                if (parent.Kind() == SyntaxKind.SimpleAssignmentExpression)
                {
                    var assignment = parent as AssignmentExpressionSyntax;
                    if (assignment.Right.IsEquivalentTo(node))
                        CastEnabled = true;
                    else
                        CastEnabled = false;
                }                    
            }
            else
                CastEnabled = true;
        }

        private void CheckParenthesizeContex(IdentifierNameSyntax node)
        {
            //TODO: check pointers
            var parent = node.Parent;
            if (parent.Kind() == SyntaxKind.SimpleMemberAccessExpression)
            {
                ParenthesizeEnabled = true;
            }
            else if (parent.Kind() == SyntaxKind.ElementAccessExpression)
            {
                ParenthesizeEnabled = true;
            }
            else
                ParenthesizeEnabled = false;
        }
    }
}
