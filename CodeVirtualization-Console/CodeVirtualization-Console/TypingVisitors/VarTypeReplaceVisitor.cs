using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.TypingVisitors
{
    class VarTypeReplaceVisitor : CSharpSyntaxRewriter
    {
        private VirtualizationContext _virtualizationContext;

        private readonly List<SyntaxNode> markedNodes =
           new List<SyntaxNode>();

        private readonly List<Tuple<ExpressionStatementSyntax, SyntaxNode, List<ExpressionStatementSyntax>>> replacementNodes =
            new List<Tuple<ExpressionStatementSyntax, SyntaxNode, List<ExpressionStatementSyntax>>>();

        public VarTypeReplaceVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            node = (LocalDeclarationStatementSyntax)base.VisitLocalDeclarationStatement(node);

            if (node.Declaration.Variables.Count != 1)
                return node;
            if (!node.Declaration.Type.ToString().Equals("var"))
                return node;

            var identifier = node.Declaration.Variables.First().Identifier.ValueText;
            var initializerValue = node.Declaration.Variables.First().Initializer.Value;
            var typeInfo = _virtualizationContext.semanticModel.GetTypeInfo(initializerValue).Type;
            string type = typeInfo.ToString();
            
            markedNodes.Add(node);
            var newVar = SyntaxFactoryExtensions.LocalVariableDeclaration(identifier, initializerValue, type);
            
            return newVar;
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            node = (IdentifierNameSyntax) base.VisitIdentifierName(node);

            var parentExpression = GetParentExpression(node);
            var type = _virtualizationContext.semanticModel.GetTypeInfo(node);

            markedNodes.Add(node);
            return node;
        }


        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            //TODO: replace with auxiliary variable
            //TODO: insert auxiliary variables before
            //TODO: keep in mind the order 

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
            replacementNodes.Clear();
            markedNodes.Clear();

            var visited = this.Visit(oldBody);
            oldBody = (BlockSyntax)visited;
            //            oldBody = this.ReplaceNodes(oldBody);

            return oldBody;
        }

        public SyntaxNode GetParentExpression(SyntaxNode node)
        {
            if (node == null)
                return node;
            if (node.Kind() == SyntaxKind.ExpressionStatement)
                return node;
            if (node.Kind() == SyntaxKind.LocalDeclarationStatement)
                return node;
            if (node.Kind() == SyntaxKind.ForEachStatement)
                return node;

            return GetParentExpression(node.Parent);
        }

    }
}
