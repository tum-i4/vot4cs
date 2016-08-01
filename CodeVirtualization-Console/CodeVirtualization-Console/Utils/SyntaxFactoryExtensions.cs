using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.Context;
using CodeVirtualization_Console.Utils;
using CodeVirtualization_Console.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console
{
    class SyntaxFactoryExtensions
    {
        /* virtualization obfuscation variables identifiers */
        public static string DATA_IDENTIFIER = VirtualizationContext.DATA_IDENTIFIER;
        public static string CODE_IDENTIFIER = VirtualizationContext.CODE_IDENTIFIER;
        public static string VPC_IDENTIFIER = VirtualizationContext.VPC_IDENTIFIER;

        private static Random RandomGenerator = new Random();
        /// <summary>
        /// type identifier = initializer
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static StatementSyntax LocalVariableDeclaration(string identifier, ExpressionSyntax initializer, SyntaxKind type)
        {
            var statement = SyntaxFactory.LocalDeclarationStatement
                (
                    SyntaxFactory.VariableDeclaration
                        (
                            SyntaxFactory.PredefinedType
                                (
                                    SyntaxFactory.Token
                                        (
                                            type
                                        )
                                )
                        )
                        .WithVariables
                        (
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>
                                (
                                    SyntaxFactory.VariableDeclarator
                                        (
                                            SyntaxFactory.Identifier
                                                (
                                                    @"" + identifier
                                                )
                                        )
                                        .WithInitializer
                                        (
                                            SyntaxFactory.EqualsValueClause
                                                (
                                                    initializer
                                                )
                                                .WithEqualsToken
                                                (
                                                    SyntaxFactory.Token
                                                        (
                                                            SyntaxKind.EqualsToken
                                                        )
                                                )
                                        )
                                )
                        )
                ).NormalizeWhitespace()
                .WithSemicolonToken
                (
                    SyntaxFactory.Token
                        (
                            SyntaxKind.SemicolonToken
                        )
                );

            return statement;
        }

        /// <summary>
        /// var identifier = initializer
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static StatementSyntax LocalVariableDeclaration(string identifier, ExpressionSyntax initializer)
        {
            var statement = SyntaxFactory.LocalDeclarationStatement
                (
                    SyntaxFactory.VariableDeclaration
                        (
                           SyntaxFactory.IdentifierName
                                        (
                                            @"var"
                                        )
                        )
                        .WithVariables
                        (
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>
                                (
                                    SyntaxFactory.VariableDeclarator
                                        (
                                            SyntaxFactory.Identifier
                                                (
                                                    @"" + identifier
                                                )
                                        )
                                        .WithInitializer
                                        (
                                            SyntaxFactory.EqualsValueClause
                                                (
                                                    initializer
                                                )
                                                .WithEqualsToken
                                                (
                                                    SyntaxFactory.Token
                                                        (
                                                            SyntaxKind.EqualsToken
                                                        )
                                                )
                                        )
                                )
                        )
                ).NormalizeWhitespace()
                .WithSemicolonToken
                (
                    SyntaxFactory.Token
                        (
                            SyntaxKind.SemicolonToken
                        )
                );

            return statement;
        }

        /// <summary>
        /// type identifier = initializer
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static StatementSyntax LocalVariableDeclaration(string identifier, ExpressionSyntax initializer, string type)
        {
            var statement = SyntaxFactory.LocalDeclarationStatement
                (
                    SyntaxFactory.VariableDeclaration
                        (
                           SyntaxFactory.IdentifierName
                                        (
                                            @"" + type
                                        )
                        )
                        .WithVariables
                        (
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>
                                (
                                    SyntaxFactory.VariableDeclarator
                                        (
                                            SyntaxFactory.Identifier
                                                (
                                                    @"" + identifier
                                                )
                                        )
                                        .WithInitializer
                                        (
                                            SyntaxFactory.EqualsValueClause
                                                (
                                                    initializer
                                                )
                                                .WithEqualsToken
                                                (
                                                    SyntaxFactory.Token
                                                        (
                                                            SyntaxKind.EqualsToken
                                                        )
                                                )
                                        )
                                )
                        )
                ).NormalizeWhitespace()
                .WithSemicolonToken
                (
                    SyntaxFactory.Token
                        (
                            SyntaxKind.SemicolonToken
                        )
                );

            return statement;
        }

        /// <summary>
        /// type identifier = value
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static StatementSyntax LocalVariableDeclaration(string identifier, int value, SyntaxKind type)
        {
            var statement = SyntaxFactory.LocalDeclarationStatement
                (
                    SyntaxFactory.VariableDeclaration
                        (
                            SyntaxFactory.PredefinedType
                                (
                                    SyntaxFactory.Token
                                        (
                                            type
                                        )
                                )
                        )
                        .WithVariables
                        (
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>
                                (
                                    SyntaxFactory.VariableDeclarator
                                        (
                                            SyntaxFactory.Identifier
                                                (
                                                    @"" + identifier
                                                )
                                        )
                                        .WithInitializer
                                        (
                                            SyntaxFactory.EqualsValueClause
                                                (
                                                    SyntaxFactory.LiteralExpression
                                                        (
                                                            SyntaxKind.NumericLiteralExpression,
                                                            SyntaxFactory.Literal
                                                                (
                                                                    SyntaxFactory.TriviaList(),
                                                                    @"" + value,
                                                                    value,
                                                                    SyntaxFactory.TriviaList()
                                                                )
                                                        )
                                                )
                                                .WithEqualsToken
                                                (
                                                    SyntaxFactory.Token
                                                        (
                                                            SyntaxKind.EqualsToken
                                                        )
                                                )
                                        )
                                )
                        )
                ).NormalizeWhitespace()
                .WithSemicolonToken
                (
                    SyntaxFactory.Token
                        (
                            SyntaxKind.SemicolonToken
                        )
                );

            return statement;
        }

        public static StatementSyntax GenerateArrayDeclaration(string identifier, int size, SyntaxKind kind)
        {

            var arrayDeclaration = SyntaxFactory.VariableDeclaration(
                SyntaxFactory.ArrayType(
                    SyntaxFactory.PredefinedType(
                        SyntaxFactory.Token(
                            kind)))
                    .WithRankSpecifiers(
                        SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(
                            SyntaxFactory.ArrayRankSpecifier(
                                SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                    SyntaxFactory.OmittedArraySizeExpression()
                                        .WithOmittedArraySizeExpressionToken(
                                            SyntaxFactory.Token(
                                                SyntaxKind.OmittedArraySizeExpressionToken))))
                                .WithOpenBracketToken(
                                    SyntaxFactory.Token(
                                        SyntaxKind.OpenBracketToken))
                                .WithCloseBracketToken(
                                    SyntaxFactory.Token(
                                        SyntaxKind.CloseBracketToken)))))
                .WithVariables(
                    SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier(
                                @"" + identifier))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.ArrayCreationExpression(
                                        SyntaxFactory.ArrayType(
                                            SyntaxFactory.PredefinedType(
                                                SyntaxFactory.Token(
                                                    kind)))
                                            .WithRankSpecifiers(
                                                SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(
                                                    SyntaxFactory.ArrayRankSpecifier(
                                                        SyntaxFactory
                                                            .SingletonSeparatedList<ExpressionSyntax>(
                                                                SyntaxFactory.LiteralExpression(
                                                                    SyntaxKind.NumericLiteralExpression,
                                                                    SyntaxFactory.Literal(
                                                                        SyntaxFactory.TriviaList(),
                                                                        @"" + size,
                                                                        size,
                                                                        SyntaxFactory.TriviaList()))))
                                                        .WithOpenBracketToken(
                                                            SyntaxFactory.Token(
                                                                SyntaxKind.OpenBracketToken))
                                                        .WithCloseBracketToken(
                                                            SyntaxFactory.Token(
                                                                SyntaxKind.CloseBracketToken)))))
                                        .WithNewKeyword(
                                            SyntaxFactory.Token(
                                                SyntaxKind.NewKeyword)))
                                    .WithEqualsToken(
                                        SyntaxFactory.Token(
                                            SyntaxKind.EqualsToken)))))

                .NormalizeWhitespace();
            ;

            LocalDeclarationStatementSyntax arrayNode = SyntaxFactory.LocalDeclarationStatement(arrayDeclaration).WithSemicolonToken
                (
                    SyntaxFactory.Token
                        (
                            SyntaxKind.SemicolonToken
                        )
                );
            return arrayNode;
        }

        public static StatementSyntax GetVirtualCodeAssignment(int index, int value)
        {
            return GetVirtualCodeAssignment(index, ""+value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns>code[index] = value</returns>
        public static StatementSyntax GetVirtualCodeAssignment(int index, string value)
        {
            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.LiteralExpression
                                                        (
                                                            SyntaxKind.NumericLiteralExpression,
                                                            SyntaxFactory.Literal
                                                            (
                                                                SyntaxFactory.TriviaList(),
                                                                @"" + index,
                                                                index,
                                                                SyntaxFactory.TriviaList()
                                                            )
                                                        )
                                            ))));
            
            var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal
                (
                    SyntaxFactory.TriviaList(),
                    @"" + value,
                    value,
                    SyntaxFactory.TriviaList()
                ));

            var assignementStatement = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    codeAccess,
                    literalExpression));

            return assignementStatement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>code[vpc++]</returns>
        public static ExpressionSyntax GetVirtualCodeAccessIncremented()
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @""  + VPC_IDENTIFIER
                );

            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.PostfixUnaryExpression
                                            (SyntaxKind.PostIncrementExpression, vpcAccess)
                                            ))));

            return codeAccess;
        }

        /// <summary>
        /// code[vpc+index]
        /// </summary>
        /// <returns>code[vpc+index]</returns>
        public static ExpressionSyntax GetVirtualCodeAccessIndex(int index)
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @"" + VPC_IDENTIFIER
                );

            var indexIdentifier = SyntaxFactory.IdentifierName
                (
                    @"" + index
                );

            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, vpcAccess, indexIdentifier)
                                            )
                                )));

            return codeAccess;
        }

        /// <summary>
        /// code[vpc]
        /// </summary>
        /// <returns>code[vpc]</returns>
        public static ExpressionSyntax GetVirtualCodeAccess()
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @"" + VPC_IDENTIFIER
                );


            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(vpcAccess)
                                )));

            return codeAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="index"></param>
        /// <param name="rightValue"></param>
        /// <returns></returns>
        public static StatementSyntax ArrayElementInit(string identifier, int index, ExpressionSyntax rightValue)
        {
            var arrayAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + identifier))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.LiteralExpression
                                    (
                                        SyntaxKind.NumericLiteralExpression,
                                        SyntaxFactory.Literal
                                        (
                                            SyntaxFactory.TriviaList(),
                                            @"" + index,
                                            index,
                                            SyntaxFactory.TriviaList()
                                        )
                                    )
                                ))));

            var assignementStatement = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    arrayAccess,
                    rightValue));

            return assignementStatement;
        }
        /// <summary>
        /// data[code[vpc++]] = righValue
        /// </summary>
        /// <param name="rightValue"></param>
        /// <param name="annotations"></param>
        /// <returns></returns>
        public static ExpressionStatementSyntax DataVirtualAssignment(SyntaxNode rightValue, params SyntaxAnnotation[] annotations)
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @"" + VPC_IDENTIFIER
                );

            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.PostfixUnaryExpression
                                            (SyntaxKind.PostIncrementExpression, vpcAccess)
                                            ))));

            var dataAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + DATA_IDENTIFIER ))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                codeAccess))))
                .WithAdditionalAnnotations(annotations);

            var assignementStatement = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    dataAccess,
                    (ExpressionSyntax)rightValue));
            
            return assignementStatement;
        }


        /// <summary>
        /// data[code[vpc++]] = (type) (righValue)
        /// </summary>
        /// <param name="rightValue"></param>
        /// <param name="annotations"></param>
        /// <returns></returns>
        public static ExpressionStatementSyntax DataVirtualAssignment(String type, SyntaxNode rightValue, params SyntaxAnnotation[] annotations)
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @""  + VPC_IDENTIFIER
                );

            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.PostfixUnaryExpression
                                            (SyntaxKind.PostIncrementExpression, vpcAccess)
                                            ))));

            var dataAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + DATA_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                codeAccess))))
                .WithAdditionalAnnotations(annotations);

            rightValue = SyntaxFactory.ParenthesizedExpression((ExpressionSyntax)rightValue);

            var newExpression = SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName
                                                       (
                                                           @"" + type
                                                       ),
                                                          (ExpressionSyntax)rightValue
                                                      );

            var assignementStatement = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    dataAccess,
                    newExpression));

            return assignementStatement;
        }


        /// <summary>
        /// data[code[vpc++]]
        /// </summary>
        /// <returns></returns>
        public static ExpressionSyntax DataCodeVirtualAccess()
        {
            var vpcAccess = SyntaxFactory.IdentifierName
                (
                    @""  + VPC_IDENTIFIER
                );

            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.PostfixUnaryExpression
                                            (SyntaxKind.PostIncrementExpression, vpcAccess)
                                            ))));

            var dataAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @""  + DATA_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                codeAccess))));

            return dataAccess;
        }

        /// <summary>
        /// data[code[vpc+(indexSkip)]]
        /// </summary>
        /// <returns></returns>
        public static ExpressionSyntax DataCodeVirtualAccess(string indexSkip)
        {
            var codeAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + CODE_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.BinaryExpression(
                                        SyntaxKind.AddExpression,
                                        SyntaxFactory.IdentifierName
                                        (
                                            @"" + VPC_IDENTIFIER
                                        ),
                                        SyntaxFactory.ParenthesizedExpression(
                                            SyntaxFactory.LiteralExpression
                                            (
                                                SyntaxKind.NumericLiteralExpression,
                                                SyntaxFactory.Literal
                                                (
                                                    SyntaxFactory.TriviaList(),
                                                    @"" + indexSkip,
                                                    indexSkip,
                                                    SyntaxFactory.TriviaList()
                                                )
                                            )
                                        )
                                    )
                                    ))));

            var dataAccess = SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(
                    @"" + DATA_IDENTIFIER))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                codeAccess))));

            return dataAccess;
        }


        public static ExpressionSyntax NumericLiteralExpression(int value)
        {
            var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal
                    (
                        SyntaxFactory.TriviaList(),
                        @"" + value,
                        value,
                        SyntaxFactory.TriviaList()
                    ));
            return literalExpression;
        }

        public static ExpressionSyntax NumericLiteralExpression(long value)
        {
            var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal
                    (
                        SyntaxFactory.TriviaList(),
                        @"" + value + "L",
                        value,
                        SyntaxFactory.TriviaList()
                    ));
            return literalExpression;
        }

        public static ExpressionSyntax NumericLiteralExpression(double value)
        {
            int pointIndex = ("" + value).IndexOf(".");
            string integerValue = "" + value;
            string decimalValue = "0";
            if (pointIndex > 0)
            {
                integerValue = ("" + value).Substring(0, pointIndex);
                decimalValue = ("" + value).Substring(pointIndex + 1);
            }
            
           var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal
                    (
                        SyntaxFactory.TriviaList(),
                        @"" + integerValue + "." +decimalValue,
                        value,
                        SyntaxFactory.TriviaList()
                    ));
            return literalExpression;
        }

        public static ExpressionSyntax NumericLiteralExpression(float value)
        {
            var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal
                    (
                        SyntaxFactory.TriviaList(),
                        @"" + value + "F",
                        value,
                        SyntaxFactory.TriviaList()
                    ));
            return literalExpression;
        }

        public static ExpressionSyntax StringLiteralExpression(string value)
        {
            var literalExpression = SyntaxFactory.LiteralExpression(
                SyntaxKind.StringLiteralExpression,
                SyntaxFactory.Literal
                    (
                        SyntaxFactory.TriviaList(),
                        @"" + value,
                        value,
                        SyntaxFactory.TriviaList()
                    ));
            return literalExpression;
        }

        public static ExpressionSyntax NullLiteralExpression()
        {
            var nullExpression = SyntaxFactory.LiteralExpression
                                   (
                                       SyntaxKind.NullLiteralExpression
                                   )
                                   .WithToken
                                   (
                                       SyntaxFactory.Token
                                       (
                                           SyntaxKind.NullKeyword
                                       )
                                   )
                                   .WithLeadingTrivia(SyntaxFactory.Space);
            return nullExpression;
        }
        

        public static ExpressionSyntax BooleanLiteralExpression(bool value)
        {
            ExpressionSyntax returnExpression;
            if(value)
                returnExpression = SyntaxFactory.LiteralExpression
                                    (
                                        SyntaxKind.TrueLiteralExpression
                                    )
                                    .WithToken
                                    (
                                        SyntaxFactory.Token
                                        (
                                            SyntaxKind.TrueKeyword
                                        )
                                    );
            else
                returnExpression = SyntaxFactory.LiteralExpression
                                    (
                                        SyntaxKind.FalseLiteralExpression
                                    )
                                    .WithToken
                                    (
                                        SyntaxFactory.Token
                                        (
                                            SyntaxKind.FalseKeyword
                                        )
                                    );
            return returnExpression;
        }

        public static StatementSyntax ReturnNullStatement()
        {
            var returnStatement = SyntaxFactory.ReturnStatement
                               (
                                   SyntaxFactory.LiteralExpression
                                   (
                                       SyntaxKind.NullLiteralExpression
                                   )
                                   .WithToken
                                   (
                                       SyntaxFactory.Token
                                       (
                                           SyntaxKind.NullKeyword
                                       )
                                   )
                                   .WithLeadingTrivia(SyntaxFactory.Space)
                               )
                               .WithReturnKeyword
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.ReturnKeyword
                                   )
                               )
                               .WithSemicolonToken
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.SemicolonToken
                                   )
                               );
            return returnStatement;
        }

        public static StatementSyntax ReturnZeroStatement()
        {
            var returnStatement = SyntaxFactory.ReturnStatement
                               (
                                   SyntaxFactory.LiteralExpression
                                        (
                                            SyntaxKind.NumericLiteralExpression,
                                            SyntaxFactory.Literal
                                            (
                                                SyntaxFactory.TriviaList(),
                                                @"0",
                                                0,
                                                SyntaxFactory.TriviaList()
                                            )
                                        ).WithLeadingTrivia(SyntaxFactory.Space)
                               )
                               .WithReturnKeyword
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.ReturnKeyword
                                   )
                               )
                               .WithSemicolonToken
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.SemicolonToken
                                   )
                               );
            return returnStatement;
        }

        public static StatementSyntax ReturnFalseStatement()
        {
            var returnStatement = SyntaxFactory.ReturnStatement
                               (
                                   SyntaxFactory.LiteralExpression
                                    (
                                        SyntaxKind.FalseLiteralExpression
                                    )
                                    .WithToken
                                    (
                                        SyntaxFactory.Token
                                        (
                                            SyntaxKind.FalseKeyword
                                        )
                                    ).WithLeadingTrivia(SyntaxFactory.Space)
                               )
                               .WithReturnKeyword
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.ReturnKeyword
                                   )
                               )
                               .WithSemicolonToken
                               (
                                   SyntaxFactory.Token
                                   (
                                       SyntaxKind.SemicolonToken
                                   )
                               );
            return returnStatement;
        }

        public static StatementSyntax ReturnStatement(string type)
        {
            //TODO: treat char
            switch (type)
            {
                case "void":
                    return SyntaxFactory.ReturnStatement();
                case "bool":
                    return ReturnFalseStatement();
                case "byte":
                case "short":
                case "int":                                        
                case "double":
                case "float":
                case "long":
                    return ReturnZeroStatement();

                case "string":
                default:
                    return ReturnNullStatement();
            }

        }
        /// <summary>
        /// true: bool, byte, short, int, double, float, long, string
        /// false: otherwise
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsBasicType(string type)
        {
            //TODO: treat char
            switch (type)
            {
                case "bool":
                case "byte":
                case "enum":     
                case "UInt16":
                case "ushort":
                case "short":
                case "int":
                case "double":
                case "float":
                case "long":
                case "string":
                    return true;
                default:
                    return false;
            }

        }

        public static ExpressionSyntax DefaultValue(string type)
        {
            //TODO: treat char
            switch (type)
            {
                case "bool":
                    return BooleanLiteralExpression(false);
                case "byte":
                case "short":
                case "ushort":
                case "UInt16":
                case "int":
                    return NumericLiteralExpression(0);
                case "long":
                    return NumericLiteralExpression(0L);
                case "float":
                    return NumericLiteralExpression(0.0F);
                case "double":
                    return NumericLiteralExpression(0.0);
                case "string":
                    return StringLiteralExpression("");
                case "void":
                default:
                    return NullLiteralExpression();
            }
        }

        public static ExpressionSyntax DefaultRandomValue(string type)
        {
            //TODO: treat char
            switch (type)
            {
                case "bool":
                    return BooleanLiteralExpression(false);
                case "byte":
                    return NumericLiteralExpression((long)RandomGenerator.Next(0, 8));
                case "ushort":
                case "UInt16":
                    return NumericLiteralExpression((short)RandomGenerator.Next(0, 200));
                case "short":
                    return NumericLiteralExpression((short)RandomGenerator.Next(-100, 100));
                case "enum":
                case "int":
                    return NumericLiteralExpression(RandomGenerator.Next(-1000, 1000));
                case "long":
                    return NumericLiteralExpression((long) RandomGenerator.Next(-1000, 1000));
                case "float":
                    return NumericLiteralExpression((float) RandomGenerator.NextDouble());
                case "double":
                    return NumericLiteralExpression(RandomGenerator.NextDouble());
                case "string":
                    return StringLiteralExpression(RandomGenerator.Next() + "");
                case "void":                
                default:
                    return NullLiteralExpression();
            }
        }

        public static SwitchSectionSyntax SwitchKeySection(int key, VirtualOperation operation, SyntaxTrivia leadingTrivia, VirtualizationContext context = null, bool continueStatement = false)
        {
            var switchSection1 = SyntaxFactory.SwitchSection();
            SyntaxTrivia[] sectionTrivia = new[] { leadingTrivia, SyntaxFactory.Tab };
            SyntaxTrivia[] statementTrivia = new[] { leadingTrivia, SyntaxFactory.Tab, SyntaxFactory.Tab };
            var literalExpression = NumericLiteralExpression(key).WithLeadingTrivia(SyntaxFactory.Space);
            List<StatementSyntax> statements = new List<StatementSyntax>();
            bool isReturn = false;
            foreach (var statement in operation.Statetements)
            {
                var statementClean = statement.WithoutLeadingTrivia().WithoutTrailingTrivia();
                statementClean = statementClean.WithLeadingTrivia(statementTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));
                statements.Add(statementClean);
                if (statement.Kind() == SyntaxKind.ReturnStatement)
                {
                    isReturn = true;
                }
            }
            
            StatementSyntax finalStatement;
            if(!continueStatement)
                finalStatement = SyntaxFactory.BreakStatement().WithLeadingTrivia(statementTrivia);
            else
                finalStatement = SyntaxFactory.ContinueStatement().WithLeadingTrivia(statementTrivia);

            SyntaxTrivia[] trailingTrivia = new[] { SyntaxFactory.EndOfLine(Environment.NewLine) };
            if (context.ReadableOn)
            {
                trailingTrivia = new[] { SyntaxFactory.Comment(" //frequency"  + " " + operation.Frequency + " " + operation.Name), SyntaxFactory.EndOfLine(Environment.NewLine) };
            }

            SwitchLabelSyntax label1 = SyntaxFactory.CaseSwitchLabel(literalExpression)
                .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                .WithLeadingTrivia(SyntaxFactory.Space)
                .WithTrailingTrivia(trailingTrivia);
            SwitchLabelSyntax[] labels1 = new SwitchLabelSyntax[] { label1 };
            
            if (!isReturn)
            {
                statements.Add(finalStatement);
            }
            StatementSyntax[] statements1 = statements.ToArray();

            switchSection1 = switchSection1.AddLabels(labels1);
            switchSection1 = switchSection1.AddStatements(statements1);
            switchSection1 = switchSection1.WithLeadingTrivia(sectionTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));

            return switchSection1;
        }

        public static SwitchSectionSyntax SwitchDefaultSection(VirtualOperation operation, SyntaxTrivia leadingTrivia, VirtualizationContext context = null, bool continueStatement = false, int defaultOperationFrequence = -1)
        {
            var switchSection1 = SyntaxFactory.SwitchSection();
            SyntaxTrivia[] sectionTrivia = new[] { leadingTrivia, SyntaxFactory.Tab };
            SyntaxTrivia[] statementTrivia = new[] { leadingTrivia, SyntaxFactory.Tab, SyntaxFactory.Tab };

            List<StatementSyntax> statements = new List<StatementSyntax>();
            bool isReturn = false;
            foreach (var statement in operation.Statetements)
            {
                var statementClean = statement.WithoutLeadingTrivia().WithoutTrailingTrivia();
                statementClean = statementClean.WithLeadingTrivia(statementTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));
                statements.Add(statementClean);
                if (statement.Kind() == SyntaxKind.ReturnStatement)
                {
                    isReturn = true;
                }
            }

            StatementSyntax finalStatement;
            if (!continueStatement)
                finalStatement = SyntaxFactory.BreakStatement().WithLeadingTrivia(statementTrivia);
            else
                finalStatement = SyntaxFactory.ContinueStatement().WithLeadingTrivia(statementTrivia);

            SyntaxTrivia[] trailingTrivia = new[] { SyntaxFactory.EndOfLine(Environment.NewLine) };
            if (context.ReadableOn)
            {
                trailingTrivia = new[] { SyntaxFactory.Comment(" //frequency" + " " + defaultOperationFrequence + " "+ operation.Name), SyntaxFactory.EndOfLine(Environment.NewLine) };
            }

            if (!isReturn)
            {
                statements.Add(finalStatement);
            }
            StatementSyntax[] statements1 = statements.ToArray();

            SwitchLabelSyntax label1 = SyntaxFactory.DefaultSwitchLabel()
                .WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                .WithLeadingTrivia(SyntaxFactory.Space)
                .WithTrailingTrivia(trailingTrivia);
            SwitchLabelSyntax[] labels1 = new SwitchLabelSyntax[] { label1 };
           
            switchSection1 = switchSection1.AddLabels(labels1);
            switchSection1 = switchSection1.AddStatements(statements1);
            switchSection1 = switchSection1.WithLeadingTrivia(sectionTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine));

            return switchSection1;
        }


        public static StatementSyntax WhileTrue(SyntaxTrivia leadingTrivia, StatementSyntax[] statements)
        {
            BlockSyntax block = SyntaxFactory.Block(statements);
            block = block.WithOpenBraceToken(
                SyntaxFactory.Token(SyntaxKind.OpenBraceToken)
                    .WithLeadingTrivia(leadingTrivia)
//                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))
                    );
            block = block.WithCloseBraceToken(SyntaxFactory.Token(SyntaxKind.CloseBraceToken).WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)));
            block = (BlockSyntax) block.Accept(FormatInsertTabRightVisitor.Instance);

            var whileStatement = SyntaxFactory.WhileStatement(
                SyntaxFactory.Token(SyntaxKind.WhileKeyword),
                SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactoryExtensions.BooleanLiteralExpression(true),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken)
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)),
                
                block
                
            ).WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), leadingTrivia);
                
            return whileStatement;
        }

        public static StatementSyntax SwitchBlockStatement(SyntaxTrivia leadingTrivia, VirtualizationContext context)
        {
            List<VirtualOperation> operations = context.Operations;
            VirtualOperation defaultOperation = new VirtualOperation();
            int defaultFrequency = 0;
            
            if (VirtualizationContext.DEFAULT_MOST_FREQUENT_OPERATION)
            {
                //get most frequent operation
                int mostFrequentKey = VirtualOperation.MaxFrequencyKey;
                var operation = operations.FirstOrDefault(_ => _.Key == mostFrequentKey);
                int defaultKey = -1;
                if (operation != null)
                {
                    defaultOperation = operation;
                    defaultFrequency = operation.Frequency;
                    defaultKey = operation.Key;
                }

//                var oldDefaultExpression = defaultOperation.Syntax;
//                var updatedDefaultExpression = RandomizeInstruction(oldDefaultExpression);
//                defaultOperation.Syntax = updatedDefaultExpression;
//                defaultOperation.ReplaceStatement(oldDefaultExpression, updatedDefaultExpression);

                List<VirtualOperation> operationsUpdated = new List<VirtualOperation>();
                foreach (var op in operations)
                {
                    if (op.Key == defaultKey)
                    {
                        //change the key for the most frequent while it is als referenced in code[]
                        op.Key = context.SWITCH_KEY;
//                        var newExpression = defaultOperation.Syntax;
//                        var baseExpression = op.Syntax;
//                        newExpression = UpdateAnnotationsInstruction(baseExpression, newExpression);
//                        op.ReplaceStatement(op.Syntax, newExpression);
//                        op.Syntax = defaultOperation.Syntax;
                    }
                    else
                    {
                        operationsUpdated.Add(op);
                    }
                }
                operations = operationsUpdated;
            }
            
            var codeAccess = GetVirtualCodeAccess();

            SyntaxList<SwitchSectionSyntax> sectionList = new SyntaxList<SwitchSectionSyntax>();
            int key = 0;

            Dictionary<int, VirtualOperation> uniqueOperations = new Dictionary<int, VirtualOperation>();            
            foreach (var statement in operations)
            {
                key = statement.Key;
                if (uniqueOperations.Keys.Contains(key))
                {
//                    var baseExpression = statement.Syntax;
//                    var newExpression = uniqueOperations[key].Syntax;
//                    newExpression = UpdateAnnotationsInstruction(statement.Syntax, newExpression);
//                    statement.Syntax = newExpression;
//                    statement.Size = uniqueOperations[key].Size;
//                    statement.ReplaceStatement(baseExpression, newExpression);
                    continue;
                }
                                                    
//                var oldExpression = statement.Syntax;
////                var updatedExpression = RandomizeInstruction(oldExpression);
//                var updatedExpression = RandomizeInstruction(oldExpression);
//                statement.Syntax = updatedExpression;
//                statement.ReplaceStatement(oldExpression, updatedExpression);
                uniqueOperations.Add(key,statement);
                var switchSection = SwitchKeySection(key, statement, leadingTrivia, context);
                sectionList = sectionList.Add(switchSection);
            }
            
            var defaultSection = SwitchDefaultSection(defaultOperation, leadingTrivia, context, false, defaultFrequency);
            sectionList = sectionList.Add(defaultSection);

            var shuffledList = sectionList.ToList();
            shuffledList.Shuffle();
            sectionList = new SyntaxList<SwitchSectionSyntax>();
            sectionList = sectionList.AddRange(shuffledList);

            var switchStatement = SyntaxFactory.SwitchStatement(
                SyntaxFactory.Token(SyntaxKind.SwitchKeyword),
                SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                codeAccess,
                SyntaxFactory.Token(SyntaxKind.CloseParenToken).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)),
                SyntaxFactory.Token(SyntaxKind.OpenBraceToken).WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine)),
                sectionList,
                SyntaxFactory.Token(SyntaxKind.CloseBraceToken).WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine))).WithLeadingTrivia(SyntaxFactory.EndOfLine(Environment.NewLine), leadingTrivia);

            return switchStatement;
        }

        public static StatementSyntax RandomizeInstruction(StatementSyntax statement)
        {
            List<SyntaxNode> replacementNodes = new List<SyntaxNode>();
            //get all annotated nodes of kind code
            var annotadedNodes = statement.GetAnnotatedNodes("unique");            
//            statement = statement.TrackNodes(annotadedNodes);

            List<int> positions = new List<int>();
            positions.Add(0); // it is always the code of the next instruction

            Func<SyntaxNode, SyntaxNode, SyntaxNode> computeReplacementNode = new Func<SyntaxNode, SyntaxNode, SyntaxNode>( (old, updated) =>
            {
                List<SyntaxAnnotation> annotations = new List<SyntaxAnnotation>();
                var indexAnnotations = old.GetAnnotations("index");
                var nameAnnotations = old.GetAnnotations("name");
                var typeAnnotations = old.GetAnnotations("type");
                var uniqueAnnotations = old.GetAnnotations("unique");
                var codeAnnotations = old.GetAnnotations("code").ToList();
                if (codeAnnotations.Count() > 0)
                {   
                    var marker = codeAnnotations[0];
                    if(!marker.Data.Equals("undefined"))
                        return old;
                }

                annotations.AddRange(indexAnnotations);
                annotations.AddRange(nameAnnotations);
                annotations.AddRange(typeAnnotations);
                annotations.AddRange(uniqueAnnotations);
                int codeAnnotationIndex = -1;
                var paramIndex = VirtualizationContext.RandomInstructionPosition();
                while (positions.Contains(paramIndex))
                {
                    paramIndex = VirtualizationContext.RandomInstructionPosition();
                }
                positions.Add(paramIndex);
                SyntaxAnnotation codeIndexMarker = new SyntaxAnnotation("code", paramIndex + "");

                annotations.Add(codeIndexMarker);
                var dataCodeAccess = DataCodeVirtualAccess(paramIndex + "").WithAdditionalAnnotations(annotations);

                return dataCodeAccess;
            });
            var updatedStatement = statement.ReplaceNodes(annotadedNodes, computeReplacementNode);

            return updatedStatement;
        }

        public static StatementSyntax UpdateAnnotationsInstruction(StatementSyntax fromStatement, StatementSyntax toStatement, params string[] kinds)
        {
            //get all annotated nodes of kind code
            var fromAnnotadedNodes = fromStatement.GetAnnotatedNodes("unique").ToList();
            var toAnnotatedNodes = toStatement.GetAnnotatedNodes("unique").ToList();
            int index = 0;

            Func<SyntaxNode, SyntaxNode, SyntaxNode> computeReplacementNode = new Func<SyntaxNode, SyntaxNode, SyntaxNode>((old, updated) =>
            {
                List<SyntaxAnnotation> annotations = new List<SyntaxAnnotation>();
                foreach(string kind in kinds)
                {
                    var oldAnnotations = old.GetAnnotations(kind);
                    annotations.AddRange(oldAnnotations);
                }

//                var oldIndexAnnotations = old.GetAnnotations("index");
//                var oldNameAnnotations = old.GetAnnotations("name");
//                var oldTypeAnnotations = old.GetAnnotations("type");
//                var oldUniqueAnnotation = old.GetAnnotations("unique").FirstOrDefault();
                
//                annotations.AddRange(oldIndexAnnotations);
//                annotations.AddRange(oldNameAnnotations);
//                annotations.AddRange(oldTypeAnnotations);
//                annotations.Add(oldUniqueAnnotation);

                var newNode = toAnnotatedNodes[index++];
//                var oldCodeAnnotations = newNode.GetAnnotations("code");
//                annotations.AddRange(oldCodeAnnotations);

                var updatedNode = ClearAnnotations(newNode, kinds);
                updatedNode = updatedNode.WithAdditionalAnnotations(annotations);

                var oldIndexAnnotations1 = updatedNode.GetAnnotations("index");
                var oldNameAnnotations1 = updatedNode.GetAnnotations("name");
                var oldTypeAnnotations1 = updatedNode.GetAnnotations("type");
                var oldUniqueAnnotation1 = updatedNode.GetAnnotations("unique").FirstOrDefault();

                return updatedNode;
            });
            var updatedStatement = fromStatement.ReplaceNodes(fromAnnotadedNodes, computeReplacementNode);

            return updatedStatement;
        }


        private static SyntaxNode ClearAnnotations(SyntaxNode node, params string[] annotations)
        {
            var updatedNode = node;
            foreach (string annotation in annotations)
            {
                updatedNode = updatedNode.WithoutAnnotations(annotation);
            }
            return updatedNode;
        }

        /// <summary>
        /// identifier(vpc, data, code);
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static ExpressionStatementSyntax InvocationDeclarationSyntax(string identifier)
        {
            var invocationExpressionStatement = SyntaxFactory.ExpressionStatement
                (
                    SyntaxFactory.InvocationExpression
                        (
                            SyntaxFactory.IdentifierName
                                (
                                    @"" + identifier
                                )
                        )
                        .WithArgumentList
                        (
                            SyntaxFactory.ArgumentList
                                (
                                    SyntaxFactory.SeparatedList<ArgumentSyntax>
                                        (
                                            new SyntaxNodeOrToken[]
                                            {
                                                SyntaxFactory.Argument
                                                    (
                                                        SyntaxFactory.IdentifierName
                                                            (
                                                                @"" + VirtualizationContext.VPC_IDENTIFIER
                                                            )
                                                    ),
                                                SyntaxFactory.Token
                                                    (
                                                        SyntaxKind.CommaToken
                                                    ),
                                                SyntaxFactory.Argument
                                                    (
                                                        SyntaxFactory.IdentifierName
                                                            (
                                                                @"" + VirtualizationContext.DATA_IDENTIFIER
                                                            )
                                                    ),
                                                SyntaxFactory.Token
                                                    (
                                                        SyntaxKind.CommaToken
                                                    ),
                                                SyntaxFactory.Argument
                                                    (
                                                        SyntaxFactory.IdentifierName
                                                            (
                                                                @"" + VirtualizationContext.CODE_IDENTIFIER
                                                            )
                                                    )
                                            }
                                        )
                                )
                        )
                ).NormalizeWhitespace();
            return invocationExpressionStatement;
        }


        /// <summary>
        /// private [static] object identifer (int vpc, object[] data, int[] code)
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="body"></param>
        /// <param name="isStatic"> default false</param>
        public static MethodDeclarationSyntax MethodDeclarationSyntax(string identifier, BlockSyntax body, bool isStatic = false)
        {
            var tokenList = SyntaxFactory.TokenList
                        (
                            SyntaxFactory.Token
                                (
                                    SyntaxKind.PrivateKeyword
                                )
                        );
            if (isStatic)
                tokenList = SyntaxFactory.TokenList
                    (
                        new[]
                        {
                            SyntaxFactory.Token
                                (
                                    SyntaxKind.PrivateKeyword
                                ),
                            SyntaxFactory.Token
                                (
                                    SyntaxKind.StaticKeyword
                                )
                        }
                    );

            var methodDeclaration = SyntaxFactory.MethodDeclaration
                (
                    SyntaxFactory.PredefinedType
                        (
                            SyntaxFactory.Token
                                (
                                    SyntaxKind.ObjectKeyword
                                )
                        ),
                    SyntaxFactory.Identifier
                        (
                            @"" + identifier
                        )
                )
                .WithModifiers
                (
                    SyntaxFactory.TokenList
                        (
                            tokenList
                        )
                )
                .WithParameterList
                (
                    SyntaxFactory.ParameterList
                        (
                            SyntaxFactory.SeparatedList<ParameterSyntax>
                                (
                                    new SyntaxNodeOrToken[]
                                    {
                                        SyntaxFactory.Parameter
                                            (
                                                SyntaxFactory.Identifier
                                                    (
                                                        @"" + VirtualizationContext.VPC_IDENTIFIER
                                                    )
                                            )
                                            .WithType
                                            (
                                                SyntaxFactory.PredefinedType
                                                    (
                                                        SyntaxFactory.Token
                                                            (
                                                                SyntaxKind.IntKeyword
                                                            )
                                                    )
                                            ),
                                        SyntaxFactory.Token
                                            (
                                                SyntaxKind.CommaToken
                                            ),
                                        SyntaxFactory.Parameter
                                            (
                                                SyntaxFactory.Identifier
                                                    (
                                                        @"" + VirtualizationContext.DATA_IDENTIFIER
                                                    )
                                            )
                                            .WithType
                                            (
                                                SyntaxFactory.ArrayType
                                                    (
                                                        SyntaxFactory.PredefinedType
                                                            (
                                                                SyntaxFactory.Token
                                                                    (
                                                                        SyntaxKind.ObjectKeyword
                                                                    )
                                                            )
                                                    )
                                                    .WithRankSpecifiers
                                                    (
                                                        SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>
                                                            (
                                                                SyntaxFactory.ArrayRankSpecifier
                                                                    (
                                                                        SyntaxFactory
                                                                            .SingletonSeparatedList<ExpressionSyntax>
                                                                            (
                                                                                SyntaxFactory.OmittedArraySizeExpression
                                                                                    ()
                                                                            )
                                                                    )
                                                            )
                                                    )
                                            ),
                                        SyntaxFactory.Token
                                            (
                                                SyntaxKind.CommaToken
                                            ),
                                        SyntaxFactory.Parameter
                                            (
                                                SyntaxFactory.Identifier
                                                    (
                                                        @"" + VirtualizationContext.CODE_IDENTIFIER
                                                    )
                                            )
                                            .WithType
                                            (
                                                SyntaxFactory.ArrayType
                                                    (
                                                        SyntaxFactory.PredefinedType
                                                            (
                                                                SyntaxFactory.Token
                                                                    (
                                                                        SyntaxKind.IntKeyword
                                                                    )
                                                            )
                                                    )
                                                    .WithRankSpecifiers
                                                    (
                                                        SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>
                                                            (
                                                                SyntaxFactory.ArrayRankSpecifier
                                                                    (
                                                                        SyntaxFactory
                                                                            .SingletonSeparatedList<ExpressionSyntax>
                                                                            (
                                                                                SyntaxFactory.OmittedArraySizeExpression
                                                                                    ()
                                                                            )
                                                                    )
                                                            )
                                                    )
                                            )
                                    }
                                )
                        )
                )
                .WithBody
                (
                    body
                );
            return methodDeclaration;
        }

        
    }

    

}
