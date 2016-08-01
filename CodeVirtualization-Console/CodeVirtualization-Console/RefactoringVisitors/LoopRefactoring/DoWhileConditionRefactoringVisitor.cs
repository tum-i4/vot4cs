using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.RefactoringVisitors.LoopRefactoring
{
    class DoWhileConditionRefactoringVisitor : CSharpSyntaxRewriter
    {
        private static int CONDITION_COUNTER = 0;
        private static string CONDITION_VAR = "var_doWhileCondition_";

        private static string ConditionIdentifier
        {
            get { return CONDITION_VAR + CONDITION_COUNTER++; }
        }

        private SyntaxNode currentWhileNode;

        private readonly List<SyntaxNode> markedNodes = new List<SyntaxNode>();

        private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, DoStatementSyntax>> whileReplacementNodes =
            new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, DoStatementSyntax>>();

        private readonly Dictionary<SyntaxNode, List<SyntaxNode>> continueStatements = new Dictionary<SyntaxNode, List<SyntaxNode>>();
        private readonly Dictionary<SyntaxNode, List<SyntaxNode>> breakStatements = new Dictionary<SyntaxNode, List<SyntaxNode>>();

        public override SyntaxNode VisitDoStatement(DoStatementSyntax node)
        {
            currentWhileNode = node;
            continueStatements.Add(currentWhileNode, new List<SyntaxNode>());
            breakStatements.Add(currentWhileNode, new List<SyntaxNode>());
            var nodeVisited = (DoStatementSyntax) base.VisitDoStatement(node);
            
            var condition = nodeVisited.Condition;
            if (condition.Kind() == SyntaxKind.IdentifierName)  //check if the code was formatted before to while(condition)
                return nodeVisited; //return if already refactored 
            
            string conditionVarIdentifier = ConditionIdentifier;
            var newConditionVar = SyntaxFactoryExtensions.LocalVariableDeclaration(conditionVarIdentifier,
                condition, SyntaxKind.BoolKeyword).NormalizeWhitespace().WithTriviaFrom(nodeVisited);
            var newCondition = SyntaxFactory.IdentifierName(conditionVarIdentifier).WithTriviaFrom(condition);

            markedNodes.Add(condition);
            markedNodes.Add(node);
            whileReplacementNodes.Add(new Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, DoStatementSyntax>(condition, newCondition, newConditionVar, node));

            return nodeVisited;
        }

        public override SyntaxNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            if (currentWhileNode == null)
                return node;
            continueStatements[currentWhileNode].Add(node);
            return node;
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            if (currentWhileNode == null)
                return node;
            breakStatements[currentWhileNode].Add(node);
            return node;
        }

        private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
        {
            List<SyntaxNode> nodesToTrack = this.markedNodes;
            var continueSts = continueStatements.SelectMany(x => x.Value);
            var breakSts = breakStatements.SelectMany(x => x.Value);
            nodesToTrack.AddRange(continueSts);
            nodesToTrack.AddRange(breakSts);
            oldBody = oldBody.TrackNodes(nodesToTrack);
            foreach (var tuple in this.whileReplacementNodes)
            {
                var currentA = oldBody.GetCurrentNode(tuple.Item1);
                if (currentA != null)
                {
                    //create new statement
                    var localCondition = tuple.Item3 as LocalDeclarationStatementSyntax;
                    var initializer = localCondition.Declaration.Variables.First();
                    var updateCondition = SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName(initializer.Identifier), initializer.Initializer.Value));

                    var whileStatement = currentA.Parent;                    
                    var trueCondition = SyntaxFactoryExtensions.LocalVariableDeclaration(initializer.Identifier.Text, SyntaxFactoryExtensions.BooleanLiteralExpression(true), SyntaxKind.BoolKeyword).NormalizeWhitespace().WithTriviaFrom(localCondition);
                    oldBody = oldBody.InsertNodesBefore(whileStatement, new List<SyntaxNode>() { trueCondition });
                    var currentB = oldBody.GetCurrentNode(tuple.Item1);
                    oldBody = oldBody.ReplaceNode(currentB, tuple.Item2);
                    //update continue statements
                    foreach (var cont in continueStatements[tuple.Item4])
                    {
                        var currentContinue = oldBody.GetCurrentNode(cont);
                        oldBody = oldBody.ReplaceNode(currentContinue, new List<SyntaxNode>() { updateCondition, cont });
                    }
                    //update break statements
                    foreach (var brk in breakStatements[tuple.Item4])
                    {
                        var currentBreak = oldBody.GetCurrentNode(brk);
                        var invalidateCondition = SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName(initializer.Identifier), SyntaxFactoryExtensions.BooleanLiteralExpression(false)));
                        oldBody = oldBody.ReplaceNode(currentBreak, new List<SyntaxNode>() { invalidateCondition, SyntaxFactory.ContinueStatement() });
                    }
                    var currentWhile = oldBody.GetCurrentNode(tuple.Item4);
                    //modify body
                    var whileBody = currentWhile.Statement as BlockSyntax;
                    
                    var newStatements = whileBody.Statements.Add(updateCondition);
                    whileBody = whileBody.WithStatements(newStatements);
                    //convert DoWhile into While
                    var newWhile = SyntaxFactory.WhileStatement(SyntaxFactory.IdentifierName(initializer.Identifier), whileBody);
                    oldBody = oldBody.ReplaceNode(currentWhile, newWhile);
                }
            }
            return oldBody;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            markedNodes.Clear();
            whileReplacementNodes.Clear();
            oldBody = (BlockSyntax)this.Visit(oldBody);
            oldBody = this.ReplaceNodes(oldBody);

            return oldBody;
        }

    }
}
