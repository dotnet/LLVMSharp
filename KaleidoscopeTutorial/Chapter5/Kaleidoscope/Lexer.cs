namespace Kaleidoscope
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public sealed class Lexer : ILexer
    {
        private const int EOF = -1;

        private readonly TextReader reader;

        private readonly StringBuilder identifierBuilder = new StringBuilder();

        private readonly StringBuilder numberBuilder = new StringBuilder();

        private readonly Dictionary<char, int> binopPrecedence;

        private int c = ' ';

        private string identifier;

        private double numVal;

        public Lexer(TextReader reader, Dictionary<char, int> binOpPrecedence)
        {
            this.reader = reader;
            this.binopPrecedence = binOpPrecedence;
        }

        public int CurrentToken { get; private set; }

        public string GetLastIdentifier()
        {
            return this.identifier;
        }

        public double GetLastNumber()
        {
            return this.numVal;
        }

        public int GetTokPrecedence()
        {
            // Make sure it's a declared binop.
            int tokPrec;
            if (this.binopPrecedence.TryGetValue((char)this.CurrentToken, out tokPrec))
            {
                return tokPrec;
            }

            return -1;
        }

        public int GetNextToken()
        {
            // Skip any whitespace.
            while (char.IsWhiteSpace((char)c))
            {
                c = this.reader.Read();
            }

            if (char.IsLetter((char)c)) // identifier: [a-zA-Z][a-zA-Z0-9]*
            {
                this.identifierBuilder.Append((char)c);
                while (char.IsLetterOrDigit((char)(c = this.reader.Read())))
                {
                    this.identifierBuilder.Append((char)c);
                }

                this.identifier = this.identifierBuilder.ToString();
                this.identifierBuilder.Clear();

                if (string.Equals(identifier, "def", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.DEF;
                }
                else if (string.Equals(identifier, "extern", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.EXTERN;
                }
                else if (string.Equals(identifier, "if", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.IF;
                }
                else if (string.Equals(identifier, "then", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.THEN;
                }
                else if (string.Equals(identifier, "else", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.ELSE;
                }
                else if (string.Equals(identifier, "for", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.FOR;
                }
                else if (string.Equals(identifier, "in", StringComparison.Ordinal))
                {
                    this.CurrentToken = (int)Token.IN;
                }
                else
                {
                    this.CurrentToken = (int)Token.IDENTIFIER;
                }

                return this.CurrentToken;
            }

            // Number: [0-9.]+
            if (char.IsDigit((char)c) || c == '.')
            {
                do
                {
                    this.numberBuilder.Append((char)c);
                    c = this.reader.Read();
                } while (char.IsDigit((char)c) || c == '.');
                
                this.numVal = double.Parse(this.numberBuilder.ToString());
                this.numberBuilder.Clear();
                this.CurrentToken = (int)Token.NUMBER;

                return this.CurrentToken;
            }

            if (c == '#')
            {
                // Comment until end of line.
                do
                {
                    c = this.reader.Read();
                } while (c != EOF && c != '\n' && c != '\r');

                if (c != EOF)
                {
                    return this.GetNextToken();
                }
            }

            // Check for end of file.  Don't eat the EOF.
            if (c == EOF)
            {
                this.CurrentToken = c;
                return (int)Token.EOF;
            }

            this.CurrentToken = c;
            c = this.reader.Read();
            return this.c;
        }
    }
}