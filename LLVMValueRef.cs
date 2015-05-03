namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial struct LLVMValueRef : IEquatable<LLVMValueRef>
    {
        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this);
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal ?? string.Empty;
        }

        public static LLVMValueRef ConstVector(LLVMValueRef[] @ScalarConstantVars)
        {
            return LLVM.ConstVector(@ScalarConstantVars);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] @ConstantVals, LLVMBool @Packed)
        {
            return LLVM.ConstStruct(@ConstantVals, @Packed);
        }

        public static LLVMValueRef MDNode(LLVMValueRef[] Vals)
        {
            return LLVM.MDNode(Vals);
        }
        
        public LLVMValueRef GetNextFunction()
        {
            return LLVM.GetNextFunction(this);
        }

        public LLVMValueRef GetPreviousFunction()
        {
            return LLVM.GetPreviousFunction(this);
        }

        public LLVMTypeRef TypeOf()
        {
            return LLVM.TypeOf(this);
        }

        public string GetValueName()
        {
            return this.ToString();
        }

        public void SetValueName(string @Name)
        {
            LLVM.SetValueName(this, @Name);
        }

        public void DumpValue()
        {
            LLVM.DumpValue(this);
        }

        public string PrintValueToString()
        {
            return this.ToString();
        }

        public void ReplaceAllUsesWith(LLVMValueRef @NewVal)
        {
            LLVM.ReplaceAllUsesWith(this, @NewVal);
        }

        public LLVMBool IsConstant()
        {
            return LLVM.IsConstant(this);
        }

        public LLVMBool IsUndef()
        {
            return LLVM.IsUndef(this);
        }

        public LLVMValueRef IsAArgument()
        {
            return LLVM.IsAArgument(this);
        }

        public LLVMValueRef IsABasicBlock()
        {
            return LLVM.IsABasicBlock(this);
        }

        public LLVMValueRef IsAInlineAsm()
        {
            return LLVM.IsAInlineAsm(this);
        }

        public LLVMValueRef IsAUser()
        {
            return LLVM.IsAUser(this);
        }

        public LLVMValueRef IsAConstant()
        {
            return LLVM.IsAConstant(this);
        }

        public LLVMValueRef IsABlockAddress()
        {
            return LLVM.IsABlockAddress(this);
        }

        public LLVMValueRef IsAConstantAggregateZero()
        {
            return LLVM.IsAConstantAggregateZero(this);
        }

        public LLVMValueRef IsAConstantArray()
        {
            return LLVM.IsAConstantArray(this);
        }

        public LLVMValueRef IsAConstantDataSequential()
        {
            return LLVM.IsAConstantDataSequential(this);
        }

        public LLVMValueRef IsAConstantDataArray()
        {
            return LLVM.IsAConstantDataArray(this);
        }

        public LLVMValueRef IsAConstantDataVector()
        {
            return LLVM.IsAConstantDataVector(this);
        }

        public LLVMValueRef IsAConstantExpr()
        {
            return LLVM.IsAConstantExpr(this);
        }

        public LLVMValueRef IsAConstantFP()
        {
            return LLVM.IsAConstantFP(this);
        }

        public LLVMValueRef IsAConstantInt()
        {
            return LLVM.IsAConstantInt(this);
        }

        public LLVMValueRef IsAConstantPointerNull()
        {
            return LLVM.IsAConstantPointerNull(this);
        }

        public LLVMValueRef IsAConstantStruct()
        {
            return LLVM.IsAConstantStruct(this);
        }

        public LLVMValueRef IsAConstantVector()
        {
            return LLVM.IsAConstantVector(this);
        }

        public LLVMValueRef IsAGlobalValue()
        {
            return LLVM.IsAGlobalValue(this);
        }

        public LLVMValueRef IsAGlobalAlias()
        {
            return LLVM.IsAGlobalAlias(this);
        }

        public LLVMValueRef IsAGlobalObject()
        {
            return LLVM.IsAGlobalObject(this);
        }

        public LLVMValueRef IsAFunction()
        {
            return LLVM.IsAFunction(this);
        }

        public LLVMValueRef IsAGlobalVariable()
        {
            return LLVM.IsAGlobalVariable(this);
        }

        public LLVMValueRef IsAUndefValue()
        {
            return LLVM.IsAUndefValue(this);
        }

        public LLVMValueRef IsAInstruction()
        {
            return LLVM.IsAInstruction(this);
        }

        public LLVMValueRef IsABinaryOperator()
        {
            return LLVM.IsABinaryOperator(this);
        }

        public LLVMValueRef IsACallInst()
        {
            return LLVM.IsACallInst(this);
        }

        public LLVMValueRef IsAIntrinsicInst()
        {
            return LLVM.IsAIntrinsicInst(this);
        }

        public LLVMValueRef IsADbgInfoIntrinsic()
        {
            return LLVM.IsADbgInfoIntrinsic(this);
        }

        public LLVMValueRef IsADbgDeclareInst()
        {
            return LLVM.IsADbgDeclareInst(this);
        }

        public LLVMValueRef IsAMemIntrinsic()
        {
            return LLVM.IsAMemIntrinsic(this);
        }

        public LLVMValueRef IsAMemCpyInst()
        {
            return LLVM.IsAMemCpyInst(this);
        }

        public LLVMValueRef IsAMemMoveInst()
        {
            return LLVM.IsAMemMoveInst(this);
        }

        public LLVMValueRef IsAMemSetInst()
        {
            return LLVM.IsAMemSetInst(this);
        }

        public LLVMValueRef IsACmpInst()
        {
            return LLVM.IsACmpInst(this);
        }

        public LLVMValueRef IsAFCmpInst()
        {
            return LLVM.IsAFCmpInst(this);
        }

        public LLVMValueRef IsAICmpInst()
        {
            return LLVM.IsAICmpInst(this);
        }

        public LLVMValueRef IsAExtractElementInst()
        {
            return LLVM.IsAExtractElementInst(this);
        }

        public LLVMValueRef IsAGetElementPtrInst()
        {
            return LLVM.IsAGetElementPtrInst(this);
        }

        public LLVMValueRef IsAInsertElementInst()
        {
            return LLVM.IsAInsertElementInst(this);
        }

        public LLVMValueRef IsAInsertValueInst()
        {
            return LLVM.IsAInsertValueInst(this);
        }

        public LLVMValueRef IsALandingPadInst()
        {
            return LLVM.IsALandingPadInst(this);
        }

        public LLVMValueRef IsAPHINode()
        {
            return LLVM.IsAPHINode(this);
        }

        public LLVMValueRef IsASelectInst()
        {
            return LLVM.IsASelectInst(this);
        }

        public LLVMValueRef IsAShuffleVectorInst()
        {
            return LLVM.IsAShuffleVectorInst(this);
        }

        public LLVMValueRef IsAStoreInst()
        {
            return LLVM.IsAStoreInst(this);
        }

        public LLVMValueRef IsATerminatorInst()
        {
            return LLVM.IsATerminatorInst(this);
        }

        public LLVMValueRef IsABranchInst()
        {
            return LLVM.IsABranchInst(this);
        }

        public LLVMValueRef IsAIndirectBrInst()
        {
            return LLVM.IsAIndirectBrInst(this);
        }

        public LLVMValueRef IsAInvokeInst()
        {
            return LLVM.IsAInvokeInst(this);
        }

        public LLVMValueRef IsAReturnInst()
        {
            return LLVM.IsAReturnInst(this);
        }

        public LLVMValueRef IsASwitchInst()
        {
            return LLVM.IsASwitchInst(this);
        }

        public LLVMValueRef IsAUnreachableInst()
        {
            return LLVM.IsAUnreachableInst(this);
        }

        public LLVMValueRef IsAResumeInst()
        {
            return LLVM.IsAResumeInst(this);
        }

        public LLVMValueRef IsAUnaryInstruction()
        {
            return LLVM.IsAUnaryInstruction(this);
        }

        public LLVMValueRef IsAAllocaInst()
        {
            return LLVM.IsAAllocaInst(this);
        }

        public LLVMValueRef IsACastInst()
        {
            return LLVM.IsACastInst(this);
        }

        public LLVMValueRef IsAAddrSpaceCastInst()
        {
            return LLVM.IsAAddrSpaceCastInst(this);
        }

        public LLVMValueRef IsABitCastInst()
        {
            return LLVM.IsABitCastInst(this);
        }

        public LLVMValueRef IsAFPExtInst()
        {
            return LLVM.IsAFPExtInst(this);
        }

        public LLVMValueRef IsAFPToSIInst()
        {
            return LLVM.IsAFPToSIInst(this);
        }

        public LLVMValueRef IsAFPToUIInst()
        {
            return LLVM.IsAFPToUIInst(this);
        }

        public LLVMValueRef IsAFPTruncInst()
        {
            return LLVM.IsAFPTruncInst(this);
        }

        public LLVMValueRef IsAIntToPtrInst()
        {
            return LLVM.IsAIntToPtrInst(this);
        }

        public LLVMValueRef IsAPtrToIntInst()
        {
            return LLVM.IsAPtrToIntInst(this);
        }

        public LLVMValueRef IsASExtInst()
        {
            return LLVM.IsASExtInst(this);
        }

        public LLVMValueRef IsASIToFPInst()
        {
            return LLVM.IsASIToFPInst(this);
        }

        public LLVMValueRef IsATruncInst()
        {
            return LLVM.IsATruncInst(this);
        }

        public LLVMValueRef IsAUIToFPInst()
        {
            return LLVM.IsAUIToFPInst(this);
        }

        public LLVMValueRef IsAZExtInst()
        {
            return LLVM.IsAZExtInst(this);
        }

        public LLVMValueRef IsAExtractValueInst()
        {
            return LLVM.IsAExtractValueInst(this);
        }

        public LLVMValueRef IsALoadInst()
        {
            return LLVM.IsALoadInst(this);
        }

        public LLVMValueRef IsAVAArgInst()
        {
            return LLVM.IsAVAArgInst(this);
        }

        public LLVMValueRef IsAMDNode()
        {
            return LLVM.IsAMDNode(this);
        }

        public LLVMValueRef IsAMDString()
        {
            return LLVM.IsAMDString(this);
        }

        public LLVMUseRef GetFirstUse()
        {
            return LLVM.GetFirstUse(this);
        }

        public LLVMValueRef GetOperand(uint @Index)
        {
            return LLVM.GetOperand(this, @Index);
        }

        public LLVMUseRef GetOperandUse(uint @Index)
        {
            return LLVM.GetOperandUse(this, @Index);
        }

        public void SetOperand(uint @Index, LLVMValueRef @Val)
        {
            LLVM.SetOperand(this, @Index, @Val);
        }

        public int GetNumOperands()
        {
            return LLVM.GetNumOperands(this);
        }

        public LLVMBool IsNull()
        {
            return LLVM.IsNull(this);
        }

        public ulong ConstIntGetZExtValue()
        {
            return LLVM.ConstIntGetZExtValue(this);
        }

        public long ConstIntGetSExtValue()
        {
            return LLVM.ConstIntGetSExtValue(this);
        }

        public double ConstRealGetDouble(out LLVMBool @losesInfo)
        {
            return LLVM.ConstRealGetDouble(this, out @losesInfo);
        }

        public LLVMBool IsConstantString()
        {
            return LLVM.IsConstantString(this);
        }

        public string GetAsString(out int @out)
        {
            return LLVM.GetAsString(this, out @out);
        }

        public LLVMValueRef GetElementAsConstant(uint @idx)
        {
            return LLVM.GetElementAsConstant(this, @idx);
        }

        public LLVMOpcode GetConstOpcode()
        {
            return LLVM.GetConstOpcode(this);
        }

        public LLVMValueRef ConstNeg()
        {
            return LLVM.ConstNeg(this);
        }

        public LLVMValueRef ConstNSWNeg()
        {
            return LLVM.ConstNSWNeg(this);
        }

        public LLVMValueRef ConstNUWNeg()
        {
            return LLVM.ConstNUWNeg(this);
        }

        public LLVMValueRef ConstFNeg()
        {
            return LLVM.ConstFNeg(this);
        }

        public LLVMValueRef ConstNot()
        {
            return LLVM.ConstNot(this);
        }

        public LLVMValueRef ConstAdd(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstAdd(this, @RHSConstant);
        }

        public LLVMValueRef ConstNSWAdd(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNSWAdd(this, @RHSConstant);
        }

        public LLVMValueRef ConstNUWAdd(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNUWAdd(this, @RHSConstant);
        }

        public LLVMValueRef ConstFAdd(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstFAdd(this, @RHSConstant);
        }

        public LLVMValueRef ConstSub(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstSub(this, @RHSConstant);
        }

        public LLVMValueRef ConstNSWSub(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNSWSub(this, @RHSConstant);
        }

        public LLVMValueRef ConstNUWSub(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNUWSub(this, @RHSConstant);
        }

        public LLVMValueRef ConstFSub(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstFSub(this, @RHSConstant);
        }

        public LLVMValueRef ConstMul(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstMul(this, @RHSConstant);
        }

        public LLVMValueRef ConstNSWMul(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNSWMul(this, @RHSConstant);
        }

        public LLVMValueRef ConstNUWMul(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstNUWMul(this, @RHSConstant);
        }

        public LLVMValueRef ConstFMul(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstFMul(this, @RHSConstant);
        }

        public LLVMValueRef ConstUDiv(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstUDiv(this, @RHSConstant);
        }

        public LLVMValueRef ConstSDiv(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstSDiv(this, @RHSConstant);
        }

        public LLVMValueRef ConstExactSDiv(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstExactSDiv(this, @RHSConstant);
        }

        public LLVMValueRef ConstFDiv(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstFDiv(this, @RHSConstant);
        }

        public LLVMValueRef ConstURem(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstURem(this, @RHSConstant);
        }

        public LLVMValueRef ConstSRem(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstSRem(this, @RHSConstant);
        }

        public LLVMValueRef ConstFRem(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstFRem(this, @RHSConstant);
        }

        public LLVMValueRef ConstAnd(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstAnd(this, @RHSConstant);
        }

        public LLVMValueRef ConstOr(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstOr(this, @RHSConstant);
        }

        public LLVMValueRef ConstXor(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstXor(this, @RHSConstant);
        }

        public LLVMValueRef ConstShl(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstShl(this, @RHSConstant);
        }

        public LLVMValueRef ConstLShr(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstLShr(this, @RHSConstant);
        }

        public LLVMValueRef ConstAShr(LLVMValueRef @RHSConstant)
        {
            return LLVM.ConstAShr(this, @RHSConstant);
        }

        public LLVMValueRef ConstGEP(LLVMValueRef[] @ConstantIndices)
        {
            return LLVM.ConstGEP(this, @ConstantIndices);
        }

        public LLVMValueRef ConstInBoundsGEP(LLVMValueRef[] @ConstantIndices)
        {
            return LLVM.ConstInBoundsGEP(this, @ConstantIndices);
        }

        public LLVMValueRef ConstTrunc(LLVMTypeRef @ToType)
        {
            return LLVM.ConstTrunc(this, @ToType);
        }

        public LLVMValueRef ConstSExt(LLVMTypeRef @ToType)
        {
            return LLVM.ConstSExt(this, @ToType);
        }

        public LLVMValueRef ConstZExt(LLVMTypeRef @ToType)
        {
            return LLVM.ConstZExt(this, @ToType);
        }

        public LLVMValueRef ConstFPTrunc(LLVMTypeRef @ToType)
        {
            return LLVM.ConstFPTrunc(this, @ToType);
        }

        public LLVMValueRef ConstFPExt(LLVMTypeRef @ToType)
        {
            return LLVM.ConstFPExt(this, @ToType);
        }

        public LLVMValueRef ConstUIToFP(LLVMTypeRef @ToType)
        {
            return LLVM.ConstUIToFP(this, @ToType);
        }

        public LLVMValueRef ConstSIToFP(LLVMTypeRef @ToType)
        {
            return LLVM.ConstSIToFP(this, @ToType);
        }

        public LLVMValueRef ConstFPToUI(LLVMTypeRef @ToType)
        {
            return LLVM.ConstFPToUI(this, @ToType);
        }

        public LLVMValueRef ConstFPToSI(LLVMTypeRef @ToType)
        {
            return LLVM.ConstFPToSI(this, @ToType);
        }

        public LLVMValueRef ConstPtrToInt(LLVMTypeRef @ToType)
        {
            return LLVM.ConstPtrToInt(this, @ToType);
        }

        public LLVMValueRef ConstIntToPtr(LLVMTypeRef @ToType)
        {
            return LLVM.ConstIntToPtr(this, @ToType);
        }

        public LLVMValueRef ConstBitCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstBitCast(this, @ToType);
        }

        public LLVMValueRef ConstAddrSpaceCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstAddrSpaceCast(this, @ToType);
        }

        public LLVMValueRef ConstZExtOrBitCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstZExtOrBitCast(this, @ToType);
        }

        public LLVMValueRef ConstSExtOrBitCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstSExtOrBitCast(this, @ToType);
        }

        public LLVMValueRef ConstTruncOrBitCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstTruncOrBitCast(this, @ToType);
        }

        public LLVMValueRef ConstPointerCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstPointerCast(this, @ToType);
        }

        public LLVMValueRef ConstIntCast(LLVMTypeRef @ToType, LLVMBool @isSigned)
        {
            return LLVM.ConstIntCast(this, @ToType, @isSigned);
        }

        public LLVMValueRef ConstFPCast(LLVMTypeRef @ToType)
        {
            return LLVM.ConstFPCast(this, @ToType);
        }

        public LLVMValueRef ConstSelect(LLVMValueRef @ConstantIfTrue, LLVMValueRef @ConstantIfFalse)
        {
            return LLVM.ConstSelect(this, @ConstantIfTrue, @ConstantIfFalse);
        }

        public LLVMValueRef ConstExtractElement(LLVMValueRef @IndexConstant)
        {
            return LLVM.ConstExtractElement(this, @IndexConstant);
        }

        public LLVMValueRef ConstInsertElement(LLVMValueRef @ElementValueConstant, LLVMValueRef @IndexConstant)
        {
            return LLVM.ConstInsertElement(this, @ElementValueConstant, @IndexConstant);
        }

        public LLVMValueRef ConstShuffleVector(LLVMValueRef @VectorBConstant, LLVMValueRef @MaskConstant)
        {
            return LLVM.ConstShuffleVector(this, @VectorBConstant, @MaskConstant);
        }

        public LLVMValueRef ConstExtractValue(uint[] @IdxList)
        {
            return LLVM.ConstExtractValue(this, @IdxList);
        }

        public LLVMValueRef ConstInsertValue(LLVMValueRef @ElementValueConstant, uint[] @IdxList)
        {
            return LLVM.ConstInsertValue(this, @ElementValueConstant, @IdxList);
        }

        public LLVMValueRef BlockAddress(LLVMBasicBlockRef @BB)
        {
            return LLVM.BlockAddress(this, @BB);
        }

        public LLVMModuleRef GetGlobalParent()
        {
            return LLVM.GetGlobalParent(this);
        }

        public LLVMBool IsDeclaration()
        {
            return LLVM.IsDeclaration(this);
        }

        public LLVMLinkage GetLinkage()
        {
            return LLVM.GetLinkage(this);
        }

        public void SetLinkage(LLVMLinkage @Linkage)
        {
            LLVM.SetLinkage(this, @Linkage);
        }

        public string GetSection()
        {
            return LLVM.GetSection(this);
        }

        public void SetSection(string @Section)
        {
            LLVM.SetSection(this, @Section);
        }

        public LLVMVisibility GetVisibility()
        {
            return LLVM.GetVisibility(this);
        }

        public void SetVisibility(LLVMVisibility @Viz)
        {
            LLVM.SetVisibility(this, @Viz);
        }

        public LLVMDLLStorageClass GetDLLStorageClass()
        {
            return LLVM.GetDLLStorageClass(this);
        }

        public void SetDLLStorageClass(LLVMDLLStorageClass @Class)
        {
            LLVM.SetDLLStorageClass(this, @Class);
        }

        public LLVMBool HasUnnamedAddr()
        {
            return LLVM.HasUnnamedAddr(this);
        }

        public void SetUnnamedAddr(LLVMBool @HasUnnamedAddr)
        {
            LLVM.SetUnnamedAddr(this, @HasUnnamedAddr);
        }

        public uint GetAlignment()
        {
            return LLVM.GetAlignment(this);
        }

        public void SetAlignment(uint @Bytes)
        {
            LLVM.SetAlignment(this, @Bytes);
        }

        public LLVMValueRef GetNextGlobal()
        {
            return LLVM.GetNextGlobal(this);
        }

        public LLVMValueRef GetPreviousGlobal()
        {
            return LLVM.GetPreviousGlobal(this);
        }

        public void DeleteGlobal()
        {
            LLVM.DeleteGlobal(this);
        }

        public LLVMValueRef GetInitializer()
        {
            return LLVM.GetInitializer(this);
        }

        public void SetInitializer(LLVMValueRef @ConstantVal)
        {
            LLVM.SetInitializer(this, @ConstantVal);
        }

        public LLVMBool IsThreadLocal()
        {
            return LLVM.IsThreadLocal(this);
        }

        public void SetThreadLocal(LLVMBool @IsThreadLocal)
        {
            LLVM.SetThreadLocal(this, @IsThreadLocal);
        }

        public LLVMBool IsGlobalConstant()
        {
            return LLVM.IsGlobalConstant(this);
        }

        public void SetGlobalConstant(LLVMBool @IsConstant)
        {
            LLVM.SetGlobalConstant(this, @IsConstant);
        }

        public LLVMThreadLocalMode GetThreadLocalMode()
        {
            return LLVM.GetThreadLocalMode(this);
        }

        public void SetThreadLocalMode(LLVMThreadLocalMode @Mode)
        {
            LLVM.SetThreadLocalMode(this, @Mode);
        }

        public LLVMBool IsExternallyInitialized()
        {
            return LLVM.IsExternallyInitialized(this);
        }

        public void SetExternallyInitialized(LLVMBool @IsExtInit)
        {
            LLVM.SetExternallyInitialized(this, @IsExtInit);
        }

        public void DeleteFunction()
        {
            LLVM.DeleteFunction(this);
        }

        public uint GetIntrinsicID()
        {
            return LLVM.GetIntrinsicID(this);
        }

        public uint GetFunctionCallConv()
        {
            return LLVM.GetFunctionCallConv(this);
        }

        public void SetFunctionCallConv(uint @CC)
        {
            LLVM.SetFunctionCallConv(this, @CC);
        }

        public string GetGC()
        {
            return LLVM.GetGC(this);
        }

        public void SetGC(string @Name)
        {
            LLVM.SetGC(this, @Name);
        }

        public void AddFunctionAttr(LLVMAttribute @PA)
        {
            LLVM.AddFunctionAttr(this, @PA);
        }

        public void AddTargetDependentFunctionAttr(string @A, string @V)
        {
            LLVM.AddTargetDependentFunctionAttr(this, @A, @V);
        }

        public LLVMAttribute GetFunctionAttr()
        {
            return LLVM.GetFunctionAttr(this);
        }

        public void RemoveFunctionAttr(LLVMAttribute @PA)
        {
            LLVM.RemoveFunctionAttr(this, @PA);
        }

        public uint CountParams()
        {
            return LLVM.CountParams(this);
        }

        public LLVMValueRef[] GetParams()
        {
            return LLVM.GetParams(this);
        }

        public LLVMValueRef GetParam(uint @Index)
        {
            return LLVM.GetParam(this, @Index);
        }

        public LLVMValueRef GetParamParent()
        {
            return LLVM.GetParamParent(this);
        }

        public LLVMValueRef GetFirstParam()
        {
            return LLVM.GetFirstParam(this);
        }

        public LLVMValueRef GetLastParam()
        {
            return LLVM.GetLastParam(this);
        }

        public LLVMValueRef GetNextParam()
        {
            return LLVM.GetNextParam(this);
        }

        public LLVMValueRef GetPreviousParam()
        {
            return LLVM.GetPreviousParam(this);
        }

        public void AddAttribute(LLVMAttribute @PA)
        {
            LLVM.AddAttribute(this, @PA);
        }

        public void RemoveAttribute(LLVMAttribute @PA)
        {
            LLVM.RemoveAttribute(this, @PA);
        }

        public LLVMAttribute GetAttribute()
        {
            return LLVM.GetAttribute(this);
        }

        public void SetParamAlignment(uint @align)
        {
            LLVM.SetParamAlignment(this, @align);
        }

        public string GetMDString(out uint @Len)
        {
            return LLVM.GetMDString(this, out @Len);
        }

        public uint GetMDNodeNumOperands()
        {
            return LLVM.GetMDNodeNumOperands(this);
        }

        public LLVMValueRef[] GetMDNodeOperands()
        {
            return LLVM.GetMDNodeOperands(this);
        }

        public LLVMBool ValueIsBasicBlock()
        {
            return LLVM.ValueIsBasicBlock(this);
        }

        public LLVMBasicBlockRef ValueAsBasicBlock()
        {
            return LLVM.ValueAsBasicBlock(this);
        }

        public uint CountBasicBlocks()
        {
            return LLVM.CountBasicBlocks(this);
        }

        public LLVMBasicBlockRef[] GetBasicBlocks()
        {
            return LLVM.GetBasicBlocks(this);
        }

        public LLVMBasicBlockRef GetFirstBasicBlock()
        {
            return LLVM.GetFirstBasicBlock(this);
        }

        public LLVMBasicBlockRef GetLastBasicBlock()
        {
            return LLVM.GetLastBasicBlock(this);
        }

        public LLVMBasicBlockRef GetEntryBasicBlock()
        {
            return LLVM.GetEntryBasicBlock(this);
        }

        public LLVMBasicBlockRef AppendBasicBlock(string @Name)
        {
            return LLVM.AppendBasicBlock(this, @Name);
        }

        public int HasMetadata()
        {
            return LLVM.HasMetadata(this);
        }

        public LLVMValueRef GetMetadata(uint @KindID)
        {
            return LLVM.GetMetadata(this, @KindID);
        }

        public void SetMetadata(uint @KindID, LLVMValueRef @Node)
        {
            LLVM.SetMetadata(this, @KindID, @Node);
        }

        public LLVMBasicBlockRef GetInstructionParent()
        {
            return LLVM.GetInstructionParent(this);
        }

        public LLVMValueRef GetNextInstruction()
        {
            return LLVM.GetNextInstruction(this);
        }

        public LLVMValueRef GetPreviousInstruction()
        {
            return LLVM.GetPreviousInstruction(this);
        }

        public void InstructionEraseFromParent()
        {
            LLVM.InstructionEraseFromParent(this);
        }

        public LLVMOpcode GetInstructionOpcode()
        {
            return LLVM.GetInstructionOpcode(this);
        }

        public LLVMIntPredicate GetICmpPredicate()
        {
            return LLVM.GetICmpPredicate(this);
        }

        public LLVMRealPredicate GetFCmpPredicate()
        {
            return LLVM.GetFCmpPredicate(this);
        }

        public LLVMValueRef InstructionClone()
        {
            return LLVM.InstructionClone(this);
        }

        public void SetInstructionCallConv(uint @CC)
        {
            LLVM.SetInstructionCallConv(this, @CC);
        }

        public uint GetInstructionCallConv()
        {
            return LLVM.GetInstructionCallConv(this);
        }

        public void AddInstrAttribute(uint @index, LLVMAttribute @param2)
        {
            LLVM.AddInstrAttribute(this, @index, @param2);
        }

        public void RemoveInstrAttribute(uint @index, LLVMAttribute @param2)
        {
            LLVM.RemoveInstrAttribute(this, @index, @param2);
        }

        public void SetInstrParamAlignment(uint @index, uint @align)
        {
            LLVM.SetInstrParamAlignment(this, @index, @align);
        }

        public LLVMBool IsTailCall()
        {
            return LLVM.IsTailCall(this);
        }

        public void SetTailCall(LLVMBool @IsTailCall)
        {
            LLVM.SetTailCall(this, @IsTailCall);
        }

        public uint GetNumSuccessors()
        {
            return LLVM.GetNumSuccessors(this);
        }

        public LLVMBasicBlockRef GetSuccessor(uint @i)
        {
            return LLVM.GetSuccessor(this, @i);
        }

        public void SetSuccessor(uint @i, LLVMBasicBlockRef @block)
        {
            LLVM.SetSuccessor(this, @i, @block);
        }

        public LLVMBool IsConditional()
        {
            return LLVM.IsConditional(this);
        }

        public LLVMValueRef GetCondition()
        {
            return LLVM.GetCondition(this);
        }

        public void SetCondition(LLVMValueRef @Cond)
        {
            LLVM.SetCondition(this, @Cond);
        }

        public LLVMBasicBlockRef GetSwitchDefaultDest()
        {
            return LLVM.GetSwitchDefaultDest(this);
        }

        public void AddIncoming(LLVMValueRef[] @IncomingValues, LLVMBasicBlockRef[] @IncomingBlocks, uint @Count)
        {
            LLVM.AddIncoming(this, @IncomingValues, @IncomingBlocks, @Count);
        }

        public uint CountIncoming()
        {
            return LLVM.CountIncoming(this);
        }

        public LLVMValueRef GetIncomingValue(uint @Index)
        {
            return LLVM.GetIncomingValue(this, @Index);
        }

        public LLVMBasicBlockRef GetIncomingBlock(uint @Index)
        {
            return LLVM.GetIncomingBlock(this, @Index);
        }

        public void AddCase(LLVMValueRef @OnVal, LLVMBasicBlockRef @Dest)
        {
            LLVM.AddCase(this, @OnVal, @Dest);
        }

        public void AddDestination(LLVMBasicBlockRef @Dest)
        {
            LLVM.AddDestination(this, @Dest);
        }

        public void AddClause(LLVMValueRef @ClauseVal)
        {
            LLVM.AddClause(this, @ClauseVal);
        }

        public void SetCleanup(LLVMBool @Val)
        {
            LLVM.SetCleanup(this, @Val);
        }

        public LLVMBool GetVolatile()
        {
            return LLVM.GetVolatile(this);
        }

        public void SetVolatile(LLVMBool @IsVolatile)
        {
            LLVM.SetVolatile(this, @IsVolatile);
        }

        public LLVMBool VerifyFunction(LLVMVerifierFailureAction @Action)
        {
            return LLVM.VerifyFunction(this, @Action);
        }

        public void ViewFunctionCFG()
        {
            LLVM.ViewFunctionCFG(this);
        }

        public void ViewFunctionCFGOnly()
        {
            LLVM.ViewFunctionCFGOnly(this);
        }

        public bool Equals(LLVMValueRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMValueRef)
            {
                return this.Equals((LLVMValueRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMValueRef op1, LLVMValueRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMValueRef op1, LLVMValueRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}