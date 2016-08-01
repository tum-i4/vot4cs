using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.RefactoringVisitors;
using CodeVirtualization_Console.TypingVisitors;
using CodeVirtualization_Console.VirtualizationVisitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeVirtualization_Console
{
    class VirtualizationHandler
    {
        private VirtualizationContext _virtualizationContext;

        public VirtualizationHandler(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public void VirtualizeProject()
        {
            var tree = _virtualizationContext.semanticModel.SyntaxTree;

            var classVirtualizationVisitor = new ClassVirtualizationVisitor(_virtualizationContext);

            var methodRefactoringVisitor = new MethodRefactoringVisitor(_virtualizationContext);
            var methodExplicitTypeVisitor = new MethodExplicitTypeVisitor(_virtualizationContext);

            SyntaxNode newSource = tree.GetRoot();
            _virtualizationContext.currentRoot = newSource;

            //REFACTORING
            newSource = methodRefactoringVisitor.Visit(newSource);
           _virtualizationContext.UpdateCompilation(newSource);
            
            //EXPLICIT_TYPE
            newSource = methodExplicitTypeVisitor.Visit(newSource);
            _virtualizationContext.UpdateCompilation(newSource);

            //VIRTUALIZATION
            newSource = classVirtualizationVisitor.Visit(newSource);


            if (!_virtualizationContext.currentRoot.Equals(newSource.SyntaxTree.GetRoot()))
                _virtualizationContext.currentRoot = newSource.SyntaxTree.GetRoot();

            if (!newSource.Equals(tree.GetRoot()))
            {
                Console.WriteLine(tree.FilePath);
                File.WriteAllText(tree.FilePath, newSource.ToFullString());
            }

        }





        
    }
}
