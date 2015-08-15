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

        public void PositionBuilder(BasicBlock block, Value instr)
        {
            LLVM.PositionBuilder(this.instance, block.ToBasicBlockRef(), instr.ToValueRef());
        }

        public void PositionBuilderBefore(Value instr)
        {
            LLVM.PositionBuilderBefore(this.instance, instr.ToValueRef());
        }

        public void PositionBuilderAtEnd(BasicBlock block)
        {
            LLVM.PositionBuilderAtEnd(this.instance, block.ToBasicBlockRef());
        }

        public BasicBlock GetInsertBlock()
        {
            return new BasicBlock(LLVM.GetInsertBlock(this.instance));
        }

        public void ClearInsertionPosition()
        {
            LLVM.ClearInsertionPosition(this.instance);
        }

        public void InsertIntoBuilder(Value instr)
        {
            LLVM.InsertIntoBuilder(this.instance, instr.ToValueRef());
        }

        public void InsertIntoBuilderWithName(Value instr, string name)
        {
            LLVM.InsertIntoBuilderWithName(this.instance, instr.ToValueRef(), name);
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
            LLVM.SetCurrentDebugLocation(this.instance, l.ToValueRef());
        }

        public Value GetCurrentDebugLocation()
        {
            return LLVM.GetCurrentDebugLocation(this.instance).ToValue();
        }

        public void SetInstDebugLocation(Value inst)
        {
            LLVM.SetInstDebugLocation(this.instance, inst.ToValueRef());
        }

        public ReturnInst CreateRetVoid()
        {
            return new ReturnInst(LLVM.BuildRetVoid(this.instance));
        }

        public ReturnInst CreateRet(Value v)
        {
            return new ReturnInst(LLVM.BuildRet(this.instance, v.ToValueRef()));
        }

        public ReturnInst CreateAggregateRet(Value[] retVals)
        {
            return new ReturnInst(LLVM.BuildAggregateRet(this.instance, retVals.ToValueRefs()));
        }

        public BranchInst CreateBr(BasicBlock dest)
        {
            return new BranchInst(LLVM.BuildBr(this.instance, dest.ToBasicBlockRef()));
        }

        public BranchInst CreateCondBr(Value @If, BasicBlock then, BasicBlock @Else)
        {
            return new BranchInst(LLVM.BuildCondBr(this.instance, @If.ToValueRef(), then.ToBasicBlockRef(), @Else.ToBasicBlockRef()));
        }

        public SwitchInst CreateSwitch(Value v, BasicBlock @Else, uint numCases)
        {
            return new SwitchInst(LLVM.BuildSwitch(this.instance, v.ToValueRef(), @Else.ToBasicBlockRef(), numCases));
        }

        public IndirectBrInst CreateIndirectBr(Value addr, uint numDests)
        {
            return new IndirectBrInst(LLVM.BuildIndirectBr(this.instance, addr.ToValueRef(), numDests));
        }

        public InvokeInst CreateInvoke(Value fn, Value[] args, BasicBlock then, BasicBlock @Catch, string name)
        {
            return new InvokeInst(LLVM.BuildInvoke(this.instance, fn.ToValueRef(), args.ToValueRefs(), then.ToBasicBlockRef(), @Catch.ToBasicBlockRef(), name));
        }

        public LandingPadInst CreateLandingPad(Type ty, Value persFn, uint numClauses, string name)
        {
            return new LandingPadInst(LLVM.BuildLandingPad(this.instance, ty.ToTypeRef(), persFn.ToValueRef(), numClauses, name));
        }

        public ResumeInst CreateResume(Value exn)
        {
            return new ResumeInst(LLVM.BuildResume(this.instance, exn.ToValueRef()));
        }

        public UnreachableInst CreateUnreachable()
        {
            return new UnreachableInst(LLVM.BuildUnreachable(this.instance));
        }

        public Add CreateAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildAdd(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Add CreateNSWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNSWAdd(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Add CreateNUWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNUWAdd(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FAdd CreateFAdd(Value lhs, Value rhs, string name)
        {
            return new FAdd(LLVM.BuildFAdd(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildSub(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateNSWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNSWSub(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Sub CreateNUWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNUWSub(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FSub CreateFSub(Value lhs, Value rhs, string name)
        {
            return new FSub(LLVM.BuildFSub(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildMul(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateNSWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNSWMul(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Mul CreateNUWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNUWMul(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FMul CreateFMul(Value lhs, Value rhs, string name)
        {
            return new FMul(LLVM.BuildFMul(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public UDiv CreateUDiv(Value lhs, Value rhs, string name)
        {
            return new UDiv(LLVM.BuildUDiv(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SDiv CreateSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildSDiv(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SDiv CreateExactSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildExactSDiv(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FDiv CreateFDiv(Value lhs, Value rhs, string name)
        {
            return new FDiv(LLVM.BuildFDiv(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public URem CreateURem(Value lhs, Value rhs, string name)
        {
            return new URem(LLVM.BuildURem(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public SRem CreateSRem(Value lhs, Value rhs, string name)
        {
            return new SRem(LLVM.BuildSRem(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FRem CreateFRem(Value lhs, Value rhs, string name)
        {
            return new FRem(LLVM.BuildFRem(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Shl CreateShl(Value lhs, Value rhs, string name)
        {
            return new Shl(LLVM.BuildShl(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public LShr CreateLShr(Value lhs, Value rhs, string name)
        {
            return new LShr(LLVM.BuildLShr(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public AShr CreateAShr(Value lhs, Value rhs, string name)
        {
            return new AShr(LLVM.BuildAShr(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public And CreateAnd(Value lhs, Value rhs, string name)
        {
            return new And(LLVM.BuildAnd(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Or CreateOr(Value lhs, Value rhs, string name)
        {
            return new Or(LLVM.BuildOr(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Xor CreateXor(Value lhs, Value rhs, string name)
        {
            return new Xor(LLVM.BuildXor(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public BinaryOperator CreateBinOp(LLVMOpcode op, Value lhs, Value rhs, string name)
        {
            return new BinaryOperator(LLVM.BuildBinOp(this.instance, op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public Neg CreateNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNeg(this.instance, v.ToValueRef(), name));
        }

        public Neg CreateNSWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNSWNeg(this.instance, v.ToValueRef(), name));
        }

        public Neg CreateNUWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNUWNeg(this.instance, v.ToValueRef(), name));
        }

        public FNeg CreateFNeg(Value v, string name)
        {
            return new FNeg(LLVM.BuildFNeg(this.instance, v.ToValueRef(), name));
        }

        public Not CreateNot(Value v, string name)
        {
            return new Not(LLVM.BuildNot(this.instance, v.ToValueRef(), name));
        }

        public Instruction CreateMalloc(Type ty, string name)
        {
            return new Instruction(LLVM.BuildMalloc(this.instance, ty.ToTypeRef(), name));
        }

        public Instruction CreateArrayMalloc(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayMalloc(this.instance, ty.ToTypeRef(), val.ToValueRef(), name));
        }

        public AllocaInst CreateAlloca(Type ty, string name)
        {
            return new AllocaInst(LLVM.BuildAlloca(this.instance, ty.ToTypeRef(), name));
        }

        public Instruction CreateArrayAlloca(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayAlloca(this.instance, ty.ToTypeRef(), val.ToValueRef(), name));
        }

        public Instruction CreateFree(Value pointerVal)
        {
            return new Instruction(LLVM.BuildFree(this.instance, pointerVal.ToValueRef()));
        }

        public LoadInst CreateLoad(Value pointerVal, string name)
        {
            return new LoadInst(LLVM.BuildLoad(this.instance, pointerVal.ToValueRef(), name));
        }

        public StoreInst CreateStore(Value val, Value ptr)
        {
            return new StoreInst(LLVM.BuildStore(this.instance, val.ToValueRef(), ptr.ToValueRef()));
        }

        public GetElementPtrInst CreateGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGEP(this.instance, pointer.ToValueRef(), indices.ToValueRefs(), name));
        }

        public GetElementPtrInst CreateInBoundsGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildInBoundsGEP(this.instance, pointer.ToValueRef(), indices.ToValueRefs(), name));
        }

        public GetElementPtrInst CreateStructGEP(Value pointer, uint idx, string name)
        {
            return new GetElementPtrInst(LLVM.BuildStructGEP(this.instance, pointer.ToValueRef(), idx, name));
        }

        // NOTE: Likely to stay GlobalVariable, but you never know.
        public GlobalVariable CreateGlobalString(string str, string name)
        {
            return new GlobalVariable(LLVM.BuildGlobalString(this.instance, str, name));
        }

        // NOTE: Likely to stay GetElementPtrInst, but you never know.
        public GetElementPtrInst CreateGlobalStringPtr(string str, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGlobalStringPtr(this.instance, str, name));
        }

        public TruncInst CreateTrunc(Value val, Type destTy, string name)
        {
            return new TruncInst(LLVM.BuildTrunc(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public ZExtInst CreateZExt(Value val, Type destTy, string name)
        {
            return new ZExtInst(LLVM.BuildZExt(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public SExtInst CreateSExt(Value val, Type destTy, string name)
        {
            return new SExtInst(LLVM.BuildSExt(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPToUIInst CreateFPToUI(Value val, Type destTy, string name)
        {
            return new FPToUIInst(LLVM.BuildFPToUI(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPToSIInst CreateFPToSI(Value val, Type destTy, string name)
        {
            return new FPToSIInst(LLVM.BuildFPToSI(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public UIToFPInst CreateUIToFP(Value val, Type destTy, string name)
        {
            return new UIToFPInst(LLVM.BuildUIToFP(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public SIToFPInst CreateSIToFP(Value val, Type destTy, string name)
        {
            return new SIToFPInst(LLVM.BuildSIToFP(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPTruncInst CreateFPTrunc(Value val, Type destTy, string name)
        {
            return new FPTruncInst(LLVM.BuildFPTrunc(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public FPExtInst CreateFPExt(Value val, Type destTy, string name)
        {
            return new FPExtInst(LLVM.BuildFPExt(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public PtrToIntInst CreatePtrToInt(Value val, Type destTy, string name)
        {
            return new PtrToIntInst(LLVM.BuildPtrToInt(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public IntToPtrInst CreateIntToPtr(Value val, Type destTy, string name)
        {
            return new IntToPtrInst(LLVM.BuildIntToPtr(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public BitCastInst CreateBitCast(Value val, Type destTy, string name)
        {
            return new BitCastInst(LLVM.BuildBitCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public AddrSpaceCastInst CreateAddrSpaceCast(Value val, Type destTy, string name)
        {
            return new AddrSpaceCastInst(LLVM.BuildAddrSpaceCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateZExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildZExtOrBitCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateSExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildSExtOrBitCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateTruncOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildTruncOrBitCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateCast(LLVMOpcode op, Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildCast(this.instance, op, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreatePointerCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildPointerCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateIntCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildIntCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public CastInst CreateFPCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildFPCast(this.instance, val.ToValueRef(), destTy.ToTypeRef(), name));
        }

        public ICmpInst CreateICmp(LLVMIntPredicate op, Value lhs, Value rhs, string name)
        {
            return new ICmpInst(LLVM.BuildICmp(this.instance, op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FCmpInst CreateFCmp(LLVMRealPredicate op, Value lhs, Value rhs, string name)
        {
            return new FCmpInst(LLVM.BuildFCmp(this.instance, op, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public PHINode CreatePhi(Type ty, string name)
        {
            return new PHINode(LLVM.BuildPhi(this.instance, ty.ToTypeRef(), name));
        }

        public CallInst CreateCall(Value fn, Value[] args, string name)
        {
            return new CallInst(LLVM.BuildCall(this.instance, fn.ToValueRef(), args.ToValueRefs(), name));
        }

        public SelectInst CreateSelect(Value @If, Value then, Value @Else, string name)
        {
            return new SelectInst(LLVM.BuildSelect(this.instance, @If.ToValueRef(), then.ToValueRef(), @Else.ToValueRef(), name));
        }

        public VAArgInst CreateVAArg(Value list, Type ty, string name)
        {
            return new VAArgInst(LLVM.BuildVAArg(this.instance, list.ToValueRef(), ty.ToTypeRef(), name));
        }

        public ExtractElementInst CreateExtractElement(Value vecVal, Value index, string name)
        {
            return new ExtractElementInst(LLVM.BuildExtractElement(this.instance, vecVal.ToValueRef(), index.ToValueRef(), name));
        }

        public InsertElementInst CreateInsertElement(Value vecVal, Value eltVal, Value index, string name)
        {
            return new InsertElementInst(LLVM.BuildInsertElement(this.instance, vecVal.ToValueRef(), eltVal.ToValueRef(), index.ToValueRef(), name));
        }

        public ShuffleVectorInst CreateShuffleVector(Value v1, Value v2, Value mask, string name)
        {
            return new ShuffleVectorInst(LLVM.BuildShuffleVector(this.instance, v1.ToValueRef(), v2.ToValueRef(), mask.ToValueRef(), name));
        }

        public ExtractValueInst CreateExtractValue(Value aggVal, uint index, string name)
        {
            return new ExtractValueInst(LLVM.BuildExtractValue(this.instance, aggVal.ToValueRef(), index, name));
        }

        public InsertValueInst CreateInsertValue(Value aggVal, Value eltVal, uint index, string name)
        {
            return new InsertValueInst(LLVM.BuildInsertValue(this.instance, aggVal.ToValueRef(), eltVal.ToValueRef(), index, name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNull(this.instance, val.ToValueRef(), name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNotNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNotNull(this.instance, val.ToValueRef(), name));
        }

        // NOTE: Likely to stay SDiv, but you never know.
        public SDiv CreatePtrDiff(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildPtrDiff(this.instance, lhs.ToValueRef(), rhs.ToValueRef(), name));
        }

        public FenceInst CreateFence(LLVMAtomicOrdering @ordering, bool @singleThread, string name)
        {
            return new FenceInst(LLVM.BuildFence(this.instance, @ordering, @singleThread, name));
        }

        public AtomicRMWInst CreateAtomicRMW(LLVMAtomicRMWBinOp @op, Value ptr, Value val, LLVMAtomicOrdering @ordering, bool @singleThread)
        {
            return new AtomicRMWInst(LLVM.BuildAtomicRMW(this.instance, @op, ptr.ToValueRef(), val.ToValueRef(), @ordering, @singleThread));
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