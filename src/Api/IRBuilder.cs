namespace LLVMSharp.Api
{
    using System;
    using Utilities;
    using Values;
    using Values.Constants.GlobalValues.GlobalObjects;
    using Values.Instructions;
    using Values.Instructions.Binary;
    using Values.Instructions.Cmp;
    using Values.Instructions.Terminator;
    using Values.Instructions.Unary;
    using Values.Instructions.Unary.Casts;

    public sealed class IRBuilder : IDisposable, IEquatable<IRBuilder>, IDisposableWrapper<LLVMBuilderRef>
    {
        public static IRBuilder Create()
        {
            return LLVM.CreateBuilder().Wrap().MakeHandleOwner<IRBuilder, LLVMBuilderRef>();
        }

        public static IRBuilder Create(Context context)
        {
            return LLVM.CreateBuilderInContext(context.Unwrap()).Wrap().MakeHandleOwner<IRBuilder, LLVMBuilderRef>();
        }

        LLVMBuilderRef IWrapper<LLVMBuilderRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMBuilderRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMBuilderRef _instance;
        private bool _disposed;
        private bool _owner;

        internal IRBuilder(LLVMBuilderRef builderRef)
        {
            this._instance = builderRef;
        }

        ~IRBuilder()
        {
            this.Dispose(false);
        }
        
        public void PositionBuilder(BasicBlock block, Instruction instr)
        {
            LLVM.PositionBuilder(this.Unwrap(), block.Unwrap<LLVMBasicBlockRef>(), instr.Unwrap());
        }

        public void PositionBuilderBefore(Instruction instr)
        {
            LLVM.PositionBuilderBefore(this.Unwrap(), instr.Unwrap());
        }

        public void PositionBuilderAtEnd(BasicBlock block)
        {
            LLVM.PositionBuilderAtEnd(this.Unwrap(), block.Unwrap<LLVMBasicBlockRef>());
        }

        public BasicBlock GetInsertBlock()
        {
            return LLVM.GetInsertBlock(this.Unwrap()).Wrap();
        }

        public void ClearInsertionPosition()
        {
            LLVM.ClearInsertionPosition(this.Unwrap());
        }

        public void InsertIntoBuilder(Instruction instr)
        {
            LLVM.InsertIntoBuilder(this.Unwrap(), instr.Unwrap());
        }

        public void InsertIntoBuilder(Instruction instr, string name)
        {
            LLVM.InsertIntoBuilderWithName(this.Unwrap(), instr.Unwrap(), name);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposeBuilder(this._instance);
            }

            this._disposed = true;
        }

        public Value CurrentDebugLocation
        {
            get { return LLVM.GetCurrentDebugLocation(this.Unwrap()).Wrap(); }
            set { LLVM.SetCurrentDebugLocation(this.Unwrap(), value.Unwrap()); }
        }
        
        public void SetInstDebugLocation(Instruction inst)
        {
            LLVM.SetInstDebugLocation(this.Unwrap(), inst.Unwrap());
        }

        public ReturnInst CreateRetVoid()
        {
            return new ReturnInst(LLVM.BuildRetVoid(this.Unwrap()));
        }

        public ReturnInst CreateRet(Value v)
        {
            return new ReturnInst(LLVM.BuildRet(this.Unwrap(), v.Unwrap()));
        }

        public ReturnInst CreateAggregateRet(Value[] retVals)
        {
            return new ReturnInst(LLVM.BuildAggregateRet(this.Unwrap(), retVals.Unwrap()));
        }

        public BranchInst CreateBr(BasicBlock dest)
        {
            return new BranchInst(LLVM.BuildBr(this.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>()));
        }

        public BranchInst CreateCondBr(Value If, BasicBlock then, BasicBlock Else)
        {
            return new BranchInst(LLVM.BuildCondBr(this.Unwrap(), If.Unwrap(), then.Unwrap<LLVMBasicBlockRef>(),
                                                   Else.Unwrap<LLVMBasicBlockRef>()));
        }

        public SwitchInst CreateSwitch(Value v, BasicBlock Else, uint numCases)
        {
            return
                new SwitchInst(LLVM.BuildSwitch(this.Unwrap(), v.Unwrap(), Else.Unwrap<LLVMBasicBlockRef>(), numCases));
        }

        public IndirectBrInst CreateIndirectBr(Value addr, uint numDests)
        {
            return new IndirectBrInst(LLVM.BuildIndirectBr(this.Unwrap(), addr.Unwrap(), numDests));
        }

        public InvokeInst CreateInvoke(Value fn, Value[] args, BasicBlock then, BasicBlock Catch, string name)
        {
            return new InvokeInst(LLVM.BuildInvoke(this.Unwrap(), fn.Unwrap(), args.Unwrap(),
                                                   then.Unwrap<LLVMBasicBlockRef>(), Catch.Unwrap<LLVMBasicBlockRef>(),
                                                   name));
        }

        public LandingPadInst CreateLandingPad(Type ty, Value persFn, uint numClauses, string name)
        {
            return
                new LandingPadInst(LLVM.BuildLandingPad(this.Unwrap(), ty.Unwrap(), persFn.Unwrap(), numClauses, name));
        }

        public ResumeInst CreateResume(Value exn)
        {
            return new ResumeInst(LLVM.BuildResume(this.Unwrap(), exn.Unwrap()));
        }

        public UnreachableInst CreateUnreachable()
        {
            return new UnreachableInst(LLVM.BuildUnreachable(this.Unwrap()));
        }

        public Add CreateAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Add CreateNSWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNSWAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Add CreateNUWAdd(Value lhs, Value rhs, string name)
        {
            return new Add(LLVM.BuildNUWAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FAdd CreateFAdd(Value lhs, Value rhs, string name)
        {
            return new FAdd(LLVM.BuildFAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Sub CreateSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Sub CreateNSWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNSWSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Sub CreateNUWSub(Value lhs, Value rhs, string name)
        {
            return new Sub(LLVM.BuildNUWSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FSub CreateFSub(Value lhs, Value rhs, string name)
        {
            return new FSub(LLVM.BuildFSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Mul CreateMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Mul CreateNSWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNSWMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Mul CreateNUWMul(Value lhs, Value rhs, string name)
        {
            return new Mul(LLVM.BuildNUWMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FMul CreateFMul(Value lhs, Value rhs, string name)
        {
            return new FMul(LLVM.BuildFMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public UDiv CreateUDiv(Value lhs, Value rhs, string name)
        {
            return new UDiv(LLVM.BuildUDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public SDiv CreateSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildSDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public SDiv CreateExactSDiv(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildExactSDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FDiv CreateFDiv(Value lhs, Value rhs, string name)
        {
            return new FDiv(LLVM.BuildFDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public URem CreateURem(Value lhs, Value rhs, string name)
        {
            return new URem(LLVM.BuildURem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public SRem CreateSRem(Value lhs, Value rhs, string name)
        {
            return new SRem(LLVM.BuildSRem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FRem CreateFRem(Value lhs, Value rhs, string name)
        {
            return new FRem(LLVM.BuildFRem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Shl CreateShl(Value lhs, Value rhs, string name)
        {
            return new Shl(LLVM.BuildShl(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public LShr CreateLShr(Value lhs, Value rhs, string name)
        {
            return new LShr(LLVM.BuildLShr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public AShr CreateAShr(Value lhs, Value rhs, string name)
        {
            return new AShr(LLVM.BuildAShr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public And CreateAnd(Value lhs, Value rhs, string name)
        {
            return new And(LLVM.BuildAnd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Or CreateOr(Value lhs, Value rhs, string name)
        {
            return new Or(LLVM.BuildOr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Xor CreateXor(Value lhs, Value rhs, string name)
        {
            return new Xor(LLVM.BuildXor(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public BinaryOperator CreateBinOp(LLVMOpcode op, Value lhs, Value rhs, string name)
        {
            return new BinaryOperator(LLVM.BuildBinOp(this.Unwrap(), op, lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public Neg CreateNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNeg(this.Unwrap(), v.Unwrap(), name));
        }

        public Neg CreateNSWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNSWNeg(this.Unwrap(), v.Unwrap(), name));
        }

        public Neg CreateNUWNeg(Value v, string name)
        {
            return new Neg(LLVM.BuildNUWNeg(this.Unwrap(), v.Unwrap(), name));
        }

        public FNeg CreateFNeg(Value v, string name)
        {
            return new FNeg(LLVM.BuildFNeg(this.Unwrap(), v.Unwrap(), name));
        }

        public Not CreateNot(Value v, string name)
        {
            return new Not(LLVM.BuildNot(this.Unwrap(), v.Unwrap(), name));
        }

        public Instruction CreateMalloc(Type ty, string name)
        {
            return new Instruction(LLVM.BuildMalloc(this.Unwrap(), ty.Unwrap(), name));
        }

        public Instruction CreateArrayMalloc(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayMalloc(this.Unwrap(), ty.Unwrap(), val.Unwrap(), name));
        }

        public AllocaInst CreateAlloca(Type ty, string name)
        {
            return new AllocaInst(LLVM.BuildAlloca(this.Unwrap(), ty.Unwrap(), name));
        }

        public Instruction CreateArrayAlloca(Type ty, Value val, string name)
        {
            return new Instruction(LLVM.BuildArrayAlloca(this.Unwrap(), ty.Unwrap(), val.Unwrap(), name));
        }

        public Instruction CreateFree(Value pointerVal)
        {
            return new Instruction(LLVM.BuildFree(this.Unwrap(), pointerVal.Unwrap()));
        }

        public LoadInst CreateLoad(Value pointerVal, string name)
        {
            return new LoadInst(LLVM.BuildLoad(this.Unwrap(), pointerVal.Unwrap(), name));
        }

        public StoreInst CreateStore(Value val, Value ptr)
        {
            return new StoreInst(LLVM.BuildStore(this.Unwrap(), val.Unwrap(), ptr.Unwrap()));
        }

        public GetElementPtrInst CreateGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGEP(this.Unwrap(), pointer.Unwrap(), indices.Unwrap(), name));
        }

        public GetElementPtrInst CreateInBoundsGEP(Value pointer, Value[] indices, string name)
        {
            return new GetElementPtrInst(LLVM.BuildInBoundsGEP(this.Unwrap(), pointer.Unwrap(), indices.Unwrap(), name));
        }

        public GetElementPtrInst CreateStructGEP(Value pointer, uint idx, string name)
        {
            return new GetElementPtrInst(LLVM.BuildStructGEP(this.Unwrap(), pointer.Unwrap(), idx, name));
        }

        // NOTE: Likely to stay GlobalVariable, but you never know.
        public GlobalVariable CreateGlobalString(string str, string name)
        {
            return new GlobalVariable(LLVM.BuildGlobalString(this.Unwrap(), str, name));
        }

        // NOTE: Likely to stay GetElementPtrInst, but you never know.
        public GetElementPtrInst CreateGlobalStringPtr(string str, string name)
        {
            return new GetElementPtrInst(LLVM.BuildGlobalStringPtr(this.Unwrap(), str, name));
        }

        public TruncInst CreateTrunc(Value val, Type destTy, string name)
        {
            return new TruncInst(LLVM.BuildTrunc(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public ZExtInst CreateZExt(Value val, Type destTy, string name)
        {
            return new ZExtInst(LLVM.BuildZExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public SExtInst CreateSExt(Value val, Type destTy, string name)
        {
            return new SExtInst(LLVM.BuildSExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public FPToUIInst CreateFPToUI(Value val, Type destTy, string name)
        {
            return new FPToUIInst(LLVM.BuildFPToUI(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public FPToSIInst CreateFPToSI(Value val, Type destTy, string name)
        {
            return new FPToSIInst(LLVM.BuildFPToSI(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public UIToFPInst CreateUIToFP(Value val, Type destTy, string name)
        {
            return new UIToFPInst(LLVM.BuildUIToFP(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public SIToFPInst CreateSIToFP(Value val, Type destTy, string name)
        {
            return new SIToFPInst(LLVM.BuildSIToFP(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public FPTruncInst CreateFPTrunc(Value val, Type destTy, string name)
        {
            return new FPTruncInst(LLVM.BuildFPTrunc(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public FPExtInst CreateFPExt(Value val, Type destTy, string name)
        {
            return new FPExtInst(LLVM.BuildFPExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public PtrToIntInst CreatePtrToInt(Value val, Type destTy, string name)
        {
            return new PtrToIntInst(LLVM.BuildPtrToInt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public IntToPtrInst CreateIntToPtr(Value val, Type destTy, string name)
        {
            return new IntToPtrInst(LLVM.BuildIntToPtr(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public BitCastInst CreateBitCast(Value val, Type destTy, string name)
        {
            return new BitCastInst(LLVM.BuildBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public AddrSpaceCastInst CreateAddrSpaceCast(Value val, Type destTy, string name)
        {
            return new AddrSpaceCastInst(LLVM.BuildAddrSpaceCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateZExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildZExtOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateSExtOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildSExtOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateTruncOrBitCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildTruncOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateCast(LLVMOpcode op, Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildCast(this.Unwrap(), op, val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreatePointerCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildPointerCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateIntCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildIntCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public CastInst CreateFPCast(Value val, Type destTy, string name)
        {
            return new CastInst(LLVM.BuildFPCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name));
        }

        public ICmpInst CreateICmp(LLVMIntPredicate op, Value lhs, Value rhs, string name)
        {
            return new ICmpInst(LLVM.BuildICmp(this.Unwrap(), op, lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public ICmpInst CreateICmpEQ(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntEQ, lhs, rhs, name);
        }

        public ICmpInst CreateICmpNE(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntNE, lhs, rhs, name);
        }

        public ICmpInst CreateICmpUGT(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntUGT, lhs, rhs, name);
        }

        public ICmpInst CreateICmpULT(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntULT, lhs, rhs, name);
        }

        public ICmpInst CreateICmpULE(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntULE, lhs, rhs, name);
        }

        public ICmpInst CreateICmpSGT(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntSGT, lhs, rhs, name);
        }

        public ICmpInst CreateICmpSGE(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntSGE, lhs, rhs, name);
        }

        public ICmpInst CreateICmpSLT(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntSLT, lhs, rhs, name);
        }

        public ICmpInst CreateICmpSLE(Value lhs, Value rhs, string name)
        {
            return this.CreateICmp(LLVMIntPredicate.LLVMIntSLE, lhs, rhs, name);
        }

        public FCmpInst CreateFCmp(LLVMRealPredicate op, Value lhs, Value rhs, string name)
        {
            return new FCmpInst(LLVM.BuildFCmp(this.Unwrap(), op, lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FCmpInst CreateFCmpOEQ(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealOEQ, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpOGT(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealOGT, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpOGE(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealOGE, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpOLT(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealOLT, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpOLE(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealOLE, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpONE(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealONE, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpORD(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealORD, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpUNO(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealUNO, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpUEQ(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealUEQ, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpUGT(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealUGT, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpUGE(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealUGE, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpULT(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealULT, lhs, rhs, name);
        }

        public FCmpInst CreateFCmpUNE(Value lhs, Value rhs, string name)
        {
            return this.CreateFCmp(LLVMRealPredicate.LLVMRealUNE, lhs, rhs, name);
        }

        public PHINode CreatePhi(Type ty, string name)
        {
            return new PHINode(LLVM.BuildPhi(this.Unwrap(), ty.Unwrap(), name));
        }

        public CallInst CreateCall(Value fn, Value[] args, string name)
        {
            return new CallInst(LLVM.BuildCall(this.Unwrap(), fn.Unwrap(), args.Unwrap(), name));
        }

        public SelectInst CreateSelect(Value @If, Value then, Value @Else, string name)
        {
            return new SelectInst(LLVM.BuildSelect(this.Unwrap(), @If.Unwrap(), then.Unwrap(), @Else.Unwrap(), name));
        }

        public VAArgInst CreateVAArg(Value list, Type ty, string name)
        {
            return new VAArgInst(LLVM.BuildVAArg(this.Unwrap(), list.Unwrap(), ty.Unwrap(), name));
        }

        public ExtractElementInst CreateExtractElement(Value vecVal, Value index, string name)
        {
            return new ExtractElementInst(LLVM.BuildExtractElement(this.Unwrap(), vecVal.Unwrap(), index.Unwrap(), name));
        }

        public InsertElementInst CreateInsertElement(Value vecVal, Value eltVal, Value index, string name)
        {
            return new InsertElementInst(LLVM.BuildInsertElement(this.Unwrap(), vecVal.Unwrap(), eltVal.Unwrap(),
                                                                 index.Unwrap(), name));
        }

        public ShuffleVectorInst CreateShuffleVector(Value v1, Value v2, Value mask, string name)
        {
            return new ShuffleVectorInst(LLVM.BuildShuffleVector(this.Unwrap(), v1.Unwrap(), v2.Unwrap(), mask.Unwrap(),
                                                                 name));
        }

        public ExtractValueInst CreateExtractValue(Value aggVal, uint index, string name)
        {
            return new ExtractValueInst(LLVM.BuildExtractValue(this.Unwrap(), aggVal.Unwrap(), index, name));
        }

        public InsertValueInst CreateInsertValue(Value aggVal, Value eltVal, uint index, string name)
        {
            return
                new InsertValueInst(LLVM.BuildInsertValue(this.Unwrap(), aggVal.Unwrap(), eltVal.Unwrap(), index, name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNull(this.Unwrap(), val.Unwrap(), name));
        }

        // NOTE: Likely to stay ICmpInst, but you never know.
        public ICmpInst CreateIsNotNull(Value val, string name)
        {
            return new ICmpInst(LLVM.BuildIsNotNull(this.Unwrap(), val.Unwrap(), name));
        }

        // NOTE: Likely to stay SDiv, but you never know.
        public SDiv CreatePtrDiff(Value lhs, Value rhs, string name)
        {
            return new SDiv(LLVM.BuildPtrDiff(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name));
        }

        public FenceInst CreateFence(LLVMAtomicOrdering ordering, bool singleThread, string name)
        {
            return new FenceInst(LLVM.BuildFence(this.Unwrap(), ordering, singleThread, name));
        }

        public AtomicRMWInst CreateAtomicRMW(LLVMAtomicRMWBinOp op, Value ptr, Value val, LLVMAtomicOrdering ordering,
                                             bool singleThread)
        {
            return new AtomicRMWInst(LLVM.BuildAtomicRMW(this.Unwrap(), op, ptr.Unwrap(), val.Unwrap(), ordering,
                                                         singleThread));
        }

        public bool Equals(IRBuilder other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return this._instance == other._instance;
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
            return op1.Equals(op2);
        }

        public static bool operator !=(IRBuilder op1, IRBuilder op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
        }
    }
}