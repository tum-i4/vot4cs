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
    class MethodParamsExtractorVisitor : CSharpSyntaxRewriter
    {

        private VirtualizationContext _virtualizationContext;

        private readonly List<LocalDeclarationStatementSyntax> markedNodes =
            new List<LocalDeclarationStatementSyntax>();
        private readonly List<Tuple<LocalDeclarationStatementSyntax, List<StatementSyntax>>> replacementNodes =
            new List<Tuple<LocalDeclarationStatementSyntax, List<StatementSyntax>>>();

        public MethodParamsExtractorVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitParameter(ParameterSyntax node)
        {
            bool isRef = node.Modifiers.Count(m => m.Kind() == SyntaxKind.RefKeyword) > 0;
            if (isRef)
            {
                throw new NotImplementedException("Virtualization: No support for REF parameter");
            }
            bool isOut = node.Modifiers.Count(m => m.Kind() == SyntaxKind.OutKeyword) > 0;
            if (isOut)
                throw new NotImplementedException("Virtualization: No support for OUT parameter");

            int index = _virtualizationContext.DataIndex;
            string name = node.Identifier.ToString();
            SyntaxAnnotation indexMarker = new SyntaxAnnotation("index", index + "");
            SyntaxAnnotation nameMarker = new SyntaxAnnotation("name", name);
            SyntaxAnnotation variableMarker = new SyntaxAnnotation("type", "variable");
            SyntaxAnnotation codeIndexMarker = new SyntaxAnnotation("code", "undefined");
            SyntaxAnnotation uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

            var initializer = SyntaxFactory.IdentifierName(name);
            var virtualData = new VirtualData();
            virtualData.Type = node.Type.ToString();
            virtualData.Index = index;
            virtualData.Name = name;
            virtualData.Annotations.Add(indexMarker);
            virtualData.Annotations.Add(nameMarker);
            virtualData.Annotations.Add(variableMarker);
            virtualData.Annotations.Add(codeIndexMarker);
            virtualData.Annotations.Add(uniqueMarker);
            virtualData.DefaultValue = initializer;
            _virtualizationContext.data.Add(virtualData);

            return node;
        }


    }
}
