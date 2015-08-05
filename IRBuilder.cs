namespace LLVMSharp
{
    using System;

    public sealed class IRBuilder : IDisposable, IEquatable<IRBuilder>
    {
        internal readonly LLVMBuilderRef instance;

        private bool disposed;

        public IRBuilder(LLVMContext context) : this(context.InternalValue)
        {
        }

        internal IRBuilder(LLVMContextRef context)
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
            LLVM.PositionBuilder(this.instance, @Block.ToBasicBlockRef(), @Instr.ToValueRef());
        }

        public void PositionBuilderBefore(Value @Instr)
        {
            LLVM.PositionBuilderBefore(this.instance, @Instr.ToValueRef());
        }

        public void PositionBuilderAtEnd(BasicBlock @Block)
        {
            LLVM.PositionBuilderAtEnd(this.instance, @Block.ToBasicBlockRef());
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
            LLVM.InsertIntoBuilder(this.instance, @Instr.ToValueRef());
        }

        public void InsertIntoBuilderWithName(Value @Instr, string @Name)
        {
            LLVM.InsertIntoBuilderWithName(this.instance, @Instr.ToValueRef(), @Name);
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
            LLVM.SetCurrentDebugLocation(this.instance, @L.ToValueRef());
        }

        public Value GetCurrentDebugLocation()
        {
            return LLVM.GetCurrentDebugLocation(this.instance).ToValue();
        }

        public void SetInstDebugLocation(Value @Inst)
        {
            LLVM.SetInstDebugLocation(this.instance, @Inst.ToValueRef());
        }

        public ReturnInst CreateRetVoid()
        {
            return new ReturnInst(LLVM.BuildRetVoid(this.instance));
        }

        public ReturnInst CreateRet(Value @V)
        {
            return new ReturnInst(LLVM.BuildRet(this.instance, @V.ToValueRef()));
        }

        public ReturnInst CreateAggregateRet(Value[] @RetVals)
        {
            return new ReturnInst(LLVM.BuildAggregateRet(this.instance, RetVals.ToValueRefs()));
        }

        public BranchInst CreateBr(BasicBlock @Dest)
        {
            return new BranchInst(LLVM.BuildBr(this.instance, @Dest.ToBasicBlockRef()));
        }

        public BranchInst CreateCondBr(Value @If, BasicBlock @Then, BasicBlock @Else)
        {
            return new BranchInst(LLVM.BuildCondBr(this.instance, @If.ToValueRef(), @Then.ToBasicBlockRef(), @Else.ToBasicBlockRef()));
        }

        public SwitchInst CreateSwitch(Value @V, BasicBlock @Else, uint @NumCases)
        {
            return new SwitchInst(LLVM.BuildSwitch(this.instance, @V.ToValueRef(), @Else.ToBasicBlockRef(), @NumCases));
        }

        public IndirectBrInst CreateIndirectBr(Value @Addr, uint @NumDests)
        {
            return new IndirectBrInst(LLVM.BuildIndirectBr(this.instance, @Addr.ToValueRef(), @NumDests));
        }

        public InvokeInst CreateInvoke(Value @Fn, Value[] @Args, BasicBlock @Then, BasicBlock @Catch, string @Name)
        {
            return new InvokeInst(LLVM.BuildInvoke(this.instance, @Fn.ToValueRef(), Args.ToValueRefs(), @Then.ToBasicBlockRef(), @Catch.ToBasicBlockRef(), @Name));
        }

        public LandingPadInst CreateLandingPad(Type @Ty, Value @PersFn, uint @NumClauses, string @Name)
        {
            return new LandingPadInst(LLVM.BuildLandingPad(this.instance, @Ty.ToTypeRef(), @PersFn.ToValueRef(), @NumClauses, @Name));
        }

        public ResumeInst CreateResume(Value @Exn)
        {
            return new ResumeInst(LLVM.BuildResume(this.instance, @Exn.ToValueRef()));
        }

        public UnreachableInst CreateUnreachable()
        {
            return new UnreachableInst(LLVM.BuildUnreachable(this.instance));
        }

        public Add CreateAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildAdd(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Add CreateNSWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildNSWAdd(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Add CreateNUWAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new Add(LLVM.BuildNUWAdd(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FAdd CreateFAdd(Value @LHS, Value @RHS, string @Name)
        {
            return new FAdd(LLVM.BuildFAdd(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Sub CreateSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildSub(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Sub CreateNSWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildNSWSub(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Sub CreateNUWSub(Value @LHS, Value @RHS, string @Name)
        {
            return new Sub(LLVM.BuildNUWSub(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FSub CreateFSub(Value @LHS, Value @RHS, string @Name)
        {
            return new FSub(LLVM.BuildFSub(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Mul CreateMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildMul(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Mul CreateNSWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildNSWMul(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Mul CreateNUWMul(Value @LHS, Value @RHS, string @Name)
        {
            return new Mul(LLVM.BuildNUWMul(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FMul CreateFMul(Value @LHS, Value @RHS, string @Name)
        {
            return new FMul(LLVM.BuildFMul(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public UDiv CreateUDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new UDiv(LLVM.BuildUDiv(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public SDiv CreateSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildSDiv(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public SDiv CreateExactSDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildExactSDiv(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FDiv CreateFDiv(Value @LHS, Value @RHS, string @Name)
        {
            return new FDiv(LLVM.BuildFDiv(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public URem CreateURem(Value @LHS, Value @RHS, string @Name)
        {
            return new URem(LLVM.BuildURem(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public SRem CreateSRem(Value @LHS, Value @RHS, string @Name)
        {
            return new SRem(LLVM.BuildSRem(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FRem CreateFRem(Value @LHS, Value @RHS, string @Name)
        {
            return new FRem(LLVM.BuildFRem(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Shl CreateShl(Value @LHS, Value @RHS, string @Name)
        {
            return new Shl(LLVM.BuildShl(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public LShr CreateLShr(Value @LHS, Value @RHS, string @Name)
        {
            return new LShr(LLVM.BuildLShr(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public AShr CreateAShr(Value @LHS, Value @RHS, string @Name)
        {
            return new AShr(LLVM.BuildAShr(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public And CreateAnd(Value @LHS, Value @RHS, string @Name)
        {
            return new And(LLVM.BuildAnd(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Or CreateOr(Value @LHS, Value @RHS, string @Name)
        {
            return new Or(LLVM.BuildOr(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Xor CreateXor(Value @LHS, Value @RHS, string @Name)
        {
            return new Xor(LLVM.BuildXor(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public BinaryOperator CreateBinOp(LLVMOpcode @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new BinaryOperator(LLVM.BuildBinOp(this.instance, @Op, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public Neg CreateNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNeg(this.instance, @V.ToValueRef(), @Name));
        }

        public Neg CreateNSWNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNSWNeg(this.instance, @V.ToValueRef(), @Name));
        }

        public Neg CreateNUWNeg(Value @V, string @Name)
        {
            return new Neg(LLVM.BuildNUWNeg(this.instance, @V.ToValueRef(), @Name));
        }

        public FNeg CreateFNeg(Value @V, string @Name)
        {
            return new FNeg(LLVM.BuildFNeg(this.instance, @V.ToValueRef(), @Name));
        }

        public Not CreateNot(Value @V, string @Name)
        {
            return new Not(LLVM.BuildNot(this.instance, @V.ToValueRef(), @Name));
        }

        public Instruction CreateMalloc(Type @Ty, string @Name)
        {
            return new Instruction(LLVM.BuildMalloc(this.instance, @Ty.ToTypeRef(), @Name));
        }

        public Instruction CreateArrayMalloc(Type @Ty, Value @Val, string @Name)
        {
            return new Instruction(LLVM.BuildArrayMalloc(this.instance, @Ty.ToTypeRef(), @Val.ToValueRef(), @Name));
        }

        public AllocaInst CreateAlloca(Type @Ty, string @Name)
        {
            return new AllocaInst(LLVM.BuildAlloca(this.instance, @Ty.ToTypeRef(), @Name));
        }

        public Instruction CreateArrayAlloca(Type @Ty, Value @Val, string @Name)
        {
            return new Instruction(LLVM.BuildArrayAlloca(this.instance, @Ty.ToTypeRef(), @Val.ToValueRef(), @Name));
        }

        public Instruction CreateFree(Value @PointerVal)
        {
            return new Instruction(LLVM.BuildFree(this.instance, @PointerVal.ToValueRef()));
        }

        public LoadInst CreateLoad(Value @PointerVal, string @Name)
        {
            return new LoadInst(LLVM.BuildLoad(this.instance, @PointerVal.ToValueRef(), @Name));
        }

        public StoreInst CreateStore(Value @Val, Value @Ptr)
        {
            return new StoreInst(LLVM.BuildStore(this.instance, @Val.ToValueRef(), @Ptr.ToValueRef()));
        }

        public GetElementPtrInst CreateGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildGEP(this.instance, @Pointer.ToValueRef(), @Indices.ToValueRefs(), @Name));
        }

        public GetElementPtrInst CreateInBoundsGEP(Value @Pointer, Value[] @Indices, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildInBoundsGEP(this.instance, @Pointer.ToValueRef(), @Indices.ToValueRefs(), @Name));
        }

        public GetElementPtrInst CreateStructGEP(Value @Pointer, uint @Idx, string @Name)
        {
            return new GetElementPtrInst(LLVM.BuildStructGEP(this.instance, @Pointer.ToValueRef(), @Idx, @Name));
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

        public TruncInst CreateTrunc(Value @Val, Type @DestTy, string @Name)
        {
            return new TruncInst(LLVM.BuildTrunc(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public ZExtInst CreateZExt(Value @Val, Type @DestTy, string @Name)
        {
            return new ZExtInst(LLVM.BuildZExt(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public SExtInst CreateSExt(Value @Val, Type @DestTy, string @Name)
        {
            return new SExtInst(LLVM.BuildSExt(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public FPToUIInst CreateFPToUI(Value @Val, Type @DestTy, string @Name)
        {
            return new FPToUIInst(LLVM.BuildFPToUI(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public FPToSIInst CreateFPToSI(Value @Val, Type @DestTy, string @Name)
        {
            return new FPToSIInst(LLVM.BuildFPToSI(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public UIToFPInst CreateUIToFP(Value @Val, Type @DestTy, string @Name)
        {
            return new UIToFPInst(LLVM.BuildUIToFP(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public SIToFPInst CreateSIToFP(Value @Val, Type @DestTy, string @Name)
        {
            return new SIToFPInst(LLVM.BuildSIToFP(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public FPTruncInst CreateFPTrunc(Value @Val, Type @DestTy, string @Name)
        {
            return new FPTruncInst(LLVM.BuildFPTrunc(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public FPExtInst CreateFPExt(Value @Val, Type @DestTy, string @Name)
        {
            return new FPExtInst(LLVM.BuildFPExt(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public PtrToIntInst CreatePtrToInt(Value @Val, Type @DestTy, string @Name)
        {
            return new PtrToIntInst(LLVM.BuildPtrToInt(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public IntToPtrInst CreateIntToPtr(Value @Val, Type @DestTy, string @Name)
        {
            return new IntToPtrInst(LLVM.BuildIntToPtr(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public BitCastInst CreateBitCast(Value @Val, Type @DestTy, string @Name)
        {
            return new BitCastInst(LLVM.BuildBitCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public AddrSpaceCastInst CreateAddrSpaceCast(Value @Val, Type @DestTy, string @Name)
        {
            return new AddrSpaceCastInst(LLVM.BuildAddrSpaceCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateZExtOrBitCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildZExtOrBitCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateSExtOrBitCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildSExtOrBitCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateTruncOrBitCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildTruncOrBitCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateCast(LLVMOpcode @Op, Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildCast(this.instance, @Op, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreatePointerCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildPointerCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateIntCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildIntCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public CastInst CreateFPCast(Value @Val, Type @DestTy, string @Name)
        {
            return new CastInst(LLVM.BuildFPCast(this.instance, @Val.ToValueRef(), @DestTy.ToTypeRef(), @Name));
        }

        public ICmpInst CreateICmp(LLVMIntPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new ICmpInst(LLVM.BuildICmp(this.instance, @Op, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FCmpInst CreateFCmp(LLVMRealPredicate @Op, Value @LHS, Value @RHS, string @Name)
        {
            return new FCmpInst(LLVM.BuildFCmp(this.instance, @Op, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public PHINode CreatePhi(Type @Ty, string @Name)
        {
            return new PHINode(LLVM.BuildPhi(this.instance, @Ty.ToTypeRef(), @Name));
        }

        public CallInst CreateCall(Value @Fn, Value[] @Args, string @Name)
        {
            return new CallInst(LLVM.BuildCall(this.instance, @Fn.ToValueRef(), @Args.ToValueRefs(), @Name));
        }

        public SelectInst CreateSelect(Value @If, Value @Then, Value @Else, string @Name)
        {
            return new SelectInst(LLVM.BuildSelect(this.instance, @If.ToValueRef(), @Then.ToValueRef(), @Else.ToValueRef(), @Name));
        }

        public VAArgInst CreateVAArg(Value @List, Type @Ty, string @Name)
        {
            return new VAArgInst(LLVM.BuildVAArg(this.instance, @List.ToValueRef(), @Ty.ToTypeRef(), @Name));
        }

        public ExtractElementInst CreateExtractElement(Value @VecVal, Value @Index, string @Name)
        {
            return new ExtractElementInst(LLVM.BuildExtractElement(this.instance, @VecVal.ToValueRef(), @Index.ToValueRef(), @Name));
        }

        public InsertElementInst CreateInsertElement(Value @VecVal, Value @EltVal, Value @Index, string @Name)
        {
            return new InsertElementInst(LLVM.BuildInsertElement(this.instance, @VecVal.ToValueRef(), @EltVal.ToValueRef(), @Index.ToValueRef(), @Name));
        }

        public ShuffleVectorInst CreateShuffleVector(Value @V1, Value @V2, Value @Mask, string @Name)
        {
            return new ShuffleVectorInst(LLVM.BuildShuffleVector(this.instance, @V1.ToValueRef(), @V2.ToValueRef(), @Mask.ToValueRef(), @Name));
        }

        public ExtractValueInst CreateExtractValue(Value @AggVal, uint @Index, string @Name)
        {
            return new ExtractValueInst(LLVM.BuildExtractValue(this.instance, @AggVal.ToValueRef(), @Index, @Name));
        }

        public InsertValueInst CreateInsertValue(Value @AggVal, Value @EltVal, uint @Index, string @Name)
        {
            return new InsertValueInst(LLVM.BuildInsertValue(this.instance, @AggVal.ToValueRef(), @EltVal.ToValueRef(), @Index, @Name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNull(Value @Val, string @Name)
        {
            return new ICmpInst(LLVM.BuildIsNull(this.instance, @Val.ToValueRef(), @Name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNotNull(Value @Val, string @Name)
        {
            return new ICmpInst(LLVM.BuildIsNotNull(this.instance, @Val.ToValueRef(), @Name));
        }

        // NOTE: Likely to stay SDiv, but you never know.
        public SDiv CreatePtrDiff(Value @LHS, Value @RHS, string @Name)
        {
            return new SDiv(LLVM.BuildPtrDiff(this.instance, @LHS.ToValueRef(), @RHS.ToValueRef(), @Name));
        }

        public FenceInst CreateFence(LLVMAtomicOrdering @ordering, bool @singleThread, string @Name)
        {
            return new FenceInst(LLVM.BuildFence(this.instance, @ordering, @singleThread, @Name));
        }

        public AtomicRMWInst CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value @PTR, Value @Val, LLVMAtomicOrdering @ordering, bool @singleThread)
        {
            return new AtomicRMWInst(LLVM.BuildAtomicRMW(this.instance, @op, @PTR.ToValueRef(), @Val.ToValueRef(), @ordering, @singleThread));
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