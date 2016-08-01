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
    /// force cast to avoid casting errors at conversion: e.g. int -> object -> double not allowed!
    /// create expression with default value for double, float, long
    internal class LocalDeclarationConstantForceType : CSharpSyntaxRewriter
    {
        private VirtualizationContext _virtualizationContext;

        private readonly List<ExpressionSyntax> markedNodes =
           new List<ExpressionSyntax>();
        private readonly List<Tuple<ExpressionSyntax, ExpressionSyntax>> replacementNodes =
            new List<Tuple<ExpressionSyntax, ExpressionSyntax>>();


        public LocalDeclarationConstantForceType(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            string declaredType = node.Declaration.Type.ToString();

            bool basicType = SyntaxFactoryExtensions.IsBasicType(declaredType);
            if (!basicType)
                return node;

            if (declaredType.Equals("int"))
                return node;
            if (declaredType.Equals("bool"))
                return node;
            if (declaredType.Equals("char"))
                return node;
            if (declaredType.Equals("string"))
                return node;

            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer == null)
                    continue;
                var oldRightValue = variable.Initializer.Value;
                markedNodes.Add(oldRightValue);

                var newRightValue = SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, oldRightValue,
                    SyntaxFactoryExtensions.DefaultValue(declaredType));
                replacementNodes.Add(new Tuple<ExpressionSyntax, ExpressionSyntax> (oldRightValue, newRightValue));
            }

            return node;
        }

        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            oldBody = oldBody.TrackNodes(this.markedNodes);
            foreach (var tuple in this.replacementNodes)
            {
                var currentA = oldBody.GetCurrentNode(tuple.Item1);
                if (currentA != null)
                {                                        
                    oldBody = oldBody.ReplaceNode(currentA, tuple.Item2);
                }
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
