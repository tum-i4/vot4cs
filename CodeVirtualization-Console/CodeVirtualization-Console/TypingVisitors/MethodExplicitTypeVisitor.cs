using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.VirtualizationVisitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.TypingVisitors
{
    internal class MethodExplicitTypeVisitor : CSharpSyntaxRewriter
    {

        private const int METHOD_MIN_STATEMENTS = 2;
        private VirtualizationContext _virtualizationContext;

        public MethodExplicitTypeVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax method)
        {
            if (!ClassVirtualizationVisitor.MarkedForVirtualization(method).Item1)
                return method;

            if (method.Body.DescendantNodes().OfType<StatementSyntax>().Count() <= METHOD_MIN_STATEMENTS)
            {
                return method;
            }

            var oldBody = method.Body;

            var varTypeReplaceVisitor = new VarTypeReplaceVisitor(_virtualizationContext);

            oldBody = (BlockSyntax) varTypeReplaceVisitor.Refactor(oldBody);


            var updatedMethod = method.ReplaceNode(method.Body, oldBody);
            updatedMethod = updatedMethod.NormalizeWhitespace().WithTriviaFrom(method);

            return updatedMethod;
        }
    }
}
