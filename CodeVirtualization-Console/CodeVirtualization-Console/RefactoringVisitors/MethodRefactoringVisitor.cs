using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.RefactoringVisitors.LoopRefactoring;
using CodeVirtualization_Console.RefactoringVisitors.TryCatch;
using CodeVirtualization_Console.VirtualizationVisitors;
using CodeVirtualization_Console.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;

namespace CodeVirtualization_Console.RefactoringVisitors
{
    internal class MethodRefactoringVisitor : CSharpSyntaxRewriter
    {

        private const int METHOD_MIN_STATEMENTS = 2;
        private VirtualizationContext _virtualizationContext;

        public MethodRefactoringVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax method)
        {
            var marked = ClassVirtualizationVisitor.MarkedForVirtualization(method);
            if (!marked.Item1)
                return method;

            if (method.Body.DescendantNodes().OfType<StatementSyntax>().Count() <= METHOD_MIN_STATEMENTS)
            {
                return method;
            }

            _virtualizationContext.Options = marked.Item2;
            var oldBody = method.Body;

            Debug.WriteLine("Method to be Refactored: " + method.Identifier);

            //WARNING: Do Not Change Order!
            var localDeclarationForceType = new LocalDeclarationConstantForceType(_virtualizationContext);

            // must be before: comparison simplifier, IF refactoring
            var switchConditionRefactoringVisitor = new SwitchConditionRefactoringVisitor();
            var switchSectionRefactoringVisitor = new SwitchSectionRefactoringVisitor();
            var switchStatementRefactoringVisitor = new SwitchStatementRefactoringVisitor();

            var comparisonSignSimplifier = new ComparisonSignSimplifierVisitor();
            var conditionalExpressionVisitor = new ConditionalExpressionVisitor();
            var ifBranchRefactoringVisitor = new IfBranchesRefactoringVisitor();
            var loopBodyRefactoringVisitor = new LoopBodyRefactoringVisitor();
            var ifConditionRefactoringVisitor = new IfConditionRefactoringVisitor();
            var forConditionRefactoringVisitor = new ForConditionRefactoringVisitor();
            var whileConditionRefactoringVisitor = new WhileConditionRefactoringVisitor();
            var doWhileConditionRefactoringVisitor = new DoWhileConditionRefactoringVisitor();
            var composedAssignmentVisitor = new ComposedAssignmentVisitor();
            var prePostOperationVisitor = new PrePostOperationVisitor();

            var tryCatchVisitor = new TryCatchRefactoringVisitor(_virtualizationContext);

            var parenthesisOperationVisitor = new ParenthesisOperationSimplifierVisitor(_virtualizationContext);
            var multiplicativeOperationVisitor = new MultiplicativeOperationSimplifierVisitor(_virtualizationContext);
            var additiveOperationVisitor = new AdditiveOperationSimplifierVisitor(_virtualizationContext);
            var invocationExpressionVisitor = new InvocationExpressionSimplifier();
            var memberAccessExpresionVisitor = new MemberAccessExpressionSimplifier();
            
            oldBody = (BlockSyntax)localDeclarationForceType.Refactor(oldBody);

            oldBody = (BlockSyntax)switchConditionRefactoringVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)switchSectionRefactoringVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)switchStatementRefactoringVisitor.Refactor(oldBody);

            //IF branch before condition
            oldBody = (BlockSyntax) conditionalExpressionVisitor.Visit(oldBody);
            oldBody = (BlockSyntax) comparisonSignSimplifier.Visit(oldBody);
            oldBody = (BlockSyntax) ifBranchRefactoringVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax) ifConditionRefactoringVisitor.Refactor(oldBody);
            

            oldBody = (BlockSyntax)loopBodyRefactoringVisitor.Refactor(oldBody);
            //FOR before while!
            oldBody = (BlockSyntax) forConditionRefactoringVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax) doWhileConditionRefactoringVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax) whileConditionRefactoringVisitor.Refactor(oldBody);

            oldBody = (BlockSyntax)tryCatchVisitor.Visit(oldBody);

            oldBody = (BlockSyntax)composedAssignmentVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)parenthesisOperationVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)multiplicativeOperationVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)additiveOperationVisitor.Refactor(oldBody);


            oldBody = (BlockSyntax)prePostOperationVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)invocationExpressionVisitor.Refactor(oldBody);
            oldBody = (BlockSyntax)memberAccessExpresionVisitor.Refactor(oldBody);

            string returnType = method.ReturnType.ToString();
            if (returnType.Equals("void"))
                oldBody = AddReturnToVoidMethod(oldBody);
           

            var updatedMethod = method.ReplaceNode(method.Body, oldBody);

            //TODO: fix formatting
            //            oldBody = (BlockSyntax) Formatter.Format(oldBody, texts, VisualStudioSolutionHandler.workspace);
            updatedMethod = updatedMethod.NormalizeWhitespace().WithTriviaFrom(method);

//            Console.WriteLine("Method Refactored: " + method.Identifier);
            Debug.WriteLine("Method Refactored: " + method.Identifier);

            return updatedMethod;
        }

        /// <summary>
        /// If the method is void, in order to exit the interpreter, the body of the method must contain a return statement with random expression;
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <param name="oldBody"></param>
        /// <returns>return 1;</returns>
        private BlockSyntax AddReturnToVoidMethod(BlockSyntax oldBody)
        {
            var expression = SyntaxFactoryExtensions.NumericLiteralExpression(_virtualizationContext.DataIndexFake);
            //class level interpreter
            var returnStatement = SyntaxFactory.ReturnStatement(expression).NormalizeWhitespace();

            if (_virtualizationContext.MethodLevelOn)
            {
                returnStatement = SyntaxFactory.ReturnStatement();
            }

            var list = oldBody.Statements;
            list = list.Add(returnStatement);
            oldBody = oldBody.WithStatements(list);

            return oldBody;
        }
    }
}
