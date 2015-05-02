namespace LLVMSharp
{
    using System;

    public sealed class IRBuilder : IDisposable
    {
        private readonly LLVMBuilderRef instance;

        private bool disposed;

        public IRBuilder(LLVMContextRef context)
        {
            this.instance = LLVM.CreateBuilderInContext(context);
        }

        public IRBuilder() : this(LLVM.GetGlobalContext())
        {
        }

        ~IRBuilder()
        {
            this.Dispose(false);
        }

        public void PositionBuilder(BasicBlock @Block, Value @Instr)
        {
            LLVM.PositionBuilder(this.instance, @Block, @Instr);
        }

        public void PositionBuilderBefore(Value @Instr)
        {
            LLVM.PositionBuilderBefore(this.instance, @Instr);
        }

        public void PositionBuilderAtEnd(BasicBlock @Block)
        {
            LLVM.PositionBuilderAtEnd(this.instance, @Block);
        }

        public BasicBlock GetInsertBlock()
        {
            return new BasicBlock(LLVM.GetInsertBlock(this.instance));
        }

        public void ClearInsertionPosition()
        {
            LLVM.ClearInsertionPosition(this.instance);
        }

        public void InsertIntoBuilder(Value @Instr)
        {
            LLVM.InsertIntoBuilder(this.instance, @Instr);
        }

        public void InsertIntoBuilderWithName(Value @Instr, string @Name)
        {
            LLVM.InsertIntoBuilderWithName(this.instance, @Instr, @Name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            LLVM.DisposeBuilder(this.instance);

            this.disposed = true;
        }

        public void SetCurrentDebugLocation(Value @L)
        {
            LLVM.SetCurrentDebugLocation(this.instance, @L);
        }

        public Value GetCurrentDebugLocation()
        {
            return LLVM.GetCurrentDebugLocation(this.instance);
        }

        public void SetInstDebugLocation(Value @Inst)
        {
            LLVM.SetInstDebugLocation(this.instance, @Inst);
        }

        public Value CreateRetVoid()
        {
            return LLVM.BuildRetVoid(this.instance);
        }

        public Value CreateRet(Value @V)
        {
            return LLVM.BuildRet(this.instance, @V);
        }

        public Value CreateAggregateRet(Value[] @RetVals)
        {
            return LLVM.BuildAggregateRet(this.instance, LLVMValueRef.FromArray(@RetVals));
        }

        public Value CreateBr(BasicBlock @Dest)
        {
            return LLVM.BuildBr(this.instance, @Dest);
        }

        public Value CreateCondBr(Value @If, BasicBlock @Then, BasicBlock @Else)
        {
            return LLVM.BuildCondBr(this.instance, @If, @Then, @Else);
        }

        public Value CreateSwitch(Value @V, BasicBlock @Else, uint @NumCases)
        {
            return LLVM.BuildSwitch(this.instance, @V, @Else, @NumCases);
        }

        public Value CreateIndirectBr(Value @Addr, uint @NumDests)
        {
            return LLVM.BuildIndirectBr(this.instance, @Addr, @NumDests);
        }

        public Value CreateInvoke(Value @Fn, Value[] @Args, BasicBlock @Then, BasicBlock @Catch, string @Name)
        {
            return LLVM.BuildInvoke(this.instance, @Fn, LLVMValueRef.FromArray(Args), @Then, @Catch, @Name);
        }

        public Value CreateLandingPad(LLVMTypeRef @Ty, Value @PersFn, uint @NumClauses, string @Name)
        {
            return LLVM.BuildLandingPad(this.instance, @Ty, @PersFn, @NumClauses, @Name);
        }

        public Value CreateResume(Value @Exn)
        {
            return LLVM.BuildResume(this.instance, @Exn);
        }

        public Value CreateUnreachable()
        {
            return LLVM.BuildUnreachable(this.instance);
        }

        public Value CreateAdd(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildAdd(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNSWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNSWAdd(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNUWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNUWAdd(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFAdd(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFAdd(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateSub(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildSub(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNSWSub(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNSWSub(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNUWSub(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNUWSub(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFSub(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFSub(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateMul(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildMul(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNSWMul(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNSWMul(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateNUWMul(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildNUWMul(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFMul(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFMul(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateUDiv(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildUDiv(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildSDiv(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateExactSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildExactSDiv(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFDiv(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFDiv(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateURem(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildURem(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateSRem(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildSRem(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFRem(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFRem(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateShl(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildShl(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateLShr(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildLShr(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateAShr(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildAShr(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateAnd(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildAnd(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateOr(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildOr(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateXor(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildXor(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateBinOp(LLVMOpcode @Op, Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildBinOp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        public Value CreateNeg(Value @V, string @Name)
        {
            return LLVM.BuildNeg(this.instance, @V, @Name);
        }

        public Value CreateNSWNeg(Value @V, string @Name)
        {
            return LLVM.BuildNSWNeg(this.instance, @V, @Name);
        }

        public Value CreateNUWNeg(Value @V, string @Name)
        {
            return LLVM.BuildNUWNeg(this.instance, @V, @Name);
        }

        public Value CreateFNeg(Value @V, string @Name)
        {
            return LLVM.BuildFNeg(this.instance, @V, @Name);
        }

        public Value CreateNot(Value @V, string @Name)
        {
            return LLVM.BuildNot(this.instance, @V, @Name);
        }

        public Value CreateMalloc(LLVMTypeRef @Ty, string @Name)
        {
            return LLVM.BuildMalloc(this.instance, @Ty, @Name);
        }

        public Value CreateArrayMalloc(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return LLVM.BuildArrayMalloc(this.instance, @Ty, @Val, @Name);
        }

        public Value CreateAlloca(LLVMTypeRef @Ty, string @Name)
        {
            return LLVM.BuildAlloca(this.instance, @Ty, @Name);
        }

        public Value CreateArrayAlloca(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return LLVM.BuildArrayAlloca(this.instance, @Ty, @Val, @Name);
        }

        public Value CreateFree(Value @PointerVal)
        {
            return LLVM.BuildFree(this.instance, @PointerVal);
        }

        public Value CreateLoad(Value @PointerVal, string @Name)
        {
            return LLVM.BuildLoad(this.instance, @PointerVal, @Name);
        }

        public Value CreateStore(Value @Val, Value @Ptr)
        {
            return LLVM.BuildStore(this.instance, @Val, @Ptr);
        }

        public Value CreateGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return LLVM.BuildGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name);
        }

        public Value CreateInBoundsGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return LLVM.BuildInBoundsGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name);
        }

        public Value CreateStructGEP(Value @Pointer, uint @Idx, string @Name)
        {
            return LLVM.BuildStructGEP(this.instance, @Pointer, @Idx, @Name);
        }

        public Value CreateGlobalString(string @Str, string @Name)
        {
            return LLVM.BuildGlobalString(this.instance, @Str, @Name);
        }

        public Value CreateGlobalStringPtr(string @Str, string @Name)
        {
            return LLVM.BuildGlobalStringPtr(this.instance, @Str, @Name);
        }

        public Value CreateTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildTrunc(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateZExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildZExt(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateSExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildSExt(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateFPToUI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildFPToUI(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateFPToSI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildFPToSI(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateUIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildUIToFP(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateSIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildSIToFP(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateFPTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildFPTrunc(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateFPExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildFPExt(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreatePtrToInt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildPtrToInt(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateIntToPtr(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildIntToPtr(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildBitCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateAddrSpaceCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildAddrSpaceCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateZExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildZExtOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateSExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildSExtOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateTruncOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildTruncOrBitCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateCast(LLVMOpcode @Op, Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildCast(this.instance, @Op, @Val, @DestTy, @Name);
        }

        public Value CreatePointerCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildPointerCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateIntCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildIntCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateFPCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return LLVM.BuildFPCast(this.instance, @Val, @DestTy, @Name);
        }

        public Value CreateICmp(LLVMIntPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildICmp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        public Value CreateFCmp(LLVMRealPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildFCmp(this.instance, @Op, @LHS, @RHS, @Name);
        }

        public Value CreatePhi(LLVMTypeRef @Ty, string @Name)
        {
            return LLVM.BuildPhi(this.instance, @Ty, @Name);
        }

        public Value CreateCall(Value @Fn, Value[] @Args, string @Name)
        {
            return LLVM.BuildCall(this.instance, @Fn, LLVMValueRef.FromArray(@Args), @Name);
        }

        public Value CreateSelect(Value @If, Value @Then, Value @Else, string @Name)
        {
            return LLVM.BuildSelect(this.instance, @If, @Then, @Else, @Name);
        }

        public Value CreateVAArg(Value @List, LLVMTypeRef @Ty, string @Name)
        {
            return LLVM.BuildVAArg(this.instance, @List, @Ty, @Name);
        }

        public Value CreateExtractElement(Value @VecVal, Value @Index, string @Name)
        {
            return LLVM.BuildExtractElement(this.instance, @VecVal, @Index, @Name);
        }

        public Value CreateInsertElement(Value @VecVal, Value @EltVal, Value @Index, string @Name)
        {
            return LLVM.BuildInsertElement(this.instance, @VecVal, @EltVal, @Index, @Name);
        }

        public Value CreateShuffleVector(Value @V1, Value @V2, Value @Mask, string @Name)
        {
            return LLVM.BuildShuffleVector(this.instance, @V1, @V2, @Mask, @Name);
        }

        public Value CreateExtractValue(Value @AggVal, uint @Index, string @Name)
        {
            return LLVM.BuildExtractValue(this.instance, @AggVal, @Index, @Name);
        }

        public Value CreateInsertValue(Value @AggVal, Value @EltVal, uint @Index, string @Name)
        {
            return LLVM.BuildInsertValue(this.instance, @AggVal, @EltVal, @Index, @Name);
        }

        public Value CreateIsNull(Value @Val, string @Name)
        {
            return LLVM.BuildIsNull(this.instance, @Val, @Name);
        }

        public Value CreateIsNotNull(Value @Val, string @Name)
        {
            return LLVM.BuildIsNotNull(this.instance, @Val, @Name);
        }

        public Value CreatePtrDiff(Value @LHS, Value @RHS, string @Name)
        {
            return LLVM.BuildPtrDiff(this.instance, @LHS, @RHS, @Name);
        }

        public Value CreateFence(LLVMAtomicOrdering @ordering, LLVMBool @singleThread, string @Name)
        {
            return LLVM.BuildFence(this.instance, @ordering, @singleThread, @Name);
        }

        public Value CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value @PTR, Value @Val, LLVMAtomicOrdering @ordering, LLVMBool @singleThread)
        {
            return LLVM.BuildAtomicRMW(this.instance, @op, @PTR, @Val, @ordering, @singleThread);
        }
    }
}