namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial struct LLVMValueRef : IEquatable<LLVMValueRef>, IHandle<Value>
    {
        public IntPtr GetInternalPointer() => Pointer;

        Value IHandle<Value>.ToWrapperType()
        {
            return Value.Create(this);
        }

        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this);
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal ?? string.Empty;
        }

        public static LLVMValueRef ConstVector(LLVMValueRef[] scalarConstantVars)
        {
            return LLVM.ConstVector(scalarConstantVars);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] constantVals, LLVMBool packed)
        {
            return LLVM.ConstStruct(constantVals, packed);
        }

        public static LLVMValueRef MDNode(LLVMValueRef[] vals)
        {
            return LLVM.MDNode(vals);
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

        public void SetValueName(string name)
        {
            LLVM.SetValueName(this, name);
        }

        public void DumpValue()
        {
            LLVM.DumpValue(this);
        }

        public string PrintValueToString()
        {
            return this.ToString();
        }

        public void ReplaceAllUsesWith(LLVMValueRef newVal)
        {
            LLVM.ReplaceAllUsesWith(this, newVal);
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

        public LLVMValueRef GetOperand(uint index)
        {
            return LLVM.GetOperand(this, index);
        }

        public LLVMUseRef GetOperandUse(uint index)
        {
            return LLVM.GetOperandUse(this, index);
        }

        public void SetOperand(uint index, LLVMValueRef val)
        {
            LLVM.SetOperand(this, index, val);
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

        public LLVMValueRef ConstAdd(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstAdd(this, rhsConstant);
        }

        public LLVMValueRef ConstNSWAdd(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNSWAdd(this, rhsConstant);
        }

        public LLVMValueRef ConstNUWAdd(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNUWAdd(this, rhsConstant);
        }

        public LLVMValueRef ConstFAdd(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstFAdd(this, rhsConstant);
        }

        public LLVMValueRef ConstSub(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstSub(this, rhsConstant);
        }

        public LLVMValueRef ConstNSWSub(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNSWSub(this, rhsConstant);
        }

        public LLVMValueRef ConstNUWSub(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNUWSub(this, rhsConstant);
        }

        public LLVMValueRef ConstFSub(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstFSub(this, rhsConstant);
        }

        public LLVMValueRef ConstMul(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstMul(this, rhsConstant);
        }

        public LLVMValueRef ConstNSWMul(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNSWMul(this, rhsConstant);
        }

        public LLVMValueRef ConstNUWMul(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstNUWMul(this, rhsConstant);
        }

        public LLVMValueRef ConstFMul(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstFMul(this, rhsConstant);
        }

        public LLVMValueRef ConstUDiv(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstUDiv(this, rhsConstant);
        }

        public LLVMValueRef ConstSDiv(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstSDiv(this, rhsConstant);
        }

        public LLVMValueRef ConstExactSDiv(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstExactSDiv(this, rhsConstant);
        }

        public LLVMValueRef ConstFDiv(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstFDiv(this, rhsConstant);
        }

        public LLVMValueRef ConstURem(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstURem(this, rhsConstant);
        }

        public LLVMValueRef ConstSRem(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstSRem(this, rhsConstant);
        }

        public LLVMValueRef ConstFRem(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstFRem(this, rhsConstant);
        }

        public LLVMValueRef ConstAnd(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstAnd(this, rhsConstant);
        }

        public LLVMValueRef ConstOr(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstOr(this, rhsConstant);
        }

        public LLVMValueRef ConstXor(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstXor(this, rhsConstant);
        }

        public LLVMValueRef ConstShl(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstShl(this, rhsConstant);
        }

        public LLVMValueRef ConstLShr(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstLShr(this, rhsConstant);
        }

        public LLVMValueRef ConstAShr(LLVMValueRef rhsConstant)
        {
            return LLVM.ConstAShr(this, rhsConstant);
        }

        public LLVMValueRef ConstGEP(LLVMValueRef[] constantIndices)
        {
            return LLVM.ConstGEP(this, constantIndices);
        }

        public LLVMValueRef ConstInBoundsGEP(LLVMValueRef[] constantIndices)
        {
            return LLVM.ConstInBoundsGEP(this, constantIndices);
        }

        public LLVMValueRef ConstTrunc(LLVMTypeRef toType)
        {
            return LLVM.ConstTrunc(this, toType);
        }

        public LLVMValueRef ConstSExt(LLVMTypeRef toType)
        {
            return LLVM.ConstSExt(this, toType);
        }

        public LLVMValueRef ConstZExt(LLVMTypeRef toType)
        {
            return LLVM.ConstZExt(this, toType);
        }

        public LLVMValueRef ConstFPTrunc(LLVMTypeRef toType)
        {
            return LLVM.ConstFPTrunc(this, toType);
        }

        public LLVMValueRef ConstFPExt(LLVMTypeRef toType)
        {
            return LLVM.ConstFPExt(this, toType);
        }

        public LLVMValueRef ConstUIToFP(LLVMTypeRef toType)
        {
            return LLVM.ConstUIToFP(this, toType);
        }

        public LLVMValueRef ConstSIToFP(LLVMTypeRef toType)
        {
            return LLVM.ConstSIToFP(this, toType);
        }

        public LLVMValueRef ConstFPToUI(LLVMTypeRef toType)
        {
            return LLVM.ConstFPToUI(this, toType);
        }

        public LLVMValueRef ConstFPToSI(LLVMTypeRef toType)
        {
            return LLVM.ConstFPToSI(this, toType);
        }

        public LLVMValueRef ConstPtrToInt(LLVMTypeRef toType)
        {
            return LLVM.ConstPtrToInt(this, toType);
        }

        public LLVMValueRef ConstIntToPtr(LLVMTypeRef toType)
        {
            return LLVM.ConstIntToPtr(this, toType);
        }

        public LLVMValueRef ConstBitCast(LLVMTypeRef toType)
        {
            return LLVM.ConstBitCast(this, toType);
        }

        public LLVMValueRef ConstAddrSpaceCast(LLVMTypeRef toType)
        {
            return LLVM.ConstAddrSpaceCast(this, toType);
        }

        public LLVMValueRef ConstZExtOrBitCast(LLVMTypeRef toType)
        {
            return LLVM.ConstZExtOrBitCast(this, toType);
        }

        public LLVMValueRef ConstSExtOrBitCast(LLVMTypeRef toType)
        {
            return LLVM.ConstSExtOrBitCast(this, toType);
        }

        public LLVMValueRef ConstTruncOrBitCast(LLVMTypeRef toType)
        {
            return LLVM.ConstTruncOrBitCast(this, toType);
        }

        public LLVMValueRef ConstPointerCast(LLVMTypeRef toType)
        {
            return LLVM.ConstPointerCast(this, toType);
        }

        public LLVMValueRef ConstIntCast(LLVMTypeRef toType, LLVMBool @isSigned)
        {
            return LLVM.ConstIntCast(this, toType, @isSigned);
        }

        public LLVMValueRef ConstFPCast(LLVMTypeRef toType)
        {
            return LLVM.ConstFPCast(this, toType);
        }

        public LLVMValueRef ConstSelect(LLVMValueRef constantIfTrue, LLVMValueRef constantIfFalse)
        {
            return LLVM.ConstSelect(this, constantIfTrue, constantIfFalse);
        }

        public LLVMValueRef ConstExtractElement(LLVMValueRef indexConstant)
        {
            return LLVM.ConstExtractElement(this, indexConstant);
        }

        public LLVMValueRef ConstInsertElement(LLVMValueRef elementValueConstant, LLVMValueRef indexConstant)
        {
            return LLVM.ConstInsertElement(this, elementValueConstant, indexConstant);
        }

        public LLVMValueRef ConstShuffleVector(LLVMValueRef vectorBConstant, LLVMValueRef maskConstant)
        {
            return LLVM.ConstShuffleVector(this, vectorBConstant, maskConstant);
        }

        public LLVMValueRef ConstExtractValue(uint[] idxList)
        {
            return LLVM.ConstExtractValue(this, idxList);
        }

        public LLVMValueRef ConstInsertValue(LLVMValueRef elementValueConstant, uint[] idxList)
        {
            return LLVM.ConstInsertValue(this, elementValueConstant, idxList);
        }

        public LLVMValueRef BlockAddress(LLVMBasicBlockRef bb)
        {
            return LLVM.BlockAddress(this, bb);
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

        public void SetLinkage(LLVMLinkage linkage)
        {
            LLVM.SetLinkage(this, linkage);
        }

        public string GetSection()
        {
            return LLVM.GetSection(this);
        }

        public void SetSection(string section)
        {
            LLVM.SetSection(this, section);
        }

        public LLVMVisibility GetVisibility()
        {
            return LLVM.GetVisibility(this);
        }

        public void SetVisibility(LLVMVisibility viz)
        {
            LLVM.SetVisibility(this, viz);
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

        public void SetUnnamedAddr(LLVMBool hasUnnamedAddr)
        {
            LLVM.SetUnnamedAddr(this, hasUnnamedAddr);
        }

        public uint GetAlignment()
        {
            return LLVM.GetAlignment(this);
        }

        public void SetAlignment(uint bytes)
        {
            LLVM.SetAlignment(this, bytes);
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

        public void SetInitializer(LLVMValueRef constantVal)
        {
            LLVM.SetInitializer(this, constantVal);
        }

        public LLVMBool IsThreadLocal()
        {
            return LLVM.IsThreadLocal(this);
        }

        public void SetThreadLocal(LLVMBool isThreadLocal)
        {
            LLVM.SetThreadLocal(this, isThreadLocal);
        }

        public LLVMBool IsGlobalConstant()
        {
            return LLVM.IsGlobalConstant(this);
        }

        public void SetGlobalConstant(LLVMBool isConstant)
        {
            LLVM.SetGlobalConstant(this, isConstant);
        }

        public LLVMThreadLocalMode GetThreadLocalMode()
        {
            return LLVM.GetThreadLocalMode(this);
        }

        public void SetThreadLocalMode(LLVMThreadLocalMode mode)
        {
            LLVM.SetThreadLocalMode(this, mode);
        }

        public LLVMBool IsExternallyInitialized()
        {
            return LLVM.IsExternallyInitialized(this);
        }

        public void SetExternallyInitialized(LLVMBool isExtInit)
        {
            LLVM.SetExternallyInitialized(this, isExtInit);
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

        public void SetFunctionCallConv(uint cc)
        {
            LLVM.SetFunctionCallConv(this, cc);
        }

        public string GetGC()
        {
            return LLVM.GetGC(this);
        }

        public void SetGC(string name)
        {
            LLVM.SetGC(this, name);
        }

        public void AddFunctionAttr(LLVMAttribute pa)
        {
            LLVM.AddFunctionAttr(this, pa);
        }

        public void AddTargetDependentFunctionAttr(string a, string v)
        {
            LLVM.AddTargetDependentFunctionAttr(this, a, v);
        }

        public LLVMAttribute GetFunctionAttr()
        {
            return LLVM.GetFunctionAttr(this);
        }

        public void RemoveFunctionAttr(LLVMAttribute pa)
        {
            LLVM.RemoveFunctionAttr(this, pa);
        }

        public uint CountParams()
        {
            return LLVM.CountParams(this);
        }

        public LLVMValueRef[] GetParams()
        {
            return LLVM.GetParams(this);
        }

        public LLVMValueRef GetParam(uint index)
        {
            return LLVM.GetParam(this, index);
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

        public void AddAttribute(LLVMAttribute pa)
        {
            LLVM.AddAttribute(this, pa);
        }

        public void RemoveAttribute(LLVMAttribute pa)
        {
            LLVM.RemoveAttribute(this, pa);
        }

        public LLVMAttribute GetAttribute()
        {
            return LLVM.GetAttribute(this);
        }

        public void SetParamAlignment(uint @align)
        {
            LLVM.SetParamAlignment(this, @align);
        }

        public string GetMDString(out uint len)
        {
            return LLVM.GetMDString(this, out len);
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

        public LLVMBasicBlockRef AppendBasicBlock(string name)
        {
            return LLVM.AppendBasicBlock(this, name);
        }

        public int HasMetadata()
        {
            return LLVM.HasMetadata(this);
        }

        public LLVMValueRef GetMetadata(uint kindID)
        {
            return LLVM.GetMetadata(this, kindID);
        }

        public void SetMetadata(uint kindID, LLVMValueRef node)
        {
            LLVM.SetMetadata(this, kindID, node);
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

        public void SetInstructionCallConv(uint cc)
        {
            LLVM.SetInstructionCallConv(this, cc);
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

        public void SetTailCall(LLVMBool isTailCall)
        {
            LLVM.SetTailCall(this, isTailCall);
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

        public void SetCondition(LLVMValueRef cond)
        {
            LLVM.SetCondition(this, cond);
        }

        public LLVMBasicBlockRef GetSwitchDefaultDest()
        {
            return LLVM.GetSwitchDefaultDest(this);
        }

        public void AddIncoming(LLVMValueRef[] incomingValues, LLVMBasicBlockRef[] incomingBlocks, uint count)
        {
            LLVM.AddIncoming(this, incomingValues, incomingBlocks, count);
        }

        public uint CountIncoming()
        {
            return LLVM.CountIncoming(this);
        }

        public LLVMValueRef GetIncomingValue(uint index)
        {
            return LLVM.GetIncomingValue(this, index);
        }

        public LLVMBasicBlockRef GetIncomingBlock(uint index)
        {
            return LLVM.GetIncomingBlock(this, index);
        }

        public void AddCase(LLVMValueRef onVal, LLVMBasicBlockRef dest)
        {
            LLVM.AddCase(this, onVal, dest);
        }

        public void AddDestination(LLVMBasicBlockRef dest)
        {
            LLVM.AddDestination(this, dest);
        }

        public void AddClause(LLVMValueRef clauseVal)
        {
            LLVM.AddClause(this, clauseVal);
        }

        public void SetCleanup(LLVMBool val)
        {
            LLVM.SetCleanup(this, val);
        }

        public LLVMBool GetVolatile()
        {
            return LLVM.GetVolatile(this);
        }

        public void SetVolatile(LLVMBool isVolatile)
        {
            LLVM.SetVolatile(this, isVolatile);
        }

        public LLVMBool VerifyFunction(LLVMVerifierFailureAction action)
        {
            return LLVM.VerifyFunction(this, action);
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