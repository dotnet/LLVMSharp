namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class Module : IEquatable<Module>
    {
        public string DataLayout
        {
            get { return LLVM.GetDataLayout(this.ToModuleRef()); }
            set { LLVM.SetDataLayout(this.ToModuleRef(), value); }
        }

        public string Target
        {
            get { return LLVM.GetTarget(this.ToModuleRef()); }
            set { LLVM.SetTarget(this.ToModuleRef(), value); }
        }

        public LLVMContextRef ModuleContext
        {
            get { return LLVM.GetModuleContext(this.ToModuleRef()); }
        }

        internal readonly LLVMModuleRef Instance;

        public Module(string moduleId)
        {
            this.Instance = LLVM.ModuleCreateWithName(moduleId);
        }

        public Module(string moduleId, LLVMContextRef context)
        {
            this.Instance = LLVM.ModuleCreateWithNameInContext(moduleId, context);
        }

        internal Module(LLVMModuleRef module)
        {
            this.Instance = LLVM.CloneModule(module);
        }
        
        public Module Clone()
        {
            return new Module(this.ToModuleRef());
        }

        public void DisposeModule()
        {
            LLVM.DisposeModule(this.ToModuleRef());
        }

        public void DumpModule()
        {
            LLVM.DumpModule(this.ToModuleRef());
        }

        public bool PrintModuleToFile(string filename, out IntPtr errorMessage)
        {
            return LLVM.PrintModuleToFile(this.ToModuleRef(), filename, out errorMessage);
        }

        public string PrintModuleToString()
        {
            var ptr = LLVM.PrintModuleToString(this.ToModuleRef());
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal;
        }

        public void SetModuleInlineAsm(string asm)
        {
            LLVM.SetModuleInlineAsm(this.ToModuleRef(), asm);
        }

        public Type GetTypeByName(string name)
        {
            return new Type(LLVM.GetTypeByName(this.ToModuleRef(), name));
        }

        public uint GetNamedMetadataNumOperands(string @name)
        {
            return LLVM.GetNamedMetadataNumOperands(this.ToModuleRef(), @name);
        }

        public Value[] GetNamedMetadataOperands(string @name)
        {
            return Conversions.ToValues(LLVM.GetNamedMetadataOperands(this.ToModuleRef(), @name));
        }

        public void AddNamedMetadataOperand(string @name, Value val)
        {
            LLVM.AddNamedMetadataOperand(this.ToModuleRef(), @name, val.ToValueRef());
        }

        public Function AddFunction(string name, Type functionTy)
        {
            return new Function(LLVM.AddFunction(this.ToModuleRef(), name, functionTy.ToTypeRef()));
        }

        public Function GetNamedFunction(string name)
        {
            return new Function(LLVM.GetNamedFunction(this.ToModuleRef(), name));
        }

        public Function GetFirstFunction()
        {
            return new Function(LLVM.GetFirstFunction(this.ToModuleRef()));
        }

        public Function GetLastFunction()
        {
            return new Function(LLVM.GetLastFunction(this.ToModuleRef()));
        }

        public Value AddGlobal(Type ty, string name)
        {
            return new GlobalValue(LLVM.AddGlobal(this.ToModuleRef(), ty.ToTypeRef(), name));
        }

        public Value AddGlobalInAddressSpace(Type ty, string name, uint addressSpace)
        {
            return new GlobalValue(LLVM.AddGlobalInAddressSpace(this.ToModuleRef(), ty.ToTypeRef(), name, addressSpace));
        }

        public Value GetNamedGlobal(string name)
        {
            return new GlobalValue(LLVM.GetNamedGlobal(this.ToModuleRef(), name));
        }

        public Value GetFirstGlobal()
        {
            return new GlobalValue(LLVM.GetFirstGlobal(this.ToModuleRef()));
        }

        public Value GetLastGlobal()
        {
            return new GlobalValue(LLVM.GetLastGlobal(this.ToModuleRef()));
        }

        public Value AddAlias(Type ty, Value aliasee, string name)
        {
            return new GlobalValue(LLVM.AddAlias(this.ToModuleRef(), ty.ToTypeRef(), aliasee.ToValueRef(), name));
        }

        public bool CreateMCJITCompilerForModule(out ExecutionEngine executionEngine,
                                                 out LLVMMCJITCompilerOptions options,
                                                 out string message)
        {
            LLVMExecutionEngineRef executionEngineRef;
            IntPtr messagePtr;
            var optionsSize = Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions));
            var result = LLVM.CreateMCJITCompilerForModule(out executionEngineRef, this.ToModuleRef(), out options, optionsSize,
                                              out messagePtr);
            executionEngine = new ExecutionEngine(executionEngineRef);
            message = Marshal.PtrToStringAnsi(messagePtr);
            return result;
        }

        public LLVMModuleProviderRef CreateModuleProviderForExistingModule()
        {
            return LLVM.CreateModuleProviderForExistingModule(this.ToModuleRef());
        }

        public LLVMPassManagerRef CreateFunctionPassManagerForModule()
        {
            return LLVM.CreateFunctionPassManagerForModule(this.ToModuleRef());
        }

        public bool VerifyModule(LLVMVerifierFailureAction action, out IntPtr outMessage)
        {
            return LLVM.VerifyModule(this.ToModuleRef(), action, out outMessage);
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
            return LLVM.WriteBitcodeToFile(this.ToModuleRef(), path);
        }

        public int WriteBitcodeToFD(int fd, int shouldClose, int unbuffered)
        {
            return LLVM.WriteBitcodeToFD(this.ToModuleRef(), fd, shouldClose, unbuffered);
        }

        public int WriteBitcodeToFileHandle(int handle)
        {
            return LLVM.WriteBitcodeToFileHandle(this.ToModuleRef(), handle);
        }

        public LLVMMemoryBufferRef WriteBitcodeToMemoryBuffer()
        {
            return LLVM.WriteBitcodeToMemoryBuffer(this.ToModuleRef());
        }

        public bool LinkModules(Module src, uint unused, out IntPtr outMessage)
        {
            return LLVM.LinkModules(this.ToModuleRef(), src.ToModuleRef(), unused, out outMessage);
        }

        public bool Equals(Module other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.Instance == other.Instance;
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
            return this.Instance.GetHashCode();
        }

        public void SetTarget(string target)
        {
            LLVM.SetTarget(this.ToModuleRef(), target);
        }
    }
}