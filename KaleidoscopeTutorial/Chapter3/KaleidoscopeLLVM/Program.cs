namespace KaleidoscopeLLVM
{
    using System;
    using System.Collections.Generic;
    using Kaleidoscope;
    using LLVMSharp;

    public sealed class Program
    {
        private static void Main(string[] args)
        {
            // Make the module, which holds all the code.
            LLVMModuleRef module = LLVM.ModuleCreateWithName("my cool jit");
            LLVMBuilderRef builder = LLVM.CreateBuilder();
            var codeGenlistener = new CodeGenParserListener(new CodeGenVisitor(module, builder));

            // Install standard binary operators.
            // 1 is lowest precedence.
            var binopPrecedence = new Dictionary<char, int>
            {
                ['<'] = 10,
                ['+'] = 20,
                ['-'] = 20,
                ['*'] = 40
            };
            // highest.

            var scanner = new Lexer(Console.In, binopPrecedence);
            var parser = new Parser(scanner, codeGenlistener);

            // Prime the first token.
            Console.Write("ready> ");
            scanner.GetNextToken();

            // Run the main "interpreter loop" now.
            MainLoop(scanner, parser);

            // Print out all of the generated code.
            LLVM.DumpModule(module);
        }

        private static void MainLoop(ILexer lexer, IParser parser)
        {
            // top ::= definition | external | expression | ';'
            while (true)
            {
                Console.Write("ready> ");
                switch (lexer.CurrentToken)
                {
                case (int)Token.EOF:
                    return;
                case ';':
                    lexer.GetNextToken();
                    break;
                case (int)Token.DEF:
                    parser.HandleDefinition();
                    break;
                case (int)Token.EXTERN:
                    parser.HandleExtern();
                    break;
                default:
                    parser.HandleTopLevelExpression();
                    break;
                }
            }
        }
    }
}