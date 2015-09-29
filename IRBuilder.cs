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

        internal IRBuilder(LLVMBuilderRef builderRef)
        {
            this.instance = builderRef;
        }

        public IRBuilder() : this(LLVM.GetGlobalContext())
        {
        }

        ~IRBuilder()
        {
            this.Dispose(false);
        }

        public void PositionBuilder(BasicBlock block, Value instr)
        {
            LLVM.PositionBuilder(this.ToBuilderRef(), block.ToBasicBlockRef(), instr.ToValueRef());
        }

        public void PositionBuilderBefore(Value instr)
        {
            LLVM.PositionBuilderBefore(this.ToBuilderRef(), instr.ToValueRef());
        }

        public void PositionBuilderAtEnd(BasicBlock block)
        {
            LLVM.PositionBuilderAtEnd(this.ToBuilderRef(), block.ToBasicBlockRef());
        }

        public BasicBlock GetInsertBlock()
        {
            return LLVM.GetInsertBlock(this.ToBuilderRef()).ToBasicBlock();
        }

        public void ClearInsertionPosition()
        {
            LLVM.ClearInsertionPosition(this.ToBuilderRef());
        }

        public void InsertIntoBuilder(Value instr)
        {
            LLVM.InsertIntoBuilder(this.ToBuilderRef(), instr.ToValueRef());
        }

        public void InsertIntoBuilderWithName(Value instr, string name)
        {
            LLVM.InsertIntoBuilderWithName(this.ToBuilderRef(), instr.ToValueRef(), name);
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

        public void SetCurrentDebugLocation(Value l)
        {
            LLVM.SetCurrentDebugLocation(this.ToBuilderRef(), l.ToValueRef());
        }

        public Value GetCurrentDebugLocation()
        {
            return LLVM.GetCurrentDebugLocation(this.ToBuilderRef()).ToValue();
        }

        public void SetInstDebugLocation(Value inst)
        {
            LLVM.SetInstDebugLocation(this.ToBuilderRef(), inst.ToValueRef());
        }

        public ReturnInst CreateRetVoid()
        {
            return new ReturnInst(LLVM.BuildRetVoid(this.ToBuilderRef()));
        }

        public ReturnInst CreateRet(Value v)
        {
            return new ReturnInst(LLVM.BuildRet(this.ToBuilderRef(), v.ToValueRef()));
        }

        public ReturnInst CreateAggregateRet(Value[] retVals)
        {
            return new ReturnInst(LLVM.BuildAggregateRet(this.ToBuilderRef(), retVals.ToValueRefs()));
        }

        public BranchInst CreateBr(BasicBlock dest)
        {
            return new BranchInst(LLVM.BuildBr(this.ToBuilderRef(), dest.ToBasicBlockRef()));
        }

        public BranchInst CreateCondBr(Value @If, BasicBlock then, BasicBlock @Else)
        {
            return new BranchInst(LLVM.BuildCondBr(this.ToBuilderRef(), @If.ToValueRef(), then.ToBasicBlockRef(), @Else.ToBasicBlockRef()));
        }

        public SwitchInst CreateSwitch(Value v, BasicBlock @Else, uint numCases)
        {
            return new SwitchInst(LLVM.BuildSwitch(this.ToBuilderRef(), v.ToValueRef(), @Else.ToBasicBlockRef(), numCases));
        }

        public IndirectBrInst CreateIndirectBr(Value addr, uint numDests)
        {
            return new IndirectBrInst(LLVM.BuildIndirectBr(this.ToBuilderRef(), addr.ToValueRef(), numDests));
        }

        public InvokeInst CreateInvoke(Value fn, Value[] args, BasicBlock then, BasicBlock @Catch, string name)
        {
            return new InvokeInst(LLVM.BuildInvoke(this.ToBuilderRef(), fn.ToValueRef(), args.ToValueRefs(), then.ToBasicBlockRef(), @Catch.ToBasicBlockRef(), name));
        }

        public LandingPadInst CreateLandingPad(Type ty, Value persFn, uint numClauses, string name)
        {
            return new LandingPadInst(LLVM.BuildLandingPad(this.ToBuilderRef(), ty.ToTypeRef(), persFn.ToValueRef(), numClauses, name));
        }

        public ResumeInst CreateResume(Value exn)
        {
            return new ResumeInst(LLVM.BuildResume(this.ToBuilderRef(), exn.ToValueRef()));
        }

        public UnreachableInst CreateUnreachable()
        {
            return new UnreachableInst(LLVM.BuildUnreachable(this.ToBuilderRef()));
        }

        public Add CreateAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildAdd(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Add CreateNSWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNSWAdd(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Add CreateNUWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNUWAdd(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FAdd CreateFAdd(Value lhs, Value rhs, string name)
        {
            return new FAdd(LLVM.BuildFAdd(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildSub(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateNSWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNSWSub(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateNUWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNUWSub(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FSub CreateFSub(Value lhs, Value rhs, string name)
        {
            return new FSub(LLVM.BuildFSub(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildMul(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateNSWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNSWMul(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateNUWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNUWMul(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FMul CreateFMul(Value lhs, Value rhs, string name)
        {
            return new FMul(LLVM.BuildFMul(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public UDiv CreateUDiv(Value lhs, Value rhs, string name)
        {
            return new UDiv(LLVM.BuildUDiv(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SDiv CreateSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildSDiv(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SDiv CreateExactSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildExactSDiv(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FDiv CreateFDiv(Value lhs, Value rhs, string name)
        {
            return new FDiv(LLVM.BuildFDiv(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public URem CreateURem(Value lhs, Value rhs, string name)
        {
            return new URem(LLVM.BuildURem(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SRem CreateSRem(Value lhs, Value rhs, string name)
        {
            return new SRem(LLVM.BuildSRem(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FRem CreateFRem(Value lhs, Value rhs, string name)
        {
            return new FRem(LLVM.BuildFRem(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Shl CreateShl(Value lhs, Value rhs, string name)
        {
            return new Shl(LLVM.BuildShl(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public LShr CreateLShr(Value lhs, Value rhs, string name)
        {
            return new LShr(LLVM.BuildLShr(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public AShr CreateAShr(Value lhs, Value rhs, string name)
        {
            return new AShr(LLVM.BuildAShr(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public And CreateAnd(Value lhs, Value rhs, string name)
        {
            return new And(LLVM.BuildAnd(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Or CreateOr(Value lhs, Value rhs, string name)
        {
            return new Or(LLVM.BuildOr(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Xor CreateXor(Value lhs, Value rhs, string name)
        {
            return new Xor(LLVM.BuildXor(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public BinaryOperator CreateBinOp(LLVMOpcode op, Value lhs, Value rhs, string name)
        {
            return new BinaryOperator(LLVM.BuildBinOp(this.ToBuilderRef(), op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Neg CreateNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNeg(this.ToBuilderRef(), v.ToValueRef(), name));
        }

        public Neg CreateNSWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNSWNeg(this.ToBuilderRef(), v.ToValueRef(), name));
        }

        public Neg CreateNUWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNUWNeg(this.ToBuilderRef(), v.ToValueRef(), name));
        }

        public FNeg CreateFNeg(Value v, string name)
        {
            return new FNeg(LLVM.BuildFNeg(this.ToBuilderRef(), v.ToValueRef(), name));
        }

        public Not CreateNot(Value v, string name)
        {
            return new Not(LLVM.BuildNot(this.ToBuilderRef(), v.ToValueRef(), name));
        }

        public Instruction CreateMalloc(Type ty, string name)
        {
            return new Instruction(LLVM.BuildMalloc(this.ToBuilderRef(), ty.ToTypeRef(), name));
        }

        public Instruction CreateArrayMalloc(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayMalloc(this.ToBuilderRef(), ty.ToTypeRef(), val.ToValueRef(), name));
        }

        public AllocaInst CreateAlloca(Type ty, string name)
        {
            return new AllocaInst(LLVM.BuildAlloca(this.ToBuilderRef(), ty.ToTypeRef(), name));
        }

        public Instruction CreateArrayAlloca(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayAlloca(this.ToBuilderRef(), ty.ToTypeRef(), val.ToValueRef(), name));
        }

        public Instruction CreateFree(Value pointerVal)
        {
            return new Instruction(LLVM.BuildFree(this.ToBuilderRef(), pointerVal.ToValueRef()));
        }

        public LoadInst CreateLoad(Value pointerVal, string name)
        {
            return new LoadInst(LLVM.BuildLoad(this.ToBuilderRef(), pointerVal.ToValueRef(), name));
        }

        public StoreInst CreateStore(Value val, Value ptr)
        {
            return new StoreInst(LLVM.BuildStore(this.ToBuilderRef(), val.ToValueRef(), ptr.ToValueRef()));
        }

        public GetElementPtrInst CreateGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGEP(this.ToBuilderRef(), pointer.ToValueRef(), indices.ToValueRefs(), name));
        }

        public GetElementPtrInst CreateInBoundsGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildInBoundsGEP(this.ToBuilderRef(), pointer.ToValueRef(), indices.ToValueRefs(), name));
        }

        public GetElementPtrInst CreateStructGEP(Value pointer, uint idx, string name)
        {
            return new GetElementPtrInst(LLVM.BuildStructGEP(this.ToBuilderRef(), pointer.ToValueRef(), idx, name));
        }

        // NOTE: Likely to stay GlobalVariable, but you never know.
        public GlobalVariable CreateGlobalString(string str, string name)
        {
            return new GlobalVariable(LLVM.BuildGlobalString(this.ToBuilderRef(), str, name));
        }

        // NOTE: Likely to stay GetElementPtrInst, but you never know.
        public GetElementPtrInst CreateGlobalStringPtr(string str, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGlobalStringPtr(this.ToBuilderRef(), str, name));
        }

        public TruncInst CreateTrunc(Value val, Type destTy, string name)
        {
            return new TruncInst(LLVM.BuildTrunc(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public ZExtInst CreateZExt(Value val, Type destTy, string name)
        {
            return new ZExtInst(LLVM.BuildZExt(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public SExtInst CreateSExt(Value val, Type destTy, string name)
        {
            return new SExtInst(LLVM.BuildSExt(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPToUIInst CreateFPToUI(Value val, Type destTy, string name)
        {
            return new FPToUIInst(LLVM.BuildFPToUI(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPToSIInst CreateFPToSI(Value val, Type destTy, string name)
        {
            return new FPToSIInst(LLVM.BuildFPToSI(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public UIToFPInst CreateUIToFP(Value val, Type destTy, string name)
        {
            return new UIToFPInst(LLVM.BuildUIToFP(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public SIToFPInst CreateSIToFP(Value val, Type destTy, string name)
        {
            return new SIToFPInst(LLVM.BuildSIToFP(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPTruncInst CreateFPTrunc(Value val, Type destTy, string name)
        {
            return new FPTruncInst(LLVM.BuildFPTrunc(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPExtInst CreateFPExt(Value val, Type destTy, string name)
        {
            return new FPExtInst(LLVM.BuildFPExt(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public PtrToIntInst CreatePtrToInt(Value val, Type destTy, string name)
        {
            return new PtrToIntInst(LLVM.BuildPtrToInt(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public IntToPtrInst CreateIntToPtr(Value val, Type destTy, string name)
        {
            return new IntToPtrInst(LLVM.BuildIntToPtr(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public BitCastInst CreateBitCast(Value val, Type destTy, string name)
        {
            return new BitCastInst(LLVM.BuildBitCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public AddrSpaceCastInst CreateAddrSpaceCast(Value val, Type destTy, string name)
        {
            return new AddrSpaceCastInst(LLVM.BuildAddrSpaceCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateZExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildZExtOrBitCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateSExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildSExtOrBitCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateTruncOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildTruncOrBitCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateCast(LLVMOpcode op, Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildCast(this.ToBuilderRef(), op, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreatePointerCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildPointerCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateIntCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildIntCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateFPCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildFPCast(this.ToBuilderRef(), val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public ICmpInst CreateICmp(LLVMIntPredicate op, Value lhs, Value rhs, string name)
        {
            return new ICmpInst(LLVM.BuildICmp(this.ToBuilderRef(), op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FCmpInst CreateFCmp(LLVMRealPredicate op, Value lhs, Value rhs, string name)
        {
            return new FCmpInst(LLVM.BuildFCmp(this.ToBuilderRef(), op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public PHINode CreatePhi(Type ty, string name)
        {
            return new PHINode(LLVM.BuildPhi(this.ToBuilderRef(), ty.ToTypeRef(), name));
        }

        public CallInst CreateCall(Value fn, Value[] args, string name)
        {
            return new CallInst(LLVM.BuildCall(this.ToBuilderRef(), fn.ToValueRef(), args.ToValueRefs(), name));
        }

        public SelectInst CreateSelect(Value @If, Value then, Value @Else, string name)
        {
            return new SelectInst(LLVM.BuildSelect(this.ToBuilderRef(), @If.ToValueRef(), then.ToValueRef(), @Else.ToValueRef(), name));
        }

        public VAArgInst CreateVAArg(Value list, Type ty, string name)
        {
            return new VAArgInst(LLVM.BuildVAArg(this.ToBuilderRef(), list.ToValueRef(), ty.ToTypeRef(), name));
        }

        public ExtractElementInst CreateExtractElement(Value vecVal, Value index, string name)
        {
            return new ExtractElementInst(LLVM.BuildExtractElement(this.ToBuilderRef(), vecVal.ToValueRef(), index.ToValueRef(), name));
        }

        public InsertElementInst CreateInsertElement(Value vecVal, Value eltVal, Value index, string name)
        {
            return new InsertElementInst(LLVM.BuildInsertElement(this.ToBuilderRef(), vecVal.ToValueRef(), eltVal.ToValueRef(), index.ToValueRef(), name));
        }

        public ShuffleVectorInst CreateShuffleVector(Value v1, Value v2, Value mask, string name)
        {
            return new ShuffleVectorInst(LLVM.BuildShuffleVector(this.ToBuilderRef(), v1.ToValueRef(), v2.ToValueRef(), mask.ToValueRef(), name));
        }

        public ExtractValueInst CreateExtractValue(Value aggVal, uint index, string name)
        {
            return new ExtractValueInst(LLVM.BuildExtractValue(this.ToBuilderRef(), aggVal.ToValueRef(), index, name));
        }

        public InsertValueInst CreateInsertValue(Value aggVal, Value eltVal, uint index, string name)
        {
            return new InsertValueInst(LLVM.BuildInsertValue(this.ToBuilderRef(), aggVal.ToValueRef(), eltVal.ToValueRef(), index, name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNull(this.ToBuilderRef(), val.ToValueRef(), name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNotNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNotNull(this.ToBuilderRef(), val.ToValueRef(), name));
        }

        // NOTE: Likely to stay SDiv, but you never know.
        public SDiv CreatePtrDiff(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildPtrDiff(this.ToBuilderRef(), lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FenceInst CreateFence(LLVMAtomicOrdering @ordering, bool @singleThread, string name)
        {
            return new FenceInst(LLVM.BuildFence(this.ToBuilderRef(), @ordering, @singleThread, name));
        }

        public AtomicRMWInst CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value ptr, Value val, LLVMAtomicOrdering @ordering, bool @singleThread)
        {
            return new AtomicRMWInst(LLVM.BuildAtomicRMW(this.ToBuilderRef(), @op, ptr.ToValueRef(), val.ToValueRef(), @ordering, @singleThread));
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