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

        public int RunFunctionAsMain(LLVMValueRef f, uint argC, string[] argV, string[] envP)
        {
            return LLVM.RunFunctionAsMain(this.instance, f, argC, argV, envP);
        }

        public LLVMGenericValueRef RunFunction(LLVMValueRef f, LLVMGenericValueRef[] args)
        {
            return LLVM.RunFunction(this.instance, f, args);
        }

        public void FreeMachineCodeForFunction(LLVMValueRef f)
        {
            LLVM.FreeMachineCodeForFunction(this.instance, f);
        }

        public void AddModule(LLVMModuleRef m)
        {
            LLVM.AddModule(this.instance, m);
        }

        public void AddModuleProvider(LLVMModuleProviderRef mp)
        {
            LLVM.AddModuleProvider(this.instance, mp);
        }

        public LLVMBool RemoveModule(LLVMModuleRef m, out LLVMModuleRef outMod, out IntPtr outError)
        {
            return LLVM.RemoveModule(this.instance, m, out outMod, out outError);
        }

        public LLVMBool RemoveModuleProvider(LLVMModuleProviderRef mp, out LLVMModuleRef outMod, out IntPtr outError)
        {
            return LLVM.RemoveModuleProvider(this.instance, mp, out outMod, out outError);
        }

        public LLVMBool FindFunction(string name, out LLVMValueRef outFn)
        {
            return LLVM.FindFunction(this.instance, name, out outFn);
        }

        public IntPtr RecompileAndRelinkFunction(LLVMValueRef fn)
        {
            return LLVM.RecompileAndRelinkFunction(this.instance, fn);
        }

        public LLVMTargetDataRef GetExecutionEngineTargetData()
        {
            return LLVM.GetExecutionEngineTargetData(this.instance);
        }

        public LLVMTargetMachineRef GetExecutionEngineTargetMachine()
        {
            return LLVM.GetExecutionEngineTargetMachine(this.instance);
        }

        public void AddGlobalMapping(LLVMValueRef @Global, IntPtr addr)
        {
            LLVM.AddGlobalMapping(this.instance, @Global, addr);
        }

        public IntPtr GetPointerToGlobal(Value @Global)
        {
            return LLVM.GetPointerToGlobal(this.instance, @Global.ToValueRef());
        }

        public int GetGlobalValueAddress(string name)
        {
            return LLVM.GetGlobalValueAddress(this.instance, name);
        }

        public int GetFunctionAddress(string name)
        {
            return LLVM.GetFunctionAddress(this.instance, name);
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