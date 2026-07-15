// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;

namespace Kaleidoscope;

/// <summary>
/// A recursive-descent parser producing the <see cref="AST"/> (tutorial chapter 2). It exposes a
/// handful of <c>protected virtual</c> seams — <see cref="ParsePrimary"/>,
/// <see cref="TryParseKeywordPrimary"/>, <see cref="ParseUnary"/>, and <see cref="ParsePrototype"/> —
/// so later chapters can add new grammar productions without copying the whole parser.
/// </summary>
public class Parser
{
    /// <summary>The name given to the anonymous function wrapping a top-level expression.</summary>
    public const string AnonymousExpressionName = "__anon_expr";

    public Parser(Lexer lexer) => Lexer = lexer;

    protected Lexer Lexer { get; }

    // definition ::= 'def' prototype expression
    public FunctionAST? ParseDefinition()
    {
        Lexer.GetNextToken(); // eat def.

        PrototypeAST? proto = ParsePrototype();
        if (proto is null)
        {
            return null;
        }

        ExprAST? body = ParseExpression();
        return body is null ? null : new FunctionAST(proto, body);
    }

    // external ::= 'extern' prototype
    public PrototypeAST? ParseExtern()
    {
        Lexer.GetNextToken(); // eat extern.
        return ParsePrototype();
    }

    // toplevelexpr ::= expression
    public FunctionAST? ParseTopLevelExpr()
    {
        ExprAST? expr = ParseExpression();
        if (expr is null)
        {
            return null;
        }

        // Make an anonymous prototype so a top-level expression can be JIT-compiled and called.
        var proto = new PrototypeAST(AnonymousExpressionName, Array.Empty<string>());
        return new FunctionAST(proto, expr);
    }

    protected static ExprAST? LogError(string message)
    {
        Console.Error.WriteLine($"Error: {message}");
        return null;
    }

    protected static PrototypeAST? LogErrorProto(string message)
    {
        Console.Error.WriteLine($"Error: {message}");
        return null;
    }

    // expression ::= unary binoprhs
    protected ExprAST? ParseExpression()
    {
        ExprAST? lhs = ParseUnary();
        return lhs is null ? null : ParseBinOpRHS(0, lhs);
    }

    // primary
    //   ::= identifierexpr
    //   ::= numberexpr
    //   ::= parenexpr
    //   ::= <chapter-specific keyword forms>
    protected virtual ExprAST? ParsePrimary()
    {
        switch (Lexer.CurrentToken)
        {
            case (int)Token.Identifier:
                return ParseIdentifierExpr();

            case (int)Token.Number:
                return ParseNumberExpr();

            case '(':
                return ParseParenExpr();

            default:
                if (TryParseKeywordPrimary(Lexer.CurrentToken, out ExprAST? result))
                {
                    return result;
                }

                return LogError("unknown token when expecting an expression");
        }
    }

    /// <summary>Hook for chapters that add primary forms (if/for in ch5, var in ch7).</summary>
    protected virtual bool TryParseKeywordPrimary(int token, out ExprAST? result)
    {
        result = null;
        return false;
    }

    // unary ::= primary | <op> unary. Chapter 6 overrides this to parse user-defined unary operators.
    protected virtual ExprAST? ParseUnary() => ParsePrimary();

    // binoprhs ::= (<op> unary)*
    protected ExprAST? ParseBinOpRHS(int expressionPrecedence, ExprAST lhs)
    {
        while (true)
        {
            int tokenPrecedence = Lexer.GetTokenPrecedence();

            // If this binop binds less tightly than the current one, we are done.
            if (tokenPrecedence < expressionPrecedence)
            {
                return lhs;
            }

            int binaryOp = Lexer.CurrentToken;
            Lexer.GetNextToken(); // eat binop.

            ExprAST? rhs = ParseUnary();
            if (rhs is null)
            {
                return null;
            }

            // If the operator after RHS binds more tightly, let it take RHS as its LHS.
            int nextPrecedence = Lexer.GetTokenPrecedence();
            if (tokenPrecedence < nextPrecedence)
            {
                rhs = ParseBinOpRHS(tokenPrecedence + 1, rhs);
                if (rhs is null)
                {
                    return null;
                }
            }

            lhs = new BinaryExprAST((char)binaryOp, lhs, rhs);
        }
    }

    // prototype ::= id '(' id* ')'. Chapter 6 overrides this to parse operator prototypes.
    protected virtual PrototypeAST? ParsePrototype()
    {
        if (Lexer.CurrentToken != (int)Token.Identifier)
        {
            return LogErrorProto("Expected function name in prototype");
        }

        string fnName = Lexer.LastIdentifier;
        Lexer.GetNextToken();

        if (Lexer.CurrentToken != '(')
        {
            return LogErrorProto("Expected '(' in prototype");
        }

        var argNames = new List<string>();
        while (Lexer.GetNextToken() == (int)Token.Identifier)
        {
            argNames.Add(Lexer.LastIdentifier);
        }

        if (Lexer.CurrentToken != ')')
        {
            return LogErrorProto("Expected ')' in prototype");
        }

        Lexer.GetNextToken(); // eat ')'.
        return new PrototypeAST(fnName, argNames);
    }

    // numberexpr ::= number
    private ExprAST ParseNumberExpr()
    {
        var result = new NumberExprAST(Lexer.LastNumber);
        Lexer.GetNextToken(); // consume the number.
        return result;
    }

    // parenexpr ::= '(' expression ')'
    private ExprAST? ParseParenExpr()
    {
        Lexer.GetNextToken(); // eat (.

        ExprAST? v = ParseExpression();
        if (v is null)
        {
            return null;
        }

        if (Lexer.CurrentToken != ')')
        {
            return LogError("expected ')'");
        }

        Lexer.GetNextToken(); // eat ).
        return v;
    }

    // identifierexpr
    //   ::= identifier
    //   ::= identifier '(' expression* ')'
    private ExprAST? ParseIdentifierExpr()
    {
        string idName = Lexer.LastIdentifier;
        Lexer.GetNextToken(); // eat identifier.

        if (Lexer.CurrentToken != '(')
        {
            return new VariableExprAST(idName); // simple variable ref.
        }

        Lexer.GetNextToken(); // eat (.
        var args = new List<ExprAST>();

        if (Lexer.CurrentToken != ')')
        {
            while (true)
            {
                ExprAST? arg = ParseExpression();
                if (arg is null)
                {
                    return null;
                }

                args.Add(arg);

                if (Lexer.CurrentToken == ')')
                {
                    break;
                }

                if (Lexer.CurrentToken != ',')
                {
                    return LogError("Expected ')' or ',' in argument list");
                }

                Lexer.GetNextToken();
            }
        }

        Lexer.GetNextToken(); // eat ).
        return new CallExprAST(idName, args);
    }
}
