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

        public bool PrintModuleToFile(string @Filename, out IntPtr @ErrorMessage)
        {
            return LLVM.PrintModuleToFile(this.instance, @Filename, out @ErrorMessage);
        }

        public string PrintModuleToString()
        {
            var ptr = LLVM.PrintModuleToString(this.instance);
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal;
        }

        public void SetModuleInlineAsm(string @Asm)
        {
            LLVM.SetModuleInlineAsm(this.instance, @Asm);
        }

        public Type GetTypeByName(string @Name)
        {
            return new Type(LLVM.GetTypeByName(this.instance, @Name));
        }

        public uint GetNamedMetadataNumOperands(string @name)
        {
            return LLVM.GetNamedMetadataNumOperands(this.instance, @name);
        }

        public Value[] GetNamedMetadataOperands(string @name)
        {
            return Common.ToValues(LLVM.GetNamedMetadataOperands(this.instance, @name));
        }

        public void AddNamedMetadataOperand(string @name, Value @Val)
        {
            LLVM.AddNamedMetadataOperand(this.instance, @name, @Val.ToValueRef());
        }

        public Function AddFunction(string @Name, Type @FunctionTy)
        {
            return new Function(LLVM.AddFunction(this.instance, @Name, @FunctionTy.ToTypeRef()));
        }

        public Function GetNamedFunction(string @Name)
        {
            return new Function(LLVM.GetNamedFunction(this.instance, @Name));
        }

        public Function GetFirstFunction()
        {
            return new Function(LLVM.GetFirstFunction(this.instance));
        }

        public Function GetLastFunction()
        {
            return new Function(LLVM.GetLastFunction(this.instance));
        }

        public Value AddGlobal(Type @Ty, string @Name)
        {
            return new GlobalValue(LLVM.AddGlobal(this.instance, @Ty.ToTypeRef(), @Name));
        }

        public Value AddGlobalInAddressSpace(Type @Ty, string @Name, uint @AddressSpace)
        {
            return new GlobalValue(LLVM.AddGlobalInAddressSpace(this.instance, @Ty.ToTypeRef(), @Name, @AddressSpace));
        }

        public Value GetNamedGlobal(string @Name)
        {
            return new GlobalValue(LLVM.GetNamedGlobal(this.instance, @Name));
        }

        public Value GetFirstGlobal()
        {
            return new GlobalValue(LLVM.GetFirstGlobal(this.instance));
        }

        public Value GetLastGlobal()
        {
            return new GlobalValue(LLVM.GetLastGlobal(this.instance));
        }

        public Value AddAlias(Type @Ty, Value @Aliasee, string @Name)
        {
            return new GlobalValue(LLVM.AddAlias(this.instance, @Ty.ToTypeRef(), @Aliasee.ToValueRef(), @Name));
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

        public bool VerifyModule(LLVMVerifierFailureAction @Action, out IntPtr @OutMessage)
        {
            return LLVM.VerifyModule(this.instance, @Action, out @OutMessage);
        }

        public bool VerifyModule(LLVMVerifierFailureAction action, out string message)
        {
            IntPtr messagePointer;
            var result = VerifyModule(action, out messagePointer);
            message = Marshal.PtrToStringAnsi(messagePointer);
            return result;
        }

        public int WriteBitcodeToFile(string @Path)
        {
            return LLVM.WriteBitcodeToFile(this.instance, @Path);
        }

        public int WriteBitcodeToFD(int @FD, int @ShouldClose, int @Unbuffered)
        {
            return LLVM.WriteBitcodeToFD(this.instance, @FD, @ShouldClose, @Unbuffered);
        }

        public int WriteBitcodeToFileHandle(int @Handle)
        {
            return LLVM.WriteBitcodeToFileHandle(this.instance, @Handle);
        }

        public LLVMMemoryBufferRef WriteBitcodeToMemoryBuffer()
        {
            return LLVM.WriteBitcodeToMemoryBuffer(this.instance);
        }

        public bool LinkModules(Module @Src, uint @Unused, out IntPtr @OutMessage)
        {
            return LLVM.LinkModules(this.instance, @Src.ToModuleRef(), @Unused, out @OutMessage);
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