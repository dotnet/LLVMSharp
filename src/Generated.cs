using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public enum LLVMVerifierFailureAction
    {
        LLVMAbortProcessAction = 0,
        LLVMPrintMessageAction = 1,
        LLVMReturnStatusAction = 2,
    }

    public enum LLVMComdatSelectionKind
    {
        LLVMAnyComdatSelectionKind = 0,
        LLVMExactMatchComdatSelectionKind = 1,
        LLVMLargestComdatSelectionKind = 2,
        LLVMNoDuplicatesComdatSelectionKind = 3,
        LLVMSameSizeComdatSelectionKind = 4,
    }

    public enum LLVMOpcode
    {
        LLVMRet = 1,
        LLVMBr = 2,
        LLVMSwitch = 3,
        LLVMIndirectBr = 4,
        LLVMInvoke = 5,
        LLVMUnreachable = 7,
        LLVMFNeg = 66,
        LLVMAdd = 8,
        LLVMFAdd = 9,
        LLVMSub = 10,
        LLVMFSub = 11,
        LLVMMul = 12,
        LLVMFMul = 13,
        LLVMUDiv = 14,
        LLVMSDiv = 15,
        LLVMFDiv = 16,
        LLVMURem = 17,
        LLVMSRem = 18,
        LLVMFRem = 19,
        LLVMShl = 20,
        LLVMLShr = 21,
        LLVMAShr = 22,
        LLVMAnd = 23,
        LLVMOr = 24,
        LLVMXor = 25,
        LLVMAlloca = 26,
        LLVMLoad = 27,
        LLVMStore = 28,
        LLVMGetElementPtr = 29,
        LLVMTrunc = 30,
        LLVMZExt = 31,
        LLVMSExt = 32,
        LLVMFPToUI = 33,
        LLVMFPToSI = 34,
        LLVMUIToFP = 35,
        LLVMSIToFP = 36,
        LLVMFPTrunc = 37,
        LLVMFPExt = 38,
        LLVMPtrToInt = 39,
        LLVMIntToPtr = 40,
        LLVMBitCast = 41,
        LLVMAddrSpaceCast = 60,
        LLVMICmp = 42,
        LLVMFCmp = 43,
        LLVMPHI = 44,
        LLVMCall = 45,
        LLVMSelect = 46,
        LLVMUserOp1 = 47,
        LLVMUserOp2 = 48,
        LLVMVAArg = 49,
        LLVMExtractElement = 50,
        LLVMInsertElement = 51,
        LLVMShuffleVector = 52,
        LLVMExtractValue = 53,
        LLVMInsertValue = 54,
        LLVMFence = 55,
        LLVMAtomicCmpXchg = 56,
        LLVMAtomicRMW = 57,
        LLVMResume = 58,
        LLVMLandingPad = 59,
        LLVMCleanupRet = 61,
        LLVMCatchRet = 62,
        LLVMCatchPad = 63,
        LLVMCleanupPad = 64,
        LLVMCatchSwitch = 65,
    }

    public enum LLVMTypeKind
    {
        LLVMVoidTypeKind = 0,
        LLVMHalfTypeKind = 1,
        LLVMFloatTypeKind = 2,
        LLVMDoubleTypeKind = 3,
        LLVMX86_FP80TypeKind = 4,
        LLVMFP128TypeKind = 5,
        LLVMPPC_FP128TypeKind = 6,
        LLVMLabelTypeKind = 7,
        LLVMIntegerTypeKind = 8,
        LLVMFunctionTypeKind = 9,
        LLVMStructTypeKind = 10,
        LLVMArrayTypeKind = 11,
        LLVMPointerTypeKind = 12,
        LLVMVectorTypeKind = 13,
        LLVMMetadataTypeKind = 14,
        LLVMX86_MMXTypeKind = 15,
        LLVMTokenTypeKind = 16,
    }

    public enum LLVMLinkage
    {
        LLVMExternalLinkage = 0,
        LLVMAvailableExternallyLinkage = 1,
        LLVMLinkOnceAnyLinkage = 2,
        LLVMLinkOnceODRLinkage = 3,
        LLVMLinkOnceODRAutoHideLinkage = 4,
        LLVMWeakAnyLinkage = 5,
        LLVMWeakODRLinkage = 6,
        LLVMAppendingLinkage = 7,
        LLVMInternalLinkage = 8,
        LLVMPrivateLinkage = 9,
        LLVMDLLImportLinkage = 10,
        LLVMDLLExportLinkage = 11,
        LLVMExternalWeakLinkage = 12,
        LLVMGhostLinkage = 13,
        LLVMCommonLinkage = 14,
        LLVMLinkerPrivateLinkage = 15,
        LLVMLinkerPrivateWeakLinkage = 16,
    }

    public enum LLVMVisibility
    {
        LLVMDefaultVisibility = 0,
        LLVMHiddenVisibility = 1,
        LLVMProtectedVisibility = 2,
    }

    public enum LLVMUnnamedAddr
    {
        LLVMNoUnnamedAddr = 0,
        LLVMLocalUnnamedAddr = 1,
        LLVMGlobalUnnamedAddr = 2,
    }

    public enum LLVMDLLStorageClass
    {
        LLVMDefaultStorageClass = 0,
        LLVMDLLImportStorageClass = 1,
        LLVMDLLExportStorageClass = 2,
    }

    public enum LLVMCallConv
    {
        LLVMCCallConv = 0,
        LLVMFastCallConv = 8,
        LLVMColdCallConv = 9,
        LLVMGHCCallConv = 10,
        LLVMHiPECallConv = 11,
        LLVMWebKitJSCallConv = 12,
        LLVMAnyRegCallConv = 13,
        LLVMPreserveMostCallConv = 14,
        LLVMPreserveAllCallConv = 15,
        LLVMSwiftCallConv = 16,
        LLVMCXXFASTTLSCallConv = 17,
        LLVMX86StdcallCallConv = 64,
        LLVMX86FastcallCallConv = 65,
        LLVMARMAPCSCallConv = 66,
        LLVMARMAAPCSCallConv = 67,
        LLVMARMAAPCSVFPCallConv = 68,
        LLVMMSP430INTRCallConv = 69,
        LLVMX86ThisCallCallConv = 70,
        LLVMPTXKernelCallConv = 71,
        LLVMPTXDeviceCallConv = 72,
        LLVMSPIRFUNCCallConv = 75,
        LLVMSPIRKERNELCallConv = 76,
        LLVMIntelOCLBICallConv = 77,
        LLVMX8664SysVCallConv = 78,
        LLVMWin64CallConv = 79,
        LLVMX86VectorCallCallConv = 80,
        LLVMHHVMCallConv = 81,
        LLVMHHVMCCallConv = 82,
        LLVMX86INTRCallConv = 83,
        LLVMAVRINTRCallConv = 84,
        LLVMAVRSIGNALCallConv = 85,
        LLVMAVRBUILTINCallConv = 86,
        LLVMAMDGPUVSCallConv = 87,
        LLVMAMDGPUGSCallConv = 88,
        LLVMAMDGPUPSCallConv = 89,
        LLVMAMDGPUCSCallConv = 90,
        LLVMAMDGPUKERNELCallConv = 91,
        LLVMX86RegCallCallConv = 92,
        LLVMAMDGPUHSCallConv = 93,
        LLVMMSP430BUILTINCallConv = 94,
        LLVMAMDGPULSCallConv = 95,
        LLVMAMDGPUESCallConv = 96,
    }

    public enum LLVMValueKind
    {
        LLVMArgumentValueKind = 0,
        LLVMBasicBlockValueKind = 1,
        LLVMMemoryUseValueKind = 2,
        LLVMMemoryDefValueKind = 3,
        LLVMMemoryPhiValueKind = 4,
        LLVMFunctionValueKind = 5,
        LLVMGlobalAliasValueKind = 6,
        LLVMGlobalIFuncValueKind = 7,
        LLVMGlobalVariableValueKind = 8,
        LLVMBlockAddressValueKind = 9,
        LLVMConstantExprValueKind = 10,
        LLVMConstantArrayValueKind = 11,
        LLVMConstantStructValueKind = 12,
        LLVMConstantVectorValueKind = 13,
        LLVMUndefValueValueKind = 14,
        LLVMConstantAggregateZeroValueKind = 15,
        LLVMConstantDataArrayValueKind = 16,
        LLVMConstantDataVectorValueKind = 17,
        LLVMConstantIntValueKind = 18,
        LLVMConstantFPValueKind = 19,
        LLVMConstantPointerNullValueKind = 20,
        LLVMConstantTokenNoneValueKind = 21,
        LLVMMetadataAsValueValueKind = 22,
        LLVMInlineAsmValueKind = 23,
        LLVMInstructionValueKind = 24,
    }

    public enum LLVMIntPredicate
    {
        LLVMIntEQ = 32,
        LLVMIntNE = 33,
        LLVMIntUGT = 34,
        LLVMIntUGE = 35,
        LLVMIntULT = 36,
        LLVMIntULE = 37,
        LLVMIntSGT = 38,
        LLVMIntSGE = 39,
        LLVMIntSLT = 40,
        LLVMIntSLE = 41,
    }

    public enum LLVMRealPredicate
    {
        LLVMRealPredicateFalse = 0,
        LLVMRealOEQ = 1,
        LLVMRealOGT = 2,
        LLVMRealOGE = 3,
        LLVMRealOLT = 4,
        LLVMRealOLE = 5,
        LLVMRealONE = 6,
        LLVMRealORD = 7,
        LLVMRealUNO = 8,
        LLVMRealUEQ = 9,
        LLVMRealUGT = 10,
        LLVMRealUGE = 11,
        LLVMRealULT = 12,
        LLVMRealULE = 13,
        LLVMRealUNE = 14,
        LLVMRealPredicateTrue = 15,
    }

    public enum LLVMLandingPadClauseTy
    {
        LLVMLandingPadCatch = 0,
        LLVMLandingPadFilter = 1,
    }

    public enum LLVMThreadLocalMode
    {
        LLVMNotThreadLocal = 0,
        LLVMGeneralDynamicTLSModel = 1,
        LLVMLocalDynamicTLSModel = 2,
        LLVMInitialExecTLSModel = 3,
        LLVMLocalExecTLSModel = 4,
    }

    public enum LLVMAtomicOrdering
    {
        LLVMAtomicOrderingNotAtomic = 0,
        LLVMAtomicOrderingUnordered = 1,
        LLVMAtomicOrderingMonotonic = 2,
        LLVMAtomicOrderingAcquire = 4,
        LLVMAtomicOrderingRelease = 5,
        LLVMAtomicOrderingAcquireRelease = 6,
        LLVMAtomicOrderingSequentiallyConsistent = 7,
    }

    public enum LLVMAtomicRMWBinOp
    {
        LLVMAtomicRMWBinOpXchg = 0,
        LLVMAtomicRMWBinOpAdd = 1,
        LLVMAtomicRMWBinOpSub = 2,
        LLVMAtomicRMWBinOpAnd = 3,
        LLVMAtomicRMWBinOpNand = 4,
        LLVMAtomicRMWBinOpOr = 5,
        LLVMAtomicRMWBinOpXor = 6,
        LLVMAtomicRMWBinOpMax = 7,
        LLVMAtomicRMWBinOpMin = 8,
        LLVMAtomicRMWBinOpUMax = 9,
        LLVMAtomicRMWBinOpUMin = 10,
    }

    public enum LLVMDiagnosticSeverity
    {
        LLVMDSError = 0,
        LLVMDSWarning = 1,
        LLVMDSRemark = 2,
        LLVMDSNote = 3,
    }

    public enum LLVMInlineAsmDialect
    {
        LLVMInlineAsmDialectATT = 0,
        LLVMInlineAsmDialectIntel = 1,
    }

    public enum LLVMModuleFlagBehavior
    {
        LLVMModuleFlagBehaviorError = 0,
        LLVMModuleFlagBehaviorWarning = 1,
        LLVMModuleFlagBehaviorRequire = 2,
        LLVMModuleFlagBehaviorOverride = 3,
        LLVMModuleFlagBehaviorAppend = 4,
        LLVMModuleFlagBehaviorAppendUnique = 5,
    }

    public enum LLVMAttributeIndex
    {
        LLVMAttributeReturnIndex = 0,
        LLVMAttributeFunctionIndex = -1,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMDiagnosticHandler(LLVMDiagnosticInfoRef param0, IntPtr param1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMYieldCallback(LLVMContextRef param0, IntPtr param1);

    public partial struct ssize_t
    {
        public ssize_t(long value)
        {
            Value = value;
        }

        public long Value;
    }

    public enum LLVMDIFlags
    {
        LLVMDIFlagZero = 0,
        LLVMDIFlagPrivate = 1,
        LLVMDIFlagProtected = 2,
        LLVMDIFlagPublic = 3,
        LLVMDIFlagFwdDecl = 4,
        LLVMDIFlagAppleBlock = 8,
        LLVMDIFlagBlockByrefStruct = 16,
        LLVMDIFlagVirtual = 32,
        LLVMDIFlagArtificial = 64,
        LLVMDIFlagExplicit = 128,
        LLVMDIFlagPrototyped = 256,
        LLVMDIFlagObjcClassComplete = 512,
        LLVMDIFlagObjectPointer = 1024,
        LLVMDIFlagVector = 2048,
        LLVMDIFlagStaticMember = 4096,
        LLVMDIFlagLValueReference = 8192,
        LLVMDIFlagRValueReference = 16384,
        LLVMDIFlagReserved = 32768,
        LLVMDIFlagSingleInheritance = 65536,
        LLVMDIFlagMultipleInheritance = 131072,
        LLVMDIFlagVirtualInheritance = 196608,
        LLVMDIFlagIntroducedVirtual = 262144,
        LLVMDIFlagBitField = 524288,
        LLVMDIFlagNoReturn = 1048576,
        LLVMDIFlagMainSubprogram = 2097152,
        LLVMDIFlagTypePassByValue = 4194304,
        LLVMDIFlagTypePassByReference = 8388608,
        LLVMDIFlagEnumClass = 16777216,
        LLVMDIFlagFixedEnum = 16777216,
        LLVMDIFlagThunk = 33554432,
        LLVMDIFlagTrivial = 67108864,
        LLVMDIFlagBigEndian = 134217728,
        LLVMDIFlagLittleEndian = 268435456,
        LLVMDIFlagIndirectVirtualBase = 36,
        LLVMDIFlagAccessibility = 3,
        LLVMDIFlagPtrToMemberRep = 196608,
    }

    public enum LLVMDWARFSourceLanguage
    {
        LLVMDWARFSourceLanguageC89 = 0,
        LLVMDWARFSourceLanguageC = 1,
        LLVMDWARFSourceLanguageAda83 = 2,
        LLVMDWARFSourceLanguageC_plus_plus = 3,
        LLVMDWARFSourceLanguageCobol74 = 4,
        LLVMDWARFSourceLanguageCobol85 = 5,
        LLVMDWARFSourceLanguageFortran77 = 6,
        LLVMDWARFSourceLanguageFortran90 = 7,
        LLVMDWARFSourceLanguagePascal83 = 8,
        LLVMDWARFSourceLanguageModula2 = 9,
        LLVMDWARFSourceLanguageJava = 10,
        LLVMDWARFSourceLanguageC99 = 11,
        LLVMDWARFSourceLanguageAda95 = 12,
        LLVMDWARFSourceLanguageFortran95 = 13,
        LLVMDWARFSourceLanguagePLI = 14,
        LLVMDWARFSourceLanguageObjC = 15,
        LLVMDWARFSourceLanguageObjC_plus_plus = 16,
        LLVMDWARFSourceLanguageUPC = 17,
        LLVMDWARFSourceLanguageD = 18,
        LLVMDWARFSourceLanguagePython = 19,
        LLVMDWARFSourceLanguageOpenCL = 20,
        LLVMDWARFSourceLanguageGo = 21,
        LLVMDWARFSourceLanguageModula3 = 22,
        LLVMDWARFSourceLanguageHaskell = 23,
        LLVMDWARFSourceLanguageC_plus_plus_03 = 24,
        LLVMDWARFSourceLanguageC_plus_plus_11 = 25,
        LLVMDWARFSourceLanguageOCaml = 26,
        LLVMDWARFSourceLanguageRust = 27,
        LLVMDWARFSourceLanguageC11 = 28,
        LLVMDWARFSourceLanguageSwift = 29,
        LLVMDWARFSourceLanguageJulia = 30,
        LLVMDWARFSourceLanguageDylan = 31,
        LLVMDWARFSourceLanguageC_plus_plus_14 = 32,
        LLVMDWARFSourceLanguageFortran03 = 33,
        LLVMDWARFSourceLanguageFortran08 = 34,
        LLVMDWARFSourceLanguageRenderScript = 35,
        LLVMDWARFSourceLanguageBLISS = 36,
        LLVMDWARFSourceLanguageMips_Assembler = 37,
        LLVMDWARFSourceLanguageGOOGLE_RenderScript = 38,
        LLVMDWARFSourceLanguageBORLAND_Delphi = 39,
    }

    public enum LLVMDWARFEmissionKind
    {
        LLVMDWARFEmissionNone = 0,
        LLVMDWARFEmissionFull = 1,
        LLVMDWARFEmissionLineTablesOnly = 2,
    }

    public enum LLVMMetadataKind
    {
        LLVMMDStringMetadataKind = 0,
        LLVMConstantAsMetadataMetadataKind = 1,
        LLVMLocalAsMetadataMetadataKind = 2,
        LLVMDistinctMDOperandPlaceholderMetadataKind = 3,
        LLVMMDTupleMetadataKind = 4,
        LLVMDILocationMetadataKind = 5,
        LLVMDIExpressionMetadataKind = 6,
        LLVMDIGlobalVariableExpressionMetadataKind = 7,
        LLVMGenericDINodeMetadataKind = 8,
        LLVMDISubrangeMetadataKind = 9,
        LLVMDIEnumeratorMetadataKind = 10,
        LLVMDIBasicTypeMetadataKind = 11,
        LLVMDIDerivedTypeMetadataKind = 12,
        LLVMDICompositeTypeMetadataKind = 13,
        LLVMDISubroutineTypeMetadataKind = 14,
        LLVMDIFileMetadataKind = 15,
        LLVMDICompileUnitMetadataKind = 16,
        LLVMDISubprogramMetadataKind = 17,
        LLVMDILexicalBlockMetadataKind = 18,
        LLVMDILexicalBlockFileMetadataKind = 19,
        LLVMDINamespaceMetadataKind = 20,
        LLVMDIModuleMetadataKind = 21,
        LLVMDITemplateTypeParameterMetadataKind = 22,
        LLVMDITemplateValueParameterMetadataKind = 23,
        LLVMDIGlobalVariableMetadataKind = 24,
        LLVMDILocalVariableMetadataKind = 25,
        LLVMDILabelMetadataKind = 26,
        LLVMDIObjCPropertyMetadataKind = 27,
        LLVMDIImportedEntityMetadataKind = 28,
        LLVMDIMacroMetadataKind = 29,
        LLVMDIMacroFileMetadataKind = 30,
    }

    public partial struct LLVMDWARFTypeEncoding
    {
        public LLVMDWARFTypeEncoding(uint value)
        {
            Value = value;
        }

        public uint Value;
    }

    public partial struct LLVMDisasmContextRef
    {
        public LLVMDisasmContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LLVMOpInfoCallback(IntPtr DisInfo, ulong PC, ulong Offset, ulong Size, int TagType, IntPtr TagBuf);

    public partial struct LLVMOpInfoSymbol1
    {
        public ulong Present;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Name;
        public ulong Value;
    }

    public partial struct LLVMOpInfo1
    {
        public LLVMOpInfoSymbol1 AddSymbol;
        public LLVMOpInfoSymbol1 SubtractSymbol;
        public ulong Value;
        public ulong VariantKind;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string LLVMSymbolLookupCallback(IntPtr DisInfo, ulong ReferenceValue, out ulong ReferenceType, ulong ReferencePC, out IntPtr ReferenceName);

    public partial struct LLVMOpaqueError
    {
    }

    public partial struct LLVMErrorRef
    {
        public LLVMErrorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMErrorTypeId
    {
        public LLVMErrorTypeId(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMFatalErrorHandler([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string Reason);

    public partial struct LLVMOpaqueGenericValue
    {
    }

    public partial struct LLVMGenericValueRef
    {
        public LLVMGenericValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueExecutionEngine
    {
    }

    public partial struct LLVMExecutionEngineRef
    {
        public LLVMExecutionEngineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueMCJITMemoryManager
    {
    }

    public partial struct LLVMMCJITMemoryManagerRef
    {
        public LLVMMCJITMemoryManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMMCJITCompilerOptions
    {
        public uint OptLevel;
        public LLVMCodeModel CodeModel;
        public LLVMBool NoFramePointerElim;
        public LLVMBool EnableFastISel;
        public LLVMMCJITMemoryManagerRef MCJMM;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LLVMMemoryManagerAllocateCodeSectionCallback(IntPtr Opaque, UIntPtr Size, uint Alignment, uint SectionID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string SectionName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LLVMMemoryManagerAllocateDataSectionCallback(IntPtr Opaque, UIntPtr Size, uint Alignment, uint SectionID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string SectionName, LLVMBool IsReadOnly);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate LLVMBool LLVMMemoryManagerFinalizeMemoryCallback(IntPtr Opaque, out IntPtr ErrMsg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMMemoryManagerDestroyCallback(IntPtr Opaque);

    public enum LLVMLinkerMode
    {
        LLVMLinkerDestroySource = 0,
        LLVMLinkerPreserveSource_Removed = 1,
    }

    public partial struct llvm_lto_t
    {
        public llvm_lto_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public enum llvm_lto_status
    {
        LLVM_LTO_UNKNOWN = 0,
        LLVM_LTO_OPT_SUCCESS = 1,
        LLVM_LTO_READ_SUCCESS = 2,
        LLVM_LTO_READ_FAILURE = 3,
        LLVM_LTO_WRITE_FAILURE = 4,
        LLVM_LTO_NO_TARGET = 5,
        LLVM_LTO_NO_WORK = 6,
        LLVM_LTO_MODULE_MERGE_FAILURE = 7,
        LLVM_LTO_ASM_FAILURE = 8,
        LLVM_LTO_NULL_OBJECT = 9,
    }

    public partial struct lto_bool_t
    {
        public lto_bool_t(bool value)
        {
            Value = value;
        }

        public bool Value;
    }

    public enum lto_symbol_attributes
    {
        LTO_SYMBOL_ALIGNMENT_MASK = 31,
        LTO_SYMBOL_PERMISSIONS_MASK = 224,
        LTO_SYMBOL_PERMISSIONS_CODE = 160,
        LTO_SYMBOL_PERMISSIONS_DATA = 192,
        LTO_SYMBOL_PERMISSIONS_RODATA = 128,
        LTO_SYMBOL_DEFINITION_MASK = 1792,
        LTO_SYMBOL_DEFINITION_REGULAR = 256,
        LTO_SYMBOL_DEFINITION_TENTATIVE = 512,
        LTO_SYMBOL_DEFINITION_WEAK = 768,
        LTO_SYMBOL_DEFINITION_UNDEFINED = 1024,
        LTO_SYMBOL_DEFINITION_WEAKUNDEF = 1280,
        LTO_SYMBOL_SCOPE_MASK = 14336,
        LTO_SYMBOL_SCOPE_INTERNAL = 2048,
        LTO_SYMBOL_SCOPE_HIDDEN = 4096,
        LTO_SYMBOL_SCOPE_PROTECTED = 8192,
        LTO_SYMBOL_SCOPE_DEFAULT = 6144,
        LTO_SYMBOL_SCOPE_DEFAULT_CAN_BE_HIDDEN = 10240,
        LTO_SYMBOL_COMDAT = 16384,
        LTO_SYMBOL_ALIAS = 32768,
    }

    public enum lto_debug_model
    {
        LTO_DEBUG_MODEL_NONE = 0,
        LTO_DEBUG_MODEL_DWARF = 1,
    }

    public enum lto_codegen_model
    {
        LTO_CODEGEN_PIC_MODEL_STATIC = 0,
        LTO_CODEGEN_PIC_MODEL_DYNAMIC = 1,
        LTO_CODEGEN_PIC_MODEL_DYNAMIC_NO_PIC = 2,
        LTO_CODEGEN_PIC_MODEL_DEFAULT = 3,
    }

    public partial struct LLVMOpaqueLTOModule
    {
    }

    public partial struct lto_module_t
    {
        public lto_module_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueLTOCodeGenerator
    {
    }

    public partial struct lto_code_gen_t
    {
        public lto_code_gen_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueThinLTOCodeGenerator
    {
    }

    public partial struct thinlto_code_gen_t
    {
        public thinlto_code_gen_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public enum lto_codegen_diagnostic_severity_t
    {
        LTO_DS_ERROR = 0,
        LTO_DS_WARNING = 1,
        LTO_DS_REMARK = 3,
        LTO_DS_NOTE = 2,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void lto_diagnostic_handler_t(lto_codegen_diagnostic_severity_t severity, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string diag, IntPtr ctxt);

    public partial struct LTOObjectBuffer
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Buffer;
        public IntPtr Size;
    }

    public partial struct LLVMOpaqueObjectFile
    {
    }

    public partial struct LLVMObjectFileRef
    {
        public LLVMObjectFileRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueSectionIterator
    {
    }

    public partial struct LLVMSectionIteratorRef
    {
        public LLVMSectionIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueSymbolIterator
    {
    }

    public partial struct LLVMSymbolIteratorRef
    {
        public LLVMSymbolIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueRelocationIterator
    {
    }

    public partial struct LLVMRelocationIteratorRef
    {
        public LLVMRelocationIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOptRemarkStringRef
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Str;
        public uint Len;
    }

    public partial struct LLVMOptRemarkDebugLoc
    {
        public LLVMOptRemarkStringRef SourceFile;
        public uint SourceLineNumber;
        public uint SourceColumnNumber;
    }

    public partial struct LLVMOptRemarkArg
    {
        public LLVMOptRemarkStringRef Key;
        public LLVMOptRemarkStringRef Value;
        public LLVMOptRemarkDebugLoc DebugLoc;
    }

    public partial struct LLVMOptRemarkEntry
    {
        public LLVMOptRemarkStringRef RemarkType;
        public LLVMOptRemarkStringRef PassName;
        public LLVMOptRemarkStringRef RemarkName;
        public LLVMOptRemarkStringRef FunctionName;
        public LLVMOptRemarkDebugLoc DebugLoc;
        public uint Hotness;
        public uint NumArgs;
        public IntPtr Args;
    }

    public partial struct LLVMOptRemarkOpaqueParser
    {
    }

    public partial struct LLVMOptRemarkParserRef
    {
        public LLVMOptRemarkParserRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOrcOpaqueJITStack
    {
    }

    public partial struct LLVMOrcJITStackRef
    {
        public LLVMOrcJITStackRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOrcModuleHandle
    {
        public LLVMOrcModuleHandle(ulong value)
        {
            Value = value;
        }

        public ulong Value;
    }

    public partial struct LLVMOrcTargetAddress
    {
        public LLVMOrcTargetAddress(ulong value)
        {
            Value = value;
        }

        public ulong Value;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong LLVMOrcSymbolResolverFn([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string Name, IntPtr LookupCtx);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong LLVMOrcLazyCompileCallbackFn(LLVMOrcJITStackRef JITStack, IntPtr CallbackCtx);

    public enum LLVMByteOrdering
    {
        LLVMBigEndian = 0,
        LLVMLittleEndian = 1,
    }

    public partial struct LLVMOpaqueTargetData
    {
    }

    public partial struct LLVMTargetDataRef
    {
        public LLVMTargetDataRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueTargetLibraryInfotData
    {
    }

    public partial struct LLVMTargetLibraryInfoRef
    {
        public LLVMTargetLibraryInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueTargetMachine
    {
    }

    public partial struct LLVMTargetMachineRef
    {
        public LLVMTargetMachineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMTarget
    {
    }

    public partial struct LLVMTargetRef
    {
        public LLVMTargetRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public enum LLVMCodeGenOptLevel
    {
        LLVMCodeGenLevelNone = 0,
        LLVMCodeGenLevelLess = 1,
        LLVMCodeGenLevelDefault = 2,
        LLVMCodeGenLevelAggressive = 3,
    }

    public enum LLVMRelocMode
    {
        LLVMRelocDefault = 0,
        LLVMRelocStatic = 1,
        LLVMRelocPIC = 2,
        LLVMRelocDynamicNoPic = 3,
        LLVMRelocROPI = 4,
        LLVMRelocRWPI = 5,
        LLVMRelocROPI_RWPI = 6,
    }

    public enum LLVMCodeModel
    {
        LLVMCodeModelDefault = 0,
        LLVMCodeModelJITDefault = 1,
        LLVMCodeModelTiny = 2,
        LLVMCodeModelSmall = 3,
        LLVMCodeModelKernel = 4,
        LLVMCodeModelMedium = 5,
        LLVMCodeModelLarge = 6,
    }

    public enum LLVMCodeGenFileType
    {
        LLVMAssemblyFile = 0,
        LLVMObjectFile = 1,
    }

    public partial struct LLVMBool
    {
        public LLVMBool(int value)
        {
            Value = value;
        }

        public int Value;
    }

    public partial struct LLVMOpaqueMemoryBuffer
    {
    }

    public partial struct LLVMMemoryBufferRef
    {
        public LLVMMemoryBufferRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueContext
    {
    }

    public partial struct LLVMContextRef
    {
        public LLVMContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueModule
    {
    }

    public partial struct LLVMModuleRef
    {
        public LLVMModuleRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueType
    {
    }

    public partial struct LLVMTypeRef
    {
        public LLVMTypeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueValue
    {
    }

    public partial struct LLVMValueRef
    {
        public LLVMValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueBasicBlock
    {
    }

    public partial struct LLVMBasicBlockRef
    {
        public LLVMBasicBlockRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueMetadata
    {
    }

    public partial struct LLVMMetadataRef
    {
        public LLVMMetadataRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueNamedMDNode
    {
    }

    public partial struct LLVMNamedMDNodeRef
    {
        public LLVMNamedMDNodeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueValueMetadataEntry
    {
    }

    public partial struct LLVMOpaqueBuilder
    {
    }

    public partial struct LLVMBuilderRef
    {
        public LLVMBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueDIBuilder
    {
    }

    public partial struct LLVMDIBuilderRef
    {
        public LLVMDIBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueModuleProvider
    {
    }

    public partial struct LLVMModuleProviderRef
    {
        public LLVMModuleProviderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaquePassManager
    {
    }

    public partial struct LLVMPassManagerRef
    {
        public LLVMPassManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaquePassRegistry
    {
    }

    public partial struct LLVMPassRegistryRef
    {
        public LLVMPassRegistryRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueUse
    {
    }

    public partial struct LLVMUseRef
    {
        public LLVMUseRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueAttributeRef
    {
    }

    public partial struct LLVMAttributeRef
    {
        public LLVMAttributeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueDiagnosticInfo
    {
    }

    public partial struct LLVMDiagnosticInfoRef
    {
        public LLVMDiagnosticInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMComdat
    {
    }

    public partial struct LLVMComdatRef
    {
        public LLVMComdatRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaqueModuleFlagEntry
    {
    }

    public partial struct LLVMOpaqueJITEventListener
    {
    }

    public partial struct LLVMJITEventListenerRef
    {
        public LLVMJITEventListenerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }

    public partial struct LLVMOpaquePassManagerBuilder
    {
    }

    public partial struct LLVMPassManagerBuilderRef
    {
        public LLVMPassManagerBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
