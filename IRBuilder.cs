namespace LLVMSharp
{
    using System;

    public sealed class IRBuilder : IDisposable, IEquatable<IRBuilder>
    {
        internal readonly LLVMBuilderRef instance;

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

        public ReturnInst CreateRetVoid()
        {
            return new ReturnInst(LLVM.BuildRetVoid(this.instance));
        }

        public ReturnInst CreateRet(Value @V)
        {
            return new ReturnInst(LLVM.BuildRet(this.instance, @V));
        }

        public ReturnInst CreateAggregateRet(Value[] @RetVals)
        {
            return new ReturnInst(LLVM.BuildAggregateRet(this.instance, LLVMValueRef.FromArray(@RetVals)));
        }

        public BranchInst CreateBr(BasicBlock @Dest)
        {
            return new BranchInst(LLVM.BuildBr(this.instance, @Dest));
        }

        public BranchInst CreateCondBr(Value @If, BasicBlock @Then, BasicBlock @Else)
        {
            return new BranchInst(LLVM.BuildCondBr(this.instance, @If, @Then, @Else));
        }

        public SwitchInst CreateSwitch(Value @V, BasicBlock @Else, uint @NumCases)
        {
            return new SwitchInst(LLVM.BuildSwitch(this.instance, @V, @Else, @NumCases));
        }

        public IndirectBrInst CreateIndirectBr(Value @Addr, uint @NumDests)
        {
            return new IndirectBrInst(LLVM.BuildIndirectBr(this.instance, @Addr, @NumDests));
        }

        public InvokeInst CreateInvoke(Value @Fn, Value[] @Args, BasicBlock @Then, BasicBlock @Catch, string @Name)
        {
            return new InvokeInst(LLVM.BuildInvoke(this.instance, @Fn, LLVMValueRef.FromArray(Args), @Then, @Catch, @Name));
        }

        public LandingPadInst CreateLandingPad(LLVMTypeRef @Ty, Value @PersFn, uint @NumClauses, string @Name)
        {
            return new LandingPadInst(LLVM.BuildLandingPad(this.instance, @Ty, @PersFn, @NumClauses, @Name));
        }

        public ResumeInst CreateResume(Value @Exn)
        {
            return new ResumeInst(LLVM.BuildResume(this.instance, @Exn));
        }

        public UnreachableInst CreateUnreachable()
        {
            return new UnreachableInst(LLVM.BuildUnreachable(this.instance));
        }

        public Add CreateAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Add CreateNSWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildNSWAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Add CreateNUWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildNUWAdd(this.instance, @LHS, @RHS, @Name));
        }

        public FAdd CreateFAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new FAdd(LLVM.BuildFAdd(this.instance, @LHS, @RHS, @Name));
        }

        public Sub CreateSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildSub(this.instance, @LHS, @RHS, @Name));
        }

        public Sub CreateNSWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildNSWSub(this.instance, @LHS, @RHS, @Name));
        }

        public Sub CreateNUWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildNUWSub(this.instance, @LHS, @RHS, @Name));
        }

        public FSub CreateFSub(Value @LHS, Value @RHS, string @Name)
        {
            return new FSub(LLVM.BuildFSub(this.instance, @LHS, @RHS, @Name));
        }

        public Mul CreateMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildMul(this.instance, @LHS, @RHS, @Name));
        }

        public Mul CreateNSWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildNSWMul(this.instance, @LHS, @RHS, @Name));
        }

        public Mul CreateNUWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildNUWMul(this.instance, @LHS, @RHS, @Name));
        }

        public FMul CreateFMul(Value @LHS, Value @RHS, string @Name)
        {
            return new FMul(LLVM.BuildFMul(this.instance, @LHS, @RHS, @Name));
        }

        public UDiv CreateUDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new UDiv(LLVM.BuildUDiv(this.instance, @LHS, @RHS, @Name));
        }

        public SDiv CreateSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildSDiv(this.instance, @LHS, @RHS, @Name));
        }

        public SDiv CreateExactSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildExactSDiv(this.instance, @LHS, @RHS, @Name));
        }

        public FDiv CreateFDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new FDiv(LLVM.BuildFDiv(this.instance, @LHS, @RHS, @Name));
        }

        public URem CreateURem(Value @LHS, Value @RHS, string @Name)
        {
            return new URem(LLVM.BuildURem(this.instance, @LHS, @RHS, @Name));
        }

        public SRem CreateSRem(Value @LHS, Value @RHS, string @Name)
        {
            return new SRem(LLVM.BuildSRem(this.instance, @LHS, @RHS, @Name));
        }

        public FRem CreateFRem(Value @LHS, Value @RHS, string @Name)
        {
            return new FRem(LLVM.BuildFRem(this.instance, @LHS, @RHS, @Name));
        }

        public Shl CreateShl(Value @LHS, Value @RHS, string @Name)
        {
            return new Shl(LLVM.BuildShl(this.instance, @LHS, @RHS, @Name));
        }

        public LShr CreateLShr(Value @LHS, Value @RHS, string @Name)
        {
            return new LShr(LLVM.BuildLShr(this.instance, @LHS, @RHS, @Name));
        }

        public AShr CreateAShr(Value @LHS, Value @RHS, string @Name)
        {
            return new AShr(LLVM.BuildAShr(this.instance, @LHS, @RHS, @Name));
        }

        public And CreateAnd(Value @LHS, Value @RHS, string @Name)
        {
            return new And(LLVM.BuildAnd(this.instance, @LHS, @RHS, @Name));
        }

        public Or CreateOr(Value @LHS, Value @RHS, string @Name)
        {
            return new Or(LLVM.BuildOr(this.instance, @LHS, @RHS, @Name));
        }

        public Xor CreateXor(Value @LHS, Value @RHS, string @Name)
        {
            return new Xor(LLVM.BuildXor(this.instance, @LHS, @RHS, @Name));
        }

        public BinaryOperator CreateBinOp(LLVMOpcode @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new BinaryOperator(LLVM.BuildBinOp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public Neg CreateNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNeg(this.instance, @V, @Name));
        }

        public Neg CreateNSWNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNSWNeg(this.instance, @V, @Name));
        }

        public Neg CreateNUWNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNUWNeg(this.instance, @V, @Name));
        }

        public FNeg CreateFNeg(Value @V, string @Name)
        {
            return new FNeg(LLVM.BuildFNeg(this.instance, @V, @Name));
        }

        public Not CreateNot(Value @V, string @Name)
        {
            return new Not(LLVM.BuildNot(this.instance, @V, @Name));
        }

        public Instruction CreateMalloc(LLVMTypeRef @Ty, string @Name)
        {
            return new Instruction(LLVM.BuildMalloc(this.instance, @Ty, @Name));
        }

        public Instruction CreateArrayMalloc(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return new Instruction(LLVM.BuildArrayMalloc(this.instance, @Ty, @Val, @Name));
        }

        public AllocaInst CreateAlloca(LLVMTypeRef @Ty, string @Name)
        {
            return new AllocaInst(LLVM.BuildAlloca(this.instance, @Ty, @Name));
        }

        public Instruction CreateArrayAlloca(LLVMTypeRef @Ty, Value @Val, string @Name)
        {
            return new Instruction(LLVM.BuildArrayAlloca(this.instance, @Ty, @Val, @Name));
        }

        public Instruction CreateFree(Value @PointerVal)
        {
            return new Instruction(LLVM.BuildFree(this.instance, @PointerVal));
        }

        public LoadInst CreateLoad(Value @PointerVal, string @Name)
        {
            return new LoadInst(LLVM.BuildLoad(this.instance, @PointerVal, @Name));
        }

        public StoreInst CreateStore(Value @Val, Value @Ptr)
        {
            return new StoreInst(LLVM.BuildStore(this.instance, @Val, @Ptr));
        }

        public GetElementPtrInst CreateGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name));
        }

        public GetElementPtrInst CreateInBoundsGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildInBoundsGEP(this.instance, @Pointer, LLVMValueRef.FromArray(@Indices), @Name));
        }

        public GetElementPtrInst CreateStructGEP(Value @Pointer, uint @Idx, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildStructGEP(this.instance, @Pointer, @Idx, @Name));
        }

        // NOTE: Likely to stay GlobalVariable, but you never know.
        public GlobalVariable CreateGlobalString(string @Str, string @Name)
        {
            return new GlobalVariable(LLVM.BuildGlobalString(this.instance, @Str, @Name));
        }

        // NOTE: Likely to stay GetElementPtrInst, but you never know.
        public GetElementPtrInst CreateGlobalStringPtr(string @Str, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildGlobalStringPtr(this.instance, @Str, @Name));
        }

        public TruncInst CreateTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new TruncInst(LLVM.BuildTrunc(this.instance, @Val, @DestTy, @Name));
        }

        public ZExtInst CreateZExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new ZExtInst(LLVM.BuildZExt(this.instance, @Val, @DestTy, @Name));
        }

        public SExtInst CreateSExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new SExtInst(LLVM.BuildSExt(this.instance, @Val, @DestTy, @Name));
        }

        public FPToUIInst CreateFPToUI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new FPToUIInst(LLVM.BuildFPToUI(this.instance, @Val, @DestTy, @Name));
        }

        public FPToSIInst CreateFPToSI(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new FPToSIInst(LLVM.BuildFPToSI(this.instance, @Val, @DestTy, @Name));
        }

        public UIToFPInst CreateUIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new UIToFPInst(LLVM.BuildUIToFP(this.instance, @Val, @DestTy, @Name));
        }

        public SIToFPInst CreateSIToFP(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new SIToFPInst(LLVM.BuildSIToFP(this.instance, @Val, @DestTy, @Name));
        }

        public FPTruncInst CreateFPTrunc(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new FPTruncInst(LLVM.BuildFPTrunc(this.instance, @Val, @DestTy, @Name));
        }

        public FPExtInst CreateFPExt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new FPExtInst(LLVM.BuildFPExt(this.instance, @Val, @DestTy, @Name));
        }

        public PtrToIntInst CreatePtrToInt(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new PtrToIntInst(LLVM.BuildPtrToInt(this.instance, @Val, @DestTy, @Name));
        }

        public IntToPtrInst CreateIntToPtr(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new IntToPtrInst(LLVM.BuildIntToPtr(this.instance, @Val, @DestTy, @Name));
        }

        public BitCastInst CreateBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new BitCastInst(LLVM.BuildBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public AddrSpaceCastInst CreateAddrSpaceCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new AddrSpaceCastInst(LLVM.BuildAddrSpaceCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateZExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildZExtOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateSExtOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildSExtOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateTruncOrBitCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildTruncOrBitCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateCast(LLVMOpcode @Op, Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildCast(this.instance, @Op, @Val, @DestTy, @Name));
        }

        public CastInst CreatePointerCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildPointerCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateIntCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildIntCast(this.instance, @Val, @DestTy, @Name));
        }

        public CastInst CreateFPCast(Value @Val, LLVMTypeRef @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildFPCast(this.instance, @Val, @DestTy, @Name));
        }

        public ICmpInst CreateICmp(LLVMIntPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new ICmpInst(LLVM.BuildICmp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public FCmpInst CreateFCmp(LLVMRealPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new FCmpInst(LLVM.BuildFCmp(this.instance, @Op, @LHS, @RHS, @Name));
        }

        public PHINode CreatePhi(LLVMTypeRef @Ty, string @Name)
        {
            return new PHINode(LLVM.BuildPhi(this.instance, @Ty, @Name));
        }

        public CallInst CreateCall(Value @Fn, Value[] @Args, string @Name)
        {
            return new CallInst(LLVM.BuildCall(this.instance, @Fn, LLVMValueRef.FromArray(@Args), @Name));
        }

        public SelectInst CreateSelect(Value @If, Value @Then, Value @Else, string @Name)
        {
            return new SelectInst(LLVM.BuildSelect(this.instance, @If, @Then, @Else, @Name));
        }

        public VAArgInst CreateVAArg(Value @List, LLVMTypeRef @Ty, string @Name)
        {
            return new VAArgInst(LLVM.BuildVAArg(this.instance, @List, @Ty, @Name));
        }

        public ExtractElementInst CreateExtractElement(Value @VecVal, Value @Index, string @Name)
        {
            return new ExtractElementInst(LLVM.BuildExtractElement(this.instance, @VecVal, @Index, @Name));
        }

        public InsertElementInst CreateInsertElement(Value @VecVal, Value @EltVal, Value @Index, string @Name)
        {
            return new InsertElementInst(LLVM.BuildInsertElement(this.instance, @VecVal, @EltVal, @Index, @Name));
        }

        public ShuffleVectorInst CreateShuffleVector(Value @V1, Value @V2, Value @Mask, string @Name)
        {
            return new ShuffleVectorInst(LLVM.BuildShuffleVector(this.instance, @V1, @V2, @Mask, @Name));
        }

        public ExtractValueInst CreateExtractValue(Value @AggVal, uint @Index, string @Name)
        {
            return new ExtractValueInst(LLVM.BuildExtractValue(this.instance, @AggVal, @Index, @Name));
        }

        public InsertValueInst CreateInsertValue(Value @AggVal, Value @EltVal, uint @Index, string @Name)
        {
            return new InsertValueInst(LLVM.BuildInsertValue(this.instance, @AggVal, @EltVal, @Index, @Name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNull(Value @Val, string @Name)
        {
            return new ICmpInst(LLVM.BuildIsNull(this.instance, @Val, @Name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNotNull(Value @Val, string @Name)
        {
            return new ICmpInst(LLVM.BuildIsNotNull(this.instance, @Val, @Name));
        }

        // NOTE: Likely to stay SDiv, but you never know.
        public SDiv CreatePtrDiff(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildPtrDiff(this.instance, @LHS, @RHS, @Name));
        }

        public FenceInst CreateFence(LLVMAtomicOrdering @ordering, LLVMBool @singleThread, string @Name)
        {
            return new FenceInst(LLVM.BuildFence(this.instance, @ordering, @singleThread, @Name));
        }

        public AtomicRMWInst CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value @PTR, Value @Val, LLVMAtomicOrdering @ordering, LLVMBool @singleThread)
        {
            return new AtomicRMWInst(LLVM.BuildAtomicRMW(this.instance, @op, @PTR, @Val, @ordering, @singleThread));
        }

        public bool Equals(IRBuilder other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.instance == other.instance;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as IRBuilder);
        }

        public static bool operator ==(IRBuilder op1, IRBuilder op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(IRBuilder op1, IRBuilder op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.instance.GetHashCode();
        }
    }
}