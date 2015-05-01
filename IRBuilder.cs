namespace LLVMSharp
{
    public sealed class IRBuilder
    {
        private readonly LLVMBuilderRef instance;

        public IRBuilder(LLVMBuilderRef instance)
        {
            this.instance = instance;
        }

        public void PositionBuilder(LLVMBasicBlockRef @Block, LLVMValueRef @Instr)
        {
            LLVM.PositionBuilder(this.instance, @Block, @Instr);
        }

        public void PositionBuilderBefore(LLVMValueRef @Instr)
        {
            LLVM.PositionBuilderBefore(this.instance, @Instr);
        }

        public void PositionBuilderAtEnd(LLVMBasicBlockRef @Block)
        {
            LLVM.PositionBuilderAtEnd(this.instance, @Block);
        }

        public LLVMBasicBlockRef GetInsertBlock()
        {
            return LLVM.GetInsertBlock(this.instance);
        }

        public void ClearInsertionPosition()
        {
            LLVM.ClearInsertionPosition(this.instance);
        }

        public void InsertIntoBuilder(LLVMValueRef @Instr)
        {
            LLVM.InsertIntoBuilder(this.instance, @Instr);
        }

        public void InsertIntoBuilderWithName(LLVMValueRef @Instr, string @Name)
        {
            LLVM.InsertIntoBuilderWithName(this.instance, @Instr, @Name);
        }

        public void DisposeBuilder()
        {
            LLVM.DisposeBuilder(this.instance);
        }

        public void SetCurrentDebugLocation(LLVMValueRef @L)
        {
            LLVM.SetCurrentDebugLocation(this.instance, @L);
        }

        public LLVMValueRef GetCurrentDebugLocation()
        {
            return LLVM.GetCurrentDebugLocation(this.instance);
        }

        public void SetInstDebugLocation(LLVMValueRef @Inst)
        {
            LLVM.SetInstDebugLocation(this.instance, @Inst);
        }

        {
            return LLVM.BuildRetVoid(this.instance);
        }

        {
            return LLVM.BuildRet(this.instance, @V);
        }

        {
            return LLVM.BuildAggregateRet(this.instance, out @RetVals[0], (uint)@RetVals.Length);
        }

        {
            return LLVM.BuildBr(this.instance, @Dest);
        }

        {
            return LLVM.BuildCondBr(this.instance, @If, @Then, @Else);
        }

        {
            return LLVM.BuildSwitch(this.instance, @V, @Else, @NumCases);
        }

        {
            return LLVM.BuildIndirectBr(this.instance, @Addr, @NumDests);
        }

        {
            return LLVM.BuildInvoke(this.instance, @Fn, Args, @Then, @Catch, @Name);
        }

        {
            return LLVM.BuildLandingPad(this.instance, @Ty, @PersFn, @NumClauses, @Name);
        }

        {
            return LLVM.BuildResume(this.instance, @Exn);
        }

        {
            return LLVM.BuildUnreachable(this.instance);
        }

        {
            return LLVM.BuildAdd(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNSWAdd(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNUWAdd(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFAdd(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildSub(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNSWSub(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNUWSub(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFSub(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildMul(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNSWMul(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNUWMul(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFMul(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildUDiv(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildSDiv(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildExactSDiv(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFDiv(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildURem(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildSRem(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFRem(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildShl(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildLShr(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildAShr(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildAnd(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildOr(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildXor(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildBinOp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildNeg(this.instance, @V, @Name);
        }

        {
            return LLVM.BuildNSWNeg(this.instance, @V, @Name);
        }

        {
            return LLVM.BuildNUWNeg(this.instance, @V, @Name);
        }

        {
            return LLVM.BuildFNeg(this.instance, @V, @Name);
        }

        {
            return LLVM.BuildNot(this.instance, @V, @Name);
        }

        {
            return LLVM.BuildMalloc(this.instance, @Ty, @Name);
        }

        {
            return LLVM.BuildArrayMalloc(this.instance, @Ty, @Val, @Name);
        }

        {
            return LLVM.BuildAlloca(this.instance, @Ty, @Name);
        }

        {
            return LLVM.BuildArrayAlloca(this.instance, @Ty, @Val, @Name);
        }

        {
            return LLVM.BuildFree(this.instance, @PointerVal);
        }

        {
            return LLVM.BuildLoad(this.instance, @PointerVal, @Name);
        }

        {
            return LLVM.BuildStore(this.instance, @Val, @Ptr);
        }

        {
            return LLVM.BuildGEP(this.instance, @Pointer, @Indices, @Name);
        }

        {
            return LLVM.BuildInBoundsGEP(this.instance, @Pointer, @Indices, @Name);
        }

        {
            return LLVM.BuildStructGEP(this.instance, @Pointer, @Idx, @Name);
        }

        {
            return LLVM.BuildGlobalString(this.instance, @Str, @Name);
        }

        {
            return LLVM.BuildGlobalStringPtr(this.instance, @Str, @Name);
        }

        {
            return LLVM.BuildTrunc(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildZExt(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildSExt(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildFPToUI(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildFPToSI(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildUIToFP(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildSIToFP(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildFPTrunc(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildFPExt(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildPtrToInt(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildIntToPtr(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildBitCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildAddrSpaceCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildZExtOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildSExtOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildTruncOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildCast(this.instance, @Op, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildPointerCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildIntCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildFPCast(this.instance, @Val, @DestTy, @Name);
        }

        {
            return LLVM.BuildICmp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFCmp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildPhi(this.instance, @Ty, @Name);
        }

        {
            return LLVM.BuildCall(this.instance, @Fn, @Args, @Name);
        }

        {
            return LLVM.BuildSelect(this.instance, @If, @Then, @Else, @Name);
        }

        {
            return LLVM.BuildVAArg(this.instance, @List, @Ty, @Name);
        }

        {
            return LLVM.BuildExtractElement(this.instance, @VecVal, @Index, @Name);
        }

        {
            return LLVM.BuildInsertElement(this.instance, @VecVal, @EltVal, @Index, @Name);
        }

        {
            return LLVM.BuildShuffleVector(this.instance, @V1, @V2, @Mask, @Name);
        }

        {
            return LLVM.BuildExtractValue(this.instance, @AggVal, @Index, @Name);
        }

        {
            return LLVM.BuildInsertValue(this.instance, @AggVal, @EltVal, @Index, @Name);
        }

        {
            return LLVM.BuildIsNull(this.instance, @Val, @Name);
        }

        {
            return LLVM.BuildIsNotNull(this.instance, @Val, @Name);
        }

        {
            return LLVM.BuildPtrDiff(this.instance, @LHS, @RHS, @Name);
        }

        {
            return LLVM.BuildFence(this.instance, @ordering, @singleThread, @Name);
        }

        {
            return LLVM.BuildAtomicRMW(this.instance, @op, @PTR, @Val, @ordering, @singleThread);
        }
    }
}