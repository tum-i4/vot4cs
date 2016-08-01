using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.RefactoringVisitors.LoopRefactoring
{
    /// <summary>
    /// Refactors a FOR statemetn into a WHILE.
    /// FOR refactoring visitor must be called before the WHILE refactoring visitor
    /// </summary>
    class ForEachConditionRefactoringVisitor : CSharpSyntaxRewriter
    {
        private static int INDEX_VAR_COUNTER = 0;
        private static string INDEX_VAR = "var_forEachIndex_";

        private static string ConditionIdentifier
        {
            get { return INDEX_VAR + INDEX_VAR_COUNTER++; }
        }

        private SyntaxNode currentForNode;

        private readonly List<SyntaxNode> markedNodes = new List<SyntaxNode>();

        private readonly List<Tuple< VariableDeclarationSyntax, ExpressionSyntax, ExpressionSyntax, ForStatementSyntax>> forReplacementNodes =
            new List<Tuple< VariableDeclarationSyntax, ExpressionSyntax, ExpressionSyntax, ForStatementSyntax>>();

        private readonly Dictionary<SyntaxNode, List<SyntaxNode>> continueStatements = new Dictionary<SyntaxNode, List<SyntaxNode>>();
        private readonly Dictionary<SyntaxNode, List<SyntaxNode>> breakStatements = new Dictionary<SyntaxNode, List<SyntaxNode>>();


        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            currentForNode = node;
            continueStatements.Add(currentForNode, new List<SyntaxNode>());
            breakStatements.Add(currentForNode, new List<SyntaxNode>());
            var nodeVisited = (ForEachStatementSyntax)base.VisitForEachStatement(node);

//            node.Identifier;
//            node.Statement
//            var indexer = nodeVisited.Declaration;
//            var condition = nodeVisited.Condition;
//            var incrementor = nodeVisited.Incrementors.First();

//            markedNodes.Add(node);            
//            forReplacementNodes.Add(new Tuple< VariableDeclarationSyntax, ExpressionSyntax, ExpressionSyntax, ForStatementSyntax>( indexer, condition, incrementor, node));

            return nodeVisited;
        }

        public override SyntaxNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            if (currentForNode == null)
                return node;
            continueStatements[currentForNode].Add(node);
            return node;
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            if (currentForNode == null)
                return node;
            breakStatements[currentForNode].Add(node);
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

            foreach (var tuple in this.forReplacementNodes)
            {
                var currentFor = oldBody.GetCurrentNode(tuple.Item4);
                if (currentFor != null)
                {
                    string oldName = tuple.Item1.Variables.First().Identifier.ValueText;
                    string newName = ConditionIdentifier;
                    var renameVisitor = new RenameVisitor(oldName, newName);
                    var newIndexer = (VariableDeclarationSyntax)renameVisitor.Visit(tuple.Item1);

                    oldBody = oldBody.InsertNodesBefore(currentFor, new List<SyntaxNode>() { SyntaxFactory.LocalDeclarationStatement(newIndexer) });                    
                    var newCurrentFor = oldBody.GetCurrentNode(tuple.Item4);
                    //create while
                    var whileBody = currentFor.Statement as BlockSyntax;
                    //update continue statements
                    foreach (var cont in continueStatements[tuple.Item4])
                    {
                        var currentContinue = whileBody.GetCurrentNode(cont);
                        whileBody = whileBody.ReplaceNode(currentContinue, new List<SyntaxNode>() { SyntaxFactory.ExpressionStatement(tuple.Item3), cont });
                    }
                    //update break statements
                    foreach (var brk in breakStatements[tuple.Item4])
                    {
                        var currentBreak = whileBody.GetCurrentNode(brk);
                        whileBody = whileBody.ReplaceNode(currentBreak, new List<SyntaxNode>() { SyntaxFactory.ExpressionStatement(tuple.Item3), brk });
                    }
                    var newStatements = whileBody.Statements.Add(SyntaxFactory.ExpressionStatement(tuple.Item3));
                    whileBody = whileBody.WithStatements(newStatements);
                    var whileStatement = SyntaxFactory.WhileStatement(tuple.Item2, whileBody);
                    whileStatement = (WhileStatementSyntax)renameVisitor.Visit(whileStatement);

                    //updateFor
                    oldBody = oldBody.ReplaceNode(newCurrentFor, whileStatement);                    
                }
            }
            return oldBody;
        }

        public BlockSyntax Refactor(BlockSyntax oldBody)
        {
            markedNodes.Clear();
            forReplacementNodes.Clear();
            oldBody = (BlockSyntax)this.Visit(oldBody);
            oldBody = this.ReplaceNodes(oldBody);

            return oldBody;
        }

    }
}
