namespace KaleidoscopeLLVM
{
    using System;
    using System.Collections.Generic;
    using Kaleidoscope;
    using LLVMSharp;

    public sealed class Program
    {
        public delegate double D();

        public static void Main(string[] args)
        {
            // Make the module, which holds all the code.
            LLVMModuleRef module = LLVM.ModuleCreateWithName("my cool jit");
            LLVMBuilderRef builder = LLVM.CreateBuilder();
            LLVM.LinkInMCJIT();
            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86AsmParser();
            LLVM.InitializeX86AsmPrinter();

            if (LLVM.CreateExecutionEngineForModule(out var engine, module, out var errorMessage).Value == 1)
            {
                Console.WriteLine(errorMessage);
                // LLVM.DisposeMessage(errorMessage);
                return;
            }

            // Create a function pass manager for this engine
            LLVMPassManagerRef passManager = LLVM.CreateFunctionPassManagerForModule(module);

            // Set up the optimizer pipeline.  Start with registering info about how the
            // target lays out data structures.
            // LLVM.DisposeTargetData(LLVM.GetExecutionEngineTargetData(engine));

            // Provide basic AliasAnalysis support for GVN.
            LLVM.AddBasicAliasAnalysisPass(passManager);

            // Promote allocas to registers.
            LLVM.AddPromoteMemoryToRegisterPass(passManager);

            // Do simple "peephole" optimizations and bit-twiddling optzns.
            LLVM.AddInstructionCombiningPass(passManager);

            // Reassociate expressions.
            LLVM.AddReassociatePass(passManager);

            // Eliminate Common SubExpressions.
            LLVM.AddGVNPass(passManager);

            // Simplify the control flow graph (deleting unreachable blocks, etc).
            LLVM.AddCFGSimplificationPass(passManager);

            LLVM.InitializeFunctionPassManager(passManager);

            var codeGenlistener = new CodeGenParserListener(engine, passManager, new CodeGenVisitor(module, builder));

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
                case (int) Token.EOF:
                    return;
                case ';':
                    lexer.GetNextToken();
                    break;
                case (int) Token.DEF:
                    parser.HandleDefinition();
                    break;
                case (int) Token.EXTERN:
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