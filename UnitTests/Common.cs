namespace UnitTests
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Type = LLVMSharp.Type;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int Int32Int32Int32Delegate(int a, int b);

    internal static class Common
    {
        private static TDelegate InitializeAndReturnDelegate<TDelegate>(Module module, Function function)
        {
            string verificationErrorMessage;
            module.VerifyModule(LLVMVerifierFailureAction.LLVMPrintMessageAction, out verificationErrorMessage);
            if (!string.IsNullOrEmpty(verificationErrorMessage))
            {
                Assert.Fail(verificationErrorMessage);
            }

            LLVM.LinkInMCJIT();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86AsmPrinter();

            var platform = Environment.OSVersion.Platform;
            if (platform == PlatformID.Win32NT)
            {
                var defaultTarget = Marshal.PtrToStringAnsi(LLVM.GetDefaultTargetTriple());
                module.SetTarget(defaultTarget + "-elf");
            }

            ExecutionEngine executionEngine;
            LLVMMCJITCompilerOptions options;
            string compilerErrorMessage;
            module.CreateMCJITCompilerForModule(out executionEngine, out options, out compilerErrorMessage);
            if (!string.IsNullOrEmpty(compilerErrorMessage))
            {
                Assert.Fail(compilerErrorMessage);
            }

            var functionPtr = executionEngine.GetPointerToGlobal(function);
            return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(functionPtr, typeof(TDelegate));
        }

        public static TDelegate CreateDelegateInLLVM<TDelegate>(
            string name,
            Type returnType,
            Type[] arguments,
            Action<Function, IRBuilder> generator)
        {
            var module = new Module("module");
            var signature = new FunctionType(returnType, arguments);
            var function = module.AddFunction("add", signature);
            var basicBlock = new BasicBlock(null, string.Empty, function);
            using (var builder = new IRBuilder())
            {
                builder.PositionBuilderAtEnd(basicBlock);
                generator.Invoke(function, builder);
            }
            return InitializeAndReturnDelegate<TDelegate>(module, function);
        }
    }
}
