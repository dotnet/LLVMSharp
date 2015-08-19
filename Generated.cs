namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public partial struct LLVMOpaqueMemoryBuffer
    {
    }

    public partial struct LLVMOpaqueContext
    {
    }

    public partial struct LLVMOpaqueModule
    {
    }

    public partial struct LLVMOpaqueType
    {
    }

    public partial struct LLVMOpaqueValue
    {
    }

    public partial struct LLVMOpaqueBasicBlock
    {
    }

    public partial struct LLVMOpaqueBuilder
    {
    }

    public partial struct LLVMOpaqueModuleProvider
    {
    }

    public partial struct LLVMOpaquePassManager
    {
    }

    public partial struct LLVMOpaquePassRegistry
    {
    }

    public partial struct LLVMOpaqueUse
    {
    }

    public partial struct LLVMOpaqueDiagnosticInfo
    {
    }

    public partial struct LLVMOpInfoSymbol1
    {
        public int @Present;
        [MarshalAs(UnmanagedType.LPStr)] public string @Name;
        public int @Value;
    }

    public partial struct LLVMOpInfo1
    {
        public LLVMOpInfoSymbol1 @AddSymbol;
        public LLVMOpInfoSymbol1 @SubtractSymbol;
        public int @Value;
        public int @VariantKind;
    }

    public partial struct LLVMOpaqueTargetData
    {
    }

    public partial struct LLVMOpaqueTargetLibraryInfotData
    {
    }

    public partial struct LLVMOpaqueTargetMachine
    {
    }

    public partial struct LLVMTarget
    {
    }

    public partial struct LLVMOpaqueGenericValue
    {
    }

    public partial struct LLVMOpaqueExecutionEngine
    {
    }

    public partial struct LLVMOpaqueMCJITMemoryManager
    {
    }

    public partial struct LLVMMCJITCompilerOptions
    {
        public uint @OptLevel;
        public LLVMCodeModel @CodeModel;
        public int @NoFramePointerElim;
        public int @EnableFastISel;
        public IntPtr @MCJMM;
    }

    public partial struct LLVMOpaqueLTOModule
    {
    }

    public partial struct LLVMOpaqueLTOCodeGenerator
    {
    }

    public partial struct LLVMOpaqueObjectFile
    {
    }

    public partial struct LLVMOpaqueSectionIterator
    {
    }

    public partial struct LLVMOpaqueSymbolIterator
    {
    }

    public partial struct LLVMOpaqueRelocationIterator
    {
    }

    public partial struct LLVMOpaquePassManagerBuilder
    {
    }

    public partial struct LLVMBool
    {
        public LLVMBool(int value)
        {
            this.Value = value;
        }

        public int Value;
    }

    public partial struct LLVMMemoryBufferRef
    {
        public LLVMMemoryBufferRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMContextRef
    {
        public LLVMContextRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMModuleRef
    {
        public LLVMModuleRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMTypeRef
    {
        public LLVMTypeRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMValueRef
    {
        public LLVMValueRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMBasicBlockRef
    {
        public LLVMBasicBlockRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMBuilderRef
    {
        public LLVMBuilderRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMModuleProviderRef
    {
        public LLVMModuleProviderRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMPassManagerRef
    {
        public LLVMPassManagerRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMPassRegistryRef
    {
        public LLVMPassRegistryRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMUseRef
    {
        public LLVMUseRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMDiagnosticInfoRef
    {
        public LLVMDiagnosticInfoRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMFatalErrorHandler([MarshalAs(UnmanagedType.LPStr)] string reason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMDiagnosticHandler(out LLVMOpaqueDiagnosticInfo @param0, IntPtr @param1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMYieldCallback(out LLVMOpaqueContext @param0, IntPtr @param1);

    public partial struct LLVMDisasmContextRef
    {
        public LLVMDisasmContextRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LLVMOpInfoCallback(IntPtr disInfo, int pc, int offset, int size, int tagType, IntPtr tagBuf);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string LLVMSymbolLookupCallback(IntPtr disInfo, int referenceValue, out int referenceType, int referencePc, out IntPtr referenceName);

    public partial struct LLVMTargetDataRef
    {
        public LLVMTargetDataRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMTargetLibraryInfoRef
    {
        public LLVMTargetLibraryInfoRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMTargetMachineRef
    {
        public LLVMTargetMachineRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMTargetRef
    {
        public LLVMTargetRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMGenericValueRef
    {
        public LLVMGenericValueRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMExecutionEngineRef
    {
        public LLVMExecutionEngineRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMMCJITMemoryManagerRef
    {
        public LLVMMCJITMemoryManagerRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LLVMMemoryManagerAllocateCodeSectionCallback(IntPtr opaque, int size, uint alignment, uint sectionID, [MarshalAs(UnmanagedType.LPStr)] string sectionName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LLVMMemoryManagerAllocateDataSectionCallback(IntPtr opaque, int size, uint alignment, uint sectionID, [MarshalAs(UnmanagedType.LPStr)] string sectionName, int isReadOnly);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LLVMMemoryManagerFinalizeMemoryCallback(IntPtr opaque, out IntPtr errMsg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMMemoryManagerDestroyCallback(IntPtr opaque);

    public partial struct llvm_lto_t
    {
        public llvm_lto_t(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct lto_bool_t
    {
        public lto_bool_t(bool value)
        {
            this.Value = value;
        }

        public bool Value;
    }

    public partial struct lto_module_t
    {
        public lto_module_t(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct lto_code_gen_t
    {
        public lto_code_gen_t(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void lto_diagnostic_handler_t(lto_codegen_diagnostic_severity_t @severity, [MarshalAs(UnmanagedType.LPStr)] string @diag, IntPtr @ctxt);

    public partial struct LLVMObjectFileRef
    {
        public LLVMObjectFileRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMSectionIteratorRef
    {
        public LLVMSectionIteratorRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMSymbolIteratorRef
    {
        public LLVMSymbolIteratorRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMRelocationIteratorRef
    {
        public LLVMRelocationIteratorRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMPassManagerBuilderRef
    {
        public LLVMPassManagerBuilderRef(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public enum LLVMAttribute : int
    {
        @LLVMZExtAttribute = 1,
        @LLVMSExtAttribute = 2,
        @LLVMNoReturnAttribute = 4,
        @LLVMInRegAttribute = 8,
        @LLVMStructRetAttribute = 16,
        @LLVMNoUnwindAttribute = 32,
        @LLVMNoAliasAttribute = 64,
        @LLVMByValAttribute = 128,
        @LLVMNestAttribute = 256,
        @LLVMReadNoneAttribute = 512,
        @LLVMReadOnlyAttribute = 1024,
        @LLVMNoInlineAttribute = 2048,
        @LLVMAlwaysInlineAttribute = 4096,
        @LLVMOptimizeForSizeAttribute = 8192,
        @LLVMStackProtectAttribute = 16384,
        @LLVMStackProtectReqAttribute = 32768,
        @LLVMAlignment = 2031616,
        @LLVMNoCaptureAttribute = 2097152,
        @LLVMNoRedZoneAttribute = 4194304,
        @LLVMNoImplicitFloatAttribute = 8388608,
        @LLVMNakedAttribute = 16777216,
        @LLVMInlineHintAttribute = 33554432,
        @LLVMStackAlignment = 469762048,
        @LLVMReturnsTwice = 536870912,
        @LLVMUWTable = 1073741824,
        @LLVMNonLazyBind = -2147483648,
    }

    public enum LLVMOpcode : uint
    {
        @LLVMRet = 1,
        @LLVMBr = 2,
        @LLVMSwitch = 3,
        @LLVMIndirectBr = 4,
        @LLVMInvoke = 5,
        @LLVMUnreachable = 7,
        @LLVMAdd = 8,
        @LLVMFAdd = 9,
        @LLVMSub = 10,
        @LLVMFSub = 11,
        @LLVMMul = 12,
        @LLVMFMul = 13,
        @LLVMUDiv = 14,
        @LLVMSDiv = 15,
        @LLVMFDiv = 16,
        @LLVMURem = 17,
        @LLVMSRem = 18,
        @LLVMFRem = 19,
        @LLVMShl = 20,
        @LLVMLShr = 21,
        @LLVMAShr = 22,
        @LLVMAnd = 23,
        @LLVMOr = 24,
        @LLVMXor = 25,
        @LLVMAlloca = 26,
        @LLVMLoad = 27,
        @LLVMStore = 28,
        @LLVMGetElementPtr = 29,
        @LLVMTrunc = 30,
        @LLVMZExt = 31,
        @LLVMSExt = 32,
        @LLVMFPToUI = 33,
        @LLVMFPToSI = 34,
        @LLVMUIToFP = 35,
        @LLVMSIToFP = 36,
        @LLVMFPTrunc = 37,
        @LLVMFPExt = 38,
        @LLVMPtrToInt = 39,
        @LLVMIntToPtr = 40,
        @LLVMBitCast = 41,
        @LLVMAddrSpaceCast = 60,
        @LLVMICmp = 42,
        @LLVMFCmp = 43,
        @LLVMPHI = 44,
        @LLVMCall = 45,
        @LLVMSelect = 46,
        @LLVMUserOp1 = 47,
        @LLVMUserOp2 = 48,
        @LLVMVAArg = 49,
        @LLVMExtractElement = 50,
        @LLVMInsertElement = 51,
        @LLVMShuffleVector = 52,
        @LLVMExtractValue = 53,
        @LLVMInsertValue = 54,
        @LLVMFence = 55,
        @LLVMAtomicCmpXchg = 56,
        @LLVMAtomicRMW = 57,
        @LLVMResume = 58,
        @LLVMLandingPad = 59,
    }

    public enum LLVMTypeKind : uint
    {
        @LLVMVoidTypeKind = 0,
        @LLVMHalfTypeKind = 1,
        @LLVMFloatTypeKind = 2,
        @LLVMDoubleTypeKind = 3,
        @LLVMX86_FP80TypeKind = 4,
        @LLVMFP128TypeKind = 5,
        @LLVMPPC_FP128TypeKind = 6,
        @LLVMLabelTypeKind = 7,
        @LLVMIntegerTypeKind = 8,
        @LLVMFunctionTypeKind = 9,
        @LLVMStructTypeKind = 10,
        @LLVMArrayTypeKind = 11,
        @LLVMPointerTypeKind = 12,
        @LLVMVectorTypeKind = 13,
        @LLVMMetadataTypeKind = 14,
        @LLVMX86_MMXTypeKind = 15,
    }

    public enum LLVMLinkage : uint
    {
        @LLVMExternalLinkage = 0,
        @LLVMAvailableExternallyLinkage = 1,
        @LLVMLinkOnceAnyLinkage = 2,
        @LLVMLinkOnceODRLinkage = 3,
        @LLVMLinkOnceODRAutoHideLinkage = 4,
        @LLVMWeakAnyLinkage = 5,
        @LLVMWeakODRLinkage = 6,
        @LLVMAppendingLinkage = 7,
        @LLVMInternalLinkage = 8,
        @LLVMPrivateLinkage = 9,
        @LLVMDLLImportLinkage = 10,
        @LLVMDLLExportLinkage = 11,
        @LLVMExternalWeakLinkage = 12,
        @LLVMGhostLinkage = 13,
        @LLVMCommonLinkage = 14,
        @LLVMLinkerPrivateLinkage = 15,
        @LLVMLinkerPrivateWeakLinkage = 16,
    }

    public enum LLVMVisibility : uint
    {
        @LLVMDefaultVisibility = 0,
        @LLVMHiddenVisibility = 1,
        @LLVMProtectedVisibility = 2,
    }

    public enum LLVMDLLStorageClass : uint
    {
        @LLVMDefaultStorageClass = 0,
        @LLVMDLLImportStorageClass = 1,
        @LLVMDLLExportStorageClass = 2,
    }

    public enum LLVMCallConv : uint
    {
        @LLVMCCallConv = 0,
        @LLVMFastCallConv = 8,
        @LLVMColdCallConv = 9,
        @LLVMWebKitJSCallConv = 12,
        @LLVMAnyRegCallConv = 13,
        @LLVMX86StdcallCallConv = 64,
        @LLVMX86FastcallCallConv = 65,
    }

    public enum LLVMIntPredicate : uint
    {
        @LLVMIntEQ = 32,
        @LLVMIntNE = 33,
        @LLVMIntUGT = 34,
        @LLVMIntUGE = 35,
        @LLVMIntULT = 36,
        @LLVMIntULE = 37,
        @LLVMIntSGT = 38,
        @LLVMIntSGE = 39,
        @LLVMIntSLT = 40,
        @LLVMIntSLE = 41,
    }

    public enum LLVMRealPredicate : uint
    {
        @LLVMRealPredicateFalse = 0,
        @LLVMRealOEQ = 1,
        @LLVMRealOGT = 2,
        @LLVMRealOGE = 3,
        @LLVMRealOLT = 4,
        @LLVMRealOLE = 5,
        @LLVMRealONE = 6,
        @LLVMRealORD = 7,
        @LLVMRealUNO = 8,
        @LLVMRealUEQ = 9,
        @LLVMRealUGT = 10,
        @LLVMRealUGE = 11,
        @LLVMRealULT = 12,
        @LLVMRealULE = 13,
        @LLVMRealUNE = 14,
        @LLVMRealPredicateTrue = 15,
    }

    public enum LLVMLandingPadClauseTy : uint
    {
        @LLVMLandingPadCatch = 0,
        @LLVMLandingPadFilter = 1,
    }

    public enum LLVMThreadLocalMode : uint
    {
        @LLVMNotThreadLocal = 0,
        @LLVMGeneralDynamicTLSModel = 1,
        @LLVMLocalDynamicTLSModel = 2,
        @LLVMInitialExecTLSModel = 3,
        @LLVMLocalExecTLSModel = 4,
    }

    public enum LLVMAtomicOrdering : uint
    {
        @LLVMAtomicOrderingNotAtomic = 0,
        @LLVMAtomicOrderingUnordered = 1,
        @LLVMAtomicOrderingMonotonic = 2,
        @LLVMAtomicOrderingAcquire = 4,
        @LLVMAtomicOrderingRelease = 5,
        @LLVMAtomicOrderingAcquireRelease = 6,
        @LLVMAtomicOrderingSequentiallyConsistent = 7,
    }

    public enum LLVMAtomicRMWBinOp : uint
    {
        @LLVMAtomicRMWBinOpXchg = 0,
        @LLVMAtomicRMWBinOpAdd = 1,
        @LLVMAtomicRMWBinOpSub = 2,
        @LLVMAtomicRMWBinOpAnd = 3,
        @LLVMAtomicRMWBinOpNand = 4,
        @LLVMAtomicRMWBinOpOr = 5,
        @LLVMAtomicRMWBinOpXor = 6,
        @LLVMAtomicRMWBinOpMax = 7,
        @LLVMAtomicRMWBinOpMin = 8,
        @LLVMAtomicRMWBinOpUMax = 9,
        @LLVMAtomicRMWBinOpUMin = 10,
    }

    public enum LLVMDiagnosticSeverity : uint
    {
        @LLVMDSError = 0,
        @LLVMDSWarning = 1,
        @LLVMDSRemark = 2,
        @LLVMDSNote = 3,
    }

    public enum LLVMVerifierFailureAction : uint
    {
        @LLVMAbortProcessAction = 0,
        @LLVMPrintMessageAction = 1,
        @LLVMReturnStatusAction = 2,
    }

    public enum LLVMByteOrdering : uint
    {
        @LLVMBigEndian = 0,
        @LLVMLittleEndian = 1,
    }

    public enum LLVMCodeGenOptLevel : uint
    {
        @LLVMCodeGenLevelNone = 0,
        @LLVMCodeGenLevelLess = 1,
        @LLVMCodeGenLevelDefault = 2,
        @LLVMCodeGenLevelAggressive = 3,
    }

    public enum LLVMRelocMode : uint
    {
        @LLVMRelocDefault = 0,
        @LLVMRelocStatic = 1,
        @LLVMRelocPIC = 2,
        @LLVMRelocDynamicNoPic = 3,
    }

    public enum LLVMCodeModel : uint
    {
        @LLVMCodeModelDefault = 0,
        @LLVMCodeModelJITDefault = 1,
        @LLVMCodeModelSmall = 2,
        @LLVMCodeModelKernel = 3,
        @LLVMCodeModelMedium = 4,
        @LLVMCodeModelLarge = 5,
    }

    public enum LLVMCodeGenFileType : uint
    {
        @LLVMAssemblyFile = 0,
        @LLVMObjectFile = 1,
    }

    public enum llvm_lto_status : uint
    {
        @LLVM_LTO_UNKNOWN = 0,
        @LLVM_LTO_OPT_SUCCESS = 1,
        @LLVM_LTO_READ_SUCCESS = 2,
        @LLVM_LTO_READ_FAILURE = 3,
        @LLVM_LTO_WRITE_FAILURE = 4,
        @LLVM_LTO_NO_TARGET = 5,
        @LLVM_LTO_NO_WORK = 6,
        @LLVM_LTO_MODULE_MERGE_FAILURE = 7,
        @LLVM_LTO_ASM_FAILURE = 8,
        @LLVM_LTO_NULL_OBJECT = 9,
    }

    public enum lto_symbol_attributes : uint
    {
        @LTO_SYMBOL_ALIGNMENT_MASK = 31,
        @LTO_SYMBOL_PERMISSIONS_MASK = 224,
        @LTO_SYMBOL_PERMISSIONS_CODE = 160,
        @LTO_SYMBOL_PERMISSIONS_DATA = 192,
        @LTO_SYMBOL_PERMISSIONS_RODATA = 128,
        @LTO_SYMBOL_DEFINITION_MASK = 1792,
        @LTO_SYMBOL_DEFINITION_REGULAR = 256,
        @LTO_SYMBOL_DEFINITION_TENTATIVE = 512,
        @LTO_SYMBOL_DEFINITION_WEAK = 768,
        @LTO_SYMBOL_DEFINITION_UNDEFINED = 1024,
        @LTO_SYMBOL_DEFINITION_WEAKUNDEF = 1280,
        @LTO_SYMBOL_SCOPE_MASK = 14336,
        @LTO_SYMBOL_SCOPE_INTERNAL = 2048,
        @LTO_SYMBOL_SCOPE_HIDDEN = 4096,
        @LTO_SYMBOL_SCOPE_PROTECTED = 8192,
        @LTO_SYMBOL_SCOPE_DEFAULT = 6144,
        @LTO_SYMBOL_SCOPE_DEFAULT_CAN_BE_HIDDEN = 10240,
    }

    public enum lto_debug_model : uint
    {
        @LTO_DEBUG_MODEL_NONE = 0,
        @LTO_DEBUG_MODEL_DWARF = 1,
    }

    public enum lto_codegen_model : uint
    {
        @LTO_CODEGEN_PIC_MODEL_STATIC = 0,
        @LTO_CODEGEN_PIC_MODEL_DYNAMIC = 1,
        @LTO_CODEGEN_PIC_MODEL_DYNAMIC_NO_PIC = 2,
        @LTO_CODEGEN_PIC_MODEL_DEFAULT = 3,
    }

    public enum lto_codegen_diagnostic_severity_t : uint
    {
        @LTO_DS_ERROR = 0,
        @LTO_DS_WARNING = 1,
        @LTO_DS_REMARK = 3,
        @LTO_DS_NOTE = 2,
    }

    public static partial class LLVM
    {
        private const string LibraryPath = "libLLVM";

        [DllImport(LibraryPath, EntryPoint = "LLVMLoadLibraryPermanently", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool LoadLibraryPermanently([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(LibraryPath, EntryPoint = "LLVMParseCommandLineOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ParseCommandLineOptions(int @argc, string[] @argv, [MarshalAs(UnmanagedType.LPStr)] string overview);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeCore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCore(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMShutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateMessage([MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMessage(IntPtr message);

        [DllImport(LibraryPath, EntryPoint = "LLVMInstallFatalErrorHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InstallFatalErrorHandler(LLVMFatalErrorHandler handler);

        [DllImport(LibraryPath, EntryPoint = "LLVMResetFatalErrorHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResetFatalErrorHandler();

        [DllImport(LibraryPath, EntryPoint = "LLVMEnablePrettyStackTrace", CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnablePrettyStackTrace();

        [DllImport(LibraryPath, EntryPoint = "LLVMContextCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMContextRef ContextCreate();

        [DllImport(LibraryPath, EntryPoint = "LLVMGetGlobalContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMContextRef GetGlobalContext();

        [DllImport(LibraryPath, EntryPoint = "LLVMContextSetDiagnosticHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextSetDiagnosticHandler(LLVMContextRef c, LLVMDiagnosticHandler handler, IntPtr diagnosticContext);

        [DllImport(LibraryPath, EntryPoint = "LLVMContextSetYieldCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextSetYieldCallback(LLVMContextRef c, LLVMYieldCallback callback, IntPtr opaqueHandle);

        [DllImport(LibraryPath, EntryPoint = "LLVMContextDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextDispose(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetDiagInfoDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDiagInfoDescription(LLVMDiagnosticInfoRef di);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetDiagInfoSeverity", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDiagnosticSeverity GetDiagInfoSeverity(LLVMDiagnosticInfoRef di);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMDKindIDInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetMDKindIDInContext(LLVMContextRef c, [MarshalAs(UnmanagedType.LPStr)] string name, uint sLen);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMDKindID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetMDKindID([MarshalAs(UnmanagedType.LPStr)] string name, uint sLen);

        [DllImport(LibraryPath, EntryPoint = "LLVMModuleCreateWithName", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleRef ModuleCreateWithName([MarshalAs(UnmanagedType.LPStr)] string moduleID);

        [DllImport(LibraryPath, EntryPoint = "LLVMModuleCreateWithNameInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleRef ModuleCreateWithNameInContext([MarshalAs(UnmanagedType.LPStr)] string moduleID, LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMCloneModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleRef CloneModule(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeModule(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetDataLayout(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDataLayout(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string triple);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetTarget(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTarget(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string triple);

        [DllImport(LibraryPath, EntryPoint = "LLVMDumpModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpModule(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMPrintModuleToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool PrintModuleToFile(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr errorMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMPrintModuleToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintModuleToString(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetModuleInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModuleInlineAsm(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string asm);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetModuleContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMContextRef GetModuleContext(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTypeByName", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef GetTypeByName(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNamedMetadataNumOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetNamedMetadataNumOperands(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string @name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNamedMetadataOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetNamedMetadataOperands(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string @name, out LLVMValueRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddNamedMetadataOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddNamedMetadataOperand(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string @name, LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef AddFunction(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string name, LLVMTypeRef functionTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNamedFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNamedFunction(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetFirstFunction(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLastFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetLastFunction(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNextFunction(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPreviousFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetPreviousFunction(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTypeKind", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeKind GetTypeKind(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMTypeIsSized", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TypeIsSized(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTypeContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMContextRef GetTypeContext(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMDumpType", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpType(LLVMTypeRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMPrintTypeToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintTypeToString(LLVMTypeRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt1TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int1TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt8TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int8TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt16TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int16TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt32TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int32TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt64TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int64TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMIntTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntTypeInContext(LLVMContextRef c, uint numBits);

        [DllImport(LibraryPath, EntryPoint = "LLVMInt1Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int1Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMInt8Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int8Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMInt16Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int16Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMInt32Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int32Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMInt64Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef Int64Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMIntType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntType(uint numBits);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetIntTypeWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetIntTypeWidth(LLVMTypeRef integerTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMHalfTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef HalfTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMFloatTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef FloatTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMDoubleTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef DoubleTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMX86FP80TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef X86FP80TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMFP128TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef FP128TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMPPCFP128TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef PPCFP128TypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMHalfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef HalfType();

        [DllImport(LibraryPath, EntryPoint = "LLVMFloatType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef FloatType();

        [DllImport(LibraryPath, EntryPoint = "LLVMDoubleType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef DoubleType();

        [DllImport(LibraryPath, EntryPoint = "LLVMX86FP80Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef X86FP80Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMFP128Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef FP128Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMPPCFP128Type", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef PPCFP128Type();

        [DllImport(LibraryPath, EntryPoint = "LLVMFunctionType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef FunctionType(LLVMTypeRef returnType, out LLVMTypeRef paramTypes, uint paramCount, LLVMBool isVarArg);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsFunctionVarArg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsFunctionVarArg(LLVMTypeRef functionTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetReturnType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef GetReturnType(LLVMTypeRef functionTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMCountParamTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CountParamTypes(LLVMTypeRef functionTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetParamTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetParamTypes(LLVMTypeRef functionTy, out LLVMTypeRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMStructTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef StructTypeInContext(LLVMContextRef c, out LLVMTypeRef elementTypes, uint elementCount, LLVMBool packed);

        [DllImport(LibraryPath, EntryPoint = "LLVMStructType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef StructType(out LLVMTypeRef elementTypes, uint elementCount, LLVMBool packed);

        [DllImport(LibraryPath, EntryPoint = "LLVMStructCreateNamed", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef StructCreateNamed(LLVMContextRef c, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetStructName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetStructName(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMStructSetBody", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StructSetBody(LLVMTypeRef structTy, out LLVMTypeRef elementTypes, uint elementCount, LLVMBool packed);

        [DllImport(LibraryPath, EntryPoint = "LLVMCountStructElementTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CountStructElementTypes(LLVMTypeRef structTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetStructElementTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetStructElementTypes(LLVMTypeRef structTy, out LLVMTypeRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsPackedStruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsPackedStruct(LLVMTypeRef structTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsOpaqueStruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsOpaqueStruct(LLVMTypeRef structTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetElementType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef GetElementType(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMArrayType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef ArrayType(LLVMTypeRef elementType, uint elementCount);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetArrayLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetArrayLength(LLVMTypeRef arrayTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMPointerType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef PointerType(LLVMTypeRef elementType, uint addressSpace);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPointerAddressSpace", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetPointerAddressSpace(LLVMTypeRef pointerTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMVectorType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef VectorType(LLVMTypeRef elementType, uint elementCount);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetVectorSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetVectorSize(LLVMTypeRef vectorTy);

        [DllImport(LibraryPath, EntryPoint = "LLVMVoidTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef VoidTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMLabelTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef LabelTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMX86MMXTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef X86MMXTypeInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMVoidType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef VoidType();

        [DllImport(LibraryPath, EntryPoint = "LLVMLabelType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef LabelType();

        [DllImport(LibraryPath, EntryPoint = "LLVMX86MMXType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef X86MMXType();

        [DllImport(LibraryPath, EntryPoint = "LLVMTypeOf", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef TypeOf(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetValueName(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetValueName(LLVMValueRef val, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMDumpValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpValue(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMPrintValueToString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PrintValueToString(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMReplaceAllUsesWith", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReplaceAllUsesWith(LLVMValueRef oldVal, LLVMValueRef newVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsConstant(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsUndef", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsUndef(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAArgument", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAArgument(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsABasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsABasicBlock(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAInlineAsm(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAUser", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAUser(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstant(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsABlockAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsABlockAddress(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantAggregateZero", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantAggregateZero(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantArray(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantDataSequential", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantDataSequential(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantDataArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantDataArray(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantDataVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantDataVector(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantExpr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantExpr(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantFP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantFP(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantInt(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantPointerNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantPointerNull(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantStruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantStruct(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAConstantVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAConstantVector(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAGlobalValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAGlobalValue(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAGlobalAlias(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAGlobalObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAGlobalObject(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFunction(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAGlobalVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAGlobalVariable(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAUndefValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAUndefValue(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAInstruction(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsABinaryOperator", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsABinaryOperator(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsACallInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsACallInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAIntrinsicInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAIntrinsicInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsADbgInfoIntrinsic", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsADbgInfoIntrinsic(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsADbgDeclareInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsADbgDeclareInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMemIntrinsic", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMemIntrinsic(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMemCpyInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMemCpyInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMemMoveInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMemMoveInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMemSetInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMemSetInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsACmpInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsACmpInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFCmpInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFCmpInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAICmpInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAICmpInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAExtractElementInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAExtractElementInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAGetElementPtrInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAGetElementPtrInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAInsertElementInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAInsertElementInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAInsertValueInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAInsertValueInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsALandingPadInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsALandingPadInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAPHINode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAPHINode(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsASelectInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsASelectInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAShuffleVectorInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAShuffleVectorInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAStoreInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAStoreInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsATerminatorInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsATerminatorInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsABranchInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsABranchInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAIndirectBrInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAIndirectBrInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAInvokeInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAInvokeInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAReturnInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAReturnInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsASwitchInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsASwitchInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAUnreachableInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAUnreachableInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAResumeInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAResumeInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAUnaryInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAUnaryInstruction(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAAllocaInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAAllocaInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsACastInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsACastInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAAddrSpaceCastInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAAddrSpaceCastInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsABitCastInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsABitCastInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFPExtInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFPExtInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFPToSIInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFPToSIInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFPToUIInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFPToUIInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAFPTruncInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAFPTruncInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAIntToPtrInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAIntToPtrInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAPtrToIntInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAPtrToIntInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsASExtInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsASExtInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsASIToFPInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsASIToFPInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsATruncInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsATruncInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAUIToFPInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAUIToFPInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAZExtInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAZExtInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAExtractValueInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAExtractValueInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsALoadInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsALoadInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAVAArgInst", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAVAArgInst(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMDNode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMDNode(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsAMDString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef IsAMDString(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstUse", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMUseRef GetFirstUse(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextUse", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMUseRef GetNextUse(LLVMUseRef u);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetUser", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetUser(LLVMUseRef u);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetUsedValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetUsedValue(LLVMUseRef u);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetOperand(LLVMValueRef val, uint index);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetOperandUse", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMUseRef GetOperandUse(LLVMValueRef val, uint index);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetOperand(LLVMValueRef user, uint index, LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNumOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumOperands(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNull(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstAllOnes", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstAllOnes(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetUndef", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetUndef(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsNull(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstPointerNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstPointerNull(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstInt(LLVMTypeRef intTy, ulong n, LLVMBool signExtend);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntOfArbitraryPrecision", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstIntOfArbitraryPrecision(LLVMTypeRef intTy, uint numWords, int[] words);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntOfString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstIntOfString(LLVMTypeRef intTy, [MarshalAs(UnmanagedType.LPStr)] string text, char radix);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntOfStringAndSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstIntOfStringAndSize(LLVMTypeRef intTy, [MarshalAs(UnmanagedType.LPStr)] string text, uint sLen, char radix);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstReal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstReal(LLVMTypeRef realTy, double n);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstRealOfString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstRealOfString(LLVMTypeRef realTy, [MarshalAs(UnmanagedType.LPStr)] string text);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstRealOfStringAndSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstRealOfStringAndSize(LLVMTypeRef realTy, [MarshalAs(UnmanagedType.LPStr)] string text, uint sLen);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntGetZExtValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong ConstIntGetZExtValue(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntGetSExtValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern long ConstIntGetSExtValue(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstRealGetDouble", CallingConvention = CallingConvention.Cdecl)]
        public static extern double ConstRealGetDouble(LLVMValueRef constantVal, out LLVMBool @losesInfo);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstStringInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstStringInContext(LLVMContextRef c, [MarshalAs(UnmanagedType.LPStr)] string str, uint length, LLVMBool dontNullTerminate);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstString([MarshalAs(UnmanagedType.LPStr)] string str, uint length, LLVMBool dontNullTerminate);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsConstantString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsConstantString(LLVMValueRef @c);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetAsString", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetAsString(LLVMValueRef @c, out int @out);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstStructInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstStructInContext(LLVMContextRef c, out LLVMValueRef constantVals, uint count, LLVMBool packed);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstStruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstStruct(out LLVMValueRef constantVals, uint count, LLVMBool packed);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstArray(LLVMTypeRef elementTy, out LLVMValueRef constantVals, uint length);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNamedStruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNamedStruct(LLVMTypeRef structTy, out LLVMValueRef constantVals, uint count);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetElementAsConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetElementAsConstant(LLVMValueRef @c, uint @idx);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstVector(out LLVMValueRef scalarConstantVals, uint size);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetConstOpcode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMOpcode GetConstOpcode(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMAlignOf", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef AlignOf(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMSizeOf", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef SizeOf(LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNeg(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNSWNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNSWNeg(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNUWNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNUWNeg(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFNeg(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNot", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNot(LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstAdd(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNSWAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNSWAdd(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNUWAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNUWAdd(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFAdd(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSub(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNSWSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNSWSub(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNUWSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNUWSub(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFSub(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstMul(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNSWMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNSWMul(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstNUWMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstNUWMul(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFMul(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstUDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstUDiv(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSDiv(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstExactSDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstExactSDiv(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFDiv(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstURem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstURem(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSRem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSRem(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFRem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFRem(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstAnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstAnd(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstOr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstOr(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstXor", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstXor(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstICmp", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstICmp(LLVMIntPredicate predicate, LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFCmp", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFCmp(LLVMRealPredicate predicate, LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstShl", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstShl(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstLShr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstLShr(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstAShr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstAShr(LLVMValueRef lhsConstant, LLVMValueRef rhsConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstGEP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstGEP(LLVMValueRef constantVal, out LLVMValueRef constantIndices, uint numIndices);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstInBoundsGEP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstInBoundsGEP(LLVMValueRef constantVal, out LLVMValueRef constantIndices, uint numIndices);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstTrunc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstTrunc(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSExt(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstZExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstZExt(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFPTrunc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFPTrunc(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFPExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFPExt(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstUIToFP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstUIToFP(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSIToFP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSIToFP(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFPToUI", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFPToUI(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFPToSI", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFPToSI(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstPtrToInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstPtrToInt(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntToPtr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstIntToPtr(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstBitCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstAddrSpaceCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstAddrSpaceCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstZExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstZExtOrBitCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSExtOrBitCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstTruncOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstTruncOrBitCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstPointerCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstPointerCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstIntCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstIntCast(LLVMValueRef constantVal, LLVMTypeRef toType, LLVMBool @isSigned);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstFPCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstFPCast(LLVMValueRef constantVal, LLVMTypeRef toType);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstSelect", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstSelect(LLVMValueRef constantCondition, LLVMValueRef constantIfTrue, LLVMValueRef constantIfFalse);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstExtractElement", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstExtractElement(LLVMValueRef vectorConstant, LLVMValueRef indexConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstInsertElement", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstInsertElement(LLVMValueRef vectorConstant, LLVMValueRef elementValueConstant, LLVMValueRef indexConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstShuffleVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstShuffleVector(LLVMValueRef vectorAConstant, LLVMValueRef vectorBConstant, LLVMValueRef maskConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstExtractValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstExtractValue(LLVMValueRef aggConstant, out uint idxList, uint numIdx);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstInsertValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstInsertValue(LLVMValueRef aggConstant, LLVMValueRef elementValueConstant, out uint idxList, uint numIdx);

        [DllImport(LibraryPath, EntryPoint = "LLVMConstInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef ConstInlineAsm(LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string asmString, [MarshalAs(UnmanagedType.LPStr)] string constraints, LLVMBool hasSideEffects, LLVMBool isAlignStack);

        [DllImport(LibraryPath, EntryPoint = "LLVMBlockAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BlockAddress(LLVMValueRef f, LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetGlobalParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleRef GetGlobalParent(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsDeclaration", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsDeclaration(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLinkage", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMLinkage GetLinkage(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetLinkage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLinkage(LLVMValueRef @Global, LLVMLinkage linkage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetSection(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSection(LLVMValueRef @Global, [MarshalAs(UnmanagedType.LPStr)] string section);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetVisibility", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMVisibility GetVisibility(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetVisibility", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVisibility(LLVMValueRef @Global, LLVMVisibility viz);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetDLLStorageClass", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDLLStorageClass GetDLLStorageClass(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetDLLStorageClass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDLLStorageClass(LLVMValueRef @Global, LLVMDLLStorageClass @Class);

        [DllImport(LibraryPath, EntryPoint = "LLVMHasUnnamedAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool HasUnnamedAddr(LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetUnnamedAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUnnamedAddr(LLVMValueRef @Global, LLVMBool hasUnnamedAddr);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetAlignment(LLVMValueRef v);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAlignment(LLVMValueRef v, uint bytes);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef AddGlobal(LLVMModuleRef m, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGlobalInAddressSpace", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef AddGlobalInAddressSpace(LLVMModuleRef m, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name, uint addressSpace);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNamedGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNamedGlobal(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetFirstGlobal(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLastGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetLastGlobal(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNextGlobal(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPreviousGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetPreviousGlobal(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMDeleteGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteGlobal(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetInitializer", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetInitializer(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetInitializer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInitializer(LLVMValueRef globalVar, LLVMValueRef constantVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsThreadLocal", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsThreadLocal(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetThreadLocal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetThreadLocal(LLVMValueRef globalVar, LLVMBool isThreadLocal);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsGlobalConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsGlobalConstant(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetGlobalConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGlobalConstant(LLVMValueRef globalVar, LLVMBool isConstant);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetThreadLocalMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMThreadLocalMode GetThreadLocalMode(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetThreadLocalMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetThreadLocalMode(LLVMValueRef globalVar, LLVMThreadLocalMode mode);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsExternallyInitialized", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsExternallyInitialized(LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetExternallyInitialized", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExternallyInitialized(LLVMValueRef globalVar, LLVMBool isExtInit);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAlias", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef AddAlias(LLVMModuleRef m, LLVMTypeRef ty, LLVMValueRef aliasee, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMDeleteFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteFunction(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetIntrinsicID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetIntrinsicID(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFunctionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetFunctionCallConv(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetFunctionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFunctionCallConv(LLVMValueRef fn, uint cc);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetGC", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetGC(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetGC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGC(LLVMValueRef fn, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddFunctionAttr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionAttr(LLVMValueRef fn, LLVMAttribute pa);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddTargetDependentFunctionAttr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTargetDependentFunctionAttr(LLVMValueRef fn, [MarshalAs(UnmanagedType.LPStr)] string a, [MarshalAs(UnmanagedType.LPStr)] string v);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFunctionAttr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMAttribute GetFunctionAttr(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveFunctionAttr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveFunctionAttr(LLVMValueRef fn, LLVMAttribute pa);

        [DllImport(LibraryPath, EntryPoint = "LLVMCountParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CountParams(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetParams(LLVMValueRef fn, out LLVMValueRef @Params);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetParam(LLVMValueRef fn, uint index);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetParamParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetParamParent(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetFirstParam(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLastParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetLastParam(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNextParam(LLVMValueRef arg);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPreviousParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetPreviousParam(LLVMValueRef arg);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAttribute(LLVMValueRef arg, LLVMAttribute pa);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveAttribute(LLVMValueRef arg, LLVMAttribute pa);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMAttribute GetAttribute(LLVMValueRef arg);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetParamAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParamAlignment(LLVMValueRef arg, uint @align);

        [DllImport(LibraryPath, EntryPoint = "LLVMMDStringInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef MDStringInContext(LLVMContextRef c, [MarshalAs(UnmanagedType.LPStr)] string str, uint sLen);

        [DllImport(LibraryPath, EntryPoint = "LLVMMDString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef MDString([MarshalAs(UnmanagedType.LPStr)] string str, uint sLen);

        [DllImport(LibraryPath, EntryPoint = "LLVMMDNodeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef MDNodeInContext(LLVMContextRef c, out LLVMValueRef vals, uint count);

        [DllImport(LibraryPath, EntryPoint = "LLVMMDNode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef MDNode(out LLVMValueRef vals, uint count);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMDString", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetMDString(LLVMValueRef v, out uint len);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMDNodeNumOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetMDNodeNumOperands(LLVMValueRef v);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMDNodeOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetMDNodeOperands(LLVMValueRef v, out LLVMValueRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMBasicBlockAsValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BasicBlockAsValue(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMValueIsBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool ValueIsBasicBlock(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMValueAsBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef ValueAsBasicBlock(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBasicBlockParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetBasicBlockParent(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBasicBlockTerminator", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetBasicBlockTerminator(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMCountBasicBlocks", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CountBasicBlocks(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBasicBlocks", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetBasicBlocks(LLVMValueRef fn, out LLVMBasicBlockRef basicBlocks);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetFirstBasicBlock(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLastBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetLastBasicBlock(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetNextBasicBlock(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPreviousBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetPreviousBasicBlock(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetEntryBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetEntryBasicBlock(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMAppendBasicBlockInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef AppendBasicBlockInContext(LLVMContextRef c, LLVMValueRef fn, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMAppendBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef AppendBasicBlock(LLVMValueRef fn, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMInsertBasicBlockInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef InsertBasicBlockInContext(LLVMContextRef c, LLVMBasicBlockRef bb, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMInsertBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef InsertBasicBlock(LLVMBasicBlockRef insertBeforeBb, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMDeleteBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteBasicBlock(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveBasicBlockFromParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveBasicBlockFromParent(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveBasicBlockBefore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveBasicBlockBefore(LLVMBasicBlockRef bb, LLVMBasicBlockRef movePos);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveBasicBlockAfter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveBasicBlockAfter(LLVMBasicBlockRef bb, LLVMBasicBlockRef movePos);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetFirstInstruction(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetLastInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetLastInstruction(LLVMBasicBlockRef bb);

        [DllImport(LibraryPath, EntryPoint = "LLVMHasMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HasMetadata(LLVMValueRef val);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetMetadata(LLVMValueRef val, uint kindID);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMetadata(LLVMValueRef val, uint kindID, LLVMValueRef node);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetInstructionParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetInstructionParent(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetNextInstruction(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPreviousInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetPreviousInstruction(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMInstructionEraseFromParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InstructionEraseFromParent(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetInstructionOpcode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMOpcode GetInstructionOpcode(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetICmpPredicate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMIntPredicate GetICmpPredicate(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFCmpPredicate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMRealPredicate GetFCmpPredicate(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMInstructionClone", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef InstructionClone(LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetInstructionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstructionCallConv(LLVMValueRef instr, uint cc);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetInstructionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetInstructionCallConv(LLVMValueRef instr);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddInstrAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInstrAttribute(LLVMValueRef instr, uint @index, LLVMAttribute @param2);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveInstrAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveInstrAttribute(LLVMValueRef instr, uint @index, LLVMAttribute @param2);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetInstrParamAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstrParamAlignment(LLVMValueRef instr, uint @index, uint @align);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsTailCall", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsTailCall(LLVMValueRef callInst);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetTailCall", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTailCall(LLVMValueRef callInst, LLVMBool isTailCall);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNumSuccessors", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetNumSuccessors(LLVMValueRef term);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSuccessor", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetSuccessor(LLVMValueRef term, uint @i);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetSuccessor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSuccessor(LLVMValueRef term, uint @i, LLVMBasicBlockRef @block);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsConditional", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsConditional(LLVMValueRef branch);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetCondition", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetCondition(LLVMValueRef branch);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetCondition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCondition(LLVMValueRef branch, LLVMValueRef cond);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSwitchDefaultDest", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetSwitchDefaultDest(LLVMValueRef switchInstr);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddIncoming", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIncoming(LLVMValueRef phiNode, out LLVMValueRef incomingValues, out LLVMBasicBlockRef incomingBlocks, uint count);

        [DllImport(LibraryPath, EntryPoint = "LLVMCountIncoming", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CountIncoming(LLVMValueRef phiNode);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetIncomingValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetIncomingValue(LLVMValueRef phiNode, uint index);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetIncomingBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetIncomingBlock(LLVMValueRef phiNode, uint index);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateBuilderInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBuilderRef CreateBuilderInContext(LLVMContextRef c);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBuilderRef CreateBuilder();

        [DllImport(LibraryPath, EntryPoint = "LLVMPositionBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilder(LLVMBuilderRef builder, LLVMBasicBlockRef block, LLVMValueRef instr);

        [DllImport(LibraryPath, EntryPoint = "LLVMPositionBuilderBefore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilderBefore(LLVMBuilderRef builder, LLVMValueRef instr);

        [DllImport(LibraryPath, EntryPoint = "LLVMPositionBuilderAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilderAtEnd(LLVMBuilderRef builder, LLVMBasicBlockRef block);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetInsertBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBasicBlockRef GetInsertBlock(LLVMBuilderRef builder);

        [DllImport(LibraryPath, EntryPoint = "LLVMClearInsertionPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearInsertionPosition(LLVMBuilderRef builder);

        [DllImport(LibraryPath, EntryPoint = "LLVMInsertIntoBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InsertIntoBuilder(LLVMBuilderRef builder, LLVMValueRef instr);

        [DllImport(LibraryPath, EntryPoint = "LLVMInsertIntoBuilderWithName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InsertIntoBuilderWithName(LLVMBuilderRef builder, LLVMValueRef instr, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeBuilder(LLVMBuilderRef builder);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetCurrentDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCurrentDebugLocation(LLVMBuilderRef builder, LLVMValueRef l);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetCurrentDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef GetCurrentDebugLocation(LLVMBuilderRef builder);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetInstDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstDebugLocation(LLVMBuilderRef builder, LLVMValueRef inst);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildRetVoid", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildRetVoid(LLVMBuilderRef @param0);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildRet", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildRet(LLVMBuilderRef @param0, LLVMValueRef v);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAggregateRet", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAggregateRet(LLVMBuilderRef @param0, out LLVMValueRef retVals, uint n);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildBr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildBr(LLVMBuilderRef @param0, LLVMBasicBlockRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildCondBr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildCondBr(LLVMBuilderRef @param0, LLVMValueRef @If, LLVMBasicBlockRef then, LLVMBasicBlockRef @Else);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSwitch(LLVMBuilderRef @param0, LLVMValueRef v, LLVMBasicBlockRef @Else, uint numCases);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildIndirectBr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildIndirectBr(LLVMBuilderRef b, LLVMValueRef addr, uint numDests);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildInvoke", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildInvoke(LLVMBuilderRef @param0, LLVMValueRef fn, out LLVMValueRef args, uint numArgs, LLVMBasicBlockRef then, LLVMBasicBlockRef @Catch, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildLandingPad", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildLandingPad(LLVMBuilderRef b, LLVMTypeRef ty, LLVMValueRef persFn, uint numClauses, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildResume", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildResume(LLVMBuilderRef b, LLVMValueRef exn);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildUnreachable", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildUnreachable(LLVMBuilderRef @param0);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddCase", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCase(LLVMValueRef @Switch, LLVMValueRef onVal, LLVMBasicBlockRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddDestination", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDestination(LLVMValueRef indirectBr, LLVMBasicBlockRef dest);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddClause", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddClause(LLVMValueRef landingPad, LLVMValueRef clauseVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetCleanup", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCleanup(LLVMValueRef landingPad, LLVMBool val);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAdd(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNSWAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNSWAdd(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNUWAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNUWAdd(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFAdd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFAdd(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSub(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNSWSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNSWSub(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNUWSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNUWSub(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFSub(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildMul(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNSWMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNSWMul(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNUWMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNUWMul(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFMul", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFMul(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildUDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildUDiv(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSDiv(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildExactSDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildExactSDiv(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFDiv", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFDiv(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildURem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildURem(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSRem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSRem(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFRem", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFRem(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildShl", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildShl(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildLShr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildLShr(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAShr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAShr(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAnd(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildOr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildOr(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildXor", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildXor(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildBinOp", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildBinOp(LLVMBuilderRef b, LLVMOpcode op, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNeg(LLVMBuilderRef @param0, LLVMValueRef v, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNSWNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNSWNeg(LLVMBuilderRef b, LLVMValueRef v, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNUWNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNUWNeg(LLVMBuilderRef b, LLVMValueRef v, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFNeg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFNeg(LLVMBuilderRef @param0, LLVMValueRef v, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildNot", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildNot(LLVMBuilderRef @param0, LLVMValueRef v, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildMalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildMalloc(LLVMBuilderRef @param0, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildArrayMalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildArrayMalloc(LLVMBuilderRef @param0, LLVMTypeRef ty, LLVMValueRef val, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAlloca", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAlloca(LLVMBuilderRef @param0, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildArrayAlloca", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildArrayAlloca(LLVMBuilderRef @param0, LLVMTypeRef ty, LLVMValueRef val, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFree", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFree(LLVMBuilderRef @param0, LLVMValueRef pointerVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildLoad", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildLoad(LLVMBuilderRef @param0, LLVMValueRef pointerVal, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildStore", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildStore(LLVMBuilderRef @param0, LLVMValueRef val, LLVMValueRef ptr);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildGEP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildGEP(LLVMBuilderRef b, LLVMValueRef pointer, out LLVMValueRef indices, uint numIndices, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildInBoundsGEP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildInBoundsGEP(LLVMBuilderRef b, LLVMValueRef pointer, out LLVMValueRef indices, uint numIndices, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildStructGEP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildStructGEP(LLVMBuilderRef b, LLVMValueRef pointer, uint idx, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildGlobalString", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildGlobalString(LLVMBuilderRef b, [MarshalAs(UnmanagedType.LPStr)] string str, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildGlobalStringPtr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildGlobalStringPtr(LLVMBuilderRef b, [MarshalAs(UnmanagedType.LPStr)] string str, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetVolatile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetVolatile(LLVMValueRef memoryAccessInst);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetVolatile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVolatile(LLVMValueRef memoryAccessInst, LLVMBool isVolatile);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildTrunc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildTrunc(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildZExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildZExt(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSExt(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFPToUI", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFPToUI(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFPToSI", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFPToSI(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildUIToFP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildUIToFP(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSIToFP", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSIToFP(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFPTrunc", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFPTrunc(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFPExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFPExt(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildPtrToInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildPtrToInt(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildIntToPtr", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildIntToPtr(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildBitCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAddrSpaceCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAddrSpaceCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildZExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildZExtOrBitCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSExtOrBitCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildTruncOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildTruncOrBitCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildCast(LLVMBuilderRef b, LLVMOpcode op, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildPointerCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildPointerCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildIntCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildIntCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFPCast", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFPCast(LLVMBuilderRef @param0, LLVMValueRef val, LLVMTypeRef destTy, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildICmp", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildICmp(LLVMBuilderRef @param0, LLVMIntPredicate op, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFCmp", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFCmp(LLVMBuilderRef @param0, LLVMRealPredicate op, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildPhi", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildPhi(LLVMBuilderRef @param0, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildCall", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildCall(LLVMBuilderRef @param0, LLVMValueRef fn, out LLVMValueRef args, uint numArgs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildSelect", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildSelect(LLVMBuilderRef @param0, LLVMValueRef @If, LLVMValueRef then, LLVMValueRef @Else, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildVAArg", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildVAArg(LLVMBuilderRef @param0, LLVMValueRef list, LLVMTypeRef ty, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildExtractElement", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildExtractElement(LLVMBuilderRef @param0, LLVMValueRef vecVal, LLVMValueRef index, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildInsertElement", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildInsertElement(LLVMBuilderRef @param0, LLVMValueRef vecVal, LLVMValueRef eltVal, LLVMValueRef index, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildShuffleVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildShuffleVector(LLVMBuilderRef @param0, LLVMValueRef v1, LLVMValueRef v2, LLVMValueRef mask, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildExtractValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildExtractValue(LLVMBuilderRef @param0, LLVMValueRef aggVal, uint index, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildInsertValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildInsertValue(LLVMBuilderRef @param0, LLVMValueRef aggVal, LLVMValueRef eltVal, uint index, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildIsNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildIsNull(LLVMBuilderRef @param0, LLVMValueRef val, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildIsNotNull", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildIsNotNull(LLVMBuilderRef @param0, LLVMValueRef val, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildPtrDiff", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildPtrDiff(LLVMBuilderRef @param0, LLVMValueRef lhs, LLVMValueRef rhs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildFence", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildFence(LLVMBuilderRef b, LLVMAtomicOrdering @ordering, LLVMBool @singleThread, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMBuildAtomicRMW", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueRef BuildAtomicRMW(LLVMBuilderRef b, LLVMAtomicRMWBinOp @op, LLVMValueRef ptr, LLVMValueRef val, LLVMAtomicOrdering @ordering, LLVMBool @singleThread);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateModuleProviderForExistingModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleProviderRef CreateModuleProviderForExistingModule(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeModuleProvider", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeModuleProvider(LLVMModuleProviderRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMemoryBufferWithContentsOfFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateMemoryBufferWithContentsOfFile([MarshalAs(UnmanagedType.LPStr)] string path, out LLVMMemoryBufferRef outMemBuf, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMemoryBufferWithSTDIN", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateMemoryBufferWithSTDIN(out LLVMMemoryBufferRef outMemBuf, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRange", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMemoryBufferRef CreateMemoryBufferWithMemoryRange([MarshalAs(UnmanagedType.LPStr)] string inputData, int inputDataLength, [MarshalAs(UnmanagedType.LPStr)] string bufferName, LLVMBool requiresNullTerminator);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRangeCopy", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMemoryBufferRef CreateMemoryBufferWithMemoryRangeCopy([MarshalAs(UnmanagedType.LPStr)] string inputData, int inputDataLength, [MarshalAs(UnmanagedType.LPStr)] string bufferName);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBufferStart", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetBufferStart(LLVMMemoryBufferRef memBuf);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBufferSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBufferSize(LLVMMemoryBufferRef memBuf);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMemoryBuffer(LLVMMemoryBufferRef memBuf);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetGlobalPassRegistry", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMPassRegistryRef GetGlobalPassRegistry();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreatePassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMPassManagerRef CreatePassManager();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateFunctionPassManagerForModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMPassManagerRef CreateFunctionPassManagerForModule(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMPassManagerRef CreateFunctionPassManager(LLVMModuleProviderRef mp);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool RunPassManager(LLVMPassManagerRef pm, LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool InitializeFunctionPassManager(LLVMPassManagerRef fpm);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool RunFunctionPassManager(LLVMPassManagerRef fpm, LLVMValueRef f);

        [DllImport(LibraryPath, EntryPoint = "LLVMFinalizeFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool FinalizeFunctionPassManager(LLVMPassManagerRef fpm);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposePassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposePassManager(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMStartMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool StartMultithreaded();

        [DllImport(LibraryPath, EntryPoint = "LLVMStopMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMultithreaded();

        [DllImport(LibraryPath, EntryPoint = "LLVMIsMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsMultithreaded();

        [DllImport(LibraryPath, EntryPoint = "LLVMVerifyModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool VerifyModule(LLVMModuleRef m, LLVMVerifierFailureAction action, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMVerifyFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool VerifyFunction(LLVMValueRef fn, LLVMVerifierFailureAction action);

        [DllImport(LibraryPath, EntryPoint = "LLVMViewFunctionCFG", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ViewFunctionCFG(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMViewFunctionCFGOnly", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ViewFunctionCFGOnly(LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMParseBitcode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool ParseBitcode(LLVMMemoryBufferRef memBuf, out LLVMModuleRef outModule, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMParseBitcodeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool ParseBitcodeInContext(LLVMContextRef contextRef, LLVMMemoryBufferRef memBuf, out LLVMModuleRef outModule, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBitcodeModuleInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetBitcodeModuleInContext(LLVMContextRef contextRef, LLVMMemoryBufferRef memBuf, out LLVMModuleRef outM, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBitcodeModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetBitcodeModule(LLVMMemoryBufferRef memBuf, out LLVMModuleRef outM, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBitcodeModuleProviderInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetBitcodeModuleProviderInContext(LLVMContextRef contextRef, LLVMMemoryBufferRef memBuf, out LLVMModuleProviderRef outMp, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetBitcodeModuleProvider", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetBitcodeModuleProvider(LLVMMemoryBufferRef memBuf, out LLVMModuleProviderRef outMp, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMWriteBitcodeToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFile(LLVMModuleRef m, [MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(LibraryPath, EntryPoint = "LLVMWriteBitcodeToFD", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFD(LLVMModuleRef m, int fd, int shouldClose, int unbuffered);

        [DllImport(LibraryPath, EntryPoint = "LLVMWriteBitcodeToFileHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFileHandle(LLVMModuleRef m, int handle);

        [DllImport(LibraryPath, EntryPoint = "LLVMWriteBitcodeToMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMemoryBufferRef WriteBitcodeToMemoryBuffer(LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateDisasm", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDisasmContextRef CreateDisasm([MarshalAs(UnmanagedType.LPStr)] string tripleName, IntPtr disInfo, int tagType, LLVMOpInfoCallback getOpInfo, LLVMSymbolLookupCallback symbolLookUp);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateDisasmCPU", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDisasmContextRef CreateDisasmCPU([MarshalAs(UnmanagedType.LPStr)] string triple, [MarshalAs(UnmanagedType.LPStr)] string cpu, IntPtr disInfo, int tagType, LLVMOpInfoCallback getOpInfo, LLVMSymbolLookupCallback symbolLookUp);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateDisasmCPUFeatures", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDisasmContextRef CreateDisasmCPUFeatures([MarshalAs(UnmanagedType.LPStr)] string triple, [MarshalAs(UnmanagedType.LPStr)] string cpu, [MarshalAs(UnmanagedType.LPStr)] string features, IntPtr disInfo, int tagType, LLVMOpInfoCallback getOpInfo, LLVMSymbolLookupCallback symbolLookUp);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetDisasmOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDisasmOptions(LLVMDisasmContextRef dc, int options);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisasmDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisasmDispose(LLVMDisasmContextRef dc);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisasmInstruction", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DisasmInstruction(LLVMDisasmContextRef dc, out char bytes, int bytesSize, int pc, IntPtr outString, int outStringSize);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeR600TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeR600TargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeHexagonTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNVPTXTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeCppBackendTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCppBackendTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMSP430TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430TargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeXCoreTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64TargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86TargetInfo();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeR600Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeR600Target();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeHexagonTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNVPTXTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeCppBackendTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCppBackendTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMSP430Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430Target();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeXCoreTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64Target();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86Target();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeR600TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeR600TargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeHexagonTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNVPTXTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeCppBackendTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCppBackendTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMSP430TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430TargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeXCoreTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64TargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86TargetMC();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeR600AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeR600AsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeHexagonAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNVPTXAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMSP430AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430AsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeXCoreAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64AsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86AsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeR600AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeR600AsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64AsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86AsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSystemZDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeHexagonDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeXCoreDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMipsDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAArch64Disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64Disassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeARMDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializePowerPCDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeSparcDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeX86Disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86Disassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllTargetInfos", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllTargetInfos();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllTargets", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllTargets();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllTargetMCs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllTargetMCs();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllAsmPrinters", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllAsmPrinters();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllAsmParsers", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllAsmParsers();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAllDisassemblers", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAllDisassemblers();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNativeTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool InitializeNativeTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNativeAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool InitializeNativeAsmParser();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNativeAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool InitializeNativeAsmPrinter();

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeNativeDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool InitializeNativeDisassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetDataRef CreateTargetData([MarshalAs(UnmanagedType.LPStr)] string stringRep);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTargetData(LLVMTargetDataRef td, LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddTargetLibraryInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTargetLibraryInfo(LLVMTargetLibraryInfoRef tli, LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMCopyStringRepOfTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CopyStringRepOfTargetData(LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMByteOrder", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMByteOrdering ByteOrder(LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMPointerSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PointerSize(LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMPointerSizeForAS", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PointerSizeForAS(LLVMTargetDataRef td, uint @AS);

        [DllImport(LibraryPath, EntryPoint = "LLVMIntPtrType", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntPtrType(LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMIntPtrTypeForAS", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntPtrTypeForAS(LLVMTargetDataRef td, uint @AS);

        [DllImport(LibraryPath, EntryPoint = "LLVMIntPtrTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntPtrTypeInContext(LLVMContextRef c, LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMIntPtrTypeForASInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeRef IntPtrTypeForASInContext(LLVMContextRef c, LLVMTargetDataRef td, uint @AS);

        [DllImport(LibraryPath, EntryPoint = "LLVMSizeOfTypeInBits", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SizeOfTypeInBits(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMStoreSizeOfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong StoreSizeOfType(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMABISizeOfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong ABISizeOfType(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMABIAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ABIAlignmentOfType(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMCallFrameAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CallFrameAlignmentOfType(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMPreferredAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PreferredAlignmentOfType(LLVMTargetDataRef td, LLVMTypeRef ty);

        [DllImport(LibraryPath, EntryPoint = "LLVMPreferredAlignmentOfGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PreferredAlignmentOfGlobal(LLVMTargetDataRef td, LLVMValueRef globalVar);

        [DllImport(LibraryPath, EntryPoint = "LLVMElementAtOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ElementAtOffset(LLVMTargetDataRef td, LLVMTypeRef structTy, ulong offset);

        [DllImport(LibraryPath, EntryPoint = "LLVMOffsetOfElement", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong OffsetOfElement(LLVMTargetDataRef td, LLVMTypeRef structTy, uint element);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeTargetData(LLVMTargetDataRef td);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFirstTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetRef GetFirstTarget();

        [DllImport(LibraryPath, EntryPoint = "LLVMGetNextTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetRef GetNextTarget(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetFromName", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetRef GetTargetFromName([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetFromTriple", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetTargetFromTriple([MarshalAs(UnmanagedType.LPStr)] string triple, out LLVMTargetRef @T, out IntPtr errorMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetTargetName(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetTargetDescription(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMTargetHasJIT", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetHasJIT(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMTargetHasTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetHasTargetMachine(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMTargetHasAsmBackend", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetHasAsmBackend(LLVMTargetRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetMachineRef CreateTargetMachine(LLVMTargetRef @T, [MarshalAs(UnmanagedType.LPStr)] string triple, [MarshalAs(UnmanagedType.LPStr)] string cpu, [MarshalAs(UnmanagedType.LPStr)] string features, LLVMCodeGenOptLevel level, LLVMRelocMode reloc, LLVMCodeModel codeModel);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeTargetMachine(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetMachineTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetRef GetTargetMachineTarget(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetMachineTriple", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineTriple(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetMachineCPU", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineCPU(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetMachineFeatureString", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetMachineFeatureString(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetTargetMachineData", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetDataRef GetTargetMachineData(LLVMTargetMachineRef @T);

        [DllImport(LibraryPath, EntryPoint = "LLVMSetTargetMachineAsmVerbosity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetMachineAsmVerbosity(LLVMTargetMachineRef @T, LLVMBool verboseAsm);

        [DllImport(LibraryPath, EntryPoint = "LLVMTargetMachineEmitToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetMachineEmitToFile(LLVMTargetMachineRef @T, LLVMModuleRef m, IntPtr filename, LLVMCodeGenFileType @codegen, out IntPtr errorMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMTargetMachineEmitToMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool TargetMachineEmitToMemoryBuffer(LLVMTargetMachineRef @T, LLVMModuleRef m, LLVMCodeGenFileType @codegen, out IntPtr errorMessage, out LLVMMemoryBufferRef outMemBuf);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetDefaultTargetTriple", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDefaultTargetTriple();

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAnalysisPasses", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAnalysisPasses(LLVMTargetMachineRef @T, LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMLinkInMCJIT", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkInMCJIT();

        [DllImport(LibraryPath, EntryPoint = "LLVMLinkInInterpreter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkInInterpreter();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateGenericValueOfInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMGenericValueRef CreateGenericValueOfInt(LLVMTypeRef ty, ulong n, LLVMBool isSigned);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateGenericValueOfPointer", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMGenericValueRef CreateGenericValueOfPointer(IntPtr p);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateGenericValueOfFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMGenericValueRef CreateGenericValueOfFloat(LLVMTypeRef ty, double n);

        [DllImport(LibraryPath, EntryPoint = "LLVMGenericValueIntWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GenericValueIntWidth(LLVMGenericValueRef genValRef);

        [DllImport(LibraryPath, EntryPoint = "LLVMGenericValueToInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GenericValueToInt(LLVMGenericValueRef genVal, LLVMBool isSigned);

        [DllImport(LibraryPath, EntryPoint = "LLVMGenericValueToPointer", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GenericValueToPointer(LLVMGenericValueRef genVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMGenericValueToFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GenericValueToFloat(LLVMTypeRef tyRef, LLVMGenericValueRef genVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeGenericValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeGenericValue(LLVMGenericValueRef genVal);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateExecutionEngineForModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateExecutionEngineForModule(out LLVMExecutionEngineRef outEe, LLVMModuleRef m, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateInterpreterForModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateInterpreterForModule(out LLVMExecutionEngineRef outInterp, LLVMModuleRef m, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateJITCompilerForModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateJITCompilerForModule(out LLVMExecutionEngineRef outJit, LLVMModuleRef m, uint optLevel, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeMCJITCompilerOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMCJITCompilerOptions(out LLVMMCJITCompilerOptions options, int sizeOfOptions);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateMCJITCompilerForModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateMCJITCompilerForModule(out LLVMExecutionEngineRef outJit, LLVMModuleRef m, out LLVMMCJITCompilerOptions options, int sizeOfOptions, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateExecutionEngine", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateExecutionEngine(out LLVMExecutionEngineRef outEe, LLVMModuleProviderRef mp, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateInterpreter", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateInterpreter(out LLVMExecutionEngineRef outInterp, LLVMModuleProviderRef mp, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateJITCompiler", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool CreateJITCompiler(out LLVMExecutionEngineRef outJit, LLVMModuleProviderRef mp, uint optLevel, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeExecutionEngine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeExecutionEngine(LLVMExecutionEngineRef ee);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunStaticConstructors", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunStaticConstructors(LLVMExecutionEngineRef ee);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunStaticDestructors", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunStaticDestructors(LLVMExecutionEngineRef ee);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunFunctionAsMain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RunFunctionAsMain(LLVMExecutionEngineRef ee, LLVMValueRef f, uint argC, string[] argV, string[] envP);

        [DllImport(LibraryPath, EntryPoint = "LLVMRunFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMGenericValueRef RunFunction(LLVMExecutionEngineRef ee, LLVMValueRef f, uint numArgs, out LLVMGenericValueRef args);

        [DllImport(LibraryPath, EntryPoint = "LLVMFreeMachineCodeForFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeMachineCodeForFunction(LLVMExecutionEngineRef ee, LLVMValueRef f);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddModule(LLVMExecutionEngineRef ee, LLVMModuleRef m);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddModuleProvider", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddModuleProvider(LLVMExecutionEngineRef ee, LLVMModuleProviderRef mp);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool RemoveModule(LLVMExecutionEngineRef ee, LLVMModuleRef m, out LLVMModuleRef outMod, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMRemoveModuleProvider", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool RemoveModuleProvider(LLVMExecutionEngineRef ee, LLVMModuleProviderRef mp, out LLVMModuleRef outMod, out IntPtr outError);

        [DllImport(LibraryPath, EntryPoint = "LLVMFindFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool FindFunction(LLVMExecutionEngineRef ee, [MarshalAs(UnmanagedType.LPStr)] string name, out LLVMValueRef outFn);

        [DllImport(LibraryPath, EntryPoint = "LLVMRecompileAndRelinkFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RecompileAndRelinkFunction(LLVMExecutionEngineRef ee, LLVMValueRef fn);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetExecutionEngineTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetDataRef GetExecutionEngineTargetData(LLVMExecutionEngineRef ee);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetExecutionEngineTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTargetMachineRef GetExecutionEngineTargetMachine(LLVMExecutionEngineRef ee);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGlobalMapping", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalMapping(LLVMExecutionEngineRef ee, LLVMValueRef @Global, IntPtr addr);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetPointerToGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetPointerToGlobal(LLVMExecutionEngineRef ee, LLVMValueRef @Global);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetGlobalValueAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlobalValueAddress(LLVMExecutionEngineRef ee, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetFunctionAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFunctionAddress(LLVMExecutionEngineRef ee, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateSimpleMCJITMemoryManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMMCJITMemoryManagerRef CreateSimpleMCJITMemoryManager(IntPtr opaque, LLVMMemoryManagerAllocateCodeSectionCallback allocateCodeSection, LLVMMemoryManagerAllocateDataSectionCallback allocateDataSection, LLVMMemoryManagerFinalizeMemoryCallback finalizeMemory, LLVMMemoryManagerDestroyCallback destroy);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeMCJITMemoryManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMCJITMemoryManager(LLVMMCJITMemoryManagerRef mm);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeTransformUtils", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeTransformUtils(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeScalarOpts", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeScalarOpts(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeObjCARCOpts", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeObjCARCOpts(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeVectorization", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeVectorization(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeInstCombine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeInstCombine(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeIPO", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeIPO(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeInstrumentation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeInstrumentation(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeAnalysis", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAnalysis(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeIPA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeIPA(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeCodeGen", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCodeGen(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMInitializeTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeTarget(LLVMPassRegistryRef r);

        [DllImport(LibraryPath, EntryPoint = "LLVMParseIRInContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool ParseIRInContext(LLVMContextRef contextRef, LLVMMemoryBufferRef memBuf, out LLVMModuleRef outM, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "LLVMLinkModules", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool LinkModules(LLVMModuleRef dest, LLVMModuleRef src, uint unused, out IntPtr outMessage);

        [DllImport(LibraryPath, EntryPoint = "llvm_create_optimizer", CallingConvention = CallingConvention.Cdecl)]
        public static extern llvm_lto_t llvm_create_optimizer();

        [DllImport(LibraryPath, EntryPoint = "llvm_destroy_optimizer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llvm_destroy_optimizer(llvm_lto_t @lto);

        [DllImport(LibraryPath, EntryPoint = "llvm_read_object_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern llvm_lto_status llvm_read_object_file(llvm_lto_t @lto, [MarshalAs(UnmanagedType.LPStr)] string inputFilename);

        [DllImport(LibraryPath, EntryPoint = "llvm_optimize_modules", CallingConvention = CallingConvention.Cdecl)]
        public static extern llvm_lto_status llvm_optimize_modules(llvm_lto_t @lto, [MarshalAs(UnmanagedType.LPStr)] string outputFilename);

        [DllImport(LibraryPath, EntryPoint = "lto_get_version", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_get_version();

        [DllImport(LibraryPath, EntryPoint = "lto_get_error_message", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_get_error_message();

        [DllImport(LibraryPath, EntryPoint = "lto_module_is_object_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_module_is_object_file([MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_module_is_object_file_for_target", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_module_is_object_file_for_target([MarshalAs(UnmanagedType.LPStr)] string @path, [MarshalAs(UnmanagedType.LPStr)] string targetTriplePrefix);

        [DllImport(LibraryPath, EntryPoint = "lto_module_is_object_file_in_memory", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_module_is_object_file_in_memory(IntPtr @mem, int @length);

        [DllImport(LibraryPath, EntryPoint = "lto_module_is_object_file_in_memory_for_target", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_module_is_object_file_in_memory_for_target(IntPtr @mem, int @length, [MarshalAs(UnmanagedType.LPStr)] string targetTriplePrefix);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create([MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_from_memory", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_from_memory(IntPtr @mem, int @length);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_from_memory_with_path", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_from_memory_with_path(IntPtr @mem, int @length, [MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_in_local_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_in_local_context(IntPtr @mem, int @length, [MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_in_codegen_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_in_codegen_context(IntPtr @mem, int @length, [MarshalAs(UnmanagedType.LPStr)] string @path, lto_code_gen_t @cg);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_from_fd", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_from_fd(int @fd, [MarshalAs(UnmanagedType.LPStr)] string @path, int fileSize);

        [DllImport(LibraryPath, EntryPoint = "lto_module_create_from_fd_at_offset", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_module_t lto_module_create_from_fd_at_offset(int @fd, [MarshalAs(UnmanagedType.LPStr)] string @path, int fileSize, int mapSize, int @offset);

        [DllImport(LibraryPath, EntryPoint = "lto_module_dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_module_dispose(lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_target_triple", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_module_get_target_triple(lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_module_set_target_triple", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_module_set_target_triple(lto_module_t @mod, [MarshalAs(UnmanagedType.LPStr)] string @triple);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_num_symbols", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint lto_module_get_num_symbols(lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_symbol_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_module_get_symbol_name(lto_module_t @mod, uint @index);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_symbol_attribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_symbol_attributes lto_module_get_symbol_attribute(lto_module_t @mod, uint @index);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_num_deplibs", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint lto_module_get_num_deplibs(lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_deplib", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_module_get_deplib(lto_module_t @mod, uint @index);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_num_linkeropts", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint lto_module_get_num_linkeropts(lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_module_get_linkeropt", CallingConvention = CallingConvention.Cdecl)]
        public static extern string lto_module_get_linkeropt(lto_module_t @mod, uint @index);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_diagnostic_handler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_diagnostic_handler(lto_code_gen_t @param0, lto_diagnostic_handler_t @param1, IntPtr @param2);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_create", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_code_gen_t lto_codegen_create();

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_create_in_local_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_code_gen_t lto_codegen_create_in_local_context();

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_dispose(lto_code_gen_t @param0);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_add_module", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_codegen_add_module(lto_code_gen_t @cg, lto_module_t @mod);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_debug_model", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_codegen_set_debug_model(lto_code_gen_t @cg, lto_debug_model @param1);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_pic_model", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_codegen_set_pic_model(lto_code_gen_t @cg, lto_codegen_model @param1);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_cpu", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_cpu(lto_code_gen_t @cg, [MarshalAs(UnmanagedType.LPStr)] string @cpu);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_assembler_path", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_assembler_path(lto_code_gen_t @cg, [MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_set_assembler_args", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_assembler_args(lto_code_gen_t @cg, out IntPtr @args, int @nargs);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_add_must_preserve_symbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_add_must_preserve_symbol(lto_code_gen_t @cg, [MarshalAs(UnmanagedType.LPStr)] string @symbol);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_write_merged_modules", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_codegen_write_merged_modules(lto_code_gen_t @cg, [MarshalAs(UnmanagedType.LPStr)] string @path);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_compile", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lto_codegen_compile(lto_code_gen_t @cg, out int @length);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_compile_to_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_bool_t lto_codegen_compile_to_file(lto_code_gen_t @cg, out IntPtr @name);

        [DllImport(LibraryPath, EntryPoint = "lto_codegen_debug_options", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_debug_options(lto_code_gen_t @cg, [MarshalAs(UnmanagedType.LPStr)] string @param1);

        [DllImport(LibraryPath, EntryPoint = "lto_initialize_disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_initialize_disassembler();

        [DllImport(LibraryPath, EntryPoint = "LLVMCreateObjectFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMObjectFileRef CreateObjectFile(LLVMMemoryBufferRef memBuf);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeObjectFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeObjectFile(LLVMObjectFileRef objectFile);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSections", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMSectionIteratorRef GetSections(LLVMObjectFileRef objectFile);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeSectionIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeSectionIterator(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsSectionIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsSectionIteratorAtEnd(LLVMObjectFileRef objectFile, LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveToNextSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextSection(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveToContainingSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToContainingSection(LLVMSectionIteratorRef sect, LLVMSymbolIteratorRef sym);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSymbols", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMSymbolIteratorRef GetSymbols(LLVMObjectFileRef objectFile);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeSymbolIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeSymbolIterator(LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsSymbolIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsSymbolIteratorAtEnd(LLVMObjectFileRef objectFile, LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveToNextSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextSymbol(LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSectionName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetSectionName(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSectionSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSectionSize(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSectionContents", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetSectionContents(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSectionAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSectionAddress(LLVMSectionIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSectionContainsSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool GetSectionContainsSymbol(LLVMSectionIteratorRef si, LLVMSymbolIteratorRef sym);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocations", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMRelocationIteratorRef GetRelocations(LLVMSectionIteratorRef section);

        [DllImport(LibraryPath, EntryPoint = "LLVMDisposeRelocationIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeRelocationIterator(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMIsRelocationIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMBool IsRelocationIteratorAtEnd(LLVMSectionIteratorRef section, LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMMoveToNextRelocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextRelocation(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSymbolName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetSymbolName(LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSymbolAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSymbolAddress(LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetSymbolSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSymbolSize(LLVMSymbolIteratorRef si);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRelocationAddress(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRelocationOffset(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMSymbolIteratorRef GetRelocationSymbol(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRelocationType(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationTypeName", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetRelocationTypeName(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMGetRelocationValueString", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetRelocationValueString(LLVMRelocationIteratorRef ri);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddArgumentPromotionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddArgumentPromotionPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddConstantMergePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConstantMergePass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddDeadArgEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDeadArgEliminationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddFunctionAttrsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionAttrsPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddFunctionInliningPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionInliningPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAlwaysInlinerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAlwaysInlinerPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGlobalDCEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalDCEPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGlobalOptimizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalOptimizerPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddIPConstantPropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIPConstantPropagationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddPruneEHPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPruneEHPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddIPSCCPPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIPSCCPPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddInternalizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInternalizePass(LLVMPassManagerRef @param0, uint allButMain);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddStripDeadPrototypesPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddStripDeadPrototypesPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddStripSymbolsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddStripSymbolsPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMPassManagerBuilderRef PassManagerBuilderCreate();

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderDispose(LLVMPassManagerBuilderRef pmb);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderSetOptLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetOptLevel(LLVMPassManagerBuilderRef pmb, uint optLevel);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderSetSizeLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetSizeLevel(LLVMPassManagerBuilderRef pmb, uint sizeLevel);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableUnitAtATime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableUnitAtATime(LLVMPassManagerBuilderRef pmb, LLVMBool value);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableUnrollLoops", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableUnrollLoops(LLVMPassManagerBuilderRef pmb, LLVMBool value);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableSimplifyLibCalls", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableSimplifyLibCalls(LLVMPassManagerBuilderRef pmb, LLVMBool value);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderUseInlinerWithThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderUseInlinerWithThreshold(LLVMPassManagerBuilderRef pmb, uint threshold);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateFunctionPassManager(LLVMPassManagerBuilderRef pmb, LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateModulePassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateModulePassManager(LLVMPassManagerBuilderRef pmb, LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateLTOPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateLTOPassManager(LLVMPassManagerBuilderRef pmb, LLVMPassManagerRef pm, LLVMBool internalize, LLVMBool runInliner);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAggressiveDCEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAggressiveDCEPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddAlignmentFromAssumptionsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAlignmentFromAssumptionsPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddCFGSimplificationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCFGSimplificationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddDeadStoreEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDeadStoreEliminationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddScalarizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarizerPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddMergedLoadStoreMotionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddMergedLoadStoreMotionPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddGVNPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGVNPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddIndVarSimplifyPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIndVarSimplifyPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddInstructionCombiningPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInstructionCombiningPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddJumpThreadingPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddJumpThreadingPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLICMPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLICMPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopDeletionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopDeletionPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopIdiomPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopIdiomPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopRotatePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopRotatePass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopRerollPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopRerollPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopUnrollPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopUnrollPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopUnswitchPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopUnswitchPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddMemCpyOptPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddMemCpyOptPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddPartiallyInlineLibCallsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPartiallyInlineLibCallsPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLowerSwitchPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLowerSwitchPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddPromoteMemoryToRegisterPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPromoteMemoryToRegisterPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddReassociatePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddReassociatePass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddSCCPPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSCCPPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPassSSA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPassSSA(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPassWithThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPassWithThreshold(LLVMPassManagerRef pm, int threshold);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddSimplifyLibCallsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSimplifyLibCallsPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddTailCallEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTailCallEliminationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddConstantPropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConstantPropagationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddDemoteMemoryToRegisterPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDemoteMemoryToRegisterPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddVerifierPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddVerifierPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddCorrelatedValuePropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCorrelatedValuePropagationPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddEarlyCSEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddEarlyCSEPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLowerExpectIntrinsicPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLowerExpectIntrinsicPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddTypeBasedAliasAnalysisPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTypeBasedAliasAnalysisPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddScopedNoAliasAAPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScopedNoAliasAAPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddBasicAliasAnalysisPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddBasicAliasAnalysisPass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddBBVectorizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddBBVectorizePass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddLoopVectorizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopVectorizePass(LLVMPassManagerRef pm);

        [DllImport(LibraryPath, EntryPoint = "LLVMAddSLPVectorizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSLPVectorizePass(LLVMPassManagerRef pm);

    }
}
