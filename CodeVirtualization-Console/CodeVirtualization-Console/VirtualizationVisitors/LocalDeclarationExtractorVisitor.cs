using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console
{
    class LocalDeclarationExtractorVisitor : CSharpSyntaxRewriter
    {

        private VirtualizationContext _virtualizationContext;

        private readonly List<LocalDeclarationStatementSyntax> markedNodes =
            new List<LocalDeclarationStatementSyntax>();
        private readonly List<Tuple<LocalDeclarationStatementSyntax, List<StatementSyntax>>> replacementNodes =
            new List<Tuple<LocalDeclarationStatementSyntax, List<StatementSyntax>>>();

        public LocalDeclarationExtractorVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            var declaration = node;

            List<StatementSyntax> statements = new List<StatementSyntax>();
            markedNodes.Add(node);

            foreach (var variable in declaration.Declaration.Variables)
            {

                int index = _virtualizationContext.DataIndex;
                string name = variable.Identifier.Text;
                SyntaxAnnotation indexMarker = new SyntaxAnnotation("index", index + "");
                SyntaxAnnotation nameMarker = new SyntaxAnnotation("name", name);
                SyntaxAnnotation variableMarker = new SyntaxAnnotation("type", "variable");
                SyntaxAnnotation codeIndexMarker = new SyntaxAnnotation("code", "undefined");
                SyntaxAnnotation uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

                var virtualData = new VirtualData();
                virtualData.Type = declaration.Declaration.Type.ToString();
                virtualData.Index = index;
                virtualData.Name = name;
                virtualData.Annotations.Add(indexMarker);
                virtualData.Annotations.Add(nameMarker);
                virtualData.Annotations.Add(variableMarker);
                virtualData.Annotations.Add(codeIndexMarker);
                virtualData.Annotations.Add(uniqueMarker);
                _virtualizationContext.data.Add(virtualData);

                //TODO: split for multiple variables in the same declaration
                var initializer = variable.Initializer;
                if (initializer == null)
                {
                    continue;
                }

                SyntaxNode rightValue;
               
                rightValue = initializer.DescendantNodes().First();
                ExpressionStatementSyntax newNode;
                if (SyntaxFactoryExtensions.IsBasicType(virtualData.Type))
                {                    
                        newNode = SyntaxFactoryExtensions.DataVirtualAssignment(rightValue, virtualData.Annotations.ToArray())
                        .WithLeadingTrivia(declaration.GetLeadingTrivia())
                        .WithTrailingTrivia(declaration.GetTrailingTrivia())
                    ;
                }
                else
                {
                    newNode = SyntaxFactoryExtensions.DataVirtualAssignment(virtualData.Type, rightValue, virtualData.Annotations.ToArray())
                        .WithLeadingTrivia(declaration.GetLeadingTrivia())
                        .WithTrailingTrivia(declaration.GetTrailingTrivia())
                    ;
                }

                virtualData.Node = newNode;
                virtualData.Statement = newNode;
                statements.Add(newNode);
            }

            replacementNodes.Add(new Tuple<LocalDeclarationStatementSyntax, List<StatementSyntax>>(node, statements));

            return node;
        }

        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            oldBody = oldBody.TrackNodes(this.markedNodes);
            foreach (var tuple in this.replacementNodes)
            {
                var currentA = oldBody.GetCurrentNode(tuple.Item1);

                var replacedExpr = oldBody.ReplaceNode(currentA, tuple.Item2);
                oldBody = replacedExpr;
            }
            return oldBody;
        }


        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            markedNodes.Clear();
            replacementNodes.Clear();
            oldBody = (BlockSyntax)this.Visit(oldBody);
            oldBody = this.ReplaceNodes(oldBody);

            return oldBody;
        }

    }
}
