namespace UnitTests
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OOPAPITests
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int Delegate1(int a, int b);

        private static TDelegate InitializeAndReturnDelegate<TDelegate>(LLVMModuleRef module, LLVMValueRef function)
        {
            IntPtr verificationErrorPtr;
            LLVM.VerifyModule(module, LLVMVerifierFailureAction.LLVMPrintMessageAction, out verificationErrorPtr);
            var verificationErrorMessage = Marshal.PtrToStringAnsi(verificationErrorPtr);
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
                LLVM.SetTarget(module, defaultTarget + "-elf");
            }

            LLVMExecutionEngineRef executionEngine;
            LLVMMCJITCompilerOptions options;
            var optionsSize = Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions));
            LLVM.InitializeMCJITCompilerOptions(out options, optionsSize);

            IntPtr compilerErrorPtr;
            LLVM.CreateMCJITCompilerForModule(out executionEngine, module, out options, optionsSize, out compilerErrorPtr);
            var compilerErrorMessage = Marshal.PtrToStringAnsi(compilerErrorPtr);
            if (!string.IsNullOrEmpty(compilerErrorMessage))
            {
                Assert.Fail(compilerErrorMessage);
            }

            var functionPtr = LLVM.GetPointerToGlobal(executionEngine, function);
            return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(functionPtr, typeof(TDelegate));
        }

        [TestMethod]
        public void SimpleAdd()
        {
            var module = new Module("module");
            var i32 = LLVM.Int32Type();
            var signature = LLVM.FunctionType(i32, new[] { i32, i32 }, false);
            var function = module.AddFunction("add", signature);
            var basicBlock = new BasicBlock(null, string.Empty, function);
            var builder = new IRBuilder();
            LLVM.PositionBuilderAtEnd(builder, basicBlock);
            var p1 = LLVM.GetParam(function, 0u);
            var p2 = LLVM.GetParam(function, 1u);
            var add = builder.CreateAdd(p1, p2, string.Empty);
            var ret = builder.CreateRet(add);

            var runnable = InitializeAndReturnDelegate<Delegate1>(module, function);
            var result = runnable(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}
