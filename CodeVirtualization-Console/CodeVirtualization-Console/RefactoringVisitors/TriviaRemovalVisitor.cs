using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace CodeVirtualization_Console.Visitors
{
    class TriviaRemovalVisitor : CSharpSyntaxRewriter
    {

        public static readonly TriviaRemovalVisitor Instance = new TriviaRemovalVisitor();

        public override SyntaxNode Visit(SyntaxNode node)
        {
            node = base.Visit(node);
            if (node == null)
                return node;
            node = node.WithoutTrivia();
            
            return node;
        }

        
    }
}
