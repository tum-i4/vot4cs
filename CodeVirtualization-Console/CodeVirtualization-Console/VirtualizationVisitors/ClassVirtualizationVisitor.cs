using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.Context;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.VirtualizationVisitors
{
    class ClassVirtualizationVisitor : CSharpSyntaxRewriter
    {
        private VirtualizationContext _virtualizationContext;

        public ClassVirtualizationVisitor(VirtualizationContext _virtualizationContext)
        {
            this._virtualizationContext = _virtualizationContext;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node =  (ClassDeclarationSyntax) base.VisitClassDeclaration(node);

            var classMembers = node.Members.ToArray();

            var methodMembers = classMembers.OfType<MethodDeclarationSyntax>();
            if (methodMembers.Count() < 1)
                return node;

            List<Tuple<MethodDeclarationSyntax, List<string>, int>> staticClassLevelVirtualizedMethods = new List<Tuple< MethodDeclarationSyntax, List<string>, int>> ();
            List <Tuple< MethodDeclarationSyntax, List<string>, int>> instanceClassLevelVirtualizedMethods = new List<Tuple< MethodDeclarationSyntax, List<string>, int>> ();
            List <Tuple< MethodDeclarationSyntax, List<string>, int>> methodLevelVirtualizedMethods = new List<Tuple< MethodDeclarationSyntax, List<string>, int>> ();
            List<MethodDeclarationSyntax> methodsToRemove = new List<MethodDeclarationSyntax>();

            bool staticVirtualization = false;
//            foreach (var method in classMembers)
            for(int position =0; position < classMembers.Length; position++)
            {
                var member = classMembers[position];
                if (!(member is MethodDeclarationSyntax))
                    continue;
                var method = member as MethodDeclarationSyntax;

                staticVirtualization = false;
                var marked = MarkedForVirtualization(method);
                if (marked.Item1)
                {
                    methodsToRemove.Add(method);
                    if (marked.Item2.Contains("method"))
                    {
                        methodLevelVirtualizedMethods.Add(new Tuple<MethodDeclarationSyntax, List<string>, int>(method, marked.Item2, position));
                        continue;
                    }
                    
                    //class level virtualization    
                    foreach (var modifier in method.Modifiers)
                    {
                        if (modifier.Kind() == SyntaxKind.StaticKeyword)
                            staticVirtualization = true;
                    }

                    if (staticVirtualization)
                        staticClassLevelVirtualizedMethods.Add(new Tuple<MethodDeclarationSyntax, List<string>, int>(method, marked.Item2, position));
                    else
                        instanceClassLevelVirtualizedMethods.Add(new Tuple<MethodDeclarationSyntax, List<string>, int>(method, marked.Item2, position));
                }
            }

            if (methodsToRemove.Count == 0)
                return node;

            node = node.RemoveNodes(methodsToRemove, SyntaxRemoveOptions.KeepEndOfLine | SyntaxRemoveOptions.KeepExteriorTrivia );

            string className = node.Identifier.ValueText;
            VirtualizationContext.Class_INTERPRETER = "ClassInterpreterVirtualization_" + className + "_"+ _virtualizationContext.DataIndexFake;
            VirtualizationContext.Instance_INTERPRETER = "InstanceInterpreterVirtualization_" + className +"_" + _virtualizationContext.DataIndexFake;

            //local virtualization
            VirtualizeAtMethodLevel(methodLevelVirtualizedMethods, ref classMembers);
//            memberList = memberList.AddRange(virtualizedMethodLevel);

            //instance class virtualization
            VirtualizeAtClassInstanceLevel(instanceClassLevelVirtualizedMethods, ref classMembers);
//            memberList = memberList.AddRange(virtualizedInstanceClassLevel);

            //static class virtualization
            VirtualizeAtClassStaticLevel(staticClassLevelVirtualizedMethods, ref classMembers);
            //            memberList = memberList.AddRange(virtualizedStaticClassLevel);

            var memberList = SyntaxFactory.List<MemberDeclarationSyntax>();
            memberList = memberList.AddRange(classMembers);

            node = node.WithMembers(memberList).WithTriviaFrom(node);

            return node;
        }


        private void VirtualizeAtMethodLevel(List<Tuple<MethodDeclarationSyntax, List<string>, int>> methodLevelVirtualizedMethods, ref MemberDeclarationSyntax[] members)
        {
            if (_virtualizationContext.RefactoringOn)
                return;
            _virtualizationContext.SetMethodLevelVirtualization();
            
            List<MethodDeclarationSyntax> virtualizedMethodLevel = new List<MethodDeclarationSyntax>();
            if(methodLevelVirtualizedMethods.Count() == 0)
                return ;
            var methodVirtualiztionVisitor = new MethodVirtualizationVisitor(_virtualizationContext);
            
            foreach (var method in methodLevelVirtualizedMethods)
            {
                //call reset _virtualizationContext before each method so that the code[] and data[] do not overlap
                _virtualizationContext.Reset();
                _virtualizationContext.Options = method.Item2;                
                //VIRTUALIZATION
                var virtualizedMethod = (MethodDeclarationSyntax) methodVirtualiztionVisitor.Visit(method.Item1);
                members[method.Item3] = virtualizedMethod; //replace method
                virtualizedMethodLevel.Add(virtualizedMethod);
            }
            
        }

        private void VirtualizeAtClassStaticLevel(List<Tuple<MethodDeclarationSyntax, List<string>, int>> staticClassLevelVirtualizedMethods, ref MemberDeclarationSyntax[] members)
        {
            if (_virtualizationContext.RefactoringOn)
                return;
            //call reset _virtualizationContext before each method so that the code[] and data[] do not overlap
            _virtualizationContext.Operations.Clear();
            _virtualizationContext.SetClassLevelVirtualization();
            if (staticClassLevelVirtualizedMethods.Count() == 0)
                return ;
            var methodVirtualiztionVisitor = new MethodVirtualizationVisitor(_virtualizationContext);

            foreach (var method in staticClassLevelVirtualizedMethods)
            {
                //call reset _virtualizationContext before each method so that the code[] and data[] do not overlap
                _virtualizationContext.Reset();
                _virtualizationContext.Options = method.Item2;
                //VIRTUALIZATION
                var virtualizedMethod = (MethodDeclarationSyntax)methodVirtualiztionVisitor.Visit(method.Item1);
                members[method.Item3] = virtualizedMethod;
            }

            var membersExtended = members.ToList();
            List<StatementSyntax> statements = VirtualizationInterpreter(SyntaxFactory.Space, _virtualizationContext);
            BlockSyntax block = SyntaxFactory.Block(statements);
            var staticClassInterpeter = SyntaxFactoryExtensions.MethodDeclarationSyntax(_virtualizationContext.InterpreterIdentifier(), block, true).NormalizeWhitespace().WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));


            membersExtended.Add(staticClassInterpeter);

            members = membersExtended.ToArray();
        }

        private void VirtualizeAtClassInstanceLevel(List<Tuple<MethodDeclarationSyntax, List<string>, int>> instanceClassLevelVirtualizedMethods, ref MemberDeclarationSyntax[] members)
        {
            if (_virtualizationContext.RefactoringOn)
                return;
            //call reset _virtualizationContext before each method so that the code[] and data[] do not overlap
            _virtualizationContext.Operations.Clear();
            _virtualizationContext.SetInstanceLevelVirtualization();
            if (instanceClassLevelVirtualizedMethods.Count() == 0)
                return ;
            var methodVirtualiztionVisitor = new MethodVirtualizationVisitor(_virtualizationContext);
            foreach (var method in instanceClassLevelVirtualizedMethods)
            {
                _virtualizationContext.Reset();
                _virtualizationContext.Options = method.Item2;
                //VIRTUALIZATION
                var virtualizedMethod = (MethodDeclarationSyntax)methodVirtualiztionVisitor.Visit(method.Item1);
                members[method.Item3] = virtualizedMethod;
            }
            var membersExtended = members.ToList();
            
            List<StatementSyntax> statements = VirtualizationInterpreter(SyntaxFactory.Space, _virtualizationContext);
            BlockSyntax block = SyntaxFactory.Block(statements);
            var instanceClassInterpreter = SyntaxFactoryExtensions.MethodDeclarationSyntax(_virtualizationContext.InterpreterIdentifier(), block).NormalizeWhitespace().WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));
            membersExtended.Add(instanceClassInterpreter);

            members = membersExtended.ToArray();
        }



        private List<StatementSyntax> VirtualizationInterpreter(SyntaxTrivia leadingTrivia, VirtualizationContext context)
        {
            List<StatementSyntax> statements = new List<StatementSyntax>();
            var switchStatement =
                    SyntaxFactoryExtensions.SwitchBlockStatement(leadingTrivia, context)
                        .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)
                            );

            var whileTrueStatement = SyntaxFactoryExtensions.WhileTrue(leadingTrivia,
                new StatementSyntax[] { switchStatement })
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine),
                    SyntaxFactory.EndOfLine(Environment.NewLine));

            statements.Add(whileTrueStatement);
            
            var returnStatement = SyntaxFactoryExtensions.ReturnStatement("object")
                .WithLeadingTrivia(leadingTrivia)
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)).NormalizeWhitespace();

            statements.Add(returnStatement);
            return statements;
        }


        /// <summary>
        /// returns:
        /// Item1 (isMarkedForVirtualization), 
        /// Item2(virtualizationLevel), 
        /// Item3(isDebug)
        /// </summary>
        /// <param name="oldMethod"></param>
        /// <returns> name=Item1 (isMarkedForVirtualization), Item2(virtualizationLevel), Item3(isDebug)</returns>
        public static Tuple<bool, List<string>> MarkedForVirtualization(MethodDeclarationSyntax oldMethod)
        {
            string identifier = oldMethod.Identifier.ValueText;
            List<string> virtualizationAttributes = new List<string>();
            foreach (var attribute in oldMethod.AttributeLists)
            {
                var attributesList = attribute.Attributes;
                foreach (var attr in attributesList)
                {
                    virtualizationAttributes.Clear();
                    bool isMarked = true;
                    bool localVirtualization = false;

                    if (attr.ArgumentList == null)
                        continue;

                    foreach (var arg in attr.ArgumentList.Arguments)
                    {
                        var kindString  = arg.Kind().ToString();
                        if (arg.NameEquals == null)
                            continue;
                        string name = arg.NameEquals.Name.ToString();
                        string value = arg.Expression.ToString();
                        value = value.Substring(1, value.Length - 2);
                        if (name.Equals("Feature"))
                        {
                            String[] attributes = value.Split(';', '.', '-');
                            foreach (string va in attributes)
                            {
                                string option = va.ToLower().Trim(' ',';', '-');
                                if (option.Contains("virtualization"))
                                    localVirtualization = true;
                                virtualizationAttributes.Add(option);
                            }
                            
                        }
                        else if (name.Equals("Exclude"))
                        {
                            if (value.Contains("true"))
                            {
                                isMarked = false;
                            }
                        }
                    }

                    if (localVirtualization)
                    {
                        return new Tuple<bool, List<string>>(isMarked, virtualizationAttributes);
                    }
                }
            }

            return new Tuple<bool, List<string>>(false, virtualizationAttributes);
        }
    }
}
