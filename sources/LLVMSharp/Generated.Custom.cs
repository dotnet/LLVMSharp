namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public partial struct off_t
    {
        public off_t(int value)
        {
            this.Value = value;
        }

        public int Value;
    }

    public static partial class LLVM
    {
        [DllImport(libraryPath, EntryPoint = "LLVMAddFunctionAttr2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionAttr2(LLVMValueRef @Fn, ulong @PA);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFunctionAttr2", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetFunctionAttr2(LLVMValueRef @Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveFunctionAttr2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveFunctionAttr2(LLVMValueRef @Fn, ulong @PA);

        [DllImport(libraryPath, EntryPoint = "LLVMConstantAsMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef ConstantAsMetadata(LLVMValueRef @Val);

        [DllImport(libraryPath, EntryPoint = "LLVMMDString2", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef MDString2(LLVMContextRef @C, [MarshalAs(UnmanagedType.LPStr)] string @Str, uint @SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMMDNode2", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef MDNode2(LLVMContextRef @C, out LLVMMetadataRef @MDs, uint @Count);

        [DllImport(libraryPath, EntryPoint = "LLVMTemporaryMDNode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef TemporaryMDNode(LLVMContextRef @C, out LLVMMetadataRef @MDs, uint @Count);

        [DllImport(libraryPath, EntryPoint = "LLVMAddNamedMetadataOperand2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddNamedMetadataOperand2(LLVMModuleRef @M, [MarshalAs(UnmanagedType.LPStr)] string @name, LLVMMetadataRef @Val);

        [DllImport(libraryPath, EntryPoint = "LLVMSetMetadata2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMetadata2(LLVMValueRef @Inst, uint @KindID, LLVMMetadataRef @MD);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCurrentDebugLocation2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCurrentDebugLocation2(LLVMBuilderRef @Bref, uint @Line, uint @Col, LLVMMetadataRef @Scope, LLVMMetadataRef @InlinedAt);

        [DllImport(libraryPath, EntryPoint = "LLVMNewDIBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDIBuilderRef NewDIBuilder(LLVMModuleRef @m);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderDestroy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DIBuilderDestroy(LLVMDIBuilderRef @d);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateCompileUnit", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateCompileUnit(LLVMDIBuilderRef @D, uint @Language, [MarshalAs(UnmanagedType.LPStr)] string @File, [MarshalAs(UnmanagedType.LPStr)] string @Dir, [MarshalAs(UnmanagedType.LPStr)] string @Producer, int @Optimized, [MarshalAs(UnmanagedType.LPStr)] string @Flags, uint @RuntimeVersion);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateFile(LLVMDIBuilderRef @D, [MarshalAs(UnmanagedType.LPStr)] string @File, [MarshalAs(UnmanagedType.LPStr)] string @Dir);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateLocalVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateLocalVariable(LLVMDIBuilderRef @D, uint @Tag, LLVMMetadataRef @Scope, [MarshalAs(UnmanagedType.LPStr)] string @Name, LLVMMetadataRef @File, uint @Line, LLVMMetadataRef @Ty, int @AlwaysPreserve, uint @Flags, uint @ArgNo);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateBasicType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateBasicType(LLVMDIBuilderRef @D, [MarshalAs(UnmanagedType.LPStr)] string @Name, ulong @SizeInBits, ulong @AlignInBits, uint @Encoding);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreatePointerType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreatePointerType(LLVMDIBuilderRef @D, LLVMMetadataRef @PointeeType, ulong @SizeInBits, ulong @AlignInBits, [MarshalAs(UnmanagedType.LPStr)] string @Name);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateSubroutineType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateSubroutineType(LLVMDIBuilderRef @D, LLVMMetadataRef @File, LLVMMetadataRef @ParameterTypes);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateStructType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateStructType(LLVMDIBuilderRef @D, LLVMMetadataRef @Scope, [MarshalAs(UnmanagedType.LPStr)] string @Name, LLVMMetadataRef @File, uint @Line, ulong @SizeInBits, ulong @AlignInBits, uint @Flags, LLVMMetadataRef @DerivedFrom, LLVMMetadataRef @ElementTypes);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateReplaceableCompositeType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateReplaceableCompositeType(LLVMDIBuilderRef @D, uint @Tag, [MarshalAs(UnmanagedType.LPStr)] string @Name, LLVMMetadataRef @Scope, LLVMMetadataRef @File, uint @Line, uint @RuntimeLang, ulong @SizeInBits, ulong @AlignInBits, uint @Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateMemberType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateMemberType(LLVMDIBuilderRef @D, LLVMMetadataRef @Scope, [MarshalAs(UnmanagedType.LPStr)] string @Name, LLVMMetadataRef @File, uint @Line, ulong @SizeInBits, ulong @AlignInBits, ulong @OffsetInBits, uint @Flags, LLVMMetadataRef @Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateArrayType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateArrayType(LLVMDIBuilderRef @D, ulong @SizeInBits, ulong @AlignInBits, LLVMMetadataRef @ElementType, LLVMMetadataRef @Subscripts);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateTypedef", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateTypedef(LLVMDIBuilderRef @D, LLVMMetadataRef @Ty, [MarshalAs(UnmanagedType.LPStr)] string @Name, LLVMMetadataRef @File, uint @Line, LLVMMetadataRef @Context);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderGetOrCreateArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderGetOrCreateArray(LLVMDIBuilderRef @D, out LLVMMetadataRef @Data, ulong @Length);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderGetOrCreateTypeArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderGetOrCreateTypeArray(LLVMDIBuilderRef @D, out LLVMMetadataRef @Data, ulong @Length);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateExpression", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMetadataRef DIBuilderCreateExpression(LLVMDIBuilderRef @Dref, IntPtr @Addr, ulong @Length);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertDeclareAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef DIBuilderInsertDeclareAtEnd(LLVMDIBuilderRef @D, LLVMValueRef @Storage, LLVMMetadataRef @VarInfo, LLVMMetadataRef @Expr, LLVMBasicBlockRef @Block);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertValueAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef DIBuilderInsertValueAtEnd(LLVMDIBuilderRef @D, LLVMValueRef @Val, ulong @Offset, LLVMMetadataRef @VarInfo, LLVMMetadataRef @Expr, LLVMBasicBlockRef @Block);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAddressSanitizerFunctionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAddressSanitizerFunctionPass(LLVMPassManagerRef @PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAddressSanitizerModulePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAddressSanitizerModulePass(LLVMPassManagerRef @PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddThreadSanitizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddThreadSanitizerPass(LLVMPassManagerRef @PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddMemorySanitizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddMemorySanitizerPass(LLVMPassManagerRef @PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddDataFlowSanitizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDataFlowSanitizerPass(LLVMPassManagerRef @PM);

        [DllImport(libraryPath, EntryPoint = "LLVMLinkInGC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkInGC();

        [DllImport(libraryPath, EntryPoint = "LLVMDisasmInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DisasmInstruction(LLVMDisasmContextRef DC, out byte Bytes, ulong BytesSize, ulong PC, out byte OutString, IntPtr OutStringSize);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBufferStart", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetBufferStart(LLVMMemoryBufferRef MemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDiagInfoDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDiagInfoDescription(LLVMDiagnosticInfoRef DI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDefaultTargetTriple", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDefaultTargetTriple();

        [DllImport(libraryPath, EntryPoint = "LLVMCopyStringRepOfTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CopyStringRepOfTargetData(LLVMTargetDataRef TD);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineTriple", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineTriple(LLVMTargetMachineRef T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineCPU", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineCPU(LLVMTargetMachineRef T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineFeatureString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineFeatureString(LLVMTargetMachineRef T);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintTypeToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintTypeToString(LLVMTypeRef Val);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateMessage([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string Message);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMessage(IntPtr Message);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintModuleToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintModuleToString(LLVMModuleRef M);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintValueToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintValueToString(LLVMValueRef Val);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcDisposeMangledSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OrcDisposeMangledSymbol(IntPtr MangledSymbol);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetMachineEmitToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetMachineEmitToFile(LLVMTargetMachineRef T, LLVMModuleRef M, IntPtr Filename, LLVMCodeGenFileType codegen, out IntPtr ErrorMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeCore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCore(LLVMPassRegistryRef R);

        [DllImport(libraryPath, EntryPoint = "LLVMAddInstructionCombiningPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInstructionCombiningPass(LLVMPassManagerRef PM);
    }
}