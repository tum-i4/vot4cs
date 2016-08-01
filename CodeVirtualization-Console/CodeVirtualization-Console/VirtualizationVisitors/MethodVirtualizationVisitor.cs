using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CodeVirtualization_Console.Context;
using CodeVirtualization_Console.Utils;
using CodeVirtualization_Console.VirtualizationVisitors;
using CodeVirtualization_Console.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console
{
    internal class MethodVirtualizationVisitor : CSharpSyntaxRewriter
    {
        private const int METHOD_MIN_STATEMENTS = 2;
        private readonly VirtualizationContext _virtualizationContext;

        private static int unique_id = 0;
        private static int UNIQUE_ID => unique_id++;

        public MethodVirtualizationVisitor(VirtualizationContext _virtualizationContext) 
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

            if (_virtualizationContext.RefactoringOn)
                return method;

            var oldBody = method.Body;

            var localDeclarationExtractorVisitor = new LocalDeclarationExtractorVisitor(_virtualizationContext);
            var assignmentVisitor = new AssignmentDataVirtualizationVisitor(_virtualizationContext);
            var localVariableUsageVisitor = new LocalVariableUsageDataVirtVisitor(_virtualizationContext);
            var constantValueVisitor = new ConstantValueVisitor(_virtualizationContext);
            var statementsExtractorVisitor = new StatementsExtractorVisitor();
            var parametersExtractorVisitor = new MethodParamsExtractorVisitor(_virtualizationContext);
            method = (MethodDeclarationSyntax) parametersExtractorVisitor.Visit(method);

            

            oldBody = (BlockSyntax)constantValueVisitor.Visit(oldBody);

            oldBody = localDeclarationExtractorVisitor.Refactor(oldBody);

            oldBody = (BlockSyntax) assignmentVisitor.Visit(oldBody);
            oldBody = (BlockSyntax) localVariableUsageVisitor.Visit(oldBody);

            var statements = new List<StatementSyntax>();

            int vpcRandomOffset = VirtualizationContext.INSTRUCTION_SIZE_PREFIX +
                                  VirtualizationContext.GetRandom(0, 100);

            int maxCodeKey = VirtualizationContext.GetRandom(VirtualizationContext.MAX_CODE_KEY + 1,
                VirtualizationContext.MAX_CODE_KEY + 1000);
            StatementSyntax codeNode = SyntaxFactoryExtensions.GenerateArrayDeclaration(VirtualizationContext.CODE_IDENTIFIER, maxCodeKey,
                SyntaxKind.IntKeyword);
            int maxDataKey = VirtualizationContext.GetRandom(VirtualizationContext.MAX_DATA_KEY + 1,
                VirtualizationContext.MAX_DATA_KEY + 1000);
            StatementSyntax dataNode = SyntaxFactoryExtensions.GenerateArrayDeclaration(VirtualizationContext.DATA_IDENTIFIER, maxDataKey,
                SyntaxKind.ObjectKeyword);
            StatementSyntax vpcNode = SyntaxFactoryExtensions.LocalVariableDeclaration(VirtualizationContext.VPC_IDENTIFIER, vpcRandomOffset, SyntaxKind.IntKeyword);

            SyntaxNode firstNode;
            BlockSyntax newBlock1;

            firstNode = oldBody.DescendantNodes().First();
            var leadingTrivia = firstNode.GetLeadingTrivia().Last();

            codeNode = codeNode.WithLeadingTrivia(leadingTrivia,
                SyntaxFactory.Comment("//Virtualization variables" + Environment.NewLine), leadingTrivia);
            codeNode = codeNode.WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));

            dataNode = dataNode.WithLeadingTrivia(leadingTrivia);
            dataNode = dataNode.WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));

            vpcNode = vpcNode.WithLeadingTrivia(leadingTrivia);
            vpcNode = vpcNode.WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));

            statements.Add(codeNode);
            statements.Add(dataNode);
            statements.Add(vpcNode);


            oldBody = (BlockSyntax) statementsExtractorVisitor.Visit(oldBody);
            var expressions = statementsExtractorVisitor.Statements;
            var expressionsToRemove = statementsExtractorVisitor.StatementsToRemove;

            //generate code[] sequence
            StatementsToVirtualOperation(expressionsToRemove);

            var interpreterStatements = new List<StatementSyntax>();
            if (_virtualizationContext.IsMethodLevel)
                MethodLevelInterpreter(leadingTrivia, interpreterStatements, method);
            else if (_virtualizationContext.IsClassLevel)
                ClassStaticLevelInterpreter(leadingTrivia, interpreterStatements, method);
            else if (_virtualizationContext.IsInstanceLevel)
                ClassInstanceLevelInterpreter(leadingTrivia, interpreterStatements, method);

            #region CODE_GENERATION

            List<StatementSyntax> dataInitStatements;
            List<StatementSyntax> codeInitStatements;

            List<StatementSyntax> virtualizationCodeStatements = new List<StatementSyntax>();            

            if (_virtualizationContext.ReadableOn)
            {
                dataInitStatements = DataInitReadable(leadingTrivia);
                codeInitStatements = CodeInitReadable(leadingTrivia, vpcRandomOffset);

                virtualizationCodeStatements.AddRange(dataInitStatements);
                virtualizationCodeStatements.AddRange(codeInitStatements);
            }
            else
            {
                var randomCodeInit = CodeInitRandom(leadingTrivia, maxCodeKey);

                dataInitStatements = DataInit(leadingTrivia);
                codeInitStatements = CodeInit(leadingTrivia, vpcRandomOffset);

                dataInitStatements.AddRange(codeInitStatements);
                dataInitStatements.Shuffle();

                virtualizationCodeStatements.AddRange(randomCodeInit);
                virtualizationCodeStatements.AddRange(dataInitStatements);

            }
            statements.AddRange(virtualizationCodeStatements);
            statements.AddRange(interpreterStatements);

            #endregion

            oldBody = oldBody.RemoveNodes(expressionsToRemove, SyntaxRemoveOptions.KeepNoTrivia);
            newBlock1 = oldBody.AddStatements(statements.ToArray());


            if (_virtualizationContext.DebugOn)
            {
                statements = new List<StatementSyntax>() {statements[0], statements[1], statements[2]};//keep code[], data[], vpc variables creation
                statements.AddRange(expressions.Cast<StatementSyntax>() );
                newBlock1 = oldBody.InsertNodesBefore(firstNode, statements);
            }

            var updatedMethod = method.ReplaceNode(method.Body, newBlock1);

            Console.WriteLine("Method Virtualized: " + method.Identifier);
            Debug.WriteLine("Method Virtualized: " + method.Identifier);
            return updatedMethod;
        }



        private void ClassStaticLevelInterpreter(SyntaxTrivia leadingTrivia, List<StatementSyntax> statements, MethodDeclarationSyntax method)
        {
            //invoke the class level static interpreter
            string returnType = method.ReturnType.ToString();
            var invokeInterpreter = SyntaxFactoryExtensions.InvocationDeclarationSyntax(VirtualizationContext.Class_INTERPRETER);
            if (!returnType.Equals("void"))
            {
                var castExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + returnType), invokeInterpreter.Expression);
                var returnStatement = SyntaxFactory.ReturnStatement(castExpression).NormalizeWhitespace()
                    .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), leadingTrivia)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), SyntaxFactory.EndOfLine(Environment.NewLine));
                statements.Add(returnStatement);
            }
            else
            {
                statements.Add(invokeInterpreter.WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)));
            }
        }

        private void ClassInstanceLevelInterpreter(SyntaxTrivia leadingTrivia, List<StatementSyntax> statements, MethodDeclarationSyntax method)
        {
            //invoke the class level instance interpreter
            string returnType = method.ReturnType.ToString();
            var invokeInterpreter = SyntaxFactoryExtensions.InvocationDeclarationSyntax(VirtualizationContext.Instance_INTERPRETER);
            if (!returnType.Equals("void"))
            {
                var castExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + returnType), invokeInterpreter.Expression);
                var returnStatement = SyntaxFactory.ReturnStatement(castExpression).NormalizeWhitespace()
                    .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), leadingTrivia)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), SyntaxFactory.EndOfLine(Environment.NewLine));
                statements.Add(returnStatement);
            }
            else
            {
                statements.Add(invokeInterpreter.WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)));
            }
        }

        private void MethodLevelInterpreter(SyntaxTrivia leadingTrivia, List<StatementSyntax> statements, MethodDeclarationSyntax method)
        {
            var switchStatement =
                    SyntaxFactoryExtensions.SwitchBlockStatement(leadingTrivia, _virtualizationContext)
                        .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)
                            );

            var whileTrueStatement = SyntaxFactoryExtensions.WhileTrue(leadingTrivia,
                new StatementSyntax[] { switchStatement })
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine),
                    SyntaxFactory.EndOfLine(Environment.NewLine));

            statements.Add(whileTrueStatement);

            string returnType = method.ReturnType.ToString();
            if (!returnType.Equals("void"))
            {
                var returnStatement = SyntaxFactoryExtensions.ReturnStatement(returnType)
                .WithLeadingTrivia(leadingTrivia)
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));
                statements.Add(returnStatement);
            }            
        }

        #region DATA_INIT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <returns></returns>
        private List<StatementSyntax> DataInit(SyntaxTrivia leadingTrivia)
        {
            //TODO: refactor to data[] = { ..., ..., ... };
            List<StatementSyntax> statements = new List<StatementSyntax>();
            foreach (var data in this._virtualizationContext.data)
            {
                string type = data.Type;
                var rightValue = data.DefaultValue;
                //force cast to long/short to be recognized when stored to object
                //TODO: add other types for casting
                if (!type.Equals("int") && !type.Equals("bool") && !type.Equals("string"))
                {
                    rightValue = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + type),rightValue).NormalizeWhitespace();
                }

                var assignment = SyntaxFactoryExtensions.ArrayElementInit("data", data.Index, rightValue)
                    .WithLeadingTrivia(leadingTrivia)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                ;
                statements.Add(assignment);
            }

            if (statements.Count > 0)
            {
                var firstInit = statements[0];
                var triviaList = firstInit.GetLeadingTrivia();
                triviaList = triviaList.Insert(0, leadingTrivia);
                firstInit = firstInit.WithLeadingTrivia(triviaList);
                statements[0] = firstInit;                
            }
            
            statements.Shuffle();

            return statements;
        }

        private List<StatementSyntax> DataInitReadable(SyntaxTrivia leadingTrivia)
        {
            List<StatementSyntax> statements = new List<StatementSyntax>();
            foreach (var data in this._virtualizationContext.data)
            {
                string type = data.Type;
                var rightValue = data.DefaultValue;
                //force cast to long/short to be recognized when stored to object
                //TODO: add other types for casting
                if (!type.Equals("int") && !type.Equals("bool") && !type.Equals("string"))
                {
                    rightValue = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + type), rightValue).NormalizeWhitespace();
                }

                var assignment = SyntaxFactoryExtensions.ArrayElementInit("data", data.Index, rightValue)
                    .WithLeadingTrivia(leadingTrivia)
                    .WithTrailingTrivia(SyntaxFactory.Comment(" //" + data.Name + " " + (data.IsConstant ? "constant" : ""))
                    , SyntaxFactory.EndOfLine(Environment.NewLine)
                    );
                statements.Add(assignment);
            }

            if (statements.Count > 0)
            {
                var firstInit = statements[0];
                var triviaList = firstInit.GetLeadingTrivia();
                triviaList = triviaList.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));
                triviaList = triviaList.Insert(1, leadingTrivia);
                triviaList = triviaList.Insert(2, SyntaxFactory.Comment("//Data init" + Environment.NewLine));
                firstInit = firstInit.WithLeadingTrivia(triviaList);
                statements[0] = firstInit;
            }

            return statements;
        }
        #endregion

        #region CODE_INIT

        /// <summary>
        /// Initialize 10% of the code[] elements with random int values at random positions
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <returns></returns>
        private List<StatementSyntax> CodeInitRandom(SyntaxTrivia leadingTrivia, int maxCodeSize)
        {
            var codeInitStatements = new List<StatementSyntax>();
            int numberOfElements = (int) (0.005*maxCodeSize); //initialize 10% of the elements
            int newLineMark = 6; //number of elements per line
            for(int index = 0; index < numberOfElements; index++)
            {
                int position = VirtualizationContext.GetRandom(0, maxCodeSize-1);
                int randomValue = VirtualizationContext.GetRandom(-1000,1500);
                var codeInit =
                    SyntaxFactoryExtensions.GetVirtualCodeAssignment(position, randomValue)                        
                        ;
                if (newLineMark == 0)
                {
                    codeInit =
                    SyntaxFactoryExtensions.GetVirtualCodeAssignment(position, randomValue)
                        .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), leadingTrivia)
                        ;
                    newLineMark = 6;
                }
                codeInitStatements.Add(codeInit);
                newLineMark --;
            }

            if (codeInitStatements.Count > 0)
            {
                var firstCodeInit = codeInitStatements[0];
                var triviaList = firstCodeInit.GetLeadingTrivia();
                triviaList = triviaList.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));
                triviaList = triviaList.Insert(1, leadingTrivia);                
                firstCodeInit = firstCodeInit.WithLeadingTrivia(triviaList);
                codeInitStatements[0] = firstCodeInit;
            }

