// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;

namespace Kaleidoscope;

/// <summary>
/// The top-level "read a token, decide what to parse" loop (tutorial chapter 2). It is unchanged from
/// chapter to chapter, so it lives here: it drives the lexer, recovers from a parse error by skipping a
/// token, and hands each parsed construct to a <c>protected abstract</c> that the concrete driver
/// implements (dump IR, JIT and run, or emit an object file).
/// </summary>
public abstract class ReplDriver
{
    protected ReplDriver(Lexer lexer, Parser parser)
    {
        Lexer = lexer;
        Parser = parser;
    }

    protected Lexer Lexer { get; }

    protected Parser Parser { get; }

    /// <summary>Runs the loop until end-of-file.</summary>
    public void Run()
    {
        Lexer.GetNextToken(); // prime the first token.

        while (true)
        {
            switch (Lexer.CurrentToken)
            {
                case (int)Token.Eof:
                {
                    return;
                }

                case ';':
                {
                    Lexer.GetNextToken(); // ignore top-level semicolons.
                    break;
                }

                case (int)Token.Def:
                {
                    HandleDefinition();
                    break;
                }

                case (int)Token.Extern:
                {
                    HandleExtern();
                    break;
                }

                default:
                {
                    HandleTopLevelExpression();
                    break;
                }
            }
        }
    }

    /// <summary>Consumes and code-generates a <c>def</c>.</summary>
    protected abstract void OnDefinition(FunctionAST function);

    /// <summary>Consumes and registers an <c>extern</c>.</summary>
    protected abstract void OnExtern(PrototypeAST prototype);

    /// <summary>Consumes and evaluates a top-level expression.</summary>
    protected abstract void OnTopLevelExpression(FunctionAST function);

    private void HandleDefinition()
    {
        FunctionAST? function = Parser.ParseDefinition();
        if (function is null)
        {
            Lexer.GetNextToken(); // skip token for error recovery.
            return;
        }

        Dispatch(() => OnDefinition(function));
    }

    private void HandleExtern()
    {
        PrototypeAST? prototype = Parser.ParseExtern();
        if (prototype is null)
        {
            Lexer.GetNextToken(); // skip token for error recovery.
            return;
        }

        Dispatch(() => OnExtern(prototype));
    }

    private void HandleTopLevelExpression()
    {
        FunctionAST? function = Parser.ParseTopLevelExpr();
        if (function is null)
        {
            Lexer.GetNextToken(); // skip token for error recovery.
            return;
        }

        Dispatch(() => OnTopLevelExpression(function));
    }

    private static void Dispatch(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Error: {exception.Message}");
        }
    }
}
