// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Globalization;
using System.Text;
using Kaleidoscope.AST;

namespace Kaleidoscope;

/// <summary>
/// Turns a character stream into Kaleidoscope tokens (tutorial chapter 1). One lexer serves every
/// chapter: it always recognizes the full keyword set, and the per-chapter parser decides which of
/// those keywords it is willing to accept.
/// </summary>
public sealed class Lexer
{
    private const int Eof = -1;

    private readonly TextReader _reader;
    private readonly IReadOnlyDictionary<char, int> _binaryOpPrecedence;
    private readonly StringBuilder _builder = new();

    private int _lastChar = ' ';
    private int _line = 1;
    private int _column;

    public Lexer(TextReader reader, IReadOnlyDictionary<char, int> binaryOpPrecedence)
    {
        _reader = reader;
        _binaryOpPrecedence = binaryOpPrecedence;
    }

    /// <summary>The most recently scanned token. Positive values are literal characters.</summary>
    public int CurrentToken { get; private set; }

    /// <summary>
    /// Source location of the token in <see cref="CurrentToken"/> (chapter 9). Only the debug-info
    /// chapter consults it; every other chapter ignores it.
    /// </summary>
    public SourceLocation TokenLocation { get; private set; } = new(1, 0);

    /// <summary>The identifier text for the most recent <see cref="Token.Identifier"/>.</summary>
    public string LastIdentifier { get; private set; } = string.Empty;

    /// <summary>The value for the most recent <see cref="Token.Number"/>.</summary>
    public double LastNumber { get; private set; }

    /// <summary>Precedence of the current token if it is a known binary operator, otherwise -1.</summary>
    public int GetTokenPrecedence()
    {
        if (CurrentToken > 0 && _binaryOpPrecedence.TryGetValue((char)CurrentToken, out int precedence))
        {
            return precedence;
        }

        return -1;
    }

    /// <summary>Scans and returns the next token, also exposed via <see cref="CurrentToken"/>.</summary>
    public int GetNextToken()
    {
        CurrentToken = ReadToken();
        return CurrentToken;
    }

    private int ReadToken()
    {
        // Skip any whitespace.
        while (char.IsWhiteSpace((char)_lastChar))
        {
            _lastChar = Advance();
        }

        // Record where this token begins so chapter 9 can attach debug locations.
        TokenLocation = new SourceLocation(_line, _column);

        // identifier: [a-zA-Z][a-zA-Z0-9]*
        if (char.IsLetter((char)_lastChar))
        {
            _builder.Clear();
            do
            {
                _builder.Append((char)_lastChar);
                _lastChar = Advance();
            }
            while (char.IsLetterOrDigit((char)_lastChar));

            LastIdentifier = _builder.ToString();

            return LastIdentifier switch
            {
                "def" => (int)Token.Def,
                "extern" => (int)Token.Extern,
                "if" => (int)Token.If,
                "then" => (int)Token.Then,
                "else" => (int)Token.Else,
                "for" => (int)Token.For,
                "in" => (int)Token.In,
                "binary" => (int)Token.Binary,
                "unary" => (int)Token.Unary,
                "var" => (int)Token.Var,
                _ => (int)Token.Identifier,
            };
        }

        // number: [0-9.]+
        if (char.IsDigit((char)_lastChar) || _lastChar == '.')
        {
            _builder.Clear();
            do
            {
                _builder.Append((char)_lastChar);
                _lastChar = Advance();
            }
            while (char.IsDigit((char)_lastChar) || _lastChar == '.');

            LastNumber = double.Parse(_builder.ToString(), CultureInfo.InvariantCulture);
            return (int)Token.Number;
        }

        // comment until end of line
        if (_lastChar == '#')
        {
            do
            {
                _lastChar = Advance();
            }
            while (_lastChar != Eof && _lastChar != '\n' && _lastChar != '\r');

            if (_lastChar != Eof)
            {
                return ReadToken();
            }
        }

        // Don't eat the EOF.
        if (_lastChar == Eof)
        {
            return (int)Token.Eof;
        }

        // Otherwise, return the character as its ASCII value.
        int thisChar = _lastChar;
        _lastChar = Advance();
        return thisChar;
    }

    /// <summary>Reads the next character, tracking line and column for <see cref="TokenLocation"/>.</summary>
    private int Advance()
    {
        int next = _reader.Read();

        if (next == '\n')
        {
            _line++;
            _column = 0;
        }
        else if (next != Eof)
        {
            _column++;
        }

        return next;
    }
}