//            codeInitStatements.Shuffle();

            return codeInitStatements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <returns></returns>
        private List<StatementSyntax> CodeInitReadable(SyntaxTrivia leadingTrivia, int vpcRandomOffset)
        {
            var codeInitStatements = new List<StatementSyntax>();
            int offset = vpcRandomOffset;
            int index = 0;
            int codeIndex = offset;
            foreach (var code in _virtualizationContext.code)
            {
                
                int value = code.Key;
                var codeInit =
                    SyntaxFactoryExtensions.GetVirtualCodeAssignment(codeIndex, value)
                        .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine),leadingTrivia)
                        .WithTrailingTrivia(SyntaxFactory.Comment(" //" + code.Name +" # " + code.UniqueName), SyntaxFactory.EndOfLine(Environment.NewLine));
                codeInitStatements.Add(codeInit);

                var dataNodes = code.GetData();
                foreach (var data in dataNodes)
                {
                    var dataCodeIndex = codeIndex + Int32.Parse(data.Item3);
                    string dataIndex = data.Item2;
                    var dataInit =
                        SyntaxFactoryExtensions.GetVirtualCodeAssignment(dataCodeIndex, dataIndex)
                            .WithLeadingTrivia(leadingTrivia)
                            .WithTrailingTrivia(SyntaxFactory.Comment(" //" + data.Item1), SyntaxFactory.EndOfLine(Environment.NewLine))
                            ;
                    codeInitStatements.Add(dataInit);
                }

                //process fake data items
                var fakeDataNodes = code.GetFakeData();
                foreach (var data in fakeDataNodes)
                {
                    var dataCodeIndex = codeIndex + Int32.Parse(data.Item3);
                    string dataIndex = data.Item2;
                    var dataInit =
                        SyntaxFactoryExtensions.GetVirtualCodeAssignment(dataCodeIndex, dataIndex)
                            .WithLeadingTrivia(leadingTrivia)
                            .WithTrailingTrivia(SyntaxFactory.Comment(" //" + data.Item1), SyntaxFactory.EndOfLine(Environment.NewLine))
                            ;
                    codeInitStatements.Add(dataInit);
                }

                codeIndex += code.Size;
            }

            if (codeInitStatements.Count > 0)
            {
                var firstCodeInit = codeInitStatements[0];
                var triviaList = firstCodeInit.GetLeadingTrivia();
                triviaList = triviaList.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));
                triviaList = triviaList.Insert(1, leadingTrivia);
                triviaList = triviaList.Insert(2, SyntaxFactory.Comment("//Code init" + Environment.NewLine));
                firstCodeInit = firstCodeInit.WithLeadingTrivia(triviaList);
                codeInitStatements[0] = firstCodeInit;
            }

            return codeInitStatements;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <returns></returns>
        private List<StatementSyntax> CodeInit(SyntaxTrivia leadingTrivia, int vpcRandomOffset)
        {
            var codeInitStatements = new List<StatementSyntax>();
            int offset = vpcRandomOffset;
            int index = 0;
            int codeIndex = offset;
            foreach (var code in _virtualizationContext.code)
            {

                int value = code.Key;
                var codeInit =
                    SyntaxFactoryExtensions.GetVirtualCodeAssignment(codeIndex, value)
                        ;
                codeInitStatements.Add(codeInit);

                var dataNodes = code.GetData();
                foreach (var data in dataNodes)
                {
                    var dataCodeIndex = codeIndex + Int32.Parse(data.Item3);
                    string dataIndex = data.Item2;
                    var dataInit =
                        SyntaxFactoryExtensions.GetVirtualCodeAssignment(dataCodeIndex, dataIndex)
                            
                            ;
                    codeInitStatements.Add(dataInit);
                }

                //process fake data items
                var fakeDataNodes = code.GetFakeData();
                foreach (var data in fakeDataNodes)
                {
                    var dataCodeIndex = codeIndex + Int32.Parse(data.Item3);
                    string dataIndex = data.Item2;
                    var dataInit =
                        SyntaxFactoryExtensions.GetVirtualCodeAssignment(dataCodeIndex, dataIndex)
                           
                            ;
                    codeInitStatements.Add(dataInit);
                }

                codeIndex += code.Size;
            }

//            if (codeInitStatements.Count > 0)
//            {
//                var firstCodeInit = codeInitStatements[0];
//                var triviaList = firstCodeInit.GetLeadingTrivia();
//                triviaList = triviaList.Insert(0, SyntaxFactory.EndOfLine(Environment.NewLine));
//                triviaList = triviaList.Insert(1, leadingTrivia);                
//                firstCodeInit = firstCodeInit.WithLeadingTrivia(triviaList);
//                codeInitStatements[0] = firstCodeInit;
//            }

            codeInitStatements.Shuffle();

            return codeInitStatements;
        }


        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expressions"></param>
        public void StatementsToVirtualOperation(IEnumerable<SyntaxNode> expressions)
        {
            foreach (var expression1 in expressions)
            {
                var expressionToProcess = expression1.NormalizeWhitespace() as StatementSyntax;

                if (expressionToProcess.Kind() == SyntaxKind.IfStatement)
                {
                    var ifStatement = expressionToProcess as IfStatementSyntax;
                    StatementsToVirtualOperation(ifStatement);
                    continue;
                }
                else if (expressionToProcess.Kind() == SyntaxKind.WhileStatement)
                {
                    var whileStatement = expressionToProcess as WhileStatementSyntax;
                    StatementsToVirtualOperation(whileStatement);
                    continue;
                }
                else if (expressionToProcess.Kind() == SyntaxKind.ContinueStatement)
                {
                    var continueStatement = expressionToProcess as ContinueStatementSyntax;
                    StatementsToVirtualOperation(continueStatement);
                    continue;
                }
                else if (expressionToProcess.Kind() == SyntaxKind.TryStatement)
                {
                    var tryStatement = expressionToProcess as TryStatementSyntax;
//                    StatementsToVirtualOperation(tryStatement);
                    continue;
                }

                StatementSyntax randomizedExpression = null;

                VirtualOperation foundVirtualOperation = null;
                foundVirtualOperation = new VirtualOperation();
                foundVirtualOperation.StaticSyntax = expressionToProcess;
                foundVirtualOperation.Key = -1;                

                var uniqueOperationSize = -1;
                foreach (var c in _virtualizationContext.Operations)
                {
                    var existing = c.StaticSyntax.WithoutTrivia();
                    var cleaned = expressionToProcess.WithoutTrivia();
                    var equivalent = existing.IsEquivalentTo(cleaned);
                    if (equivalent)
                    {
                        foundVirtualOperation.Key = c.Key;
                        foundVirtualOperation.Name = c.Name;
                        foundVirtualOperation.UniqueName = expressionToProcess.Kind() + "_" + UNIQUE_ID;
                        foundVirtualOperation.OffsetKeys = c.OffsetKeys;
                        var uniqueExpression = c.Syntax;
                        randomizedExpression = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(expressionToProcess, uniqueExpression,"index", "unique", "name", "type");
                        foundVirtualOperation.Syntax = randomizedExpression;
                        uniqueOperationSize = c.Size;
                        foundVirtualOperation.InstructionSizeOffset = c.InstructionSizeOffset;
                        break;
                    }
                }

                if (foundVirtualOperation.Key == -1)
                {
                    foundVirtualOperation.Key = _virtualizationContext.SWITCH_KEY;
                    foundVirtualOperation.Name = expressionToProcess.Kind() + "_" + UNIQUE_ID;
                    foundVirtualOperation.UniqueName = foundVirtualOperation.Name;
                    foundVirtualOperation.InstructionSizeOffset = VirtualizationContext.InstructionSizeOffsetRand();
                    _virtualizationContext.Operations.Add(foundVirtualOperation);
                    randomizedExpression = SyntaxFactoryExtensions.RandomizeInstruction(expressionToProcess);
                    foundVirtualOperation.Syntax = randomizedExpression;
                }

                foundVirtualOperation.AddStatement(randomizedExpression);

                VirtualOperation.MarkAppearance(foundVirtualOperation.Key);
                var descendants = randomizedExpression.GetAnnotatedNodes("name");
                
                foreach (var use in descendants)
                {
                    var nameAnnotation = use.GetAnnotations("name").FirstOrDefault();
                    var name = nameAnnotation?.Data;
                    var indexAnnotation = use.GetAnnotations("index").FirstOrDefault();
                    var dataIndexString = indexAnnotation?.Data;
                    var codeAnnotation = use.GetAnnotations("code").FirstOrDefault();
                    var codeOffsetString = codeAnnotation?.Data;
                    foundVirtualOperation.AddData(name, dataIndexString, codeOffsetString);
                }

                AddDummyDataToOperation(foundVirtualOperation.Name, foundVirtualOperation);
                if (uniqueOperationSize == -1)
                {
                    uniqueOperationSize = foundVirtualOperation.Size;
                }
                
                int skipSize = uniqueOperationSize;
                foundVirtualOperation.Size = uniqueOperationSize;
                var vpcSkip = VpcSkip(skipSize); // 
                foundVirtualOperation.AddStatement(vpcSkip);

                _virtualizationContext.code.Add(foundVirtualOperation);
            }
        }

        ///vpc = vpc + skipSize;
        private ExpressionStatementSyntax VpcSkip(int size)
        {
            var vpcIdentifier1 = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var jmpSize1 = SyntaxFactoryExtensions.NumericLiteralExpression(size);
            var modifyVpc1 = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier1, jmpSize1);
            var cmodifyVpcSyntax1 = SyntaxFactory.ExpressionStatement(modifyVpc1);
            return cmodifyVpcSyntax1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="continueStatement"></param>
        private void StatementsToVirtualOperation(ContinueStatementSyntax continueStatement)
        {
            int maxLoopTries = VirtualizationContext.INSTRUCTION_SIZE_POSTFIX + VirtualizationContext.INSTRUCTION_SIZE_PREFIX;
            int loopsLeft = maxLoopTries;
            List<int> positions = new List<int>();
            positions.Add(0); // it is always the code of the next instruction

            //compute jump size
            int jumpSize = 0;
            var operationCodes = _virtualizationContext.code;
            //search for the last loop
            for (int index = _virtualizationContext.code.Count - 1; index >= 0; index--)
            {
                var operation = _virtualizationContext.code[index];
                var opSize = operation.Size;
                jumpSize += opSize;
                if (operation.UniqueName.Contains("WhileStatementSyntax"))
                {
                    break;
                }
            }

            //store jump
            int continueDestinationIndex = _virtualizationContext.DataIndex;
            string continueDestinationName = "continueDestinationName" + continueDestinationIndex;
            SyntaxAnnotation indexMarker = new SyntaxAnnotation("index", continueDestinationIndex + "");
            SyntaxAnnotation nameMarker = new SyntaxAnnotation("name", continueDestinationName);
            SyntaxAnnotation variableMarker = new SyntaxAnnotation("type", "constant");
            SyntaxAnnotation codeMarker = new SyntaxAnnotation("code", "undefined");
            SyntaxAnnotation uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

            var continueDestinationData = new VirtualData();
            continueDestinationData.Type = "int";
            continueDestinationData.Index = continueDestinationIndex;
            continueDestinationData.Name = continueDestinationName;
            continueDestinationData.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(0 - jumpSize); //
            continueDestinationData.Annotations.Add(indexMarker);
            continueDestinationData.Annotations.Add(nameMarker);
            continueDestinationData.Annotations.Add(variableMarker);
//            continueDestinationData.Annotations.Add(codeMarker);
            continueDestinationData.Annotations.Add(uniqueMarker);

            _virtualizationContext.data.Add(continueDestinationData);
            
            //vpc = vpc + data[code[vpc++]];
            var vpcIdentifier1 = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var jmpFalseSize1 = SyntaxFactoryExtensions.DataCodeVirtualAccess();
            jmpFalseSize1 = jmpFalseSize1.WithAdditionalAnnotations(continueDestinationData.Annotations);
            jmpFalseSize1 = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName (@"" + "int"), jmpFalseSize1);
            var modifyVpc1 = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier1, jmpFalseSize1);
            var cmodifyVpcSyntax1 = SyntaxFactory.ExpressionStatement(modifyVpc1);
            //StatementsToVirtualOperation(new List<SyntaxNode>() { cmodifyVpcSyntax1 });

            var expressionToProcess = cmodifyVpcSyntax1;
            StatementSyntax randomizedExpression = null;

            VirtualOperation foundVirtualOperation = null;
            foundVirtualOperation = new VirtualOperation();
            foundVirtualOperation.StaticSyntax = expressionToProcess;
            foundVirtualOperation.Key = -1;

            var uniqueOperationSize = -1;
            foreach (var c in _virtualizationContext.Operations)
            {
                var existing = c.StaticSyntax.WithoutTrivia();
                var cleaned = expressionToProcess.WithoutTrivia();
                var equivalent = existing.IsEquivalentTo(cleaned);
                if (equivalent)
                {
                    foundVirtualOperation.Key = c.Key;
                    foundVirtualOperation.Name = c.Name;
                    foundVirtualOperation.UniqueName = "Continue_" + expressionToProcess.Kind() + "_" + UNIQUE_ID;
                    foundVirtualOperation.OffsetKeys = c.OffsetKeys;
                    var uniqueExpression = c.Syntax;
                    randomizedExpression = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(expressionToProcess, uniqueExpression, "index", "unique", "name", "type");
                    foundVirtualOperation.Syntax = randomizedExpression;
                    uniqueOperationSize = c.Size;
                    foundVirtualOperation.InstructionSizeOffset = c.InstructionSizeOffset;
                    break;
                }
            }

            if (foundVirtualOperation.Key == -1)
            {
                foundVirtualOperation.Key = _virtualizationContext.SWITCH_KEY;
                foundVirtualOperation.Name = "Continue_"+expressionToProcess.Kind() + "_" + UNIQUE_ID;
                foundVirtualOperation.UniqueName = foundVirtualOperation.Name;
                foundVirtualOperation.InstructionSizeOffset = VirtualizationContext.InstructionSizeOffsetRand();
                _virtualizationContext.Operations.Add(foundVirtualOperation);
                randomizedExpression = SyntaxFactoryExtensions.RandomizeInstruction(expressionToProcess);
                foundVirtualOperation.Syntax = randomizedExpression;
            }

            foundVirtualOperation.AddStatement(randomizedExpression);

            VirtualOperation.MarkAppearance(foundVirtualOperation.Key);
            var descendants = randomizedExpression.GetAnnotatedNodes("name");

            foreach (var use in descendants)
            {
                var nameAnnotation = use.GetAnnotations("name").FirstOrDefault();
                var name = nameAnnotation?.Data;
                var indexAnnotation = use.GetAnnotations("index").FirstOrDefault();
                var dataIndexString = indexAnnotation?.Data;
                var codeAnnotation = use.GetAnnotations("code").FirstOrDefault();
                var codeOffsetString = codeAnnotation?.Data;
                foundVirtualOperation.AddData(name, dataIndexString, codeOffsetString);
            }

            AddDummyDataToOperation(foundVirtualOperation.Name, foundVirtualOperation);
            if (uniqueOperationSize == -1)
            {
                uniqueOperationSize = foundVirtualOperation.Size;
            }

            int skipSize = uniqueOperationSize;
            foundVirtualOperation.Size = uniqueOperationSize;
            var vpcSkip = VpcSkip(skipSize); // 
