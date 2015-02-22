using System.Diagnostics;

namespace Kaleidoscope
{
    using System;
    using System.Collections.Generic;
    using AST;

    public sealed class Parser : IParser
    {
        private readonly Lexer scanner;

        private readonly BaseParserListener baseListener;

        public Parser(Lexer scanner, IParserListener listener)
        {
            this.scanner = scanner;
            this.baseListener = new BaseParserListener(listener);
        }

        public void HandleDefinition()
        {
            this.baseListener.EnterRule("HandleDefinition");

            var functionAST = this.ParseDefinition();

            baseListener.ExitRule(functionAST);

            if (functionAST != null)
            {
                this.baseListener.Listen();
            }
            else
            {
                // Skip token for error recovery.
                this.scanner.GetNextToken();
            }
        }

        public void HandleExtern()
        {
            this.baseListener.EnterRule("HandleExtern");

            var prototypeAST = this.ParseExtern();

            this.baseListener.ExitRule(prototypeAST);

            if (prototypeAST != null)
            {
                this.baseListener.Listen();
            }
            else
            {
                // Skip token for error recovery.
                this.scanner.GetNextToken();
            }
        }

        public void HandleTopLevelExpression()
        {
            // Evaluate a top-level expression into an anonymous function.
            this.baseListener.EnterRule("HandleTopLevelExpression");

            var functionAST = this.ParseTopLevelExpr();

            this.baseListener.ExitRule(functionAST);

            if (functionAST != null)
            {
                this.baseListener.Listen();
            }
            else
            {
                // Skip token for error recovery.
                this.scanner.GetNextToken();
            }
        }

        // identifierexpr
        //   ::= identifier
        //   ::= identifier '(' expression* ')'
        private ExprAST ParseIdentifierExpr()
        {
            string idName = this.scanner.GetLastIdentifier();
            
            this.scanner.GetNextToken();  // eat identifier.

            if (this.scanner.CurrentToken != '(') // Simple variable ref.
            {
                return new VariableExprAST(idName);
            }

            // Call.
            this.scanner.GetNextToken();  // eat (
            List<ExprAST> args = new List<ExprAST>();

            if (this.scanner.CurrentToken != ')')
            {
                while (true)
                {
                    ExprAST arg = this.ParseExpression();
                    if (arg == null)
                    {
                        return null;
                    }

                    args.Add(arg);

                    if (this.scanner.CurrentToken == ')')
                    {
                        break;
                    }

                    if (this.scanner.CurrentToken != ',')
                    {
                        Console.WriteLine("Expected ')' or ',' in argument list");
                        return null;
                    }
                    
                    this.scanner.GetNextToken();
                }
            }
            
            // Eat the ')'.
            this.scanner.GetNextToken();

            return new CallExprAST(idName, args);
        }

        // numberexpr ::= number
        private ExprAST ParseNumberExpr()
        {
            ExprAST result = new NumberExprAST(this.scanner.GetLastNumber());
            this.scanner.GetNextToken();
            return result;
        }

        // parenexpr ::= '(' expression ')'
        private ExprAST ParseParenExpr()
        {
            this.scanner.GetNextToken();  // eat (.
            ExprAST v = this.ParseExpression();
            if (v == null)
            {
                return null;
            }

            if (this.scanner.CurrentToken != ')')
            {
                Console.WriteLine("expected ')'");
                return null;
            }

            this.scanner.GetNextToken(); // eat ).

            return v;
        }

        // ifexpr ::= 'if' expression 'then' expression 'else' expression
        public ExprAST ParseIfExpr()
        {
            this.scanner.GetNextToken(); // eat the if.

            // condition
            ExprAST cond = this.ParseExpression();
            if (cond == null)
            {
                return null;
            }

            if (this.scanner.CurrentToken != (int)Token.THEN)
            {
                Console.WriteLine("expected then");
            }

            this.scanner.GetNextToken(); // eat the then

            ExprAST then = this.ParseExpression();
            if (then == null)
            {
                return null;
            }

            if (this.scanner.CurrentToken != (int)Token.ELSE)
            {
                Console.WriteLine("expected else");
                return null;
            }

            this.scanner.GetNextToken();

            ExprAST @else = this.ParseExpression();
            if (@else == null)
            {
                return null;
            }

            return new IfExpAST(cond, then, @else);
        }

