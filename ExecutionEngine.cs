namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class ExecutionEngine : IDisposable, IEquatable<ExecutionEngine>
    {
        internal readonly LLVMExecutionEngineRef instance;
        
        private bool disposed;

        public static ExecutionEngine Create(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (!LLVM.CreateExecutionEngineForModule(out instance, module.Instance, out error))
            {
                ThrowError(error);
            }

            return new ExecutionEngine(instance);
        }

        public static ExecutionEngine CreateInterpreter(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateInterpreterForModule(out instance, module.ToModuleRef(), out error))
            {
                ThrowError(error);
            }

            return new ExecutionEngine(instance);
        }

        public static ExecutionEngine CreateMCJITCompiler(Module module, LLVMMCJITCompilerOptions options, int optionsSize)
        {
            LLVM.InitializeMCJITCompilerOptions(out options, optionsSize);

            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateMCJITCompilerForModule(out instance, module.ToModuleRef(), out options, optionsSize, out error))
            {
                ThrowError(error);
            }

            return instance.ToExecutionEngine();
        }
        
        internal ExecutionEngine(LLVMExecutionEngineRef ee)
        {
            this.instance = ee;
        }

        ~ExecutionEngine()
        {
            this.Dispose(false);
        }

        public void RunStaticConstructors()
        {
            LLVM.RunStaticConstructors(this.ToExecutionEngineRef());
        }

        public void RunStaticDestructors()
        {
            LLVM.RunStaticDestructors(this.ToExecutionEngineRef());
        }

        public int RunFunctionAsMain(Value f, uint argC, string[] argV, string[] envP)
        {
            return LLVM.RunFunctionAsMain(this.ToExecutionEngineRef(), f.ToValueRef(), argC, argV, envP);
        }

        public LLVMGenericValueRef RunFunction(Value f, LLVMGenericValueRef[] args)
        {
            return LLVM.RunFunction(this.ToExecutionEngineRef(), f.ToValueRef(), args);
        }

        public void FreeMachineCodeForFunction(Value f)
        {
            LLVM.FreeMachineCodeForFunction(this.ToExecutionEngineRef(), f.ToValueRef());
        }

        public void AddModule(Module m)
        {
            LLVM.AddModule(this.ToExecutionEngineRef(), m.ToModuleRef());
        }

        public void AddModuleProvider(LLVMModuleProviderRef mp)
        {
            LLVM.AddModuleProvider(this.ToExecutionEngineRef(), mp);
        }

        public bool RemoveModule(Module m, out Module outMod, out IntPtr outError)
        {
            LLVMModuleRef outModRef;
            var result = LLVM.RemoveModule(this.ToExecutionEngineRef(), m.ToModuleRef(), out outModRef, out outError);
            outMod = outModRef.ToModule();
            return result;
        }

        public bool RemoveModuleProvider(LLVMModuleProviderRef mp, out Module outMod, out IntPtr outError)
        {
            LLVMModuleRef outModRef;
            var result = LLVM.RemoveModuleProvider(this.ToExecutionEngineRef(), mp, out outModRef, out outError);
            outMod = outModRef.ToModule();
            return result;
        }

        public bool FindFunction(string name, out Value outFn)
        {
            LLVMValueRef outFnValueRef;
            var result = LLVM.FindFunction(this.ToExecutionEngineRef(), name, out outFnValueRef);
            outFn = outFnValueRef.ToValue();
            return result;
        }

        public IntPtr RecompileAndRelinkFunction(Value fn)
        {
            return LLVM.RecompileAndRelinkFunction(this.ToExecutionEngineRef(), fn.ToValueRef());
        }

        public LLVMTargetDataRef GetExecutionEngineTargetData()
        {
            return LLVM.GetExecutionEngineTargetData(this.ToExecutionEngineRef());
        }

        public LLVMTargetMachineRef GetExecutionEngineTargetMachine()
        {
            return LLVM.GetExecutionEngineTargetMachine(this.ToExecutionEngineRef());
        }

        public void AddGlobalMapping(Value global, IntPtr addr)
        {
            LLVM.AddGlobalMapping(this.ToExecutionEngineRef(), global.ToValueRef(), addr);
        }

        public IntPtr GetPointerToGlobal(Value global)
        {
            return LLVM.GetPointerToGlobal(this.ToExecutionEngineRef(), global.ToValueRef());
        }

        public int GetGlobalValueAddress(string name)
        {
            return LLVM.GetGlobalValueAddress(this.ToExecutionEngineRef(), name);
        }

        public int GetFunctionAddress(string name)
        {
            return LLVM.GetFunctionAddress(this.ToExecutionEngineRef(), name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            LLVM.DisposeExecutionEngine(this.instance);

            this.disposed = true;
        }

        private static void ThrowError(IntPtr error)
        {
            string errormessage = Marshal.PtrToStringAnsi(error);
            LLVM.DisposeMessage(error);
            throw new Exception(errormessage);
        }

        public bool Equals(ExecutionEngine other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.instance == other.instance;
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
            return this.instance.GetHashCode();
        }
    }
}