//            foundVirtualOperation.AddStatement(vpcSkip);

            _virtualizationContext.code.Add(foundVirtualOperation);


        }

        /// <summary>
        /// Convert IF statement to special jump to location statement based on condition
        /// </summary>
        /// <param name="ifStatement"></param>
        public void StatementsToVirtualOperation(IfStatementSyntax ifStatement)
        {
            SyntaxAnnotation indexMarker;
            SyntaxAnnotation nameMarker;
            SyntaxAnnotation variableMarker;
            SyntaxAnnotation codeMarker;
            SyntaxAnnotation uniqueMarker;
            int maxLoopTries = VirtualizationContext.INSTRUCTION_SIZE_POSTFIX + VirtualizationContext.INSTRUCTION_SIZE_PREFIX;
            int loopsLeft = maxLoopTries;

            var ifConditionExpression = ifStatement.Condition;

            //create new virtual operation entry
            var conditionStatement = SyntaxFactory.ExpressionStatement(ifConditionExpression);
            VirtualOperation ifVirtualOperation = null;
            ifVirtualOperation = new VirtualOperation();
            ifVirtualOperation.StaticSyntax = conditionStatement;
            ifVirtualOperation.Key = -1;


            StatementSyntax randomizedExpression = null;
            var uniqueOperationSize = -1;
            //search for other IF operations that might have already been processed 
            foreach (var c in _virtualizationContext.Operations)
            {
                var existing = c.StaticSyntax.WithoutTrivia();
                var cleaned = conditionStatement.WithoutTrivia();
                var equivalent = existing.IsEquivalentTo(cleaned);
                if (equivalent)
                {
                    ifVirtualOperation.Key = c.Key;
                    ifVirtualOperation.Name = c.Name;
                    ifVirtualOperation.UniqueName = "IfStatementSyntax" + "_" + UNIQUE_ID;
                    ifVirtualOperation.OffsetKeys = c.OffsetKeys;
                    var uniqueExpression = c.Syntax;
                    
                    randomizedExpression = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(conditionStatement, uniqueExpression, "index", "unique", "name", "type");
                    var updatedConditionStatement = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(uniqueExpression, conditionStatement, "code");
                    ifVirtualOperation.StaticSyntax = conditionStatement;
                    ifConditionExpression = ((ExpressionStatementSyntax) randomizedExpression).Expression;
                    ifVirtualOperation.Syntax = randomizedExpression;
                    uniqueOperationSize = c.Size;
                    ifVirtualOperation.InstructionSizeOffset = c.InstructionSizeOffset;
                    break;
                }
            }

            List<int> positions = new List<int>();
            positions.Add(0); // it is always the code of the next instruction

            var jumpDestinationCodeIndex = -1;
            var trueBranchDestinationCodeIndex = -1;
            var falseBranchDestinationCodeIndex = -1;
            //if not found, generate unique switch key
            if (ifVirtualOperation.Key == -1)
            {
                ifVirtualOperation.Key = _virtualizationContext.SWITCH_KEY;
                ifVirtualOperation.Name = "IfStatementSyntax" + "_" + UNIQUE_ID;
                ifVirtualOperation.UniqueName = ifVirtualOperation.Name;
                _virtualizationContext.Operations.Add(ifVirtualOperation);
                ifVirtualOperation.InstructionSizeOffset = VirtualizationContext.InstructionSizeOffsetRand();
                //convert condition to randomized instruction position
                var modifiedExpression =
                    (ExpressionStatementSyntax) SyntaxFactoryExtensions.RandomizeInstruction(conditionStatement);
                var annotatedNodes = modifiedExpression.GetAnnotatedNodes("code").ToList();
                codeMarker = annotatedNodes[0].GetAnnotations("code").ToList()[0];

                if (codeMarker != null)
                {
                    int position = Int32.Parse(codeMarker.Data);
                    positions.Add(position);
                    ifConditionExpression = ifConditionExpression.WithoutAnnotations("code");
                    ifConditionExpression = ifConditionExpression.WithAdditionalAnnotations(codeMarker);
                }

                ifVirtualOperation.Syntax = modifiedExpression;
                ifConditionExpression = modifiedExpression.Expression;
            }
            else
            {
                jumpDestinationCodeIndex = Int32.Parse(ifVirtualOperation.OffsetKeys[1]);

                trueBranchDestinationCodeIndex = Int32.Parse(ifVirtualOperation.OffsetKeys[3]);
                falseBranchDestinationCodeIndex = Int32.Parse(ifVirtualOperation.OffsetKeys[4]);
                ifVirtualOperation.OffsetKeys.Clear();
                ifVirtualOperation.OffsetKeys.Add("0"); // 0 represents the offset of the instruction code. it is always 0
            }
            
            VirtualOperation.MarkAppearance(ifVirtualOperation.Key);
            _virtualizationContext.code.Add(ifVirtualOperation);
            int indexIfStatement = _virtualizationContext.code.Count;

            //construct the special JUMP_TO based on condition
            /*
                if Instruction 
                int jmpSize = condition ? sizeTrue : sizeFalse;
                vpc = vpc + jmpSize;
                                
             step 1: determine jump destination based on condition
                [e0] = [e1] ? [e2] : [e3]
                data[code[vpc+rand0]] = data[code[vpc+rand1]] ? data[code[vpc rand2]] : data[code[vpc+rand3]];                                
             step 2: increment vpc based on destination 
                  vpc = vpc + data[code[vpc+rand0]];                  
            */

            //contruct destination offset variable: [e0]
            if (jumpDestinationCodeIndex == -1)
            {
                jumpDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(jumpDestinationCodeIndex) && loopsLeft > 0)
                {
                    jumpDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft --;
                }               
            }
            var jumpDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + jumpDestinationCodeIndex);  //[e0] variable for storing to which branch to jump
            positions.Add(jumpDestinationCodeIndex);

            //construct variable [e2] offset if branch TRUE
            if (trueBranchDestinationCodeIndex == -1)
            {
                trueBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(trueBranchDestinationCodeIndex) && loopsLeft > 0)
                {
                    trueBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft--;
                }               
            }
            var trueBranchDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + trueBranchDestinationCodeIndex);
            trueBranchDestination = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), trueBranchDestination);
            positions.Add(trueBranchDestinationCodeIndex);

            //construct variable [e3] offset if branch FALSE
            if (falseBranchDestinationCodeIndex == -1)
            {
                falseBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(falseBranchDestinationCodeIndex) && loopsLeft > 0)
                {
                    falseBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft--;
                }                
            }
            var falseBranchDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + falseBranchDestinationCodeIndex);
            falseBranchDestination = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), falseBranchDestination);
            positions.Add(falseBranchDestinationCodeIndex);

            //contruct destination VirtualData variable: [e0]
            int jumpDestinationIndex = _virtualizationContext.DataIndex;
            string jmpDestinationName = "jmpDestinationName_" + jumpDestinationIndex;
            indexMarker = new SyntaxAnnotation("index", jumpDestinationIndex + "");
            nameMarker = new SyntaxAnnotation("name", jmpDestinationName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + jumpDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

            var jumpDestinationData = new VirtualData();
            jumpDestinationData.Type = "int";
            jumpDestinationData.Index = jumpDestinationIndex;
            jumpDestinationData.Name = jmpDestinationName;
            jumpDestinationData.Annotations.Add(indexMarker);
            jumpDestinationData.Annotations.Add(nameMarker);
            jumpDestinationData.Annotations.Add(variableMarker);
            jumpDestinationData.Annotations.Add(codeMarker);
            jumpDestinationData.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(jumpDestinationData);
            jumpDestination = jumpDestination.WithAdditionalAnnotations(jumpDestinationData.Annotations);

            //contruct destination VirtualData variable: [e2] if branch TRUE
            int skipToTrueBranchIndex = _virtualizationContext.DataIndex;
            string skiptToTrueBrachName = "if_GoTo_True_" + skipToTrueBranchIndex;
            indexMarker = new SyntaxAnnotation("index", skipToTrueBranchIndex + "");
            nameMarker = new SyntaxAnnotation("name", skiptToTrueBrachName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + trueBranchDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var gotoTrueBranchData = new VirtualData();
            gotoTrueBranchData.Type = "int";
            gotoTrueBranchData.Index = skipToTrueBranchIndex;
            gotoTrueBranchData.Name = skiptToTrueBrachName;
            gotoTrueBranchData.Annotations.Add(indexMarker);
            gotoTrueBranchData.Annotations.Add(nameMarker);
            gotoTrueBranchData.Annotations.Add(variableMarker);
            gotoTrueBranchData.Annotations.Add(uniqueMarker);           
            _virtualizationContext.data.Add(gotoTrueBranchData);

            trueBranchDestination = trueBranchDestination.WithAdditionalAnnotations(gotoTrueBranchData.Annotations);

            //contruct destination VirtualData variable: [e3] if branch FALSE
            int skipToFalseBranchIndex = _virtualizationContext.DataIndex;
            string skiptToFalseBrachName = "if_GoTo_False_" + skipToFalseBranchIndex;
            indexMarker = new SyntaxAnnotation("index", skipToFalseBranchIndex + "");
            nameMarker = new SyntaxAnnotation("name", skiptToFalseBrachName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + falseBranchDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var gotoFalseBranchData = new VirtualData();
            gotoFalseBranchData.Type = "int";
            gotoFalseBranchData.Index = skipToFalseBranchIndex;
            gotoFalseBranchData.Name = skiptToFalseBrachName;
            gotoFalseBranchData.Annotations.Add(indexMarker);
            gotoFalseBranchData.Annotations.Add(nameMarker);
            gotoFalseBranchData.Annotations.Add(variableMarker);
            gotoFalseBranchData.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(gotoFalseBranchData);
            falseBranchDestination = falseBranchDestination.WithAdditionalAnnotations(gotoFalseBranchData.Annotations);

            var sizeCondition = SyntaxFactory.ConditionalExpression(ifConditionExpression, trueBranchDestination, falseBranchDestination);
            var computeSizeExpression = SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, jumpDestination, sizeCondition);
            var computedBranchDestionation = SyntaxFactory.ExpressionStatement(computeSizeExpression);
            ifVirtualOperation.AddStatement(computedBranchDestionation);
            ifVirtualOperation.AddData(jumpDestinationData.Name, jumpDestinationData.Index, jumpDestinationCodeIndex);

            AddDataToOperation(ifVirtualOperation, ifConditionExpression);           
            ifVirtualOperation.AddData(gotoTrueBranchData.Name, gotoTrueBranchData.Index, trueBranchDestinationCodeIndex); //true
            ifVirtualOperation.AddData(gotoFalseBranchData.Name, gotoFalseBranchData.Index, falseBranchDestinationCodeIndex); //false

            jumpDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + jumpDestinationCodeIndex);
            var computedJmpSize = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), jumpDestination);
            var vpcIdentifier = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var modifyVpc = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier, computedJmpSize);
            var cmodifyVpcSyntax = SyntaxFactory.ExpressionStatement(modifyVpc);
            ifVirtualOperation.AddStatement(cmodifyVpcSyntax);

            var trueBranch = ifStatement.Statement;
            var statementsExtractorVisitor = new StatementsExtractorVisitor();
            statementsExtractorVisitor.Visit(trueBranch);
            var trueBranchStatements = statementsExtractorVisitor.StatementsToRemove;

            var falseBlockSizeCodeIndex = VirtualizationContext.RandomInstructionPosition();
            loopsLeft = maxLoopTries;
            while (positions.Contains(falseBlockSizeCodeIndex) && loopsLeft > 0)
            {
                falseBlockSizeCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft --;
            }
            positions.Add(falseBlockSizeCodeIndex);

            int falseBlockSizeIndex = _virtualizationContext.DataIndex;
            string ifFalseBlockSize = "if_FalseBlockSize_Skip_" + falseBlockSizeIndex;
            indexMarker = new SyntaxAnnotation("index", falseBlockSizeIndex + "");
            nameMarker = new SyntaxAnnotation("name", ifFalseBlockSize);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + falseBlockSizeCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var falseBlockSkip = new VirtualData();
            falseBlockSkip.Type = "int";
            falseBlockSkip.Index = falseBlockSizeIndex;
            falseBlockSkip.Name = ifFalseBlockSize;
            falseBlockSkip.Annotations.Add(indexMarker);
            falseBlockSkip.Annotations.Add(nameMarker);
            falseBlockSkip.Annotations.Add(variableMarker);
            falseBlockSkip.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(falseBlockSkip);

            //vpc = vpc + data[code[vpc++]];
            var vpcIdentifier1 = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var jmpFalseSize1 = SyntaxFactoryExtensions.DataCodeVirtualAccess();
            jmpFalseSize1 = jmpFalseSize1.WithAdditionalAnnotations(falseBlockSkip.Annotations);
            jmpFalseSize1 = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"),jmpFalseSize1);
            var modifyVpc1 = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier1, jmpFalseSize1);
            var cmodifyVpcSyntax1 = SyntaxFactory.ExpressionStatement(modifyVpc1);

            trueBranchStatements.Add(cmodifyVpcSyntax1);
            StatementsToVirtualOperation(trueBranchStatements);
            int indexEndOfTrueBlock = _virtualizationContext.code.Count;

            string markerTrue = "#if_fake_true_added";
            Debug.WriteLine(markerTrue);
            AddDummyDataToOperation("fake-ifVirtualOperation", ifVirtualOperation);

            int trueBlockSize = 0;
            for (int i = indexIfStatement ; i < indexEndOfTrueBlock; i++)
            {
                var code = _virtualizationContext.code[i];
                trueBlockSize += code.Size;
            }

            //after IF header, goto False block start
            int gotoFalseOffset = ifVirtualOperation.Size + trueBlockSize ;
            gotoFalseBranchData.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(gotoFalseOffset); // 1 for vpc++ and 1 for [true size]
            Debug.WriteLine("#if_trueBlockSize " + trueBlockSize);

            var falseBranch = ifStatement.Else;
            statementsExtractorVisitor.Visit(falseBranch);
            var falseBranchStatements = statementsExtractorVisitor.StatementsToRemove;
            StatementsToVirtualOperation(falseBranchStatements);
            int falseBlockSize = 0;

            for (int i = indexEndOfTrueBlock ; i < _virtualizationContext.code.Count; i++)
            {
                var code = _virtualizationContext.code[i];
                falseBlockSize += code.Size;
            }

            //the jump sizes are available only after all the other statements have been processed

            //after the IF header, goto beginning of true block
            var gotoTrueOffset = ifVirtualOperation.Size;
            gotoTrueBranchData.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(gotoTrueOffset);

            //at the end of the true block, skip the false block
            int skipFalseBranchOffset = falseBlockSize ; // 1 for vpc++ 1 for next instruction
            falseBlockSkip.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(skipFalseBranchOffset);
            Debug.WriteLine("#falseBlockSize " + falseBlockSize);
        }

        public void StatementsToVirtualOperation(TryStatementSyntax tryStatement)
        {
            if (tryStatement == null)
                return;

            var interpreterInvocation = SyntaxFactoryExtensions.InvocationDeclarationSyntax(_virtualizationContext.InterpreterIdentifier());
            var returnStatement = SyntaxFactory.ReturnStatement(interpreterInvocation.Expression);
            List<StatementSyntax> statements = new List<StatementSyntax>();
            statements.Add(returnStatement);
            BlockSyntax virtualizedBlock = SyntaxFactory.Block(statements);


            var tryBlock = tryStatement.Block;
            var tryStatements = tryBlock.Statements;
            StatementsToVirtualOperation(tryStatements);

            var catchesList = tryStatement.Catches;
            foreach (var catchObj in catchesList)
            {
                var modifiedTry = SyntaxFactory.TryStatement();
                modifiedTry = modifiedTry.WithBlock(virtualizedBlock);
                var catchClause = SyntaxFactory.CatchClause(catchObj.Declaration, catchObj.Filter, virtualizedBlock);
                var catchList = new SyntaxList<CatchClauseSyntax>();
                catchList = catchList.Add(catchClause);
                modifiedTry = modifiedTry.WithCatches(catchList);
                VirtualOperation tryOperation = null;
                tryOperation = new VirtualOperation();
                tryOperation.Syntax = modifiedTry;
                tryOperation.Key = -1;
                tryOperation.Name = "Catch_"+catchObj.Declaration.ToString();
                tryOperation.AddStatement(modifiedTry);

                foreach (var c in _virtualizationContext.Operations)
                {
                    var existing = c.Syntax.WithoutTrivia();
                    var cleaned = modifiedTry.WithoutTrivia();
                    var equivalent = existing.IsEquivalentTo(cleaned);
                    if (equivalent)
                    {
                        tryOperation.Key = c.Key;
                        break;
                    }
                }

                if (tryOperation.Key == -1)
                {
                    tryOperation.Key = _virtualizationContext.SWITCH_KEY;
                    _virtualizationContext.Operations.Add(tryOperation);
                }
                VirtualOperation.MarkAppearance(tryOperation.Key);
                _virtualizationContext.code.Add(tryOperation);

                var catchBlock = catchObj.Block;
                var catchStatements = catchBlock.Statements;
                StatementsToVirtualOperation(catchStatements);
            }
            
        }

        public void StatementsToVirtualOperation(WhileStatementSyntax whileStatement)
        {
            SyntaxAnnotation indexMarker;
            SyntaxAnnotation nameMarker;
            SyntaxAnnotation variableMarker;
            SyntaxAnnotation codeMarker;
            SyntaxAnnotation uniqueMarker;
            int maxLoopTries = VirtualizationContext.INSTRUCTION_SIZE_POSTFIX + VirtualizationContext.INSTRUCTION_SIZE_PREFIX;
            int loopsLeft = maxLoopTries;
            
            //create new virtual operation entry
            var whileConditionExpression = whileStatement.Condition;
            var conditionStatement = SyntaxFactory.ExpressionStatement(whileConditionExpression);
            VirtualOperation whileVirtualOperation = null;
            whileVirtualOperation = new VirtualOperation
            {
                StaticSyntax = conditionStatement,
                Key = -1,
                Name = "WhileStatementSyntax" 
            };

            StatementSyntax randomizedExpression = null;
            var uniqueOperationSize = -1;
            //search for other IF operations that might have already been processed
            foreach (var c in _virtualizationContext.Operations)
            {
                var existing = c.StaticSyntax.WithoutTrivia();
                var cleaned = conditionStatement.WithoutTrivia();
                var equivalent = existing.IsEquivalentTo(cleaned);
                if (equivalent)
                {
                    whileVirtualOperation.Key = c.Key;
                    whileVirtualOperation.Name = c.Name;
                    whileVirtualOperation.UniqueName = "WhileStatementSyntax" + "_" + UNIQUE_ID;
                    whileVirtualOperation.OffsetKeys = c.OffsetKeys;
                    var uniqueExpression = c.Syntax;

                    randomizedExpression = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(conditionStatement, uniqueExpression, "index", "unique", "name", "type");
                    var updatedConditionStatement = SyntaxFactoryExtensions.UpdateAnnotationsInstruction(uniqueExpression, conditionStatement, "code");
                    whileVirtualOperation.StaticSyntax = conditionStatement;
                    whileConditionExpression = ((ExpressionStatementSyntax)randomizedExpression).Expression;
                    whileVirtualOperation.Syntax = randomizedExpression;
                    uniqueOperationSize = c.Size;
                    whileVirtualOperation.InstructionSizeOffset = c.InstructionSizeOffset;
                    break;
                }
            }

            List<int> positions = new List<int>();
            positions.Add(0); // it is always the code of the next instruction

            var jumpDestinationCodeIndex = -1;
            var trueBranchDestinationCodeIndex = -1;
            var falseBranchDestinationCodeIndex = -1;

            //if not found, generate unique switch key
            if (whileVirtualOperation.Key == -1)
            {
                whileVirtualOperation.Key = _virtualizationContext.SWITCH_KEY;
                whileVirtualOperation.Name = "WhileStatementSyntax" + "_" + UNIQUE_ID;
                whileVirtualOperation.UniqueName = whileVirtualOperation.Name;
                _virtualizationContext.Operations.Add(whileVirtualOperation);
                whileVirtualOperation.InstructionSizeOffset = VirtualizationContext.InstructionSizeOffsetRand();
                //convert condition to randomized instruction position
                var modifiedExpression =
                    (ExpressionStatementSyntax)SyntaxFactoryExtensions.RandomizeInstruction(conditionStatement);
                var annotatedNodes = modifiedExpression.GetAnnotatedNodes("code").ToList();
                codeMarker = annotatedNodes[0].GetAnnotations("code").ToList()[0];

                if (codeMarker != null)
                {
                    int position = Int32.Parse(codeMarker.Data);
                    positions.Add(position);
                    whileConditionExpression = whileConditionExpression.WithoutAnnotations("code");
                    whileConditionExpression = whileConditionExpression.WithAdditionalAnnotations(codeMarker);
                }

                whileVirtualOperation.Syntax = modifiedExpression;
                whileConditionExpression = modifiedExpression.Expression;
            }
            else
            {
                jumpDestinationCodeIndex = Int32.Parse(whileVirtualOperation.OffsetKeys[1]);

                trueBranchDestinationCodeIndex = Int32.Parse(whileVirtualOperation.OffsetKeys[3]);
                falseBranchDestinationCodeIndex = Int32.Parse(whileVirtualOperation.OffsetKeys[4]);
                whileVirtualOperation.OffsetKeys.Clear();
                whileVirtualOperation.OffsetKeys.Add("0"); // 0 represents the offset of the instruction code. it is always 0
            }

            VirtualOperation.MarkAppearance(whileVirtualOperation.Key);
            _virtualizationContext.code.Add(whileVirtualOperation);
            int indexWhileStatement = _virtualizationContext.code.Count;

            //construct the special JUMP_TO based on condition
            /*
                if Instruction 
                int jmpSize = condition ? sizeTrue : sizeFalse;
                vpc = vpc + jmpSize;
                                
             step 1: determine jump destination based on condition
                [e0] = [e1] ? [e2] : [e3]
                data[code[vpc+rand0]] = data[code[vpc+rand1]] ? data[code[vpc rand2]] : data[code[vpc+rand3]];                                
             step 2: increment vpc based on destination 
                  vpc = vpc + data[code[vpc+rand0]];                  
            */

            //contruct destination offset variable: [e0]
            if (jumpDestinationCodeIndex == -1)
            {
                jumpDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(jumpDestinationCodeIndex) && loopsLeft > 0)
                {
                    jumpDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft--;
                }
            }
            var jumpDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + jumpDestinationCodeIndex);  //[e0] variable for storing to which branch to jump
            positions.Add(jumpDestinationCodeIndex);

            //construct variable [e2] offset if branch TRUE
            if (trueBranchDestinationCodeIndex == -1)
            {
                trueBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(trueBranchDestinationCodeIndex) && loopsLeft > 0)
                {
                    trueBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft--;
                }
            }
            var trueBranchDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + trueBranchDestinationCodeIndex);
            trueBranchDestination = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), trueBranchDestination);
            positions.Add(trueBranchDestinationCodeIndex);

            //construct variable [e3] offset if branch FALSE
            if (falseBranchDestinationCodeIndex == -1)
            {
                falseBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft = maxLoopTries;
                while (positions.Contains(falseBranchDestinationCodeIndex) && loopsLeft > 0)
                {
                    falseBranchDestinationCodeIndex = VirtualizationContext.RandomInstructionPosition();
                    loopsLeft--;
                }
            }
            var falseBranchDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + falseBranchDestinationCodeIndex);
            falseBranchDestination = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), falseBranchDestination);
            positions.Add(falseBranchDestinationCodeIndex);



            //contruct destination VirtualData variable: [e0]
            int jumpDestinationIndex = _virtualizationContext.DataIndex;
            string jmpDestinationName = "jmpWhileDestinationName_" + jumpDestinationIndex;
            indexMarker = new SyntaxAnnotation("index", jumpDestinationIndex + "");
            nameMarker = new SyntaxAnnotation("name", jmpDestinationName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + jumpDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);

            var jumpDestinationData = new VirtualData();
            jumpDestinationData.Type = "int";
            jumpDestinationData.Index = jumpDestinationIndex;
            jumpDestinationData.Name = jmpDestinationName;
            jumpDestinationData.Annotations.Add(indexMarker);
            jumpDestinationData.Annotations.Add(nameMarker);
            jumpDestinationData.Annotations.Add(variableMarker);
            jumpDestinationData.Annotations.Add(codeMarker);
            jumpDestinationData.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(jumpDestinationData);
            jumpDestination = jumpDestination.WithAdditionalAnnotations(jumpDestinationData.Annotations);


            //contruct destination VirtualData variable: [e2] if branch TRUE
            int skipToTrueBranchIndex = _virtualizationContext.DataIndex;
            string skiptToTrueBrachName = "while_GoTo_True_" + skipToTrueBranchIndex;
            indexMarker = new SyntaxAnnotation("index", skipToTrueBranchIndex + "");
            nameMarker = new SyntaxAnnotation("name", skiptToTrueBrachName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + trueBranchDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var gotoTrueBranchData = new VirtualData();
            gotoTrueBranchData.Type = "int";
            gotoTrueBranchData.Index = skipToTrueBranchIndex;
            gotoTrueBranchData.Name = skiptToTrueBrachName;
            gotoTrueBranchData.Annotations.Add(indexMarker);
            gotoTrueBranchData.Annotations.Add(nameMarker);
            gotoTrueBranchData.Annotations.Add(variableMarker);
            gotoTrueBranchData.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(gotoTrueBranchData);
            trueBranchDestination = trueBranchDestination.WithAdditionalAnnotations(gotoTrueBranchData.Annotations);

            //contruct destination VirtualData variable: [e3] if branch FALSE
            int skipToFalseBranchIndex = _virtualizationContext.DataIndex;
            string skiptToFalseBrachName = "while_GoTo_False_" + skipToFalseBranchIndex;
            indexMarker = new SyntaxAnnotation("index", skipToFalseBranchIndex + "");
            nameMarker = new SyntaxAnnotation("name", skiptToFalseBrachName);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + falseBranchDestinationCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var gotoFalseBranchData = new VirtualData();
            gotoFalseBranchData.Type = "int";
            gotoFalseBranchData.Index = skipToFalseBranchIndex;
            gotoFalseBranchData.Name = skiptToFalseBrachName;
            gotoFalseBranchData.Annotations.Add(indexMarker);
            gotoFalseBranchData.Annotations.Add(nameMarker);
            gotoFalseBranchData.Annotations.Add(variableMarker);
            gotoFalseBranchData.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(gotoFalseBranchData);
            falseBranchDestination = falseBranchDestination.WithAdditionalAnnotations(gotoFalseBranchData.Annotations);
            
            var sizeCondition = SyntaxFactory.ConditionalExpression(whileConditionExpression, trueBranchDestination, falseBranchDestination);
            var computeSizeExpression = SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, jumpDestination, sizeCondition);
            var computedBranchDestionation = SyntaxFactory.ExpressionStatement(computeSizeExpression);
            whileVirtualOperation.AddStatement(computedBranchDestionation);
            whileVirtualOperation.AddData(jumpDestinationData.Name, jumpDestinationData.Index, jumpDestinationCodeIndex); 

            AddDataToOperation(whileVirtualOperation, whileConditionExpression);
            whileVirtualOperation.AddData(gotoTrueBranchData.Name, gotoTrueBranchData.Index, trueBranchDestinationCodeIndex); //true 
            whileVirtualOperation.AddData(gotoFalseBranchData.Name, gotoFalseBranchData.Index, falseBranchDestinationCodeIndex); //false 


            jumpDestination = SyntaxFactoryExtensions.DataCodeVirtualAccess("" + jumpDestinationCodeIndex);
            var computedJmpSize = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), jumpDestination);
            var vpcIdentifier = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var modifyVpc = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier, computedJmpSize);
            var cmodifyVpcSyntax = SyntaxFactory.ExpressionStatement(modifyVpc);
            whileVirtualOperation.AddStatement(cmodifyVpcSyntax);

            var trueBranch = whileStatement.Statement;
            var statementsExtractorVisitor = new StatementsExtractorVisitor();
            statementsExtractorVisitor.Visit(trueBranch);
            var trueBranchStatements = statementsExtractorVisitor.StatementsToRemove;            

            var falseBlockSizeCodeIndex = VirtualizationContext.RandomInstructionPosition();
            loopsLeft = maxLoopTries;
            while (positions.Contains(falseBlockSizeCodeIndex) && loopsLeft > 0)
            {
                falseBlockSizeCodeIndex = VirtualizationContext.RandomInstructionPosition();
                loopsLeft--;
            }
            positions.Add(falseBlockSizeCodeIndex);

            int falseBlockSizeIndex = _virtualizationContext.DataIndex;
            string ifFalseBlockSize = "while_FalseBlockSkip_" + falseBlockSizeIndex;
            indexMarker = new SyntaxAnnotation("index", falseBlockSizeIndex + "");
            nameMarker = new SyntaxAnnotation("name", ifFalseBlockSize);
            variableMarker = new SyntaxAnnotation("type", "constant");
            codeMarker = new SyntaxAnnotation("code", "" + falseBlockSizeCodeIndex);
            uniqueMarker = new SyntaxAnnotation("unique", "" + VirtualizationContext.UniqueId);
            var falseBlockSkip = new VirtualData();
            falseBlockSkip.Type = "int";
            falseBlockSkip.Index = falseBlockSizeIndex;
            falseBlockSkip.Name = ifFalseBlockSize;
            falseBlockSkip.Annotations.Add(indexMarker);
            falseBlockSkip.Annotations.Add(nameMarker);
            falseBlockSkip.Annotations.Add(variableMarker);
            falseBlockSkip.Annotations.Add(uniqueMarker);
            _virtualizationContext.data.Add(falseBlockSkip);


            //vpc = vpc + data[code[vpc++]];
            var vpcIdentifier1 = SyntaxFactory.IdentifierName(VirtualizationContext.VPC_IDENTIFIER);
            var jmpFalseSize1 = SyntaxFactoryExtensions.DataCodeVirtualAccess();
            jmpFalseSize1 = jmpFalseSize1.WithAdditionalAnnotations(falseBlockSkip.Annotations);
            jmpFalseSize1 = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(@"" + "int"), jmpFalseSize1);
            var modifyVpc1 = SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, vpcIdentifier1, jmpFalseSize1);
            var cmodifyVpcSyntax1 = SyntaxFactory.ExpressionStatement(modifyVpc1);

            trueBranchStatements.Add(cmodifyVpcSyntax1);
            StatementsToVirtualOperation(trueBranchStatements);
            int indexEndOfTrueBlock = _virtualizationContext.code.Count;

            string markerTrue = "#while_fake_true_added";
            Debug.WriteLine(markerTrue);
            AddDummyDataToOperation("fake-whileVirtualOperation", whileVirtualOperation);

            int trueBlockSize = 0;
            for (int i = indexWhileStatement; i < indexEndOfTrueBlock; i++)
            {
                var code = _virtualizationContext.code[i];
                trueBlockSize += code.Size;
            }
            
            //the jump sizes are available only after all the other statements have been processed

            //after the IF header, goto beginning of true block
            var gotoTrueOffset = whileVirtualOperation.Size;
            gotoTrueBranchData.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(gotoTrueOffset);                                                                                                        //after IF header, goto False block start

            int gotoFalseOffset = whileVirtualOperation.Size + trueBlockSize;
            gotoFalseBranchData.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(gotoFalseOffset); // 1 for vpc++ and 1 for [true size]
            Debug.WriteLine("#while_trueBlockSize " + trueBlockSize);

           
            //at the end of the true block, go back to check condition
            int skipFalseBranchOffset = 0 - trueBlockSize - whileVirtualOperation.Size; // 1 for vpc++ 1 for next instruction
            falseBlockSkip.DefaultValue = SyntaxFactoryExtensions.NumericLiteralExpression(skipFalseBranchOffset);
            Debug.WriteLine("#while_falseBlockSize " + skipFalseBranchOffset);
        }

        private int AddDummyDataToOperation(string marker, VirtualOperation operation)
        {
            var dummyDataAdded = 0;

            for (int i = 0; i < VirtualizationContext.GetRandom(1, VirtualizationContext.MAX_JUNK_CODE); i++)
            {
                //inside virtual operation
                var dummyIndex = _virtualizationContext.DataIndexFake;
                var fakeDataOffset = VirtualizationContext.RandomInstructionPosition();
                while (operation.OffsetKeyUsed("" + fakeDataOffset))
                {
                    fakeDataOffset = VirtualizationContext.RandomInstructionPosition();
                }
                string name = "fake-" + marker +"_" +dummyIndex+"_"+fakeDataOffset;
                operation.AddFakeData(name, dummyIndex, fakeDataOffset);
                Debug.WriteLine(name);
                //inside data[] array
                var fakeData = new VirtualData();
                var fakeIndex = _virtualizationContext.DataIndex;
                fakeData.Type = "int";
                fakeData.Index = fakeIndex;
                fakeData.Name = "fake-" + fakeIndex;
                _virtualizationContext.data.Add(fakeData);
                //                Debug.WriteLine("fake-data" + fakeIndex);
                dummyDataAdded++;
            }
            return dummyDataAdded;
        }

        private int AddDummyDataToOperation(string marker, int index)
        {
            //add dummy data to last operation
            var lastOperation = _virtualizationContext.code[index];
            return AddDummyDataToOperation(marker, lastOperation);
        }

        public void AddDataToOperation(VirtualOperation operation, StatementSyntax node)
        {
            var descendants = node.GetAnnotatedNodes("name");            
            foreach (var use in descendants)
            {
                var nameAnnotation = use.GetAnnotations("name").FirstOrDefault();
                var name = nameAnnotation?.Data;
                var indexAnnotation = use.GetAnnotations("index").FirstOrDefault();
                var indexString = indexAnnotation?.Data;
                var typeAnnotation = use.GetAnnotations("type").FirstOrDefault();
                var typeString = typeAnnotation?.Data;
                var codeAnnotation = use.GetAnnotations("code").FirstOrDefault();
                var codeOffsetString = codeAnnotation?.Data;
                operation.AddData(name, indexString, codeOffsetString);
            }
        }

        public void AddDataToOperation(VirtualOperation operation, ExpressionSyntax node)
        {
            var descendants = node.GetAnnotatedNodes("name");

            foreach (var use in descendants)
            {
                var nameAnnotation = use.GetAnnotations("name").FirstOrDefault();
                var name = nameAnnotation?.Data;
                var indexAnnotation = use.GetAnnotations("index").FirstOrDefault();
                var indexString = indexAnnotation?.Data;
                var typeAnnotation = use.GetAnnotations("type").FirstOrDefault();
                var typeString = typeAnnotation?.Data;
                var codeAnnotation = use.GetAnnotations("code").FirstOrDefault();
                var codeOffsetString = codeAnnotation?.Data;
                operation.AddData(name, indexString, codeOffsetString);
            }
        }

    }

}

