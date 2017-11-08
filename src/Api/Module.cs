namespace LLVMSharp.Api
{
    using System;
    using System.Runtime.InteropServices;
    using Utilities;
    using Values.Constants;
    using Values.Constants.GlobalValues.GlobalObjects;

    public sealed class Module : IEquatable<Module>, IDisposable, IDisposableWrapper<LLVMModuleRef>
    {
        LLVMModuleRef IWrapper<LLVMModuleRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMModuleRef>.MakeHandleOwner() => this._owner = true;

        public static Module Create(string moduleId) => LLVM.ModuleCreateWithName(moduleId).Wrap().MakeHandleOwner<Module, LLVMModuleRef>();
        public static Module Create(string moduleId, Context context) => LLVM.ModuleCreateWithNameInContext(moduleId, context.Unwrap()).Wrap().MakeHandleOwner<Module, LLVMModuleRef>();

        public static void LinkModules(Module destination, Module source) => LLVM.LinkModules2(destination.Unwrap(), source.Unwrap());

        private readonly LLVMModuleRef _instance;
        private bool _disposed;
        private bool _owner;

        internal Module(LLVMModuleRef m) => this._instance = m;
        ~Module() => this.Dispose(false);

        public string GetDataLayout() => LLVM.GetDataLayout(this.Unwrap());
        public void SetDataLayout(string value) => LLVM.SetDataLayout(this.Unwrap(), value);

        public Context Context => LLVM.GetModuleContext(this.Unwrap()).Wrap();

        public Module CloneModule() => LLVM.CloneModule(this.Unwrap()).Wrap();

        public void Dump() => LLVM.DumpModule(this.Unwrap());

        public bool PrintToFile(string filename, out IntPtr errorMessage) => LLVM.PrintModuleToFile(this.Unwrap(), filename, out errorMessage);

        public string PrintModuleToString()
        {
            var ptr = LLVM.PrintModuleToString(this.Unwrap());
            var retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal;
        }

        public void SetModuleInlineAsm(string asm) => LLVM.SetModuleInlineAsm(this.Unwrap(), asm);
        
        public GlobalVariable GetNamedGlobal(string name) => LLVM.GetNamedGlobal(this.Unwrap(), name).WrapAs<GlobalVariable>();
        public Type GetTypeByName(string name) => LLVM.GetTypeByName(this.Unwrap(), name).Wrap();
        public uint GetNamedMetadataNumOperands(string name) => LLVM.GetNamedMetadataNumOperands(this.Unwrap(), name);
        public Value[] GetNamedMetadataOperands(string name) => LLVM.GetNamedMetadataOperands(this.Unwrap(), name).Wrap<LLVMValueRef, Value>();
        public void AddNamedMetadataOperand(string name, Value val) => LLVM.AddNamedMetadataOperand(this.Unwrap(), name, val.Unwrap());
        public Function AddFunction(string name, Type functionTy) => LLVM.AddFunction(this.Unwrap(), name, functionTy.Unwrap()).WrapAs<Function>();
        public Function GetNamedFunction(string name) => LLVM.GetNamedFunction(this.Unwrap(), name).WrapAs<Function>();

        public Function GetFirstFunction() => LLVM.GetFirstFunction(this.Unwrap()).WrapAs<Function>();

        public Function GetLastFunction() => LLVM.GetLastFunction(this.Unwrap()).WrapAs<Function>();

        public GlobalValue AddGlobal(Type ty, string name) => LLVM.AddGlobal(this.Unwrap(), ty.Unwrap(), name).WrapAs<GlobalValue>();
        public GlobalValue AddGlobalInAddressSpace(Type ty, string name, uint addressSpace) => LLVM.AddGlobalInAddressSpace(this.Unwrap(), ty.Unwrap(), name, addressSpace).WrapAs<GlobalValue>();

        public GlobalValue GetNamedValue(string name) => LLVM.GetNamedGlobal(this.Unwrap(), name).WrapAs<GlobalValue>();

        public GlobalValue GetFirstGlobal() => LLVM.GetFirstGlobal(this.Unwrap()).WrapAs<GlobalValue>();
        public GlobalValue GetLastGlobal() => LLVM.GetLastGlobal(this.Unwrap()).WrapAs<GlobalValue>();

        public GlobalValue AddAlias(Type ty, Value aliasee, string name) => LLVM.AddAlias(this.Unwrap(), ty.Unwrap(), aliasee.Unwrap(), name).WrapAs<GlobalValue>();

        public uint GetMDKindID(string name) => LLVM.GetMDKindIDInContext(this.Context.Unwrap(), name, (uint)name.Length);

        public unsafe ExecutionEngine CreateMCJITCompilerForModule()
        {
            LLVMMCJITCompilerOptions options;
            var optionsSize = new size_t(new IntPtr(Marshal.SizeOf(typeof(LLVMMCJITCompilerOptions))));
            if (LLVM.CreateMCJITCompilerForModule(out LLVMExecutionEngineRef executionEngineRef, this.Unwrap(), &options, optionsSize, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return executionEngineRef.Wrap();
        }

        public ModuleProvider CreateModuleProviderForExistingModule() => LLVM.CreateModuleProviderForExistingModule(this.Unwrap()).Wrap();
        public PassManager CreateFunctionPassManagerForModule() => LLVM.CreateFunctionPassManagerForModule(this.Unwrap()).Wrap();
        public bool VerifyModule(LLVMVerifierFailureAction action, out IntPtr outMessage) => LLVM.VerifyModule(this.Unwrap(), action, out outMessage);

        public bool VerifyModule(LLVMVerifierFailureAction action, out string message)
        {
            var result = this.VerifyModule(action, out IntPtr messagePointer);
            message = Marshal.PtrToStringAnsi(messagePointer);
            return result;
        }

        public int WriteBitcodeToFile(string path) => LLVM.WriteBitcodeToFile(this.Unwrap(), path);
        public int WriteBitcodeToFD(int fd, int shouldClose, int unbuffered) => LLVM.WriteBitcodeToFD(this.Unwrap(), fd, shouldClose, unbuffered);
        public int WriteBitcodeToFileHandle(int handle) => LLVM.WriteBitcodeToFileHandle(this.Unwrap(), handle);
        public MemoryBuffer WriteBitcodeToMemoryBuffer() => LLVM.WriteBitcodeToMemoryBuffer(this.Unwrap()).Wrap();

        public bool Equals(Module other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public override bool Equals(object obj) => this.Equals(obj as Module);
        public static bool operator ==(Module op1, Module op2) => ReferenceEquals(op1, null) ? ReferenceEquals(op2, null) : op1.Equals(op2);
        public static bool operator !=(Module op1, Module op2) => !(op1 == op2);
        public override int GetHashCode() => this._instance.GetHashCode();

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
                LLVM.DisposeModule(this.Unwrap());
            }

            this._disposed = true;
        }

        public void SetTarget(string target) => LLVM.SetTarget(this.Unwrap(), target);
        public string GetTarget() => LLVM.GetTarget(this.Unwrap());
    }
}