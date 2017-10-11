using System;
using System.Runtime.InteropServices;
using Kaleidoscope;
using Kaleidoscope.AST;
using LLVMSharp;

namespace KaleidoscopeLLVM
{
    internal sealed class CodeGenParserListener : IParserListener
    {
        private readonly CodeGenVisitor visitor;

        private readonly LLVMExecutionEngineRef ee;

        private readonly LLVMPassManagerRef passManager;

        public CodeGenParserListener(LLVMExecutionEngineRef ee, LLVMPassManagerRef passManager, CodeGenVisitor visitor)
        {
            this.visitor = visitor;
            this.ee = ee;
            this.passManager = passManager;
        }

        public void EnterHandleDefinition(FunctionAST data)
        {
        }

        public void ExitHandleDefinition(FunctionAST data)
        {
            visitor.Visit(data);
            var function = visitor.ResultStack.Pop();
            LLVM.DumpValue(function);

            LLVM.RunFunctionPassManager(passManager, function);
            LLVM.DumpValue(function); // Dump the function for exposition purposes.
        }

        public void EnterHandleExtern(PrototypeAST data)
        {
        }

        public void ExitHandleExtern(PrototypeAST data)
        {
            visitor.Visit(data);
            LLVM.DumpValue(visitor.ResultStack.Pop());
        }

        public void EnterHandleTopLevelExpression(FunctionAST data)
        {
        }

        public void ExitHandleTopLevelExpression(FunctionAST data)
        {
            visitor.Visit(data);
            var anonymousFunction = visitor.ResultStack.Pop();
            LLVM.DumpValue(anonymousFunction); // Dump the function for exposition purposes.
            var dFunc = (Program.D)Marshal.GetDelegateForFunctionPointer(LLVM.GetPointerToGlobal(ee, anonymousFunction), typeof(Program.D));
            LLVM.RunFunctionPassManager(passManager, anonymousFunction);

            LLVM.DumpValue(anonymousFunction); // Dump the function for exposition purposes.
            Console.WriteLine("Evaluated to " + dFunc());
        }
    }
}