namespace Tests
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp;
    using LLVMSharp.Api;
    using LLVMSharp.Api.Types;
    using LLVMSharp.Api.Values.Constants.GlobalValues.GlobalObjects;
    using Type = LLVMSharp.Api.Type;
    using Api = LLVMSharp.Api;

    [UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate int Int32Delegate();

    [UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate long Int64Delegate();

    [UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    internal delegate TwoInt32 TwoInt32Delegate();

    [UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate int Int32Int32Int32Delegate(int a, int b);

    [UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate byte Int32Int32Int8Delegate(int a, int b);

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct TwoInt32 { public int X, Y; }

    internal static class Common
    {
        public static Function DefineFunction(this Module module, Type returnType, string name, Type[] arguments, Action<Function, Api.IRBuilder> generator)
        {
            var signature = FunctionType.Create(returnType, arguments);
            var function = module.AddFunction(name, signature);
            var basicBlock = function.AppendBasicBlock(string.Empty);
            using (var builder = Api.IRBuilder.Create())
            {
                builder.PositionBuilderAtEnd(basicBlock);
                generator.Invoke(function, builder);
            }
            return function;
        }

        public static ExecutionEngine CreateExecutionEngine(this Module module)
        {
            module.VerifyModule(LLVMVerifierFailureAction.LLVMPrintMessageAction, out string verificationErrorMessage);
            if (!string.IsNullOrEmpty(verificationErrorMessage))
            {
                throw new Exception(verificationErrorMessage);
            }

            Initialize.X86.Target();
            Initialize.X86.TargetInfo();
            Initialize.X86.TargetMC();
            Initialize.X86.AsmPrinter();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var defaultTarget = Marshal.PtrToStringAnsi(LLVM.GetDefaultTargetTriple());
                module.SetTarget(defaultTarget + "-elf");
            }

            return module.CreateMCJITCompilerForModule();
        }

        public static TDelegate GetDelegate<TDelegate>(this ExecutionEngine executionEngine, Function function)
        {
            var functionPtr = executionEngine.GetPointerToGlobal(function);
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(functionPtr);
        }
    }
}
