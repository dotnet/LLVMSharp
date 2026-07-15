// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;

namespace Kaleidoscope.Chapter6;

/// <summary>
/// Chapter 6 parser delta — user-defined operators. It adds a <see cref="ParseUnary"/> production for
/// prefix operators and extends <see cref="ParsePrototype"/> to parse <c>unary&lt;op&gt;</c> and
/// <c>binary&lt;op&gt; [precedence]</c> definitions, registering a new binary operator's precedence into
/// the shared precedence table so subsequent input parses with the right binding.
/// </summary>
public class Parser(Lexer lexer, IDictionary<char, int> binaryOpPrecedence) : Chapter5.Parser(lexer)
{
    private readonly IDictionary<char, int> _binaryOpPrecedence = binaryOpPrecedence;

    // unary ::= primary | <op> unary
    protected override ExprAST? ParseUnary()
    {
        // If the current token isn't an operator character, it must be a primary expression. Negative
        // tokens are keywords/identifiers/numbers; '(' and ',' start or separate primaries.
        int token = Lexer.CurrentToken;
        if (token < 0 || token == '(' || token == ',')
        {
            return ParsePrimary();
        }

        // Otherwise it's a prefix unary operator; read the operator and its operand.
        int opcode = token;
        Lexer.GetNextToken();

        ExprAST? operand = ParseUnary();
        return operand is null ? null : new UnaryExprAST((char)opcode, operand);
    }

    // prototype
    //   ::= id '(' id* ')'
    //   ::= 'unary' <op> '(' id ')'
    //   ::= 'binary' <op> [precedence] '(' id id ')'
    protected override PrototypeAST? ParsePrototype()
    {
        int line = CurrentLocation.Line;

        string functionName;
        int kind; // 0 = identifier, 1 = unary operator, 2 = binary operator.
        int binaryPrecedence = 30;

        switch (Lexer.CurrentToken)
        {
            case (int)Token.Identifier:
            {
                functionName = Lexer.LastIdentifier;
                kind = 0;
                Lexer.GetNextToken();
                break;
            }

            case (int)Token.Unary:
            {
                Lexer.GetNextToken();
                if (Lexer.CurrentToken <= 0)
                {
                    return LogErrorProto("Expected unary operator");
                }

                functionName = "unary" + (char)Lexer.CurrentToken;
                kind = 1;
                Lexer.GetNextToken();
                break;
            }

            case (int)Token.Binary:
            {
                Lexer.GetNextToken();
                if (Lexer.CurrentToken <= 0)
                {
                    return LogErrorProto("Expected binary operator");
                }

                functionName = "binary" + (char)Lexer.CurrentToken;
                kind = 2;
                Lexer.GetNextToken();

                // Read the optional precedence.
                if (Lexer.CurrentToken == (int)Token.Number)
                {
                    if (Lexer.LastNumber is < 1 or > 100)
                    {
                        return LogErrorProto("Invalid precedence: must be 1..100");
                    }

                    binaryPrecedence = (int)Lexer.LastNumber;
                    Lexer.GetNextToken();
                }

                break;
            }

            default:
            {
                return LogErrorProto("Expected function name in prototype");
            }
        }

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

        if (kind != 0 && argNames.Count != kind)
        {
            return LogErrorProto("Invalid number of operands for operator");
        }

        var prototype = new PrototypeAST(functionName, argNames, IsOperator: kind != 0, binaryPrecedence) { Line = line };

        // Make a user-defined binary operator usable in the input that follows its definition.
        if (prototype.IsBinaryOperator)
        {
            _binaryOpPrecedence[prototype.OperatorName] = prototype.Precedence;
        }

        return prototype;
    }
}
