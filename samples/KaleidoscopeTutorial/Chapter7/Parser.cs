// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;

namespace Kaleidoscope.Chapter7;

/// <summary>
/// Chapter 7 parser delta — adds the <c>var/in</c> primary for introducing mutable local variables.
/// Assignment (<c>=</c>) needs no new grammar: it is registered as a low-precedence binary operator in
/// the precedence table, so the inherited binary-operator parsing handles it.
/// </summary>
public class Parser(Lexer lexer, IDictionary<char, int> binaryOpPrecedence)
    : Chapter6.Parser(lexer, binaryOpPrecedence)
{
    protected override bool TryParseKeywordPrimary(int token, out ExprAST? result)
    {
        if (token == (int)Token.Var)
        {
            result = ParseVarExpr();
            return true;
        }

        return base.TryParseKeywordPrimary(token, out result);
    }

    // varexpr ::= 'var' identifier ('=' expression)? (',' identifier ('=' expression)?)* 'in' expression
    private ExprAST? ParseVarExpr()
    {
        Lexer.GetNextToken(); // eat the var.

        var varNames = new List<(string Name, ExprAST? Init)>();

        if (Lexer.CurrentToken != (int)Token.Identifier)
        {
            return LogError("expected identifier after var");
        }

        while (true)
        {
            string name = Lexer.LastIdentifier;
            Lexer.GetNextToken(); // eat the identifier.

            // Read the optional initializer.
            ExprAST? init = null;
            if (Lexer.CurrentToken == '=')
            {
                Lexer.GetNextToken(); // eat the '='.

                init = ParseExpression();
                if (init is null)
                {
                    return null;
                }
            }

            varNames.Add((name, init));

            if (Lexer.CurrentToken != ',')
            {
                break; // end of the var list.
            }

            Lexer.GetNextToken(); // eat the ','.

            if (Lexer.CurrentToken != (int)Token.Identifier)
            {
                return LogError("expected identifier list after var");
            }
        }

        if (Lexer.CurrentToken != (int)Token.In)
        {
            return LogError("expected 'in' keyword after 'var'");
        }

        Lexer.GetNextToken(); // eat the in.

        ExprAST? body = ParseExpression();
        return body is null ? null : new VarExprAST(varNames, body);
    }
}
