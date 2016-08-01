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
    internal class ConstantValueVisitor : CSharpSyntaxRewriter
    {
        private VirtualizationContext _virtualizationContext;

        public List<LiteralExpressionSyntax> constants = new List<LiteralExpressionSyntax>();
        public readonly List<Tuple<LiteralExpressionSyntax, List<StatementSyntax>>> markedNodes =
            new List<Tuple<LiteralExpressionSyntax, List<StatementSyntax>>>();

        public ConstantValueVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
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

        public override SyntaxNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            if (node.Kind() != SyntaxKind.UnaryMinusExpression)
            {
                return base.VisitPrefixUnaryExpression(node);
            }
            var expression = node.Operand;
            if (expression.Kind() != SyntaxKind.NumericLiteralExpression)
            {
                return base.VisitPrefixUnaryExpression(node);
            }

            CheckCastContex(node);

            string value = node.ToString();
            bool found = false;
            VirtualData constant = null;
            foreach (var data in _virtualizationContext.data)
            {
                if (value.Equals(data.Name))
                {
                    found = true;
                    constant = data;
                    break;
                }
            }
            if (!found)
            {
                int index = _virtualizationContext.DataIndex;
                string name = value;
                SyntaxAnnotation indexMarker = new SyntaxAnnotation("index", index + "");
                SyntaxAnnotation nameMarker = new SyntaxAnnotation("name", name);
                SyntaxAnnotation constantMarker = new SyntaxAnnotation("type", "constant");
                SyntaxAnnotation codeMarker = new SyntaxAnnotation("code", "undefined");
                SyntaxAnnotation uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

                constant = new VirtualData();
                constant.Index = index;
                constant.Name = name;
                var typeInfo = _virtualizationContext.semanticModel.GetTypeInfo(node);
                var info = typeInfo.Type.ToString();
                constant.Type = info;
                constant.Node = node;
                constant.DefaultValue = node;
                constant.Annotations.Add(indexMarker);
                constant.Annotations.Add(nameMarker);
                constant.Annotations.Add(constantMarker);
                constant.Annotations.Add(codeMarker);
                constant.Annotations.Add(uniqueMarker);
                _virtualizationContext.data.Add(constant);
            }

            //            constants.Add(node);

            

            ExpressionSyntax newNode = SyntaxFactoryExtensions.DataCodeVirtualAccess();
            newNode = newNode.WithAdditionalAnnotations(constant.Annotations);
            ExpressionSyntax newExpression;
            if (CastEnabled)
            {
                newExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName
                    (
                        @"" + constant.Type
                    ),
                    newNode
                    );
            }
            else
            {
                newExpression = newNode;
            }

            //TODO: add annotations + comments
            newExpression = newExpression.WithLeadingTrivia(node.GetLeadingTrivia())
                .WithTrailingTrivia(node.GetTrailingTrivia())
                ;

            return newExpression;
        }
        
        public override SyntaxNode VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            var kind = node.Kind();
            if ( (kind != SyntaxKind.NumericLiteralExpression) &&
                 (kind != SyntaxKind.StringLiteralExpression) &&
                 (kind != SyntaxKind.FalseLiteralExpression) &&
                 (kind != SyntaxKind.TrueLiteralExpression) &&
                 (kind != SyntaxKind.CharacterLiteralExpression)
               )
                return node;

            CheckCastContex(node);

            string value = node.ToString();
            bool found = false;
            VirtualData constant = null ;
            string requiredType = GetRequiredType(node); //in the case of return statements
            if (requiredType.Equals("void"))
                requiredType = ""; // return statement was added as a refactoring "hack"

            var typeInfo = _virtualizationContext.semanticModel.GetTypeInfo(node);
            var declaredType = typeInfo.Type.ToString();

            foreach (var data in _virtualizationContext.data)
            {
                if (value.Equals(data.Name)) 
                {
                    if (requiredType.Equals("") && declaredType.Equals(data.Type))
                    {
                        found = true;
                        constant = data;
                        requiredType = declaredType;
                        break;
                    }
                    if (requiredType.Equals(data.Type))
                    {
                        found = true;
                        constant = data;
                        break;
                    }
                }                 
            }
            if (!found)
            {
                if(requiredType.Equals(""))
                    requiredType = declaredType;

                int index = _virtualizationContext.DataIndex;
                string name = value;
                SyntaxAnnotation dataIndexMarker = new SyntaxAnnotation("index", index + "");
                SyntaxAnnotation nameMarker = new SyntaxAnnotation("name", name);
                SyntaxAnnotation constantMarker = new SyntaxAnnotation("type", "constant");
                SyntaxAnnotation codeIndexMarker = new SyntaxAnnotation("code", "undefined");
                SyntaxAnnotation uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

                constant = new VirtualData();
                constant.Index = index;
                constant.Name = name;
                var info = requiredType;
                
                constant.Type = info;
                constant.Node = node;
                constant.DefaultValue = node;
                constant.Annotations.Add(dataIndexMarker);
                constant.Annotations.Add(nameMarker);
                constant.Annotations.Add(constantMarker);
                constant.Annotations.Add(codeIndexMarker);
                constant.Annotations.Add(uniqueMarker);
                _virtualizationContext.data.Add(constant);
            }

          
            
            ExpressionSyntax newNode = SyntaxFactoryExtensions.DataCodeVirtualAccess();
            newNode = newNode.WithAdditionalAnnotations(constant.Annotations);
            ExpressionSyntax newExpression;
            if (CastEnabled)
            {
                newExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName
                    (
                        @"" + constant.Type
                    ),
                    newNode
                    );
            }
            else
            {
                newExpression = newNode;
            }

            //TODO: add annotations + comments
            newExpression = newExpression.WithLeadingTrivia(node.GetLeadingTrivia())
                .WithTrailingTrivia(node.GetTrailingTrivia())
                ;

            return newExpression;
        }

        private bool IsUniqueInstructionIndex(string index, IEnumerable<SyntaxNode> nodes)
        {
            var newIndex = index;
            foreach (var annodatedNode in nodes)
            {
                var nameAnnotation = annodatedNode.GetAnnotations("code").FirstOrDefault();
                var usedIndex = nameAnnotation?.Data;
                if (newIndex.Equals(usedIndex))
                    return false;
            }

            return true ;
        }

        public bool CastEnabled { get; set; } = true;

        private void CheckCastContex(LiteralExpressionSyntax node)
        {
            var parent = node.Parent;
            if (parent is EqualsValueClauseSyntax)
                CastEnabled = false;
            else if (parent is AssignmentExpressionSyntax)
                CastEnabled = false;
            else
                CastEnabled = true;
        }

        private void CheckCastContex(PrefixUnaryExpressionSyntax node)
        {
            var parent = node.Parent;
            if (parent is EqualsValueClauseSyntax)
                CastEnabled = false;
            else if (parent is AssignmentExpressionSyntax)
                CastEnabled = false;
            else
                CastEnabled = true;
        }

        /// <summary>
        /// If the constant is the return argument of a method, extract the method return type
        /// to force casting from object.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string GetRequiredType(SyntaxNode node)
        {
            if (node == null)
                return "";

            string requiredType = "";
            if (node.Parent != null)
            {                            
                if ((node.Parent.Kind() == SyntaxKind.ReturnStatement))
                {
                    var method = GetParentMethod(node.Parent) as MethodDeclarationSyntax;
                    if (method != null)
                    {
                        requiredType = method.ReturnType.ToString();
                    }
                }               
            }
            return requiredType;
        }

        public SyntaxNode GetParentExpression(SyntaxNode node)
        {
            if (node == null)
                return node;
            if ((node.Kind() == SyntaxKind.ExpressionStatement) || (node.Kind() == SyntaxKind.LocalDeclarationStatement)
                || (node.Kind() == SyntaxKind.ReturnStatement)
                )
                if (node.Parent != null)
                    if (node.Parent.Kind() == SyntaxKind.Block)
                        return node;

            return GetParentExpression(node.Parent);
        }

        public SyntaxNode GetParentMethod(SyntaxNode node)
        {
            if (node == null)
                return node;
            if ((node.Kind() == SyntaxKind.MethodDeclaration))
                return node;

            return GetParentMethod(node.Parent);
        }
    }
}
