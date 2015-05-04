namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class ExecutionEngine : IDisposable, IEquatable<ExecutionEngine>
    {
        private readonly LLVMExecutionEngineRef instance;
        
        private bool disposed;

        public static ExecutionEngine Create(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (!LLVM.CreateExecutionEngineForModule(out instance, module.instance, out error))
            {
                ThrowError(error);
            }

            return new ExecutionEngine(instance);
        }

        public static ExecutionEngine CreateInterpreter(Module module)
        {
            IntPtr error;
            LLVMExecutionEngineRef instance;
            if (LLVM.CreateInterpreterForModule(out instance, module.instance, out error))
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
            if (LLVM.CreateMCJITCompilerForModule(out instance, module.instance, out options, optionsSize, out error))
            {
                ThrowError(error);
            }

            return new ExecutionEngine(instance);
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
            LLVM.RunStaticConstructors(this.instance);
        }

        public void RunStaticDestructors()
        {
            LLVM.RunStaticDestructors(this.instance);
        }

        public int RunFunctionAsMain(LLVMValueRef @F, uint @ArgC, string[] @ArgV, string[] @EnvP)
        {
            return LLVM.RunFunctionAsMain(this.instance, @F, @ArgC, @ArgV, @EnvP);
        }

        public LLVMGenericValueRef RunFunction(LLVMValueRef @F, LLVMGenericValueRef[] @Args)
        {
            return LLVM.RunFunction(this.instance, @F, @Args);
        }

        public void FreeMachineCodeForFunction(LLVMValueRef @F)
        {
            LLVM.FreeMachineCodeForFunction(this.instance, @F);
        }

        public void AddModule(LLVMModuleRef @M)
        {
            LLVM.AddModule(this.instance, @M);
        }

        public void AddModuleProvider(LLVMModuleProviderRef @MP)
        {
            LLVM.AddModuleProvider(this.instance, @MP);
        }

        public LLVMBool RemoveModule(LLVMModuleRef @M, out LLVMModuleRef @OutMod, out IntPtr @OutError)
        {
            return LLVM.RemoveModule(this.instance, @M, out @OutMod, out @OutError);
        }

        public LLVMBool RemoveModuleProvider(LLVMModuleProviderRef @MP, out LLVMModuleRef @OutMod, out IntPtr @OutError)
        {
            return LLVM.RemoveModuleProvider(this.instance, @MP, out @OutMod, out @OutError);
        }

        public LLVMBool FindFunction(string @Name, out LLVMValueRef @OutFn)
        {
            return LLVM.FindFunction(this.instance, @Name, out @OutFn);
        }

        public IntPtr RecompileAndRelinkFunction(LLVMValueRef @Fn)
        {
            return LLVM.RecompileAndRelinkFunction(this.instance, @Fn);
        }

        public LLVMTargetDataRef GetExecutionEngineTargetData()
        {
            return LLVM.GetExecutionEngineTargetData(this.instance);
        }

        public LLVMTargetMachineRef GetExecutionEngineTargetMachine()
        {
            return LLVM.GetExecutionEngineTargetMachine(this.instance);
        }

        public void AddGlobalMapping(LLVMValueRef @Global, IntPtr @Addr)
        {
            LLVM.AddGlobalMapping(this.instance, @Global, @Addr);
        }

        public IntPtr GetPointerToGlobal(LLVMValueRef @Global)
        {
            return LLVM.GetPointerToGlobal(this.instance, @Global);
        }

        public int GetGlobalValueAddress(string @Name)
        {
            return LLVM.GetGlobalValueAddress(this.instance, @Name);
        }

        public int GetFunctionAddress(string @Name)
        {
            return LLVM.GetFunctionAddress(this.instance, @Name);
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