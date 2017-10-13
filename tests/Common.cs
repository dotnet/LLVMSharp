namespace UnitTests
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp;
    using LLVMSharp.Api;
    using LLVMSharp.Api.Types;
    using LLVMSharp.Api.Values.Constants.GlobalValues.GlobalObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Type = LLVMSharp.Api.Type;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int Int32Delegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int Int32Int32Int32Delegate(int a, int b);

    internal static class Common
    {
        public static Function DefineFunction(this Module module, Type returnType, string name, Type[] arguments, Action<Function, LLVMSharp.Api.IRBuilder> generator)
        {
            var signature = new FunctionType(returnType, arguments);
            var function = module.AddFunction(name, signature);
            var basicBlock = function.AppendBasicBlock(string.Empty);
            using (var builder = LLVMSharp.Api.IRBuilder.Create())
            {
                builder.PositionBuilderAtEnd(basicBlock);
                generator.Invoke(function, builder);
            }
            return function;
        }

        public static ExecutionEngine CreateExecutionEngine(this Module module)
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

            return module.CreateMCJITCompilerForModule();
        }

        public static TDelegate GetDelegate<TDelegate>(this ExecutionEngine executionEngine, Function function)
        {
            var functionPtr = executionEngine.GetPointerToGlobal(function);
            return (TDelegate) (object) Marshal.GetDelegateForFunctionPointer(functionPtr, typeof (TDelegate));
        }

        public static void InNewAppDomain(Action action)
        {
            var domain = AppDomain.CreateDomain(string.Empty);
            try
            {
                domain.DoCallBack(new CrossAppDomainDelegate(action));
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
    }
}
