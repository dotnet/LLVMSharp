namespace LLVMSharp
{
    using System;

    public sealed class ExecutionEngine : IDisposable, IEquatable<ExecutionEngine>, IWrapper<LLVMExecutionEngineRef>
    {
        LLVMExecutionEngineRef IWrapper<LLVMExecutionEngineRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMExecutionEngineRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMExecutionEngineRef _instance;        
        private bool _disposed;
        private bool _owner;

        public static ExecutionEngine Create(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateExecutionEngineForModule(out instance, module.Unwrap(), out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine Create(ModuleProvider provider)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateExecutionEngine(out instance, provider.Unwrap(), out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateInterpreter(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateInterpreterForModule(out instance, module.Unwrap(), out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateInterpreter(ModuleProvider provider)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateInterpreter(out instance, provider.Unwrap(), out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateJITCompiler(Module m, uint optLevel)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateJITCompilerForModule(out instance, m.Unwrap(), optLevel, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateJITCompiler(ModuleProvider provider, uint optLevel)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateJITCompiler(out instance, provider.Unwrap(), optLevel, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>();
        }

        public static ExecutionEngine CreateMCJITCompiler(Module module, int optionsSize)
        {
            LLVMMCJITCompilerOptions options;
            LLVM.InitializeMCJITCompilerOptions(out options, optionsSize);

            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateMCJITCompilerForModule(out instance, module.Unwrap(), out options, optionsSize, out error).Failed())
            {
                ErrorUtilities.Throw(error);
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

        public void RunStaticConstructors()
        {
            LLVM.RunStaticConstructors(this.Unwrap());
        }

        public void RunStaticDestructors()
        {
            LLVM.RunStaticDestructors(this.Unwrap());
        }

        public int RunFunctionAsMain(Value f, uint argC, string[] argV, string[] envP)
        {
            return LLVM.RunFunctionAsMain(this.Unwrap(), f.Unwrap(), argC, argV, envP);
        }

        public GenericValue RunFunction(Value f, LLVMGenericValueRef[] args)
        {
            return LLVM.RunFunction(this.Unwrap(), f.Unwrap(), args).Wrap();
        }

        public void FreeMachineCodeForFunction(Value f)
        {
            LLVM.FreeMachineCodeForFunction(this.Unwrap(), f.Unwrap());
        }

        public void AddModule(Module m)
        {
            LLVM.AddModule(this.Unwrap(), m.Unwrap());
        }

        public void AddModuleProvider(ModuleProvider mp)
        {
            LLVM.AddModuleProvider(this.Unwrap(), mp.Unwrap());
        }

        public bool RemoveModule(Module m, out Module outMod, out IntPtr outError)
        {
            LLVMModuleRef outModRef;
            var result = LLVM.RemoveModule(this.Unwrap(), m.Unwrap(), out outModRef, out outError);
            outMod = outModRef.Wrap();
            return result;
        }

        public bool RemoveModuleProvider(ModuleProvider mp, out Module outMod, out IntPtr outError)
        {
            LLVMModuleRef outModRef;
            var result = LLVM.RemoveModuleProvider(this.Unwrap(), mp.Unwrap(), out outModRef, out outError);
            outMod = outModRef.Wrap();
            return result;
        }

        public bool FindFunction(string name, out Value outFn)
        {
            LLVMValueRef outFnValueRef;
            var result = LLVM.FindFunction(this.Unwrap(), name, out outFnValueRef);
            outFn = outFnValueRef.Wrap<Value>();
            return result;
        }

        public IntPtr RecompileAndRelinkFunction(Value fn)
        {
            return LLVM.RecompileAndRelinkFunction(this.Unwrap(), fn.Unwrap());
        }

        public TargetData TargetData
        {
            get { return LLVM.GetExecutionEngineTargetData(this.Unwrap()).Wrap(); }
        }

        public TargetMachine TargetMachine
        {
            get { return LLVM.GetExecutionEngineTargetMachine(this.Unwrap()).Wrap(); }
        }

        public void AddGlobalMapping(Value global, IntPtr addr)
        {
            LLVM.AddGlobalMapping(this.Unwrap(), global.Unwrap(), addr);
        }

        public IntPtr GetPointerToGlobal(Value global)
        {
            return LLVM.GetPointerToGlobal(this.Unwrap(), global.Unwrap());
        }

        public int GetGlobalValueAddress(string name)
        {
            return LLVM.GetGlobalValueAddress(this.Unwrap(), name);
        }

        public int GetFunctionAddress(string name)
        {
            return LLVM.GetFunctionAddress(this.Unwrap(), name);
        }

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

        public bool Equals(ExecutionEngine other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this._instance == other._instance;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ExecutionEngine);
        }

        public static bool operator ==(ExecutionEngine op1, ExecutionEngine op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(ExecutionEngine op1, ExecutionEngine op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
        }
    }
}