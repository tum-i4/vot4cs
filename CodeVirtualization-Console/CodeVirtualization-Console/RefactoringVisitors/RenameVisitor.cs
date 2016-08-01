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
    class RenameVisitor : CSharpSyntaxRewriter
    {
        private string oldName;
        private string newName;

        public RenameVisitor(string oldName, string newName)
        {
            this.oldName = oldName;
            this.newName = newName;
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            string name = node.Identifier.ValueText;
            if (!name.Equals(oldName))
                return node;

            var newIdentifier = SyntaxFactory.IdentifierName(newName).WithTriviaFrom(node);
            return newIdentifier;
        }

        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            if(token.Kind() != SyntaxKind.IdentifierToken)
                return token;
            string name = token.ValueText;
            if (!name.Equals(oldName))
                return token;

            var newToken = SyntaxFactory.Identifier(newName);
            return newToken;
        }

    }
}
