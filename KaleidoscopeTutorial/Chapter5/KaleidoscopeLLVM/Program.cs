namespace KaleidoscopeLLVM
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Kaleidoscope;
    using LLVMSharp;

    public sealed class Program
    {
        public delegate double D();

        private static void Main(string[] args)
        {
            // Make the module, which holds all the code.
            LLVMModuleRef module = LLVM.ModuleCreateWithName("my cool jit");
            LLVMBuilderRef builder = LLVM.CreateBuilder();

            LLVM.LinkInMCJIT();
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetMC();

            LLVMExecutionEngineRef engine;
            IntPtr errorMessage;
            if (LLVM.CreateExecutionEngineForModule(out engine, module, out errorMessage).Value == 1)
            {
                Console.WriteLine(Marshal.PtrToStringAnsi(errorMessage));
                LLVM.DisposeMessage(errorMessage);
                return;
            }

            // Create a function pass manager for this engine
            LLVMPassManagerRef passManager = LLVM.CreateFunctionPassManagerForModule(module);

            // Set up the optimizer pipeline.  Start with registering info about how the
            // target lays out data structures.
            LLVM.AddTargetData(LLVM.GetExecutionEngineTargetData(engine), passManager);

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
            var binopPrecedence = new Dictionary<char, int>();
            binopPrecedence['<'] = 10;
            binopPrecedence['+'] = 20;
            binopPrecedence['-'] = 20;
            binopPrecedence['*'] = 40;  // highest.

            var scanner = new Lexer(Console.In, binopPrecedence);
            var parser = new Parser(scanner, codeGenlistener);

            // Prime the first token.
            Console.Write("ready> ");
            scanner.GetNextToken();

            // Run the main "interpreter loop" now.
            MainLoop(scanner, parser);

            // Print out all of the generated code.
            LLVM.DumpModule(module);

            LLVM.DisposeModule(module);
            LLVM.DisposePassManager(passManager);
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