        // forexpr ::= 'for' identifier '=' expr ',' expr (',' expr)? 'in' expression
        public ExprAST ParseForExpr()
        {
            this.scanner.GetNextToken(); // eat the for.

            if (this.scanner.CurrentToken != (int)Token.IDENTIFIER)
            {
                Console.WriteLine("expected identifier after for");
                return null;
            }

            string idName = this.scanner.GetLastIdentifier();
            this.scanner.GetNextToken(); // eat identifier.

            if (this.scanner.CurrentToken != '=')
            {
                Console.WriteLine("expected '=' after for");
                return null;
            }

            this.scanner.GetNextToken(); // eat '='.

            ExprAST start = this.ParseExpression();
            if (start == null)
            {
                return null;
            }

            if (this.scanner.CurrentToken != ',')
            {
                Console.WriteLine("expected ',' after for start value");
                return null;
            }

            this.scanner.GetNextToken();

            ExprAST end = this.ParseExpression();
            if (end == null)
            {
                return null;
            }

            // The step value is optional;
            ExprAST step = null;
            if (this.scanner.CurrentToken == ',')
            {
                this.scanner.GetNextToken();
                step = this.ParseExpression();
                if (step == null)
                {
                    return null;
                }
            }

            if (this.scanner.CurrentToken != (int)Token.IN)
            {
                Console.WriteLine("expected 'in' after for");
                return null;
            }

            this.scanner.GetNextToken();
            ExprAST body = this.ParseExpression();
            if (body == null)
            {
                return null;
            }

            return new ForExprAST(idName, start, end, step, body);
        }

        // primary
        //   ::= identifierexpr
        //   ::= numberexpr
        //   ::= parenexpr
        private ExprAST ParsePrimary()
        {
            switch (this.scanner.CurrentToken)
            {
                case (int)Token.IDENTIFIER:
                    return this.ParseIdentifierExpr();
                case (int)Token.NUMBER:
                    return this.ParseNumberExpr();
                case '(':
                    return this.ParseParenExpr();
                case (int)Token.IF:
                    return this.ParseIfExpr();
                case (int)Token.FOR:
                    return this.ParseForExpr();
                default:
                    Console.WriteLine("unknown token when expecting an expression");
                    return null;
            }
        }

        // binoprhs
        //   ::= ('+' primary)*
        private ExprAST ParseBinOpRHS(int exprPrec, ExprAST lhs)
        {
            // If this is a binop, find its precedence.
            while (true)
            {
                int tokPrec = this.scanner.GetTokPrecedence();

                // If this is a binop that binds at least as tightly as the current binop,
                // consume it, otherwise we are done.
                if (tokPrec < exprPrec)
                {
                    return lhs;
                }

                // Okay, we know this is a binop.
                int binOp = this.scanner.CurrentToken;
                this.scanner.GetNextToken();  // eat binop

                // Parse the primary expression after the binary operator.
                ExprAST rhs = this.ParsePrimary();
                if (rhs == null)
                {
                    return null;
                }

                // If BinOp binds less tightly with RHS than the operator after RHS, let
                // the pending operator take RHS as its LHS.
                int nextPrec = this.scanner.GetTokPrecedence();
                if (tokPrec < nextPrec)
                {
                    rhs = this.ParseBinOpRHS(tokPrec + 1, rhs);
                    if (rhs == null)
                    {
                        return null;
                    }
                }

                // Merge LHS/RHS.
                lhs = new BinaryExprAST((char)binOp, lhs, rhs);
            }
        }

        // expression
        //   ::= primary binoprhs
        //
        private ExprAST ParseExpression()
        {
            ExprAST lhs = this.ParsePrimary();
            if (lhs == null)
            {
                return null;
            }

            return this.ParseBinOpRHS(0, lhs);
        }

        // prototype
        //   ::= id '(' id* ')'
        private PrototypeAST ParsePrototype()
        {
            if (this.scanner.CurrentToken != (int)Token.IDENTIFIER)
            {
                Console.WriteLine("Expected function name in prototype");
                return null;
            }

            string fnName = this.scanner.GetLastIdentifier();

            this.scanner.GetNextToken();

            if (this.scanner.CurrentToken != '(')
            {
                Console.WriteLine("Expected '(' in prototype");
                return null;
            }

            List<string> argNames = new List<string>();
            while (this.scanner.GetNextToken() == (int)Token.IDENTIFIER)
            {
                argNames.Add(this.scanner.GetLastIdentifier());
            }

            if (this.scanner.CurrentToken != ')')
            {
                Console.WriteLine("Expected ')' in prototype");
                return null;
            }

            this.scanner.GetNextToken(); // eat ')'.

            return new PrototypeAST(fnName, argNames);
        }

        // definition ::= 'def' prototype expression
        private FunctionAST ParseDefinition()
        {
            this.scanner.GetNextToken(); // eat def.
            PrototypeAST proto = this.ParsePrototype();

            if (proto == null)
            {
                return null;
            }

            ExprAST body = this.ParseExpression();
            if (body == null)
            {
                return null;
            }

            return new FunctionAST(proto, body);
        }

        /// toplevelexpr ::= expression
        private FunctionAST ParseTopLevelExpr()
        {
            ExprAST e = this.ParseExpression();
            if (e == null)
            {
                return null;
            }

            // Make an anonymous proto.
            PrototypeAST proto = new PrototypeAST(string.Empty, new List<string>());
            return new FunctionAST(proto, e);
        }

        /// external ::= 'extern' prototype
        private PrototypeAST ParseExtern()
        {
            this.scanner.GetNextToken();  // eat extern.
            return this.ParsePrototype();
        }
    }
}