// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMValueRef : IEquatable<LLVMValueRef>
    {
        public IntPtr Handle;

        public LLVMValueRef(IntPtr handle)
        {
            Handle = handle;
        }
 
        public uint Alignment
        {
            get => ((IsAGlobalValue != null) || (IsAAllocaInst != null) || (IsALoadInst != null) || (IsAStoreInst != null)) ? LLVM.GetAlignment(this) : default;
            set => LLVM.SetAlignment(this, value);
        }

        public LLVMAtomicRMWBinOp AtomicRMWBinOp
        {
            get => (IsAAtomicRMWInst != null) ? LLVM.GetAtomicRMWBinOp(this) : default;
            set => LLVM.SetAtomicRMWBinOp(this, value);
        }

        public LLVMBasicBlockRef[] BasicBlocks
        {
            get
            {
                if (IsAFunction == null)
                {
                    return Array.Empty<LLVMBasicBlockRef>();
                }

                var BasicBlocks = new LLVMBasicBlockRef[BasicBlocksCount];

                fixed (LLVMBasicBlockRef* pBasicBlocks = BasicBlocks)
                {
                    LLVM.GetBasicBlocks(this, (LLVMOpaqueBasicBlock**)pBasicBlocks);
                }

                return BasicBlocks;
            }
        }

        public uint BasicBlocksCount => (IsAFunction != null) ? LLVM.CountBasicBlocks(this) : default;

        public LLVMValueRef Condition
        {
            get => (IsABranchInst != null) ? LLVM.GetCondition(this) : default;
            set => LLVM.SetCondition(this, value);
        }

        public ulong ConstIntZExt => (IsAConstantInt != null) ? LLVM.ConstIntGetZExtValue(this) : default;

        public long ConstIntSExt => (IsAConstantInt != null) ? LLVM.ConstIntGetSExtValue(this) : default;

        public LLVMOpcode ConstOpcode => (IsAConstantExpr != null) ? LLVM.GetConstOpcode(this) : default;

        public LLVMDLLStorageClass DLLStorageClass
        {
            get => (IsAGlobalValue != null) ? LLVM.GetDLLStorageClass(this) : default;
            set => LLVM.SetDLLStorageClass(this, value);
        }

        public LLVMBasicBlockRef EntryBasicBlock => (IsAFunction != null) ? LLVM.GetEntryBasicBlock(this) : default;

        public LLVMRealPredicate FCmpPredicate => (Handle != IntPtr.Zero) ? LLVM.GetFCmpPredicate(this) : default;

        public LLVMBasicBlockRef FirstBasicBlock => (IsAFunction != null) ? LLVM.GetFirstBasicBlock(this) : default;

        public LLVMValueRef FirstParam => (IsAFunction != null) ? LLVM.GetFirstParam(this) : default;

        public LLVMUseRef FirstUse => (Handle != IntPtr.Zero) ? LLVM.GetFirstUse(this) : default;

        public uint FunctionCallConv
        {
            get => (IsAFunction != null) ? LLVM.GetFunctionCallConv(this) : default;
            set => LLVM.SetFunctionCallConv(this, value);
        }

        public string GC
        {
            get
            {
                if (IsAFunction == null)
                {
                    return string.Empty;
                }

                var pName = LLVM.GetGC(this);

                if (pName is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pName, int.MaxValue);
                return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            }

            set
            {
                using var marshaledName = new MarshaledString(value.AsSpan());
                LLVM.SetGC(this, marshaledName);
            }
        }

        public LLVMModuleRef GlobalParent => (IsAGlobalValue != null) ? LLVM.GetGlobalParent(this) : default;

        public bool HasMetadata => (IsAInstruction != null) ? LLVM.HasMetadata(this) != 0 : default;

        public bool HasUnnamedAddr
        {
            get => (IsAGlobalValue != null) ? LLVM.HasUnnamedAddr(this) != 0 : default;
            set => LLVM.SetUnnamedAddr(this, value ? 1 : 0);
        }

        public LLVMIntPredicate ICmpPredicate => (Handle != IntPtr.Zero) ? LLVM.GetICmpPredicate(this) : default;

        public uint IncomingCount => (IsAPHINode != null) ? LLVM.CountIncoming(this) : default;

        public LLVMValueRef Initializer
        {
            get => (IsAGlobalVariable != null) ? LLVM.GetInitializer(this) : default;
            set => LLVM.SetInitializer(this, value);
        }

        public uint InstructionCallConv
        {
            get => ((IsACallBrInst != null) || (IsACallInst != null) || (IsAInvokeInst != null)) ? LLVM.GetInstructionCallConv(this) : default;
            set => LLVM.SetInstructionCallConv(this, value);
        }

        public LLVMValueRef InstructionClone => (Handle != IntPtr.Zero) ? LLVM.InstructionClone(this) : default;

        public LLVMOpcode InstructionOpcode => (Handle != IntPtr.Zero) ? LLVM.GetInstructionOpcode(this) : default;

        public LLVMBasicBlockRef InstructionParent => (IsAInstruction != null) ? LLVM.GetInstructionParent(this) : default;

        public uint IntrinsicID => (Handle != IntPtr.Zero) ? LLVM.GetIntrinsicID(this) : default;

        public LLVMValueRef IsAAddrSpaceCastInst => LLVM.IsAAddrSpaceCastInst(this);

        public LLVMValueRef IsAAllocaInst => LLVM.IsAAllocaInst(this);

        public LLVMValueRef IsAArgument => LLVM.IsAArgument(this);

        public LLVMValueRef IsAAtomicCmpXchgInst => LLVM.IsAAtomicCmpXchgInst(this);

        public LLVMValueRef IsAAtomicRMWInst => LLVM.IsAAtomicRMWInst(this);

        public LLVMValueRef IsABasicBlock => LLVM.IsABasicBlock(this);

        public LLVMValueRef IsABinaryOperator => LLVM.IsABinaryOperator(this);

        public LLVMValueRef IsABitCastInst => LLVM.IsABitCastInst(this);

        public LLVMValueRef IsABlockAddress => LLVM.IsABlockAddress(this);

        public LLVMValueRef IsABranchInst => LLVM.IsABranchInst(this);

        public LLVMValueRef IsACallBrInst => LLVM.IsACallBrInst(this);

        public LLVMValueRef IsACallInst => LLVM.IsACallInst(this);

        public LLVMValueRef IsACastInst => LLVM.IsACastInst(this);

        public LLVMValueRef IsACatchPadInst => LLVM.IsACatchPadInst(this);

        public LLVMValueRef IsACatchReturnInst => LLVM.IsACatchReturnInst(this);

        public LLVMValueRef IsACatchSwitchInst => LLVM.IsACatchSwitchInst(this);

        public LLVMValueRef IsACleanupPadInst => LLVM.IsACleanupPadInst(this);

        public LLVMValueRef IsACleanupReturnInst => LLVM.IsACleanupReturnInst(this);

        public LLVMValueRef IsACmpInst => LLVM.IsACmpInst(this);

        public LLVMValueRef IsAConstant => LLVM.IsAConstant(this);

        public LLVMValueRef IsAConstantAggregateZero => LLVM.IsAConstantAggregateZero(this);

        public LLVMValueRef IsAConstantArray => LLVM.IsAConstantArray(this);

        public LLVMValueRef IsAConstantDataArray => LLVM.IsAConstantDataArray(this);

        public LLVMValueRef IsAConstantDataSequential => LLVM.IsAConstantDataSequential(this);

        public LLVMValueRef IsAConstantDataVector => LLVM.IsAConstantDataVector(this);

        public LLVMValueRef IsAConstantExpr => LLVM.IsAConstantExpr(this);

        public LLVMValueRef IsAConstantFP => LLVM.IsAConstantFP(this);

        public LLVMValueRef IsAConstantInt => LLVM.IsAConstantInt(this);

        public LLVMValueRef IsAConstantPointerNull => LLVM.IsAConstantPointerNull(this);

        public LLVMValueRef IsAConstantStruct => LLVM.IsAConstantStruct(this);

        public LLVMValueRef IsAConstantTokenNone => LLVM.IsAConstantTokenNone(this);

        public LLVMValueRef IsAConstantVector => LLVM.IsAConstantVector(this);

        public LLVMValueRef IsADbgDeclareInst => LLVM.IsADbgDeclareInst(this);

        public LLVMValueRef IsADbgInfoIntrinsic => LLVM.IsADbgInfoIntrinsic(this);

        public LLVMValueRef IsADbgLabelInst => LLVM.IsADbgLabelInst(this);

        public LLVMValueRef IsADbgVariableIntrinsic => LLVM.IsADbgVariableIntrinsic(this);

        public LLVMValueRef IsAExtractElementInst => LLVM.IsAExtractElementInst(this);

        public LLVMValueRef IsAExtractValueInst => LLVM.IsAExtractValueInst(this);

        public LLVMValueRef IsAFCmpInst => LLVM.IsAFCmpInst(this);

        public LLVMValueRef IsAFenceInst => LLVM.IsAFenceInst(this);

        public LLVMValueRef IsAFPExtInst => LLVM.IsAFPExtInst(this);

        public LLVMValueRef IsAFPToSIInst => LLVM.IsAFPToSIInst(this);

        public LLVMValueRef IsAFPToUIInst => LLVM.IsAFPToUIInst(this);

        public LLVMValueRef IsAFPTruncInst => LLVM.IsAFPTruncInst(this);

        public LLVMValueRef IsAFreezeInst => LLVM.IsAFreezeInst(this);

        public LLVMValueRef IsAFuncletPadInst => LLVM.IsAFuncletPadInst(this);

        public LLVMValueRef IsAFunction => LLVM.IsAFunction(this);

        public LLVMValueRef IsAGetElementPtrInst => LLVM.IsAGetElementPtrInst(this);

        public LLVMValueRef IsAGlobalAlias => LLVM.IsAGlobalAlias(this);

        public LLVMValueRef IsAGlobalIFunc => LLVM.IsAGlobalIFunc(this);

        public LLVMValueRef IsAGlobalObject => LLVM.IsAGlobalObject(this);

        public LLVMValueRef IsAGlobalValue => LLVM.IsAGlobalValue(this);

        public LLVMValueRef IsAGlobalVariable => LLVM.IsAGlobalVariable(this);

        public LLVMValueRef IsAICmpInst => LLVM.IsAICmpInst(this);

        public LLVMValueRef IsAIndirectBrInst => LLVM.IsAIndirectBrInst(this);

        public LLVMValueRef IsAInlineAsm => LLVM.IsAInlineAsm(this);

        public LLVMValueRef IsAInsertElementInst => LLVM.IsAInsertElementInst(this);

        public LLVMValueRef IsAInsertValueInst => LLVM.IsAInsertValueInst(this);

        public LLVMValueRef IsAInstruction => LLVM.IsAInstruction(this);

        public LLVMValueRef IsAIntrinsicInst => LLVM.IsAIntrinsicInst(this);

        public LLVMValueRef IsAIntToPtrInst => LLVM.IsAIntToPtrInst(this);

        public LLVMValueRef IsAInvokeInst => LLVM.IsAInvokeInst(this);

        public LLVMValueRef IsALandingPadInst => LLVM.IsALandingPadInst(this);

        public LLVMValueRef IsALoadInst => LLVM.IsALoadInst(this);

        public LLVMValueRef IsAMDNode => LLVM.IsAMDNode(this);

        public LLVMValueRef IsAMDString => LLVM.IsAMDString(this);

        public LLVMValueRef IsAMemCpyInst => LLVM.IsAMemCpyInst(this);

        public LLVMValueRef IsAMemIntrinsic => LLVM.IsAMemIntrinsic(this);

        public LLVMValueRef IsAMemMoveInst => LLVM.IsAMemMoveInst(this);

        public LLVMValueRef IsAMemSetInst => LLVM.IsAMemSetInst(this);

        public LLVMValueRef IsAPHINode => LLVM.IsAPHINode(this);

        public LLVMValueRef IsAPtrToIntInst => LLVM.IsAPtrToIntInst(this);

        public LLVMValueRef IsAResumeInst => LLVM.IsAResumeInst(this);

        public LLVMValueRef IsAReturnInst => LLVM.IsAReturnInst(this);

        public LLVMValueRef IsASelectInst => LLVM.IsASelectInst(this);

        public LLVMValueRef IsASExtInst => LLVM.IsASExtInst(this);

        public LLVMValueRef IsAShuffleVectorInst => LLVM.IsAShuffleVectorInst(this);

        public LLVMValueRef IsASIToFPInst => LLVM.IsASIToFPInst(this);

        public LLVMValueRef IsAStoreInst => LLVM.IsAStoreInst(this);

        public LLVMValueRef IsASwitchInst => LLVM.IsASwitchInst(this);

        public LLVMValueRef IsATerminatorInst => LLVM.IsATerminatorInst(this);

        public LLVMValueRef IsATruncInst => LLVM.IsATruncInst(this);

        public LLVMValueRef IsAUIToFPInst => LLVM.IsAUIToFPInst(this);

        public LLVMValueRef IsAUnaryInstruction => LLVM.IsAUnaryInstruction(this);

        public LLVMValueRef IsAUnaryOperator => LLVM.IsAUnaryOperator(this);

        public LLVMValueRef IsAUndefValue => LLVM.IsAUndefValue(this);

        public LLVMValueRef IsAUnreachableInst => LLVM.IsAUnreachableInst(this);

        public LLVMValueRef IsAUser => LLVM.IsAUser(this);

        public LLVMValueRef IsAVAArgInst => LLVM.IsAVAArgInst(this);

        public LLVMValueRef IsAZExtInst => LLVM.IsAZExtInst(this);

        public bool IsBasicBlock => (Handle != IntPtr.Zero) ? LLVM.ValueIsBasicBlock(this) != 0 : default;

        public bool IsCleanup
        {
            get => (IsALandingPadInst != null) ? LLVM.IsCleanup(this) != 0 : default;
            set => LLVM.SetCleanup(this, value ? 1 : 0);
        }

        public bool IsConditional => (IsABranchInst != null) ? LLVM.IsConditional(this) != 0 : default;

        public bool IsConstant => (Handle != IntPtr.Zero) ? LLVM.IsConstant(this) != 0 : default;

        public bool IsConstantString => (IsAConstantDataSequential != null) ? LLVM.IsConstantString(this) != 0 : default;

        public bool IsDeclaration => (IsAGlobalValue != null) ? LLVM.IsDeclaration(this) != 0 : default;

        public bool IsExternallyInitialized
        {
            get => (IsAGlobalVariable != null) ? LLVM.IsExternallyInitialized(this) != 0 : default;
            set => LLVM.SetExternallyInitialized(this, value ? 1 : 0);
        }

        public bool IsGlobalConstant
        {
            get => (IsAGlobalVariable != null) ? LLVM.IsGlobalConstant(this) != 0 : default;
            set => LLVM.SetGlobalConstant(this, value ? 1 : 0);

        }

        public bool IsNull => (Handle != IntPtr.Zero) ? LLVM.IsNull(this) != 0 : default;

        public bool IsTailCall
        {
            get => (IsACallInst != null) ? LLVM.IsTailCall(this) != 0 : default;
            set => LLVM.SetTailCall(this, IsTailCall ? 1 : 0);
        }

        public bool IsThreadLocal
        {
            get => (IsAGlobalVariable != null) ? LLVM.IsThreadLocal(this) != 0 : default;
            set => LLVM.SetThreadLocal(this, value ? 1 : 0);
        }

        public bool IsUndef => (Handle != IntPtr.Zero) ? LLVM.IsUndef(this) != 0 : default;

        public LLVMValueKind Kind => (Handle != IntPtr.Zero) ? LLVM.GetValueKind(this) : default;

        public LLVMBasicBlockRef LastBasicBlock => (IsAFunction != null) ? LLVM.GetLastBasicBlock(this) : default;

        public LLVMValueRef LastParam => (IsAFunction != null) ? LLVM.GetLastParam(this) : default;

        public LLVMLinkage Linkage
        {
            get => (IsAGlobalValue != null) ? LLVM.GetLinkage(this) : default;
            set => LLVM.SetLinkage(this, value);
        }

        public LLVMValueRef[] MDNodeOperands
        {
            get
            {
                if (Kind != LLVMValueKind.LLVMMetadataAsValueValueKind)
                {
                    return Array.Empty<LLVMValueRef>();
                }

                var Dest = new LLVMValueRef[MDNodeOperandsCount];

                fixed (LLVMValueRef* pDest = Dest)
                {
                    LLVM.GetMDNodeOperands(this, (LLVMOpaqueValue**)pDest);
                }

                return Dest;
            }
        }

        public uint MDNodeOperandsCount => (Kind != LLVMValueKind.LLVMMetadataAsValueValueKind) ? LLVM.GetMDNodeNumOperands(this) : default;

        public string Name
        {
            get
            {
                if (Handle == IntPtr.Zero)
                {
                    return string.Empty;
                }

                var pStr = LLVM.GetValueName(this);

                if (pStr is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pStr, int.MaxValue);
                return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            }

            set
            {
                using var marshaledName = new MarshaledString(value.AsSpan());
                LLVM.SetValueName(this, marshaledName);
            }
        }

        public LLVMValueRef NextFunction => (IsAFunction != null) ? LLVM.GetNextFunction(this) : default;

        public LLVMValueRef NextGlobal => (IsAGlobalVariable != null) ? LLVM.GetNextGlobal(this) : default;

        public LLVMValueRef NextInstruction => (IsAInstruction != null) ? LLVM.GetNextInstruction(this) : default;

        public LLVMValueRef NextParam => (IsAArgument != null) ? LLVM.GetNextParam(this) : default;

        public int OperandCount => ((Kind == LLVMValueKind.LLVMMetadataAsValueValueKind) || (IsAUser != null)) ? LLVM.GetNumOperands(this) : default;

        public LLVMValueRef[] Params
        {
            get
            {
                if (IsAFunction == null)
                {
                    return Array.Empty<LLVMValueRef>();
                }

                var Params = new LLVMValueRef[ParamsCount];

                fixed (LLVMValueRef* pParams = Params)
                {
                    LLVM.GetParams(this, (LLVMOpaqueValue**)pParams);
                }

                return Params;
            }
        }

        public uint ParamsCount => (IsAFunction != null) ? LLVM.CountParams(this) : default;

        public LLVMValueRef ParamParent => (IsAArgument != null) ? LLVM.GetParamParent(this) : default;

        public LLVMValueRef PersonalityFn
        {
            get => (IsAFunction != null) ? LLVM.GetPersonalityFn(this) : default;
            set => LLVM.SetPersonalityFn(this, value);
        }

        public LLVMValueRef PreviousGlobal => (IsAGlobalVariable != null) ? LLVM.GetPreviousGlobal(this) : default;

        public LLVMValueRef PreviousInstruction => (IsAInstruction != null) ? LLVM.GetPreviousInstruction(this) : default;

        public LLVMValueRef PreviousParam => (IsAArgument != null) ? LLVM.GetPreviousParam(this) : default;

        public LLVMValueRef PreviousFunction => (IsAFunction != null) ? LLVM.GetPreviousFunction(this) : default;

        public string Section
        {
            get
            {
                if (IsAGlobalValue == null)
                {
                    return string.Empty;
                }

                var pSection = LLVM.GetSection(this);

                if (pSection is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pSection, int.MaxValue);
                return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            }

            set
            {
                using var marshaledSection = new MarshaledString(value.AsSpan());
                LLVM.SetSection(this, marshaledSection);
            }
        }

        public uint SuccessorsCount => (IsAInstruction != null) ? LLVM.GetNumSuccessors(this) : default;

        public LLVMBasicBlockRef SwitchDefaultDest => (IsASwitchInst != null) ? LLVM.GetSwitchDefaultDest(this) : default;

        public LLVMThreadLocalMode ThreadLocalMode
        {
            get => (IsAGlobalVariable != null) ? LLVM.GetThreadLocalMode(this) : default;
            set => LLVM.SetThreadLocalMode(this, value);
        }

        public LLVMTypeRef TypeOf => (Handle != IntPtr.Zero) ? LLVM.TypeOf(this) : default;

        public LLVMVisibility Visibility
        {
            get => (IsAGlobalValue != null) ? LLVM.GetVisibility(this) : default;
            set => LLVM.SetVisibility(this, value);
        }

        public bool Volatile
        {
            get => ((IsALoadInst != null) || (IsAStoreInst != null) || (IsAAtomicRMWInst != null) || (IsAAtomicCmpXchgInst != null)) ? LLVM.GetVolatile(this) != 0 : default;
            set => LLVM.SetVolatile(this, value ? 1 : 0);
        }

        public bool Weak
        {
            get => (IsAAtomicCmpXchgInst != null) ? LLVM.GetWeak(this) != 0 : default;
            set => LLVM.SetWeak(this, value ? 1 : 0);
        }

        public static implicit operator LLVMValueRef(LLVMOpaqueValue* value) => new LLVMValueRef((IntPtr)value);

        public static implicit operator LLVMOpaqueValue*(LLVMValueRef value) => (LLVMOpaqueValue*)value.Handle;

        public static bool operator ==(LLVMValueRef left, LLVMValueRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMValueRef left, LLVMValueRef right) => !(left == right);

        public static LLVMValueRef CreateConstAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAdd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstAddrSpaceCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstAddrSpaceCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstAllOnes(LLVMTypeRef Ty) => LLVM.ConstAllOnes(Ty);

        public static LLVMValueRef CreateConstAnd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAnd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstArray(LLVMTypeRef ElementTy, LLVMValueRef[] ConstantVals) => CreateConstArray(ElementTy, ConstantVals.AsSpan());

        public static LLVMValueRef CreateConstArray(LLVMTypeRef ElementTy, ReadOnlySpan<LLVMValueRef> ConstantVals)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstArray(ElementTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length);
            }
        }

        public static LLVMValueRef CreateConstAShr(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAShr(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstExactSDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstExactSDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstExactUDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstExactUDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstExtractElement(LLVMValueRef VectorConstant, LLVMValueRef IndexConstant) => LLVM.ConstExtractElement(VectorConstant, IndexConstant);

        public static LLVMValueRef CreateConstExtractValue(LLVMValueRef AggConstant, uint[] IdxList) => CreateConstExtractValue(AggConstant, IdxList.AsSpan());

        public static LLVMValueRef CreateConstExtractValue(LLVMValueRef AggConstant, ReadOnlySpan<uint> IdxList)
        {
            fixed (uint* pIdxList = IdxList)
            {
                return LLVM.ConstExtractValue(AggConstant, pIdxList, (uint)IdxList.Length);
            }
        }

        public static LLVMValueRef CreateConstFAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstFAdd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstFDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstFDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstFMul(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstFMul(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstFNeg(LLVMValueRef ConstantVal) => LLVM.ConstFNeg(ConstantVal);

        public static LLVMValueRef CreateConstFPCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstFPCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstFPExt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstFPExt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstFPToSI(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstFPToSI(ConstantVal, ToType);

        public static LLVMValueRef CreateConstFPToUI(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstFPToUI(ConstantVal, ToType);

        public static LLVMValueRef CreateConstFPTrunc(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstFPTrunc(ConstantVal, ToType);

        public static LLVMValueRef CreateConstFRem(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstFRem(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstFSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstFSub(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices) => CreateConstGEP(ConstantVal, ConstantIndices.AsSpan());

        public static LLVMValueRef CreateConstGEP(LLVMValueRef ConstantVal, ReadOnlySpan<LLVMValueRef> ConstantIndices)
        {
            fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
            {
                return LLVM.ConstGEP(ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices.Length);
            }
        }

        public static LLVMValueRef CreateConstInBoundsGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices) => CreateConstInBoundsGEP(ConstantVal, ConstantIndices.AsSpan());

        public static LLVMValueRef CreateConstInBoundsGEP(LLVMValueRef ConstantVal, ReadOnlySpan<LLVMValueRef> ConstantIndices)
        {
            fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
            {
                return LLVM.ConstInBoundsGEP(ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices.Length);
            }
        }

        public static LLVMValueRef CreateConstInlineAsm(LLVMTypeRef Ty, string AsmString, string Constraints, bool HasSideEffects, bool IsAlignStack) => CreateConstInlineAsm(Ty, AsmString.AsSpan(), Constraints.AsSpan(), HasSideEffects, IsAlignStack);

        public static LLVMValueRef CreateConstInlineAsm(LLVMTypeRef Ty, ReadOnlySpan<char> AsmString, ReadOnlySpan<char> Constraints, bool HasSideEffects, bool IsAlignStack)
        {
            using var marshaledAsmString = new MarshaledString(AsmString);
            using var marshaledConstraints = new MarshaledString(Constraints);
            return LLVM.ConstInlineAsm(Ty, marshaledAsmString, marshaledConstraints, HasSideEffects ? 1 : 0, IsAlignStack ? 1 : 0);
        }

        public static LLVMValueRef CreateConstInsertElement(LLVMValueRef VectorConstant, LLVMValueRef ElementValueConstant, LLVMValueRef IndexConstant) => LLVM.ConstInsertElement(VectorConstant, ElementValueConstant, IndexConstant);

        public static LLVMValueRef CreateConstInsertValue(LLVMValueRef AggConstant, LLVMValueRef ElementValueConstant, uint[] IdxList) => CreateConstInsertValue(AggConstant, ElementValueConstant, IdxList.AsSpan());

        public static LLVMValueRef CreateConstInsertValue(LLVMValueRef AggConstant, LLVMValueRef ElementValueConstant, ReadOnlySpan<uint> IdxList)
        {
            fixed (uint* pIdxList = IdxList)
            {
                return LLVM.ConstInsertValue(AggConstant, ElementValueConstant, pIdxList, (uint)IdxList.Length);
            }
        }

        public static LLVMValueRef CreateConstInt(LLVMTypeRef IntTy, ulong N, bool SignExtend = false) => LLVM.ConstInt(IntTy, N, SignExtend ? 1 : 0);

        public static LLVMValueRef CreateConstIntCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType, bool isSigned) => LLVM.ConstIntCast(ConstantVal, ToType, isSigned ? 1 : 0);

        public static LLVMValueRef CreateConstIntOfArbitraryPrecision(LLVMTypeRef IntTy, ulong[] Words) => CreateConstIntOfArbitraryPrecision(IntTy, Words.AsSpan());

        public static LLVMValueRef CreateConstIntOfArbitraryPrecision(LLVMTypeRef IntTy, ReadOnlySpan<ulong> Words)
        {
            fixed (ulong* pWords = Words)
            {
                return LLVM.ConstIntOfArbitraryPrecision(IntTy, (uint)Words.Length, pWords);
            }
        }

        public static LLVMValueRef CreateConstIntOfString(LLVMTypeRef IntTy, string Text, byte Radix) => CreateConstIntOfString(IntTy, Text.AsSpan(), Radix);

        public static LLVMValueRef CreateConstIntOfString(LLVMTypeRef IntTy, ReadOnlySpan<char> Text, byte Radix)
        {
            using var marshaledText = new MarshaledString(Text);
            return LLVM.ConstIntOfString(IntTy, marshaledText, Radix);
        }

        public static LLVMValueRef CreateConstIntOfStringAndSize(LLVMTypeRef IntTy, string Text, uint SLen, byte Radix) => CreateConstIntOfStringAndSize(IntTy, Text.AsSpan(0, (int)SLen), Radix);

        public static LLVMValueRef CreateConstIntOfStringAndSize(LLVMTypeRef IntTy, ReadOnlySpan<char> Text, byte Radix)
        {
            using var marshaledText = new MarshaledString(Text);
            return LLVM.ConstIntOfStringAndSize(IntTy, marshaledText, (uint)marshaledText.Length, Radix);
        }

        public static LLVMValueRef CreateConstIntToPtr(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstIntToPtr(ConstantVal, ToType);

        public static LLVMValueRef CreateConstLShr(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstLShr(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstMul(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstMul(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNamedStruct(LLVMTypeRef StructTy, LLVMValueRef[] ConstantVals) => CreateConstNamedStruct(StructTy, ConstantVals.AsSpan());

        public static LLVMValueRef CreateConstNamedStruct(LLVMTypeRef StructTy, ReadOnlySpan<LLVMValueRef> ConstantVals)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstNamedStruct(StructTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length);
            }
        }

        public static LLVMValueRef CreateConstNeg(LLVMValueRef ConstantVal) => LLVM.ConstNeg(ConstantVal);

        public static LLVMValueRef CreateConstNot(LLVMValueRef ConstantVal) => LLVM.ConstNot(ConstantVal);

        public static LLVMValueRef CreateConstNSWAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNSWAdd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNSWMul(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNSWMul(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNSWNeg(LLVMValueRef ConstantVal) => LLVM.ConstNSWNeg(ConstantVal);

        public static LLVMValueRef CreateConstNSWSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNSWSub(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNull(LLVMTypeRef Ty) => LLVM.ConstNull(Ty);

        public static LLVMValueRef CreateConstNUWAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNUWAdd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNUWMul(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNUWMul(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNUWNeg(LLVMValueRef ConstantVal) => LLVM.ConstNUWNeg(ConstantVal);

        public static LLVMValueRef CreateConstNUWSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNUWSub(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstOr(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstOr(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstPointerCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstPointerCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstPointerNull(LLVMTypeRef Ty) => LLVM.ConstPointerNull(Ty);

        public static LLVMValueRef CreateConstPtrToInt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstPtrToInt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstReal(LLVMTypeRef RealTy, double N) => LLVM.ConstReal(RealTy, N);

        public static LLVMValueRef CreateConstRealOfString(LLVMTypeRef RealTy, string Text) => CreateConstRealOfString(RealTy, Text.AsSpan());

        public static LLVMValueRef CreateConstRealOfString(LLVMTypeRef RealTy, ReadOnlySpan<char> Text)
        {
            using var marshaledText = new MarshaledString(Text);
            return LLVM.ConstRealOfString(RealTy, marshaledText);
        }

        public static LLVMValueRef CreateConstRealOfStringAndSize(LLVMTypeRef RealTy, string Text, uint SLen) => CreateConstRealOfStringAndSize(RealTy, Text.AsSpan(0, (int)SLen));

        public static LLVMValueRef CreateConstRealOfStringAndSize(LLVMTypeRef RealTy, ReadOnlySpan<char> Text)
        {
            using var marshaledText = new MarshaledString(Text);
            return LLVM.ConstRealOfStringAndSize(RealTy, marshaledText, (uint)marshaledText.Length);
        }

        public static LLVMValueRef CreateConstSDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstSelect(LLVMValueRef ConstantCondition, LLVMValueRef ConstantIfTrue, LLVMValueRef ConstantIfFalse) => LLVM.ConstSelect(ConstantCondition, ConstantIfTrue, ConstantIfFalse);

        public static LLVMValueRef CreateConstSExt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSExt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstSExtOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSExtOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstShl(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstShl(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstShuffleVector(LLVMValueRef VectorAConstant, LLVMValueRef VectorBConstant, LLVMValueRef MaskConstant) => LLVM.ConstShuffleVector(VectorAConstant, VectorBConstant, MaskConstant);

        public static LLVMValueRef CreateConstSIToFP(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSIToFP(ConstantVal, ToType);

        public static LLVMValueRef CreateConstSRem(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSRem(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstStruct(LLVMValueRef[] ConstantVals, bool Packed) => CreateConstStruct(ConstantVals.AsSpan(), Packed);

        public static LLVMValueRef CreateConstStruct(ReadOnlySpan<LLVMValueRef> ConstantVals, bool Packed)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstStruct((LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length, Packed ? 1 : 0);
            }
        }

        public static LLVMValueRef CreateConstSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSub(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstTrunc(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTrunc(ConstantVal, ToType);

        public static LLVMValueRef CreateConstTruncOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTruncOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstUDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstUDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstUIToFP(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstUIToFP(ConstantVal, ToType);

        public static LLVMValueRef CreateConstURem(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstURem(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstVector(LLVMValueRef[] ScalarConstantVars) => CreateConstVector(ScalarConstantVars.AsSpan());

        public static LLVMValueRef CreateConstVector(ReadOnlySpan<LLVMValueRef> ScalarConstantVars)
        {
            fixed (LLVMValueRef* pScalarConstantVars = ScalarConstantVars)
            {
                return LLVM.ConstVector((LLVMOpaqueValue**)pScalarConstantVars, (uint)ScalarConstantVars.Length);
            }
        }

        public static LLVMValueRef CreateConstXor(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstXor(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstZExt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstZExt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstZExtOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstZExtOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateMDNode(LLVMValueRef[] Vals) => CreateMDNode(Vals.AsSpan());

        public static LLVMValueRef CreateMDNode(ReadOnlySpan<LLVMValueRef> Vals)
        {
            fixed (LLVMValueRef* pVals = Vals)
            {
                return LLVM.MDNode((LLVMOpaqueValue**)pVals, (uint)Vals.Length);
            }
        }

        public void AddCase(LLVMValueRef OnVal, LLVMBasicBlockRef Dest) => LLVM.AddCase(this, OnVal, Dest);

        public void AddClause(LLVMValueRef ClauseVal) => LLVM.AddClause(this, ClauseVal);

        public void AddDestination(LLVMBasicBlockRef Dest) => LLVM.AddDestination(this, Dest);

        public void AddIncoming(LLVMValueRef[] IncomingValues, LLVMBasicBlockRef[] IncomingBlocks, uint Count) => AddIncoming(IncomingValues.AsSpan(), IncomingBlocks.AsSpan(), Count);

        public void AddIncoming(ReadOnlySpan<LLVMValueRef> IncomingValues, ReadOnlySpan<LLVMBasicBlockRef> IncomingBlocks, uint Count)
        {
            fixed (LLVMValueRef* pIncomingValues = IncomingValues)
            fixed (LLVMBasicBlockRef* pIncomingBlocks = IncomingBlocks)
            {
                LLVM.AddIncoming(this, (LLVMOpaqueValue**)pIncomingValues, (LLVMOpaqueBasicBlock**)pIncomingBlocks, Count);
            }
        }

        public void AddTargetDependentFunctionAttr(string A, string V) => AddTargetDependentFunctionAttr(A.AsSpan(), V.AsSpan());

        public void AddTargetDependentFunctionAttr(ReadOnlySpan<char> A, ReadOnlySpan<char> V)
        {
            using var marshaledA = new MarshaledString(A);
            using var marshaledV = new MarshaledString(V);
            LLVM.AddTargetDependentFunctionAttr(this, marshaledA, marshaledV);
        }

        public LLVMBasicBlockRef AppendBasicBlock(string Name) => AppendBasicBlock(Name.AsSpan());

        public LLVMBasicBlockRef AppendBasicBlock(ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.AppendBasicBlock(this, marshaledName);
        }

        public LLVMBasicBlockRef AsBasicBlock() => LLVM.ValueAsBasicBlock(this);

        public void DeleteFunction() => LLVM.DeleteFunction(this);

        public void DeleteGlobal() => LLVM.DeleteGlobal(this);

        public void Dump() => LLVM.DumpValue(this);

        public override bool Equals(object obj) => (obj is LLVMValueRef other) && Equals(other);

        public bool Equals(LLVMValueRef other) => this == other;

        public string GetAsString(out UIntPtr Length)
        {
            fixed (UIntPtr* pLength = &Length)
            {
                var pStr = LLVM.GetAsString(this, pLength);

                if (pStr is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pStr, (int)Length);
                return span.AsString();
            }
        }

        public LLVMAttributeRef[] GetAttributesAtIndex(LLVMAttributeIndex Idx)
        {
            var Attrs = new LLVMAttributeRef[GetAttributeCountAtIndex(Idx)];

            fixed (LLVMAttributeRef* pAttrs = Attrs)
            {
                LLVM.GetAttributesAtIndex(this, (uint)Idx, (LLVMOpaqueAttributeRef**)pAttrs);
            }

            return Attrs;
        }

        public uint GetAttributeCountAtIndex(LLVMAttributeIndex Idx) => LLVM.GetAttributeCountAtIndex(this, (uint)Idx);

        public LLVMValueRef GetBlockAddress(LLVMBasicBlockRef BB) => LLVM.BlockAddress(this, BB);

        public uint GetCallSiteAttributeCount(LLVMAttributeIndex Idx) => LLVM.GetCallSiteAttributeCount(this, (uint)Idx);

        public LLVMAttributeRef[] GetCallSiteAttributes(LLVMAttributeIndex Idx)
        {
            var Attrs = new LLVMAttributeRef[GetCallSiteAttributeCount(Idx)];

            fixed (LLVMAttributeRef* pAttrs = Attrs)
            {
                LLVM.GetCallSiteAttributes(this, (uint)Idx, (LLVMOpaqueAttributeRef**)pAttrs);
            }

            return Attrs;
        }

        public double GetConstRealDouble(out bool losesInfo)
        {
            int losesInfoOut;
            var result = LLVM.ConstRealGetDouble(this, &losesInfoOut);

            losesInfo = losesInfoOut != 0;
            return result;
        }

        public LLVMValueRef GetElementAsConstant(uint idx) => LLVM.GetElementAsConstant(this, idx);

        public override int GetHashCode() => Handle.GetHashCode();

        public LLVMBasicBlockRef GetIncomingBlock(uint Index) => LLVM.GetIncomingBlock(this, Index);

        public LLVMValueRef GetIncomingValue(uint Index) => LLVM.GetIncomingValue(this, Index);

        public string GetMDString(out uint Len)
        {
            fixed (uint* pLen = &Len)
            {
                var pMDStr = LLVM.GetMDString(this, pLen);

                if (pMDStr is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pMDStr, (int)Len);
                return span.AsString();
            }
        }

        public LLVMValueRef GetMetadata(uint KindID) => LLVM.GetMetadata(this, KindID);

        public LLVMValueRef GetOperand(uint Index) => LLVM.GetOperand(this, Index);

        public LLVMUseRef GetOperandUse(uint Index) => LLVM.GetOperandUse(this, Index);

        public LLVMValueRef GetParam(uint Index) => LLVM.GetParam(this, Index);

        public LLVMBasicBlockRef GetSuccessor(uint i) => LLVM.GetSuccessor(this, i);

        public void InstructionEraseFromParent() => LLVM.InstructionEraseFromParent(this);

        public string PrintToString()
        {
            var pStr = LLVM.PrintValueToString(this);

            if (pStr is null)
            {
                return string.Empty;
            }
            var span = new ReadOnlySpan<byte>(pStr, int.MaxValue);

            var result = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            LLVM.DisposeMessage(pStr);
            return result;
        }

        public void ReplaceAllUsesWith(LLVMValueRef NewVal) => LLVM.ReplaceAllUsesWith(this, NewVal);

        public void SetAlignment(uint Bytes)
        {
            Alignment = Bytes;
        }

        public void SetInstrParamAlignment(uint index, uint align) => LLVM.SetInstrParamAlignment(this, index, align);

        public void SetMetadata(uint KindID, LLVMValueRef Node) => LLVM.SetMetadata(this, KindID, Node);

        public void SetOperand(uint Index, LLVMValueRef Val) => LLVM.SetOperand(this, Index, Val);

        public void SetParamAlignment(uint align) => LLVM.SetParamAlignment(this, align);

        public void SetSuccessor(uint i, LLVMBasicBlockRef block) => LLVM.SetSuccessor(this, i, block);

        public override string ToString() => (Handle != IntPtr.Zero) ? PrintToString() : string.Empty;

        public bool VerifyFunction(LLVMVerifierFailureAction Action) => LLVM.VerifyFunction(this, Action) == 0;

        public void ViewFunctionCFG() => LLVM.ViewFunctionCFG(this);

        public void ViewFunctionCFGOnly() => LLVM.ViewFunctionCFGOnly(this);
    }
}
