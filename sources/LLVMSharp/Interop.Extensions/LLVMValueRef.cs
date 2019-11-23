// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMValueRef : IEquatable<LLVMValueRef>
    {
        public LLVMValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMValueRef(LLVMOpaqueValue* value)
        {
            return new LLVMValueRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueValue*(LLVMValueRef value)
        {
            return (LLVMOpaqueValue*)value.Pointer;
        }

        public uint Alignment
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetAlignment(this) : default;
            set => LLVM.SetAlignment(this, value);
        }

        public LLVMBasicBlockRef AsBasicBlock => (Pointer != IntPtr.Zero) ? LLVM.ValueAsBasicBlock(this) : default;

        public LLVMBasicBlockRef[] BasicBlocks
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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

        public uint BasicBlocksCount => (Pointer != IntPtr.Zero) ? LLVM.CountBasicBlocks(this) : default;

        public LLVMValueRef Condition
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetCondition(this) : default;
            set => LLVM.SetCondition(this, value);
        }

        public ulong ConstIntZExt => (Pointer != IntPtr.Zero) ? LLVM.ConstIntGetZExtValue(this) : default;

        public long ConstIntSExt => (Pointer != IntPtr.Zero) ? LLVM.ConstIntGetSExtValue(this) : default;

        public LLVMOpcode ConstOpcode => (Pointer != IntPtr.Zero) ? LLVM.GetConstOpcode(this) : default;

        public LLVMDLLStorageClass DLLStorageClass
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetDLLStorageClass(this) : default;
            set => LLVM.SetDLLStorageClass(this, value);
        }

        public LLVMBasicBlockRef EntryBasicBlock => (Pointer != IntPtr.Zero) ? LLVM.GetEntryBasicBlock(this) : default;

        public LLVMRealPredicate FCmpPredicate => (Pointer != IntPtr.Zero) ? LLVM.GetFCmpPredicate(this) : default;

        public LLVMBasicBlockRef FirstBasicBlock => (Pointer != IntPtr.Zero) ? LLVM.GetFirstBasicBlock(this) : default;

        public LLVMValueRef FirstParam => (Pointer != IntPtr.Zero) ? LLVM.GetFirstParam(this) : default;

        public LLVMUseRef FirstUse => (Pointer != IntPtr.Zero) ? LLVM.GetFirstUse(this) : default;

        public uint FunctionCallConv
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetFunctionCallConv(this) : default;
            set => LLVM.SetFunctionCallConv(this, value);
        }

        public string GC
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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
                using (var marshaledName = new MarshaledString(value))
                {
                    LLVM.SetGC(this, marshaledName);
                }
            }
        }

        public LLVMModuleRef GlobalParent => (Pointer != IntPtr.Zero) ? LLVM.GetGlobalParent(this) : default;

        public bool HasMetadata => (Pointer != IntPtr.Zero) ? LLVM.HasMetadata(this) != 0 : default;

        public bool HasUnnamedAddr
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.HasUnnamedAddr(this) != 0 : default;
            set => LLVM.SetUnnamedAddr(this, value ? 1 : 0);
        }

        public LLVMIntPredicate ICmpPredicate => (Pointer != IntPtr.Zero) ? LLVM.GetICmpPredicate(this) : default;

        public uint IncomingCount => (Pointer != IntPtr.Zero) ? LLVM.CountIncoming(this) : default;

        public LLVMValueRef Initializer
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetInitializer(this) : default;
            set => LLVM.SetInitializer(this, value);
        }

        public uint InstructionCallConv
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetInstructionCallConv(this) : default;
            set => LLVM.SetInstructionCallConv(this, value);
        }

        public LLVMValueRef InstructionClone => (Pointer != IntPtr.Zero) ? LLVM.InstructionClone(this) : default;

        public LLVMOpcode InstructionOpcode => (Pointer != IntPtr.Zero) ? LLVM.GetInstructionOpcode(this) : default;

        public LLVMBasicBlockRef InstructionParent => (Pointer != IntPtr.Zero) ? LLVM.GetInstructionParent(this) : default;

        public uint IntrinsicID => (Pointer != IntPtr.Zero) ? LLVM.GetIntrinsicID(this) : default;

        public LLVMValueRef IsAAddrSpaceCastInst => (Pointer != IntPtr.Zero) ? LLVM.IsAAddrSpaceCastInst(this) : default;

        public LLVMValueRef IsAAllocaInst => (Pointer != IntPtr.Zero) ? LLVM.IsAAllocaInst(this) : default;

        public LLVMValueRef IsAArgument => (Pointer != IntPtr.Zero) ? LLVM.IsAArgument(this) : default;

        public LLVMValueRef IsABasicBlock => (Pointer != IntPtr.Zero) ? LLVM.IsABasicBlock(this) : default;

        public LLVMValueRef IsABinaryOperator => (Pointer != IntPtr.Zero) ? LLVM.IsABinaryOperator(this) : default;

        public LLVMValueRef IsABitCastInst => (Pointer != IntPtr.Zero) ? LLVM.IsABitCastInst(this) : default;

        public LLVMValueRef IsABlockAddress => (Pointer != IntPtr.Zero) ? LLVM.IsABlockAddress(this) : default;

        public LLVMValueRef IsABranchInst => (Pointer != IntPtr.Zero) ? LLVM.IsABranchInst(this) : default;

        public LLVMValueRef IsACallInst => (Pointer != IntPtr.Zero) ? LLVM.IsACallInst(this) : default;

        public LLVMValueRef IsACastInst => (Pointer != IntPtr.Zero) ? LLVM.IsACastInst(this) : default;

        public LLVMValueRef IsACmpInst => (Pointer != IntPtr.Zero) ? LLVM.IsACmpInst(this) : default;

        public LLVMValueRef IsAConstant => (Pointer != IntPtr.Zero) ? LLVM.IsAConstant(this) : default;

        public LLVMValueRef IsAConstantAggregateZero => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantAggregateZero(this) : default;

        public LLVMValueRef IsAConstantArray => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantArray(this) : default;

        public LLVMValueRef IsAConstantDataArray => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantDataArray(this) : default;

        public LLVMValueRef IsAConstantDataSequential => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantDataSequential(this) : default;

        public LLVMValueRef IsAConstantDataVector => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantDataVector(this) : default;

        public LLVMValueRef IsAConstantExpr => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantExpr(this) : default;

        public LLVMValueRef IsAConstantFP => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantFP(this) : default;

        public LLVMValueRef IsAConstantInt => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantInt(this) : default;

        public LLVMValueRef IsAConstantPointerNull => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantPointerNull(this) : default;

        public LLVMValueRef IsAConstantStruct => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantStruct(this) : default;

        public LLVMValueRef IsAConstantVector => (Pointer != IntPtr.Zero) ? LLVM.IsAConstantVector(this) : default;

        public LLVMValueRef IsADbgDeclareInst => (Pointer != IntPtr.Zero) ? LLVM.IsADbgDeclareInst(this) : default;

        public LLVMValueRef IsADbgInfoIntrinsic => (Pointer != IntPtr.Zero) ? LLVM.IsADbgInfoIntrinsic(this) : default;

        public LLVMValueRef IsAExtractElementInst => (Pointer != IntPtr.Zero) ? LLVM.IsAExtractElementInst(this) : default;

        public LLVMValueRef IsAExtractValueInst => (Pointer != IntPtr.Zero) ? LLVM.IsAExtractValueInst(this) : default;

        public LLVMValueRef IsAFCmpInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAFCmpInst(this) : default;

        public LLVMValueRef IsAFPExtInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAFPExtInst(this) : default;

        public LLVMValueRef IsAFPToSIInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAFPToSIInst(this) : default;

        public LLVMValueRef IsAFPToUIInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAFPToUIInst(this) : default;

        public LLVMValueRef IsAFPTruncInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAFPTruncInst(this) : default;

        public LLVMValueRef IsAFunction => (Pointer != IntPtr.Zero) ?  LLVM.IsAFunction(this) : default;

        public LLVMValueRef IsAGetElementPtrInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAGetElementPtrInst(this) : default;

        public LLVMValueRef IsAGlobalAlias => (Pointer != IntPtr.Zero) ?  LLVM.IsAGlobalAlias(this) : default;

        public LLVMValueRef IsAGlobalObject => (Pointer != IntPtr.Zero) ?  LLVM.IsAGlobalObject(this) : default;

        public LLVMValueRef IsAGlobalValue => (Pointer != IntPtr.Zero) ?  LLVM.IsAGlobalValue(this) : default;

        public LLVMValueRef IsAGlobalVariable => (Pointer != IntPtr.Zero) ?  LLVM.IsAGlobalVariable(this) : default;

        public LLVMValueRef IsAICmpInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAICmpInst(this) : default;

        public LLVMValueRef IsAIndirectBrInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAIndirectBrInst(this) : default;

        public LLVMValueRef IsAInlineAsm => (Pointer != IntPtr.Zero) ?  LLVM.IsAInlineAsm(this) : default;

        public LLVMValueRef IsAInsertElementInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAInsertElementInst(this) : default;

        public LLVMValueRef IsAInsertValueInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAInsertValueInst(this) : default;

        public LLVMValueRef IsAInstruction => (Pointer != IntPtr.Zero) ?  LLVM.IsAInstruction(this) : default;

        public LLVMValueRef IsAIntrinsicInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAIntrinsicInst(this) : default;

        public LLVMValueRef IsAIntToPtrInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAIntToPtrInst(this) : default;

        public LLVMValueRef IsAInvokeInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAInvokeInst(this) : default;

        public LLVMValueRef IsALandingPadInst => (Pointer != IntPtr.Zero) ?  LLVM.IsALandingPadInst(this) : default;

        public LLVMValueRef IsALoadInst => (Pointer != IntPtr.Zero) ?  LLVM.IsALoadInst(this) : default;

        public LLVMValueRef IsAMDNode => (Pointer != IntPtr.Zero) ?  LLVM.IsAMDNode(this) : default;

        public LLVMValueRef IsAMDString => (Pointer != IntPtr.Zero) ?  LLVM.IsAMDString(this) : default;

        public LLVMValueRef IsAMemCpyInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAMemCpyInst(this) : default;

        public LLVMValueRef IsAMemIntrinsic => (Pointer != IntPtr.Zero) ?  LLVM.IsAMemIntrinsic(this) : default;

        public LLVMValueRef IsAMemMoveInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAMemMoveInst(this) : default;

        public LLVMValueRef IsAMemSetInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAMemSetInst(this) : default;

        public LLVMValueRef IsAPHINode => (Pointer != IntPtr.Zero) ?  LLVM.IsAPHINode(this) : default;

        public LLVMValueRef IsAPtrToIntInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAPtrToIntInst(this) : default;

        public LLVMValueRef IsAResumeInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAResumeInst(this) : default;

        public LLVMValueRef IsAReturnInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAReturnInst(this) : default;

        public LLVMValueRef IsASelectInst => (Pointer != IntPtr.Zero) ?  LLVM.IsASelectInst(this) : default;

        public LLVMValueRef IsASExtInst => (Pointer != IntPtr.Zero) ?  LLVM.IsASExtInst(this) : default;

        public LLVMValueRef IsAShuffleVectorInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAShuffleVectorInst(this) : default;

        public LLVMValueRef IsASIToFPInst => (Pointer != IntPtr.Zero) ?  LLVM.IsASIToFPInst(this) : default;

        public LLVMValueRef IsAStoreInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAStoreInst(this) : default;

        public LLVMValueRef IsASwitchInst => (Pointer != IntPtr.Zero) ?  LLVM.IsASwitchInst(this) : default;

        public LLVMValueRef IsATerminatorInst => (Pointer != IntPtr.Zero) ?  LLVM.IsATerminatorInst(this) : default;

        public LLVMValueRef IsATruncInst => (Pointer != IntPtr.Zero) ?  LLVM.IsATruncInst(this) : default;

        public LLVMValueRef IsAUIToFPInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAUIToFPInst(this) : default;

        public LLVMValueRef IsAUnaryInstruction => (Pointer != IntPtr.Zero) ?  LLVM.IsAUnaryInstruction(this) : default;

        public LLVMValueRef IsAUndefValue => (Pointer != IntPtr.Zero) ?  LLVM.IsAUndefValue(this) : default;

        public LLVMValueRef IsAUnreachableInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAUnreachableInst(this) : default;

        public LLVMValueRef IsAUser => (Pointer != IntPtr.Zero) ?  LLVM.IsAUser(this) : default;

        public LLVMValueRef IsAVAArgInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAVAArgInst(this) : default;

        public LLVMValueRef IsAZExtInst => (Pointer != IntPtr.Zero) ?  LLVM.IsAZExtInst(this) : default;

        public bool IsBasicBlock => (Pointer != IntPtr.Zero) ?  LLVM.ValueIsBasicBlock(this) != 0 : default;

        public bool IsCleanup
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.IsCleanup(this) != 0 : default;
            set => LLVM.SetCleanup(this, value ? 1 : 0);
        }

        public bool IsConditional => (Pointer != IntPtr.Zero) ? LLVM.IsConditional(this) != 0 : default;

        public bool IsConstant => (Pointer != IntPtr.Zero) ? LLVM.IsConstant(this) != 0 : default;

        public bool IsConstantString => (Pointer != IntPtr.Zero) ? LLVM.IsConstantString(this) != 0 : default;

        public bool IsDeclaration => (Pointer != IntPtr.Zero) ? LLVM.IsDeclaration(this) != 0 : default;

        public bool IsExternallyInitialized
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.IsExternallyInitialized(this) != 0 : default;
            set => LLVM.SetExternallyInitialized(this, value ? 1 : 0);
        }

        public bool IsGlobalConstant
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.IsGlobalConstant(this) != 0 : default;
            set => LLVM.SetGlobalConstant(this, value ? 1 : 0);

        }

        public bool IsNull => (Pointer != IntPtr.Zero) ? LLVM.IsNull(this) != 0 : default;

        public bool IsTailCall
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.IsTailCall(this) != 0 : default;
            set => LLVM.SetTailCall(this, IsTailCall ? 1 : 0);
        }

        public bool IsThreadLocal
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.IsThreadLocal(this) != 0 : default;
            set => LLVM.SetThreadLocal(this, value ? 1 : 0);
        }

        public bool IsUndef => (Pointer != IntPtr.Zero) ? LLVM.IsUndef(this) != 0 : default;

        public LLVMBasicBlockRef LastBasicBlock => (Pointer != IntPtr.Zero) ? LLVM.GetLastBasicBlock(this) : default;

        public LLVMValueRef LastParam => (Pointer != IntPtr.Zero) ? LLVM.GetLastParam(this) : default;

        public LLVMLinkage Linkage
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetLinkage(this) : default;
            set => LLVM.SetLinkage(this, value);
        }

        public LLVMValueRef[] MDNodeOperands
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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

        public uint MDNodeOperandsCount => (Pointer != IntPtr.Zero) ? LLVM.GetMDNodeNumOperands(this) : default;

        public string Name
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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
                using (var marshaledName = new MarshaledString(value))
                {
                    LLVM.SetValueName(this, marshaledName);
                }
            }
        }

        public LLVMValueRef NextFunction => (Pointer != IntPtr.Zero) ? LLVM.GetNextFunction(this) : default;

        public LLVMValueRef NextGlobal => (Pointer != IntPtr.Zero) ? LLVM.GetNextGlobal(this) : default;

        public LLVMValueRef NextInstruction => (Pointer != IntPtr.Zero) ? LLVM.GetNextInstruction(this) : default;

        public LLVMValueRef NextParam => (Pointer != IntPtr.Zero) ? LLVM.GetNextParam(this) : default;

        public int OperandCount => (Pointer != IntPtr.Zero) ? LLVM.GetNumOperands(this) : default;

        public LLVMValueRef[] Params
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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

        public uint ParamsCount => (Pointer != IntPtr.Zero) ? LLVM.CountParams(this) : default;

        public LLVMValueRef ParamParent => (Pointer != IntPtr.Zero) ? LLVM.GetParamParent(this) : default;

        public LLVMValueRef PersonalityFn
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetPersonalityFn(this) : default;
            set => LLVM.SetPersonalityFn(this, value);
        }

        public LLVMValueRef PreviousGlobal => (Pointer != IntPtr.Zero) ? LLVM.GetPreviousGlobal(this) : default;

        public LLVMValueRef PreviousInstruction => (Pointer != IntPtr.Zero) ? LLVM.GetPreviousInstruction(this) : default;

        public LLVMValueRef PreviousParam => (Pointer != IntPtr.Zero) ? LLVM.GetPreviousParam(this) : default;

        public LLVMValueRef PreviousFunction => (Pointer != IntPtr.Zero) ? LLVM.GetPreviousFunction(this) : default;

        public string Section
        {
            get
            {
                if (Pointer == IntPtr.Zero)
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
                using (var marshaledSection = new MarshaledString(value))
                {
                    LLVM.SetSection(this, marshaledSection);
                }
            }
        }

        public uint SuccessorsCount => (Pointer != IntPtr.Zero) ? LLVM.GetNumSuccessors(this) : default;

        public LLVMBasicBlockRef SwitchDefaultDest => (Pointer != IntPtr.Zero) ? LLVM.GetSwitchDefaultDest(this) : default;

        public LLVMThreadLocalMode ThreadLocalMode
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetThreadLocalMode(this) : default;
            set => LLVM.SetThreadLocalMode(this, value);
        }

        public LLVMTypeRef TypeOf => (Pointer != IntPtr.Zero) ? LLVM.TypeOf(this) : default;

        public LLVMVisibility Visibility
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetVisibility(this) : default;
            set => LLVM.SetVisibility(this, value);
        }

        public bool Volatile
        {
            get => (Pointer != IntPtr.Zero) ? LLVM.GetVolatile(this) != 0 : default;
            set => LLVM.SetVolatile(this, value ? 1 : 0);
        }

        public static bool operator ==(LLVMValueRef left, LLVMValueRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMValueRef left, LLVMValueRef right) => !(left == right);

        public static LLVMValueRef CreateConstAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAdd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstAddrSpaceCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstAddrSpaceCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstAllOnes(LLVMTypeRef Ty) => LLVM.ConstAllOnes(Ty);

        public static LLVMValueRef CreateConstAnd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAnd(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstArray(LLVMTypeRef ElementTy, LLVMValueRef[] ConstantVals)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstArray(ElementTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals?.Length);
            }
        }

        public static LLVMValueRef CreateConstAShr(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAShr(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstExactSDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstExactSDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstExactUDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstExactUDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstExtractElement(LLVMValueRef VectorConstant, LLVMValueRef IndexConstant) => LLVM.ConstExtractElement(VectorConstant, IndexConstant);

        public static LLVMValueRef CreateConstExtractValue(LLVMValueRef AggConstant, uint[] IdxList)
        {
            fixed (uint* pIdxList = IdxList)
            {
                return LLVM.ConstExtractValue(AggConstant, pIdxList, (uint)IdxList?.Length);
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

        public static LLVMValueRef CreateConstGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices)
        {
            fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
            {
                return LLVM.ConstGEP(ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices?.Length);
            }
        }

        public static LLVMValueRef CreateConstInBoundsGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices)
        {
            fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
            {
                return LLVM.ConstInBoundsGEP(ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices?.Length);
            }
        }

        public static LLVMValueRef CreateConstInlineAsm(LLVMTypeRef Ty, string AsmString, string Constraints, bool HasSideEffects, bool IsAlignStack)
        {
            using (var marshaledAsmString = new MarshaledString(AsmString))
            using (var marshaledConstraints = new MarshaledString(Constraints))
            {
                return LLVM.ConstInlineAsm(Ty, marshaledAsmString, marshaledConstraints, HasSideEffects ? 1 : 0, IsAlignStack ? 1 : 0);
            }
        }

        public static LLVMValueRef CreateConstInsertElement(LLVMValueRef VectorConstant, LLVMValueRef ElementValueConstant, LLVMValueRef IndexConstant) => LLVM.ConstInsertElement(VectorConstant, ElementValueConstant, IndexConstant);

        public static LLVMValueRef CreateConstInsertValue(LLVMValueRef AggConstant, LLVMValueRef ElementValueConstant, uint[] IdxList)
        {
            fixed (uint* pIdxList = IdxList)
            {
                return LLVM.ConstInsertValue(AggConstant, ElementValueConstant, pIdxList, (uint)IdxList?.Length);
            }
        }

        public static LLVMValueRef CreateConstInt(LLVMTypeRef IntTy, ulong N, bool SignExtend = false) => LLVM.ConstInt(IntTy, N, SignExtend ? 1 : 0);

        public static LLVMValueRef CreateConstIntCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType, bool isSigned) => LLVM.ConstIntCast(ConstantVal, ToType, isSigned ? 1 : 0);

        public static LLVMValueRef CreateConstIntOfArbitraryPrecision(LLVMTypeRef IntTy, ulong[] Words)
        {
            fixed (ulong* pWords = Words)
            {
                return LLVM.ConstIntOfArbitraryPrecision(IntTy, (uint)Words?.Length, pWords);
            }
        }

        public static LLVMValueRef CreateConstIntOfString(LLVMTypeRef IntTy, string Text, byte Radix)
        {
            using (var marshaledText = new MarshaledString(Text))
            {
                return LLVM.ConstIntOfString(IntTy, marshaledText, Radix);
            }
        }

        public static LLVMValueRef CreateConstIntOfStringAndSize(LLVMTypeRef IntTy, string Text, uint SLen, byte Radix)
        {
            using (var marshaledText = new MarshaledString(Text))
            {
                return LLVM.ConstIntOfStringAndSize(IntTy, marshaledText, SLen, Radix);
            }
        }

        public static LLVMValueRef CreateConstIntToPtr(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstIntToPtr(ConstantVal, ToType);

        public static LLVMValueRef CreateConstLShr(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstLShr(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstMul(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstMul(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstNamedStruct(LLVMTypeRef StructTy, LLVMValueRef[] ConstantVals)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstNamedStruct(StructTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals?.Length);
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

        public static LLVMValueRef CreateConstRealOfString(LLVMTypeRef RealTy, string Text)
        {
            using (var marshaledText = new MarshaledString(Text))
            {
                return LLVM.ConstRealOfString(RealTy, marshaledText);
            }
        }

        public static LLVMValueRef CreateConstRealOfStringAndSize(LLVMTypeRef RealTy, string Text, uint SLen)
        {
            using (var marshaledText = new MarshaledString(Text))
            {
                return LLVM.ConstRealOfStringAndSize(RealTy, marshaledText, SLen);
            }
        }

        public static LLVMValueRef CreateConstSDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstSelect(LLVMValueRef ConstantCondition, LLVMValueRef ConstantIfTrue, LLVMValueRef ConstantIfFalse) => LLVM.ConstSelect(ConstantCondition, ConstantIfTrue, ConstantIfFalse);

        public static LLVMValueRef CreateConstSExt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSExt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstSExtOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSExtOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstShl(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstShl(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstShuffleVector(LLVMValueRef VectorAConstant, LLVMValueRef VectorBConstant, LLVMValueRef MaskConstant) => LLVM.ConstShuffleVector(VectorAConstant, VectorBConstant, MaskConstant);

        public static LLVMValueRef CreateConstSIToFP(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstSIToFP(ConstantVal, ToType);

        public static LLVMValueRef CreateConstSRem(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSRem(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstStruct(LLVMValueRef[] ConstantVals, bool Packed)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstStruct((LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals?.Length, Packed ? 1 : 0);
            }
        }

        public static LLVMValueRef CreateConstSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSub(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstTrunc(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTrunc(ConstantVal, ToType);

        public static LLVMValueRef CreateConstTruncOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTruncOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateConstUDiv(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstUDiv(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstUIToFP(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstUIToFP(ConstantVal, ToType);

        public static LLVMValueRef CreateConstURem(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstURem(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstVector(LLVMValueRef[] ScalarConstantVars)
        {
            fixed (LLVMValueRef* pScalarConstantVars = ScalarConstantVars)
            {
                return LLVM.ConstVector((LLVMOpaqueValue**)pScalarConstantVars, (uint)ScalarConstantVars?.Length);
            }
        }

        public static LLVMValueRef CreateConstXor(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstXor(LHSConstant, RHSConstant);

        public static LLVMValueRef CreateConstZExt(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstZExt(ConstantVal, ToType);

        public static LLVMValueRef CreateConstZExtOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstZExtOrBitCast(ConstantVal, ToType);

        public static LLVMValueRef CreateMDNode(LLVMValueRef[] Vals)
        {
            fixed (LLVMValueRef* pVals = Vals)
            {
                return LLVM.MDNode((LLVMOpaqueValue**)pVals, (uint)Vals?.Length);
            }
        }

        public void AddCase(LLVMValueRef OnVal, LLVMBasicBlockRef Dest) => LLVM.AddCase(this, OnVal, Dest);

        public void AddClause(LLVMValueRef ClauseVal) => LLVM.AddClause(this, ClauseVal);

        public void AddDestination(LLVMBasicBlockRef Dest) => LLVM.AddDestination(this, Dest);

        public void AddIncoming(LLVMValueRef[] IncomingValues, LLVMBasicBlockRef[] IncomingBlocks, uint Count)
        {
            fixed (LLVMValueRef* pIncomingValues = IncomingValues)
            fixed (LLVMBasicBlockRef* pIncomingBlocks = IncomingBlocks)
            {
                LLVM.AddIncoming(this, (LLVMOpaqueValue**)pIncomingValues, (LLVMOpaqueBasicBlock**)pIncomingBlocks, Count);
            }
        }

        public void AddTargetDependentFunctionAttr(string A, string V)
        {
            using (var marshaledA = new MarshaledString(A))
            using (var marshaledV = new MarshaledString(V))
            {
                LLVM.AddTargetDependentFunctionAttr(this, marshaledA, marshaledV);
            }
        }

        public LLVMBasicBlockRef AppendBasicBlock(string Name)
        {
            using (var marshaledName = new MarshaledString(Name))
            {
                return LLVM.AppendBasicBlock(this, marshaledName);
            }
        }

        public void DeleteFunction() => LLVM.DeleteFunction(this);

        public void DeleteGlobal() => LLVM.DeleteGlobal(this);

        public void Dump() => LLVM.DumpValue(this);

        public override bool Equals(object obj) => obj is LLVMValueRef other && Equals(other);

        public bool Equals(LLVMValueRef other) => Pointer == other.Pointer;

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

        public override int GetHashCode() => Pointer.GetHashCode();

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

        public void SetInstrParamAlignment(uint index, uint align) => LLVM.SetInstrParamAlignment(this, index, align);

        public void SetMetadata(uint KindID, LLVMValueRef Node) => LLVM.SetMetadata(this, KindID, Node);

        public void SetOperand(uint Index, LLVMValueRef Val) => LLVM.SetOperand(this, Index, Val);

        public void SetParamAlignment(uint align) => LLVM.SetParamAlignment(this, align);

        public void SetSuccessor(uint i, LLVMBasicBlockRef block) => LLVM.SetSuccessor(this, i, block);

        public override string ToString() => (Pointer != IntPtr.Zero) ? PrintToString() : string.Empty;

        public bool VerifyFunction(LLVMVerifierFailureAction Action) => LLVM.VerifyFunction(this, Action) == 0;

        public void ViewFunctionCFG() => LLVM.ViewFunctionCFG(this);

        public void ViewFunctionCFGOnly() => LLVM.ViewFunctionCFGOnly(this);
    }
}
