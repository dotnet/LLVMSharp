namespace LLVMSharp.API
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
        LLVMBuilderRef IWrapper<LLVMBuilderRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMBuilderRef>.MakeHandleOwner() => this._owner = true;

        public static IRBuilder Create() => LLVM.CreateBuilder().Wrap().MakeHandleOwner<IRBuilder, LLVMBuilderRef>();
        public static IRBuilder Create(Context context) => LLVM.CreateBuilderInContext(context.Unwrap()).Wrap().MakeHandleOwner<IRBuilder, LLVMBuilderRef>();

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

        public void PositionBuilder(BasicBlock block, Instruction instr) => LLVM.PositionBuilder(this.Unwrap(), block.Unwrap<LLVMBasicBlockRef>(), instr.Unwrap());
        public void PositionBuilderBefore(Instruction instr) => LLVM.PositionBuilderBefore(this.Unwrap(), instr.Unwrap());
        public void PositionBuilderAtEnd(BasicBlock block) => LLVM.PositionBuilderAtEnd(this.Unwrap(), block.Unwrap<LLVMBasicBlockRef>());

        public BasicBlock GetInsertBlock() => LLVM.GetInsertBlock(this.Unwrap()).Wrap();

        public void ClearInsertionPosition() => LLVM.ClearInsertionPosition(this.Unwrap());

        public void InsertIntoBuilder(Instruction instr) => LLVM.InsertIntoBuilder(this.Unwrap(), instr.Unwrap());
        public void InsertIntoBuilder(Instruction instr, string name = "") => LLVM.InsertIntoBuilderWithName(this.Unwrap(), instr.Unwrap(), name);

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
            get => LLVM.GetCurrentDebugLocation(this.Unwrap()).Wrap();
            set => LLVM.SetCurrentDebugLocation(this.Unwrap(), value.Unwrap());
        }

        public void SetInstDebugLocation(Instruction inst) => LLVM.SetInstDebugLocation(this.Unwrap(), inst.Unwrap());

        public ReturnInst CreateRetVoid() => LLVM.BuildRetVoid(this.Unwrap()).WrapAs<ReturnInst>();
        public ReturnInst CreateRet(Value v) => LLVM.BuildRet(this.Unwrap(), v.Unwrap()).WrapAs<ReturnInst>();
        public ReturnInst CreateAggregateRet(Value[] retVals) => LLVM.BuildAggregateRet(this.Unwrap(), retVals.Unwrap()).WrapAs<ReturnInst>();
        public BranchInst CreateBr(BasicBlock dest) => LLVM.BuildBr(this.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>()).WrapAs<BranchInst>();
        public BranchInst CreateCondBr(Value If, BasicBlock then, BasicBlock Else) => LLVM.BuildCondBr(this.Unwrap(), If.Unwrap(), then.Unwrap<LLVMBasicBlockRef>(), Else.Unwrap<LLVMBasicBlockRef>()).WrapAs<BranchInst>();
        public SwitchInst CreateSwitch(Value v, BasicBlock Else, uint numCases) => LLVM.BuildSwitch(this.Unwrap(), v.Unwrap(), Else.Unwrap<LLVMBasicBlockRef>(), numCases).WrapAs<SwitchInst>();
        public IndirectBrInst CreateIndirectBr(Value addr, uint numDests) => LLVM.BuildIndirectBr(this.Unwrap(), addr.Unwrap(), numDests).WrapAs<IndirectBrInst>();
        public InvokeInst CreateInvoke(Value fn, Value[] args, BasicBlock then, BasicBlock Catch, string name = "") => LLVM.BuildInvoke(this.Unwrap(), fn.Unwrap(), args.Unwrap(), then.Unwrap<LLVMBasicBlockRef>(), Catch.Unwrap<LLVMBasicBlockRef>(), name).WrapAs<InvokeInst>();
        public LandingPadInst CreateLandingPad(Type ty, Value persFn, uint numClauses, string name = "") => LLVM.BuildLandingPad(this.Unwrap(), ty.Unwrap(), persFn.Unwrap(), numClauses, name).WrapAs<LandingPadInst>();  
        public ResumeInst CreateResume(Value exn) => LLVM.BuildResume(this.Unwrap(), exn.Unwrap()).WrapAs<ResumeInst>();
        public UnreachableInst CreateUnreachable() => LLVM.BuildUnreachable(this.Unwrap()).WrapAs<UnreachableInst>();
        public Value CreateAdd(Value lhs, Value rhs, string name = "") => LLVM.BuildAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNSWAdd(Value lhs, Value rhs, string name = "") => LLVM.BuildNSWAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNUWAdd(Value lhs, Value rhs, string name = "") => LLVM.BuildNUWAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFAdd(Value lhs, Value rhs, string name = "") => LLVM.BuildFAdd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateSub(Value lhs, Value rhs, string name = "") => LLVM.BuildSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNSWSub(Value lhs, Value rhs, string name = "") => LLVM.BuildNSWSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();     
        public Value CreateNUWSub(Value lhs, Value rhs, string name = "") => LLVM.BuildNUWSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFSub(Value lhs, Value rhs, string name = "") => LLVM.BuildFSub(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateMul(Value lhs, Value rhs, string name = "") => LLVM.BuildMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNSWMul(Value lhs, Value rhs, string name = "") => LLVM.BuildNSWMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNUWMul(Value lhs, Value rhs, string name = "") => LLVM.BuildNUWMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFMul(Value lhs, Value rhs, string name = "") => LLVM.BuildFMul(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateUDiv(Value lhs, Value rhs, string name = "") => LLVM.BuildUDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateExactUDiv(Value lhs, Value rhs, string name = "") => LLVM.BuildExactUDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateSDiv(Value lhs, Value rhs, string name = "") => LLVM.BuildSDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateExactSDiv(Value lhs, Value rhs, string name = "") => LLVM.BuildExactSDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFDiv(Value lhs, Value rhs, string name = "") => LLVM.BuildFDiv(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateURem(Value lhs, Value rhs, string name = "") => LLVM.BuildURem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateSRem(Value lhs, Value rhs, string name = "") => LLVM.BuildSRem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFRem(Value lhs, Value rhs, string name = "") => LLVM.BuildFRem(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateShl(Value lhs, Value rhs, string name = "") => LLVM.BuildShl(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateLShr(Value lhs, Value rhs, string name = "") => LLVM.BuildLShr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateAShr(Value lhs, Value rhs, string name = "") => LLVM.BuildAShr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateAnd(Value lhs, Value rhs, string name = "") => LLVM.BuildAnd(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateOr(Value lhs, Value rhs, string name = "") => LLVM.BuildOr(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateXor(Value lhs, Value rhs, string name = "") => LLVM.BuildXor(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateBinOp(Opcode op, Value lhs, Value rhs, string name = "") => LLVM.BuildBinOp(this.Unwrap(), op.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateNeg(Value v, string name = "") => LLVM.BuildNeg(this.Unwrap(), v.Unwrap(), name).WrapAs<Value>();
        public Value CreateNSWNeg(Value v, string name = "") => LLVM.BuildNSWNeg(this.Unwrap(), v.Unwrap(), name).WrapAs<Value>();
        public Value CreateNUWNeg(Value v, string name = "") => LLVM.BuildNUWNeg(this.Unwrap(), v.Unwrap(), name).WrapAs<Value>();
        public Value CreateFNeg(Value v, string name = "") => LLVM.BuildFNeg(this.Unwrap(), v.Unwrap(), name).WrapAs<Value>();
        public Value CreateNot(Value v, string name = "") => LLVM.BuildNot(this.Unwrap(), v.Unwrap(), name).WrapAs<Value>();
        public CallInst CreateMalloc(Type ty, string name = "") => LLVM.BuildMalloc(this.Unwrap(), ty.Unwrap(), name).WrapAs<CallInst>();
        public CallInst CreateArrayMalloc(Type ty, Value val, string name = "") => LLVM.BuildArrayMalloc(this.Unwrap(), ty.Unwrap(), val.Unwrap(), name).WrapAs<CallInst>();
        public AllocaInst CreateAlloca(Type ty, string name = "") => LLVM.BuildAlloca(this.Unwrap(), ty.Unwrap(), name).WrapAs<AllocaInst>();
        public AllocaInst CreateArrayAlloca(Type ty, Value val, string name = "") => LLVM.BuildArrayAlloca(this.Unwrap(), ty.Unwrap(), val.Unwrap(), name).WrapAs<AllocaInst>();
        public CallInst CreateFree(Value pointerVal) => LLVM.BuildFree(this.Unwrap(), pointerVal.Unwrap()).WrapAs<CallInst>();
        public LoadInst CreateLoad(Value pointerVal, string name = "") => LLVM.BuildLoad(this.Unwrap(), pointerVal.Unwrap(), name).WrapAs<LoadInst>();
        public StoreInst CreateStore(Value val, Value ptr) => LLVM.BuildStore(this.Unwrap(), val.Unwrap(), ptr.Unwrap()).WrapAs<StoreInst>();
        public Value CreateGEP(Value pointer, Value[] indices, string name = "") => LLVM.BuildGEP(this.Unwrap(), pointer.Unwrap(), indices.Unwrap(), name).WrapAs<Value>();
        public Value CreateInBoundsGEP(Value pointer, Value[] indices, string name = "") => LLVM.BuildInBoundsGEP(this.Unwrap(), pointer.Unwrap(), indices.Unwrap(), name).WrapAs<Value>();
        public Value CreateStructGEP(Value pointer, uint idx, string name = "") => LLVM.BuildStructGEP(this.Unwrap(), pointer.Unwrap(), idx, name).WrapAs<Value>();
        public Value CreateGlobalString(string str, string name = "") => LLVM.BuildGlobalString(this.Unwrap(), str, name).WrapAs<Value>();
        public Value CreateGlobalStringPtr(string str, string name = "") => LLVM.BuildGlobalStringPtr(this.Unwrap(), str, name).WrapAs<Value>();
        public Value CreateTrunc(Value val, Type destTy, string name = "") => LLVM.BuildTrunc(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateZExt(Value val, Type destTy, string name = "") => LLVM.BuildZExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateSExt(Value val, Type destTy, string name = "") => LLVM.BuildSExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateZExtOrBitCast(Value val, Type destTy, string name = "") => LLVM.BuildZExtOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateSExtOrBitCast(Value val, Type destTy, string name = "") => LLVM.BuildSExtOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateFPToUI(Value val, Type destTy, string name = "") => LLVM.BuildFPToUI(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateFPToSI(Value val, Type destTy, string name = "") => LLVM.BuildFPToSI(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateUIToFP(Value val, Type destTy, string name = "") => LLVM.BuildUIToFP(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateSIToFP(Value val, Type destTy, string name = "") => LLVM.BuildSIToFP(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateFPTrunc(Value val, Type destTy, string name = "") => LLVM.BuildFPTrunc(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateFPExt(Value val, Type destTy, string name = "") => LLVM.BuildFPExt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreatePtrToInt(Value val, Type destTy, string name = "") => LLVM.BuildPtrToInt(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateIntToPtr(Value val, Type destTy, string name = "") => LLVM.BuildIntToPtr(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateBitCast(Value val, Type destTy, string name = "") => LLVM.BuildBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateAddrSpaceCast(Value val, Type destTy, string name = "") => LLVM.BuildAddrSpaceCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateTruncOrBitCast(Value val, Type destTy, string name = "") => LLVM.BuildTruncOrBitCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateCast(Opcode op, Value val, Type destTy, string name = "") => LLVM.BuildCast(this.Unwrap(), op.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreatePointerCast(Value val, Type destTy, string name = "") => LLVM.BuildPointerCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateIntCast(Value val, Type destTy, string name = "") => LLVM.BuildIntCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateFPCast(Value val, Type destTy, string name = "") => LLVM.BuildFPCast(this.Unwrap(), val.Unwrap(), destTy.Unwrap(), name).WrapAs<Value>();
        public Value CreateICmp(IntPredicate op, Value lhs, Value rhs, string name = "") => LLVM.BuildICmp(this.Unwrap(), op.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateICmpEQ(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.EQ, lhs, rhs, name);
        public Value CreateICmpNE(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.NE, lhs, rhs, name);
        public Value CreateICmpUGT(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.UGT, lhs, rhs, name);
        public Value CreateICmpULT(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.ULT, lhs, rhs, name);
        public Value CreateICmpULE(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.ULE, lhs, rhs, name);
        public Value CreateICmpSGT(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.SGT, lhs, rhs, name);
        public Value CreateICmpSGE(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.SGE, lhs, rhs, name);
        public Value CreateICmpSLT(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.SLT, lhs, rhs, name);
        public Value CreateICmpSLE(Value lhs, Value rhs, string name = "") => this.CreateICmp(IntPredicate.SLE, lhs, rhs, name);
        public Value CreateFCmp(RealPredicate op, Value lhs, Value rhs, string name = "") => LLVM.BuildFCmp(this.Unwrap(), op.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public Value CreateFCmpOEQ(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.OEQ, lhs, rhs, name);
        public Value CreateFCmpOGT(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.OGT, lhs, rhs, name);
        public Value CreateFCmpOGE(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.OGE, lhs, rhs, name);
        public Value CreateFCmpOLT(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.OLT, lhs, rhs, name);
        public Value CreateFCmpOLE(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.OLE, lhs, rhs, name);
        public Value CreateFCmpONE(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.ONE, lhs, rhs, name);
        public Value CreateFCmpORD(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.ORD, lhs, rhs, name);
        public Value CreateFCmpUNO(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.UNO, lhs, rhs, name);
        public Value CreateFCmpUEQ(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.UEQ, lhs, rhs, name);
        public Value CreateFCmpUGT(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.UGT, lhs, rhs, name);
        public Value CreateFCmpUGE(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.UGE, lhs, rhs, name);
        public Value CreateFCmpULT(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.ULT, lhs, rhs, name);
        public Value CreateFCmpUNE(Value lhs, Value rhs, string name = "") => this.CreateFCmp(RealPredicate.UNE, lhs, rhs, name);
        public PHINode CreatePhi(Type ty, string name = "") => LLVM.BuildPhi(this.Unwrap(), ty.Unwrap(), name).WrapAs<PHINode>();
        public CallInst CreateCall(Value fn, Value[] args, string name) => LLVM.BuildCall(this.Unwrap(), fn.Unwrap(), args.Unwrap(), name).WrapAs<CallInst>();
        public CallInst CreateCall(Value fn, string name, params Value[] args) => this.CreateCall(fn, args, name);
        public CallInst CreateCall(Value fn, params Value[] args) => this.CreateCall(fn, args, string.Empty);
        public Value CreateSelect(Value @If, Value then, Value @Else, string name = "") => LLVM.BuildSelect(this.Unwrap(), If.Unwrap(), then.Unwrap(), Else.Unwrap(), name).WrapAs<Value>();
        public VAArgInst CreateVAArg(Value list, Type ty, string name = "") => LLVM.BuildVAArg(this.Unwrap(), list.Unwrap(), ty.Unwrap(), name).WrapAs<VAArgInst>();
        public Value CreateExtractElement(Value vecVal, Value index, string name = "") => LLVM.BuildExtractElement(this.Unwrap(), vecVal.Unwrap(), index.Unwrap(), name).WrapAs<Value>();
        public Value CreateInsertElement(Value vecVal, Value eltVal, Value index, string name = "") => LLVM.BuildInsertElement(this.Unwrap(), vecVal.Unwrap(), eltVal.Unwrap(), index.Unwrap(), name).WrapAs<Value>();
        public Value CreateShuffleVector(Value v1, Value v2, Value mask, string name = "") => LLVM.BuildShuffleVector(this.Unwrap(), v1.Unwrap(), v2.Unwrap(), mask.Unwrap(), name).WrapAs<Value>();
        public Value CreateExtractValue(Value aggVal, uint index, string name = "") => LLVM.BuildExtractValue(this.Unwrap(), aggVal.Unwrap(), index, name).WrapAs<Value>();
        public Value CreateInsertValue(Value aggVal, Value eltVal, uint index, string name = "") => LLVM.BuildInsertValue(this.Unwrap(), aggVal.Unwrap(), eltVal.Unwrap(), index, name).WrapAs<Value>();
        public Value CreateIsNull(Value val, string name = "") => LLVM.BuildIsNull(this.Unwrap(), val.Unwrap(), name).WrapAs<Value>();
        public Value CreateIsNotNull(Value val, string name = "") => LLVM.BuildIsNotNull(this.Unwrap(), val.Unwrap(), name).WrapAs<Value>();
        public Value CreatePtrDiff(Value lhs, Value rhs, string name = "") => LLVM.BuildPtrDiff(this.Unwrap(), lhs.Unwrap(), rhs.Unwrap(), name).WrapAs<Value>();
        public FenceInst CreateFence(AtomicOrdering ordering, bool singleThread, string name = "") => LLVM.BuildFence(this.Unwrap(), ordering.Unwrap(), singleThread, name).WrapAs<FenceInst>();
        public AtomicRMWInst CreateAtomicRMW(AtomicRMWBinOp op, Value ptr, Value val, AtomicOrdering ordering, bool singleThread) => LLVM.BuildAtomicRMW(this.Unwrap(), op.Unwrap(), ptr.Unwrap(), val.Unwrap(), ordering.Unwrap(), singleThread).WrapAs<AtomicRMWInst>();

        public bool Equals(IRBuilder other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public override bool Equals(object obj) => this.Equals(obj as IRBuilder);
        public static bool operator ==(IRBuilder op1, IRBuilder op2) => ReferenceEquals(op1, null) ? ReferenceEquals(op2, null) : op1.Equals(op2);
        public static bool operator !=(IRBuilder op1, IRBuilder op2) => !(op1 == op2);
        public override int GetHashCode() => this._instance.GetHashCode();
    }
}