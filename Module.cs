namespace LLVMSharp
{
    using System;

    public sealed class Module
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

        public IntPtr PrintModuleToString()
        {
            return LLVM.PrintModuleToString(this.instance);
        }

        public void SetModuleInlineAsm(string @Asm)
        {
            LLVM.SetModuleInlineAsm(this.instance, @Asm);
        }

        public Type GetTypeByName(string @Name)
        {
            return LLVM.GetTypeByName(this.instance, @Name);
        }

        public uint GetNamedMetadataNumOperands(string @name)
        {
            return LLVM.GetNamedMetadataNumOperands(this.instance, @name);
        }

        public Value[] GetNamedMetadataOperands(string @name)
        {
            return Value.FromArray(LLVM.GetNamedMetadataOperands(this.instance, @name));
        }

        public void AddNamedMetadataOperand(string @name, Value @Val)
        {
            LLVM.AddNamedMetadataOperand(this.instance, @name, @Val);
        }

        public Value AddFunction(string @Name, Type @FunctionTy)
        {
            return LLVM.AddFunction(this.instance, @Name, @FunctionTy);
        }

        public Value GetNamedFunction(string @Name)
        {
            return LLVM.GetNamedFunction(this.instance, @Name);
        }

        public Value GetFirstFunction()
        {
            return LLVM.GetFirstFunction(this.instance);
        }

        public Value GetLastFunction()
        {
            return LLVM.GetLastFunction(this.instance);
        }

        public Value AddGlobal(Type @Ty, string @Name)
        {
            return LLVM.AddGlobal(this.instance, @Ty, @Name);
        }

        public Value AddGlobalInAddressSpace(Type @Ty, string @Name, uint @AddressSpace)
        {
            return LLVM.AddGlobalInAddressSpace(this.instance, @Ty, @Name, @AddressSpace);
        }

        public Value GetNamedGlobal(string @Name)
        {
            return LLVM.GetNamedGlobal(this.instance, @Name);
        }

        public Value GetFirstGlobal()
        {
            return LLVM.GetFirstGlobal(this.instance);
        }

        public Value GetLastGlobal()
        {
            return LLVM.GetLastGlobal(this.instance);
        }

        public Value AddAlias(Type @Ty, Value @Aliasee, string @Name)
        {
            return LLVM.AddAlias(this.instance, @Ty, @Aliasee, @Name);
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
            return LLVM.LinkModules(this.instance, @Src, @Unused, out @OutMessage);
        }
    }
}