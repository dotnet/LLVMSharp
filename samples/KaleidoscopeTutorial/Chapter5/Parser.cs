// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;

namespace Kaleidoscope.Chapter5;

/// <summary>
/// Chapter 5 parser delta — adds the <c>if/then/else</c> and <c>for/in</c> primary expressions. Every
/// other production is inherited from the base <see cref="Kaleidoscope.Parser"/>.
/// </summary>
public class Parser(Lexer lexer) : Kaleidoscope.Parser(lexer)
{
    protected override bool TryParseKeywordPrimary(int token, out ExprAST? result)
    {
        switch (token)
        {
            case (int)Token.If:
            {
                result = ParseIfExpr();
                return true;
            }

            case (int)Token.For:
            {
                result = ParseForExpr();
                return true;
            }

            default:
            {
                return base.TryParseKeywordPrimary(token, out result);
            }
        }
    }

    // ifexpr ::= 'if' expression 'then' expression 'else' expression
    private ExprAST? ParseIfExpr()
    {
        Lexer.GetNextToken(); // eat the if.

        ExprAST? condition = ParseExpression();
        if (condition is null)
        {
            return null;
        }

        if (Lexer.CurrentToken != (int)Token.Then)
        {
            return LogError("expected then");
        }

        Lexer.GetNextToken(); // eat the then.

        ExprAST? then = ParseExpression();
        if (then is null)
        {
            return null;
        }

        if (Lexer.CurrentToken != (int)Token.Else)
        {
            return LogError("expected else");
        }

        Lexer.GetNextToken(); // eat the else.

        ExprAST? @else = ParseExpression();
        return @else is null ? null : new IfExprAST(condition, then, @else);
    }

    // forexpr ::= 'for' identifier '=' expr ',' expr (',' expr)? 'in' expression
    private ExprAST? ParseForExpr()
    {
        Lexer.GetNextToken(); // eat the for.

        if (Lexer.CurrentToken != (int)Token.Identifier)
        {
            return LogError("expected identifier after for");
        }

        string idName = Lexer.LastIdentifier;
        Lexer.GetNextToken(); // eat the identifier.

        if (Lexer.CurrentToken != '=')
        {
            return LogError("expected '=' after for");
        }

        Lexer.GetNextToken(); // eat the '='.

        ExprAST? start = ParseExpression();
        if (start is null)
        {
            return null;
        }

        if (Lexer.CurrentToken != ',')
        {
            return LogError("expected ',' after for start value");
        }

        Lexer.GetNextToken(); // eat the ','.

        ExprAST? end = ParseExpression();
        if (end is null)
        {
            return null;
        }

        // The step is optional.
        ExprAST? step = null;
        if (Lexer.CurrentToken == ',')
        {
            Lexer.GetNextToken(); // eat the ','.

            step = ParseExpression();
            if (step is null)
            {
                return null;
            }
        }

        if (Lexer.CurrentToken != (int)Token.In)
        {
            return LogError("expected 'in' after for");
        }

        Lexer.GetNextToken(); // eat the in.

        ExprAST? body = ParseExpression();
        return body is null ? null : new ForExprAST(idName, start, end, step, body);
    }
}
