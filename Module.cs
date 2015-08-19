namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class Module : IEquatable<Module>
    {
        public string DataLayout
        {
            get { return LLVM.GetDataLayout(this.instance); }
            set { LLVM.SetDataLayout(this.instance, value); }
        }

        public string Target
        {
            get { return LLVM.GetTarget(this.instance); }
            set { LLVM.SetTarget(this.instance, value); }
        }

        public LLVMContextRef ModuleContext
        {
            get { return LLVM.GetModuleContext(this.instance); }
        }

        internal readonly LLVMModuleRef instance;

        public Module(string moduleId)
        {
            this.instance = LLVM.ModuleCreateWithName(moduleId);
        }

        public Module(string moduleId, LLVMContextRef context)
        {
            this.instance = LLVM.ModuleCreateWithNameInContext(moduleId, context);
        }

        internal Module(LLVMModuleRef module)
        {
            this.instance = LLVM.CloneModule(module);
        }
        
        public Module Clone()
        {
            return new Module(this.instance);
        }

        public void DisposeModule()
        {
            LLVM.DisposeModule(this.instance);
        }

        public void DumpModule()
        {
            LLVM.DumpModule(this.instance);
        }

        public bool PrintModuleToFile(string filename, out IntPtr errorMessage)
        {
            return LLVM.PrintModuleToFile(this.instance, filename, out errorMessage);
        }

        public string PrintModuleToString()
        {
            var ptr = LLVM.PrintModuleToString(this.instance);
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal;
        }

        public void SetModuleInlineAsm(string asm)
        {
            LLVM.SetModuleInlineAsm(this.instance, asm);
        }

        public Type GetTypeByName(string name)
        {
            return new Type(LLVM.GetTypeByName(this.instance, name));
        }

        public uint GetNamedMetadataNumOperands(string @name)
        {
            return LLVM.GetNamedMetadataNumOperands(this.instance, @name);
        }

        public Value[] GetNamedMetadataOperands(string @name)
        {
            return Common.ToValues(LLVM.GetNamedMetadataOperands(this.instance, @name));
        }

        public void AddNamedMetadataOperand(string @name, Value val)
        {
            LLVM.AddNamedMetadataOperand(this.instance, @name, val.ToValueRef());
        }

        public Function AddFunction(string name, Type functionTy)
        {
            return new Function(LLVM.AddFunction(this.instance, name, functionTy.ToTypeRef()));
        }

        public Function GetNamedFunction(string name)
        {
            return new Function(LLVM.GetNamedFunction(this.instance, name));
        }

        public Function GetFirstFunction()
        {
            return new Function(LLVM.GetFirstFunction(this.instance));
        }

        public Function GetLastFunction()
        {
            return new Function(LLVM.GetLastFunction(this.instance));
        }

        public Value AddGlobal(Type ty, string name)
        {
            return new GlobalValue(LLVM.AddGlobal(this.instance, ty.ToTypeRef(), name));
        }

        public Value AddGlobalInAddressSpace(Type ty, string name, uint addressSpace)
        {
            return new GlobalValue(LLVM.AddGlobalInAddressSpace(this.instance, ty.ToTypeRef(), name, addressSpace));
        }

        public Value GetNamedGlobal(string name)
        {
            return new GlobalValue(LLVM.GetNamedGlobal(this.instance, name));
        }

        public Value GetFirstGlobal()
        {
            return new GlobalValue(LLVM.GetFirstGlobal(this.instance));
        }

        public Value GetLastGlobal()
        {
            return new GlobalValue(LLVM.GetLastGlobal(this.instance));
        }

        public Value AddAlias(Type ty, Value aliasee, string name)
        {
            return new GlobalValue(LLVM.AddAlias(this.instance, ty.ToTypeRef(), aliasee.ToValueRef(), name));
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
            return LLVM.CreateModuleProviderForExistingModule(this.instance);
        }

        public LLVMPassManagerRef CreateFunctionPassManagerForModule()
        {
            return LLVM.CreateFunctionPassManagerForModule(this.instance);
        }

        public bool VerifyModule(LLVMVerifierFailureAction action, out IntPtr outMessage)
        {
            return LLVM.VerifyModule(this.instance, action, out outMessage);
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
            return LLVM.WriteBitcodeToFile(this.instance, path);
        }

        public int WriteBitcodeToFD(int fd, int shouldClose, int unbuffered)
        {
            return LLVM.WriteBitcodeToFD(this.instance, fd, shouldClose, unbuffered);
        }

        public int WriteBitcodeToFileHandle(int handle)
        {
            return LLVM.WriteBitcodeToFileHandle(this.instance, handle);
        }

        public LLVMMemoryBufferRef WriteBitcodeToMemoryBuffer()
        {
            return LLVM.WriteBitcodeToMemoryBuffer(this.instance);
        }

        public bool LinkModules(Module src, uint unused, out IntPtr outMessage)
        {
            return LLVM.LinkModules(this.instance, src.ToModuleRef(), unused, out outMessage);
        }

        public bool Equals(Module other)
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
            return this.instance.GetHashCode();
        }

        public void SetTarget(string target)
        {
            LLVM.SetTarget(this.instance, target);
        }
    }
}