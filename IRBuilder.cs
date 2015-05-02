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
            return new Value(LLVM.GetCurrentDebugLocation(this.instance));
        }

        public void SetInstDebugLocation(Value @Inst)
        {
            LLVM.SetInstDebugLocation(this.instance, @Inst);
        }

        public Value CreateRetVoid()
        {
            return new Value(LLVM.BuildRetVoid(this.instance));
        }

        public Value CreateRet(Value @V)
        {
            return new Value(LLVM.BuildRet(this.instance, @V));
        }

        public Value CreateAggregateRet(Value[] @RetVals)
        {
            return new Value(LLVM.BuildAggregateRet(this.instance, LLVMValueRef.FromArray(@RetVals)));
        }

        public Value CreateBr(BasicBlock @Dest)
        {
            return new Value(LLVM.BuildBr(this.instance, @Dest));
        }

        public Value CreateCondBr(Value @If, BasicBlock @Then, BasicBlock @Else)
        {
            return new Value(LLVM.BuildCondBr(this.instance, @If, @Then, @Else));
        }

        public Value CreateSwitch(Value @V, BasicBlock @Else, uint @NumCases)
        {
            return new Value(LLVM.BuildSwitch(this.instance, @V, @Else, @NumCases));
        }

        public Value CreateIndirectBr(Value @Addr, uint @NumDests)
        {
            return new Value(LLVM.BuildIndirectBr(this.instance, @Addr, @NumDests));
        }

        public Value CreateInvoke(Value @Fn, Value[] @Args, BasicBlock @Then, BasicBlock @Catch, string @Name)
        {
            return new Value(LLVM.BuildInvoke(this.instance, @Fn, LLVMValueRef.FromArray(Args), @Then, @Catch, @Name));
        }

        public Value CreateLandingPad(LLVMTypeRef @Ty, Value @PersFn, uint @NumClauses, string @Name)
        {
            return new Value(LLVM.BuildLandingPad(this.instance, @Ty, @PersFn, @NumClauses, @Name));
        }

        public Value CreateResume(Value @Exn)
        {
            return new Value(LLVM.BuildResume(this.instance, @Exn));
        }

        public Value CreateUnreachable()
        {
            return new Value(LLVM.BuildUnreachable(this.instance));
        }

        public Value CreateAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNSWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNSWAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNUWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNUWAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildSub(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNSWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNSWSub(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNUWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNUWSub(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFSub(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildMul(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNSWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNSWMul(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateNUWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildNUWMul(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFMul(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateUDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildUDiv(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildSDiv(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateExactSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildExactSDiv(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFDiv(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateURem(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildURem(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateSRem(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildSRem(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFRem(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFRem(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateShl(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildShl(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateLShr(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildLShr(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateAShr(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildAShr(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateAnd(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildAnd(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateOr(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildOr(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateXor(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildXor(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateBinOp(LLVMOpcode @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildBinOp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public Value CreateNeg(Value @V, string @Name)
        {
            return new Value(LLVM.BuildNeg(this.instance, @V, @Name));
        }

        public Value CreateNSWNeg(Value @V, string @Name)
        {
            return new Value(LLVM.BuildNSWNeg(this.instance, @V, @Name));
        }

        public Value CreateNUWNeg(Value @V, string @Name)
        {
            return new Value(LLVM.BuildNUWNeg(this.instance, @V, @Name));
        }

        public Value CreateFNeg(Value @V, string @Name)
        {
            return new Value(LLVM.BuildFNeg(this.instance, @V, @Name));
        }

        public Value CreateNot(Value @V, string @Name)
        {
            return new Value(LLVM.BuildNot(this.instance, @V, @Name));
        }

        public Value CreateMalloc(LLVMTypeRef @Ty, string @Name)
        {
            return new Value(LLVM.BuildMalloc(this.instance, @Ty, @Name));
        }

        public Value CreateArrayMalloc(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return new Value(LLVM.BuildArrayMalloc(this.instance, @Ty, @Val, @Name));
        }

        public Value CreateAlloca(LLVMTypeRef @Ty, string @Name)
        {
            return new Value(LLVM.BuildAlloca(this.instance, @Ty, @Name));
        }

        public Value CreateArrayAlloca(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return new Value(LLVM.BuildArrayAlloca(this.instance, @Ty, @Val, @Name));
        }

        public Value CreateFree(Value @PointerVal)
        {
            return new Value(LLVM.BuildFree(this.instance, @PointerVal));
        }

        public Value CreateLoad(Value @PointerVal, string @Name)
        {
            return new Value(LLVM.BuildLoad(this.instance, @PointerVal, @Name));
        }

        public Value CreateStore(Value @Val, Value @Ptr)
        {
            return new Value(LLVM.BuildStore(this.instance, @Val, @Ptr));
        }

        public Value CreateGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new Value(LLVM.BuildGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name));
        }

        public Value CreateInBoundsGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new Value(LLVM.BuildInBoundsGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name));
        }

        public Value CreateStructGEP(Value @Pointer, uint @Idx, string @Name)
        {
            return new Value(LLVM.BuildStructGEP(this.instance, @Pointer, @Idx, @Name));
        }

        public Value CreateGlobalString(string @Str, string @Name)
        {
            return new Value(LLVM.BuildGlobalString(this.instance, @Str, @Name));
        }

        public Value CreateGlobalStringPtr(string @Str, string @Name)
        {
            return new Value(LLVM.BuildGlobalStringPtr(this.instance, @Str, @Name));
        }

        public Value CreateTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildTrunc(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateZExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildZExt(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateSExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildSExt(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateFPToUI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildFPToUI(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateFPToSI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildFPToSI(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateUIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildUIToFP(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateSIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildSIToFP(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateFPTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildFPTrunc(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateFPExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildFPExt(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreatePtrToInt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildPtrToInt(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateIntToPtr(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildIntToPtr(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateAddrSpaceCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildAddrSpaceCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateZExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildZExtOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateSExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildSExtOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateTruncOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildTruncOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateCast(LLVMOpcode @Op, Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildCast(this.instance, @Op, @Val, @DestTy, @Name));
        }

        public Value CreatePointerCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildPointerCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateIntCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildIntCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateFPCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new Value(LLVM.BuildFPCast(this.instance, @Val, @DestTy, @Name));
        }

        public Value CreateICmp(LLVMIntPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildICmp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public Value CreateFCmp(LLVMRealPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildFCmp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public Value CreatePhi(LLVMTypeRef @Ty, string @Name)
        {
            return new Value(LLVM.BuildPhi(this.instance, @Ty, @Name));
        }

        public Value CreateCall(Value @Fn, Value[] @Args, string @Name)
        {
            return new Value(LLVM.BuildCall(this.instance, @Fn, LLVMValueRef.FromArray(@Args), @Name));
        }

        public Value CreateSelect(Value @If, Value @Then, Value @Else, string @Name)
        {
            return new Value(LLVM.BuildSelect(this.instance, @If, @Then, @Else, @Name));
        }

        public Value CreateVAArg(Value @List, LLVMTypeRef @Ty, string @Name)
        {
            return new Value(LLVM.BuildVAArg(this.instance, @List, @Ty, @Name));
        }

        public Value CreateExtractElement(Value @VecVal, Value @Index, string @Name)
        {
            return new Value(LLVM.BuildExtractElement(this.instance, @VecVal, @Index, @Name));
        }

        public Value CreateInsertElement(Value @VecVal, Value @EltVal, Value @Index, string @Name)
        {
            return new Value(LLVM.BuildInsertElement(this.instance, @VecVal, @EltVal, @Index, @Name));
        }

        public Value CreateShuffleVector(Value @V1, Value @V2, Value @Mask, string @Name)
        {
            return new Value(LLVM.BuildShuffleVector(this.instance, @V1, @V2, @Mask, @Name));
        }

        public Value CreateExtractValue(Value @AggVal, uint @Index, string @Name)
        {
            return new Value(LLVM.BuildExtractValue(this.instance, @AggVal, @Index, @Name));
        }

        public Value CreateInsertValue(Value @AggVal, Value @EltVal, uint @Index, string @Name)
        {
            return new Value(LLVM.BuildInsertValue(this.instance, @AggVal, @EltVal, @Index, @Name));
        }

        public Value CreateIsNull(Value @Val, string @Name)
        {
            return new Value(LLVM.BuildIsNull(this.instance, @Val, @Name));
        }

        public Value CreateIsNotNull(Value @Val, string @Name)
        {
            return new Value(LLVM.BuildIsNotNull(this.instance, @Val, @Name));
        }

        public Value CreatePtrDiff(Value @LHS, Value @RHS, string @Name)
        {
            return new Value(LLVM.BuildPtrDiff(this.instance, @LHS, @RHS, @Name));
        }

        public Value CreateFence(LLVMAtomicOrdering @ordering, LLVMBool @singleThread, string @Name)
        {
            return new Value(LLVM.BuildFence(this.instance, @ordering, @singleThread, @Name));
        }

        public Value CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value @PTR, Value @Val, LLVMAtomicOrdering @ordering, LLVMBool @singleThread)
        {
            return new Value(LLVM.BuildAtomicRMW(this.instance, @op, @PTR, @Val, @ordering, @singleThread));
        }
    }
}