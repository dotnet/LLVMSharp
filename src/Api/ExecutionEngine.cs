namespace LLVMSharp.API
{
    using LLVMSharp.API.Values.Constants;
    using LLVMSharp.API.Values.Constants.GlobalValues.GlobalObjects;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Utilities;

    public sealed class ExecutionEngine : IDisposable, IEquatable<ExecutionEngine>, IDisposableWrapper<LLVMExecutionEngineRef>
    {
        private static Dictionary<LLVMExecutionEngineRef, List<Module>> _engineModuleMap = new Dictionary<LLVMExecutionEngineRef, List<Module>>();

        LLVMExecutionEngineRef IWrapper<LLVMExecutionEngineRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMExecutionEngineRef>.MakeHandleOwner() => this._owner = true;

        private readonly LLVMExecutionEngineRef _instance;
        private bool _disposed;
        private bool _owner;

        private ExecutionEngine AssociateWithModule(Module m)
        {
            var instance = this.Unwrap();
            if (!_engineModuleMap.ContainsKey(instance))
            {
                _engineModuleMap[instance] = new List<Module>();
            }
            _engineModuleMap[instance].Add(m);
            return this;
        }

        private ExecutionEngine DisassosicateWithModule(Module m)
        {
            var instance = this.Unwrap();
            if(_engineModuleMap.ContainsKey(instance))
            {
                _engineModuleMap[instance].Remove(m);
            }
            return this;
        }

        private IEnumerable<Module> GetAssociatedModules()
        {
            var instance = this.Unwrap();
            if(_engineModuleMap.ContainsKey(instance))
            {
                return _engineModuleMap[instance].ToArray();
            }
            else
            {
                return new Module[0];
            }
        }

        public static ExecutionEngine Create(Module module)
        {
            if (LLVM.CreateExecutionEngineForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>().AssociateWithModule(module);
        }
        
        public static ExecutionEngine CreateInterpreter(Module module)
        {
            if (LLVM.CreateInterpreterForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>().AssociateWithModule(module);
        }

        public static ExecutionEngine CreateJITCompiler(Module m, uint optLevel)
        {
            if (LLVM.CreateJITCompilerForModule(out LLVMExecutionEngineRef instance, m.Unwrap(), optLevel, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>().AssociateWithModule(m);
        }

        public static ExecutionEngine CreateMCJITCompilerForModule(Module module) => CreateMCJITCompiler(module, new size_t(new IntPtr(Marshal.SizeOf(typeof(LLVMMCJITCompilerOptions)))));

        public unsafe static ExecutionEngine CreateMCJITCompiler(Module module, int optionsSize)
        {
            LLVMMCJITCompilerOptions options;
            var size = new size_t(new IntPtr(optionsSize));
            LLVM.InitializeMCJITCompilerOptions(&options, size);
            if (LLVM.CreateMCJITCompilerForModule(out LLVMExecutionEngineRef instance, module.Unwrap(), &options, size, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return instance.Wrap().MakeHandleOwner<ExecutionEngine, LLVMExecutionEngineRef>().AssociateWithModule(module);
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

        public void AddModule(Module m)
        {
            LLVM.AddModule(this.Unwrap(), m.Unwrap());
            this.AssociateWithModule(m);
        }

        public Module RemoveModule(Module m)
        {
            LLVM.RemoveModule(this.Unwrap(), m.Unwrap(), out LLVMModuleRef outModRef, out IntPtr outError);
            this.DisassosicateWithModule(m);
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

        public TDelegate GetDelegate<TDelegate>(Function function)
        {
            var functionPtr = this.GetPointerToGlobal(function);
            return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(functionPtr, typeof(TDelegate));
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
                foreach(var m in GetAssociatedModules())
                {
                    this.RemoveModule(m);
                }
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