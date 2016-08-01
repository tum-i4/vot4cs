using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.RefactoringVisitors.TryCatch
{
    class TryCatchRefactoringVisitor : CSharpSyntaxRewriter
    {

        private VirtualizationContext virtualizationContext;

        public TryCatchRefactoringVisitor(VirtualizationContext virtualizationContext)
        {
            this.virtualizationContext = virtualizationContext;
        }

        public override SyntaxNode VisitTryStatement(TryStatementSyntax node)
        {
            virtualizationContext.SetClassLevelOn();
            return base.VisitTryStatement(node);
        }

//        public override SyntaxNode VisitCatchClause(CatchClauseSyntax node)
//        {
//            return base.VisitCatchClause(node);
//        }
//
//        public override SyntaxNode VisitCatchDeclaration(CatchDeclarationSyntax node)
//        {
//            return base.VisitCatchDeclaration(node);
//        }
//
//        public override SyntaxNode VisitFinallyClause(FinallyClauseSyntax node)
//        {
//            return base.VisitFinallyClause(node);
//        }
//
//        public override SyntaxNode VisitCatchFilterClause(CatchFilterClauseSyntax node)
//        {
//            return base.VisitCatchFilterClause(node);
//        }

    }
}
