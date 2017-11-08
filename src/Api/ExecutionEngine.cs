namespace LLVMSharp.Api
{
    using LLVMSharp.Api.Values.Constants;
    using LLVMSharp.Api.Values.Constants.GlobalValues.GlobalObjects;
    using System;
    using Utilities;

    public sealed class ExecutionEngine : IDisposable, IEquatable<ExecutionEngine>, IDisposableWrapper<LLVMExecutionEngineRef>
    {
        LLVMExecutionEngineRef IWrapper<LLVMExecutionEngineRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMExecutionEngineRef>.MakeHandleOwner() => this._owner = true;

        private readonly LLVMExecutionEngineRef _instance;        
        private bool _disposed;
        private bool _owner;

        public static ExecutionEngine Create(Module module)
        {
            if (LLVM.CreateExecutionEngineForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }
        
        public static ExecutionEngine CreateInterpreter(Module module)
        {
            if (LLVM.CreateInterpreterForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateJITCompiler(Module m, uint optLevel)
        {
            if (LLVM.CreateJITCompilerForModule(out LLVMExecutionEngineRef instance, m.Unwrap(), optLevel, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }
        
        public unsafe static ExecutionEngine CreateMCJITCompiler(Module module, int optionsSize)
        {
            LLVMMCJITCompilerOptions options;
            var size = new size_t(new IntPtr(optionsSize));
            LLVM.InitializeMCJITCompilerOptions(&options, size);
            if (LLVM.CreateMCJITCompilerForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), &options, size, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        internal ExecutionEngine(LLVMExecutionEngineRef ee)
        {
            this._instance = ee;
        }

        ~ExecutionEngine()
        {
            this.Dispose(false);
        }

        public void RunStaticConstructors() => LLVM.RunStaticConstructors(this.Unwrap());
        public void RunStaticDestructors() => LLVM.RunStaticDestructors(this.Unwrap());

        public GenericValue Run(Function f, params GenericValue[] args) => LLVM.RunFunction(this.Unwrap(), f.Unwrap(), args.Unwrap()).Wrap();
        public int RunAsMain(Function f, uint argC, string[] argV, string[] envP) => LLVM.RunFunctionAsMain(this.Unwrap(), f.Unwrap(), argC, argV, envP);
        public int RunAsMain(Function f, params string[] argV) => this.RunAsMain(f, (uint)argV.Length, argV, new string[0]); 
        public void FreeMachineCode(Function f) => LLVM.FreeMachineCodeForFunction(this.Unwrap(), f.Unwrap());

        public void AddModule(Module m) => LLVM.AddModule(this.Unwrap(), m.Unwrap());

        public Module RemoveModule(Module m)
        {
            LLVM.RemoveModule(this.Unwrap(), m.Unwrap(), out LLVMModuleRef outModRef, out IntPtr outError);
            return outModRef.Wrap();
        }

        public Function FindFunction(string name) => LLVM.FindFunction(this.Unwrap(), name, out LLVMValueRef outFnValueRef) ? null : outFnValueRef.WrapAs<Function>();

        public IntPtr RecompileAndRelinkFunction(Value fn) => LLVM.RecompileAndRelinkFunction(this.Unwrap(), fn.Unwrap());

        public TargetData TargetData => LLVM.GetExecutionEngineTargetData(this.Unwrap()).Wrap();
        public TargetMachine TargetMachine => LLVM.GetExecutionEngineTargetMachine(this.Unwrap()).Wrap();

        public void AddGlobalMapping(Value global, IntPtr addr) => LLVM.AddGlobalMapping(this.Unwrap(), global.Unwrap(), addr);

        public IntPtr GetPointerToGlobal(GlobalValue global) => LLVM.GetPointerToGlobal(this.Unwrap(), global.Unwrap());

        public ulong GetGlobalValueAddress(string name) => LLVM.GetGlobalValueAddress(this.Unwrap(), name);
        public ulong GetFunctionAddress(string name) => LLVM.GetFunctionAddress(this.Unwrap(), name);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposeExecutionEngine(this.Unwrap());
            }

            this._disposed = true;
        }

        public override int GetHashCode() => this._instance.GetHashCode();
        public override bool Equals(object obj) => this.Equals(obj as ExecutionEngine);
        public bool Equals(ExecutionEngine other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public static bool operator ==(ExecutionEngine op1, ExecutionEngine op2) => ReferenceEquals(op1, null) ? ReferenceEquals(op2, null) : op1.Equals(op2);
        public static bool operator !=(ExecutionEngine op1, ExecutionEngine op2) => !(op1 == op2);

    }
}