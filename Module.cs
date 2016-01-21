namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class Module : IEquatable<Module>, IDisposable, IWrapper<LLVMModuleRef>
    {
        public static Module Create(string moduleId)
        {
            return LLVM.ModuleCreateWithName(moduleId).Wrap().MakeHandleOwner<Module, LLVMModuleRef>();
        }

        public static Module Create(string moduleId, Context context)
        {
            return
                LLVM.ModuleCreateWithNameInContext(moduleId, context.Unwrap())
                    .Wrap()
                    .MakeHandleOwner<Module, LLVMModuleRef>();
        }

        LLVMModuleRef IWrapper<LLVMModuleRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMModuleRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMModuleRef _instance;
        private bool _disposed;
        private bool _owner;

        internal Module(LLVMModuleRef m)
        {
            this._instance = m;
        }

        ~Module()
        {
            this.Dispose(false);
        }

        public string DataLayout
        {
            get { return LLVM.GetDataLayout(this.Unwrap()); }
            set { LLVM.SetDataLayout(this.Unwrap(), value); }
        }

        public string Target
        {
            get { return LLVM.GetTarget(this.Unwrap()); }
            set { LLVM.SetTarget(this.Unwrap(), value); }
        }

        public Context Context
        {
            get { return LLVM.GetModuleContext(this.Unwrap()).Wrap(); }
        }

        public Module CloneModule()
        {
            return LLVM.CloneModule(this.Unwrap()).Wrap();
        }

        public void DumpModule()
        {
            LLVM.DumpModule(this.Unwrap());
        }

        public bool PrintModuleToFile(string filename, out IntPtr errorMessage)
        {
            return LLVM.PrintModuleToFile(this.Unwrap(), filename, out errorMessage);
        }

        public string PrintModuleToString()
        {
            var ptr = LLVM.PrintModuleToString(this.Unwrap());
            var retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal;
        }

        public void SetModuleInlineAsm(string asm)
        {
            LLVM.SetModuleInlineAsm(this.Unwrap(), asm);
        }

        public GlobalVariable GetGlobalVariable(string name, bool allowLocal)
        {
            var result = GetNamedValue(name) as GlobalVariable;
            if (result != null)
            {
                if (allowLocal || !result.ExternalLinkage.IsLocalLinkage())
                {
                    return result;
                }
            }
            return null;
        }

        public GlobalVariable GetNamedGlobal(string name)
        {
            return LLVM.GetNamedGlobal(this.Unwrap(), name).WrapAs<GlobalVariable>();
        }

        public GlobalVariable GetOrInsertGlobal(string name, Type ty)
        {
            var gv = GetNamedGlobal(name);
            if (gv == null)
            {
                return LLVM.AddGlobal(this.Unwrap(), ty.Unwrap(), name).WrapAs<GlobalVariable>();
            }

            var gvType = gv.Type;
            var ptrType = ty.GetPointerType(gvType.AddressSpace);

            if (gvType != ptrType)
            {
                return LLVM.ConstBitCast(gv.Unwrap(), ptrType.Unwrap()).WrapAs<GlobalVariable>();
            }

            return gv;
        }

        public Type GetTypeByName(string name)
        {
            return LLVM.GetTypeByName(this.Unwrap(), name).Wrap();
        }

        public uint GetNamedMetadataNumOperands(string name)
        {
            return LLVM.GetNamedMetadataNumOperands(this.Unwrap(), name);
        }

        public Value[] GetNamedMetadataOperands(string name)
        {
            return LLVM.GetNamedMetadataOperands(this.Unwrap(), name).Wrap<LLVMValueRef, Value>();
        }

        public void AddNamedMetadataOperand(string name, Value val)
        {
            LLVM.AddNamedMetadataOperand(this.Unwrap(), name, val.Unwrap());
        }

        public Function AddFunction(string name, Type functionTy)
        {
            return LLVM.AddFunction(this.Unwrap(), name, functionTy.Unwrap()).WrapAs<Function>();
        }

        public Function GetNamedFunction(string name)
        {
            return LLVM.GetNamedFunction(this.Unwrap(), name).WrapAs<Function>();
        }

        public Function GetFirstFunction()
        {
            return LLVM.GetFirstFunction(this.Unwrap()).WrapAs<Function>();
        }

        public Function GetLastFunction()
        {
            return LLVM.GetLastFunction(this.Unwrap()).WrapAs<Function>();
        }

        public GlobalValue AddGlobal(Type ty, string name)
        {
            return LLVM.AddGlobal(this.Unwrap(), ty.Unwrap(), name).WrapAs<GlobalValue>();
        }

        public GlobalValue AddGlobalInAddressSpace(Type ty, string name, uint addressSpace)
        {
            return LLVM.AddGlobalInAddressSpace(this.Unwrap(), ty.Unwrap(), name, addressSpace).WrapAs<GlobalValue>();
        }

        public GlobalValue GetNamedValue(string name)
        {
            return LLVM.GetNamedGlobal(this.Unwrap(), name).WrapAs<GlobalValue>();
        }

        public GlobalValue GetFirstGlobal()
        {
            return LLVM.GetFirstGlobal(this.Unwrap()).WrapAs<GlobalValue>();
        }

        public GlobalValue GetLastGlobal()
        {
            return LLVM.GetLastGlobal(this.Unwrap()).WrapAs<GlobalValue>();
        }

        public GlobalValue AddAlias(Type ty, Value aliasee, string name)
        {
            return LLVM.AddAlias(this.Unwrap(), ty.Unwrap(), aliasee.Unwrap(), name).WrapAs<GlobalValue>();
        }

        public uint GetMDKindID(string name)
        {
            return LLVM.GetMDKindIDInContext(Context.Unwrap(), name, (uint) name.Length);
        }

        public Constant GetOrInsertFunction(string name, FunctionType t)
        {
            var f = GetNamedFunction(name);
            if (f == null)
            {
                var @new = Function.Create(t, LLVMLinkage.LLVMExternalLinkage, name, this);
                return @new;
            }

            if (f.FunctionType != t)
            {
                return LLVM.ConstBitCast(f.Unwrap(), t.Unwrap()).WrapAs<Constant>();
            }

            return f;
        }

        public ExecutionEngine CreateMCJITCompilerForModule()
        {
            LLVMExecutionEngineRef executionEngineRef;
            LLVMMCJITCompilerOptions options;
            IntPtr error;
            var optionsSize = Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions));
            if (LLVM.CreateMCJITCompilerForModule(out executionEngineRef, this.Unwrap(), out options, optionsSize,
                                                  out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return executionEngineRef.Wrap();
        }

        public ModuleProvider CreateModuleProviderForExistingModule()
        {
            return LLVM.CreateModuleProviderForExistingModule(this.Unwrap()).Wrap();
        }

        public PassManager CreateFunctionPassManagerForModule()
        {
            return LLVM.CreateFunctionPassManagerForModule(this.Unwrap()).Wrap();
        }

        public bool VerifyModule(LLVMVerifierFailureAction action, out IntPtr outMessage)
        {
            return LLVM.VerifyModule(this.Unwrap(), action, out outMessage);
        }

        public bool VerifyModule(LLVMVerifierFailureAction action, out string message)
        {
            IntPtr messagePointer;
            var result = VerifyModule(action, out messagePointer);
            message = Marshal.PtrToStringAnsi(messagePointer);
            return result;
        }

        public int WriteBitcodeToFile(string path)
        {
            return LLVM.WriteBitcodeToFile(this.Unwrap(), path);
        }

        public int WriteBitcodeToFD(int fd, int shouldClose, int unbuffered)
        {
            return LLVM.WriteBitcodeToFD(this.Unwrap(), fd, shouldClose, unbuffered);
        }

        public int WriteBitcodeToFileHandle(int handle)
        {
            return LLVM.WriteBitcodeToFileHandle(this.Unwrap(), handle);
        }

        public MemoryBuffer WriteBitcodeToMemoryBuffer()
        {
            return LLVM.WriteBitcodeToMemoryBuffer(this.Unwrap()).Wrap();
        }
        
        public bool Equals(Module other)
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
            return this.Equals(obj as Module);
        }

        public static bool operator ==(Module op1, Module op2)
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

        public static bool operator !=(Module op1, Module op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
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
                LLVM.DisposeModule(this.Unwrap());
            }

            this._disposed = true;
        }

        public void SetTarget(string target)
        {
            LLVM.SetTarget(this.Unwrap(), target);
        }

        public static void LinkModules(Module destination, Module source, uint unused)
        {
            IntPtr error;
            if (LLVM.LinkModules(destination.Unwrap(), source.Unwrap(), unused, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }
        }
    }
}