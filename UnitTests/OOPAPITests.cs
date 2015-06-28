namespace UnitTests
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Type = LLVMSharp.Type;

    [TestClass]
    public class OOPAPITests
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int Delegate1(int a, int b);

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
            return (TDelegate) (object) Marshal.GetDelegateForFunctionPointer(functionPtr, typeof (TDelegate));
        }

        [TestMethod]
        public void SimpleAdd()
        {
            var module = new Module("module");
            var i32 = Type.Int32;
            var signature = new FunctionType(i32, new[] { i32, i32 });
            var function = module.AddFunction("add", signature);
            var basicBlock = new BasicBlock(null, string.Empty, function);
            using (var builder = new IRBuilder())
            {
                builder.PositionBuilderAtEnd(basicBlock);
                var p1 = function.GetParameter(0);
                var p2 = function.GetParameter(1);
                var add = builder.CreateAdd(p1, p2, string.Empty);
                var ret = builder.CreateRet(add);

                var runnable = InitializeAndReturnDelegate<Delegate1>(module, function);
                var result = runnable(1, 2);
                Assert.AreEqual(3, result);
            }
        }
    }
}
