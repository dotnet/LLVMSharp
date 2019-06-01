namespace LLVMSharp.API.Values.Constants
{
    using Utilities;
    using Type = LLVMSharp.API.Type;

    public sealed class ConstantExpr : Constant
    {
        public static ConstantExpr GetAlignOf(Type type) => LLVM.AlignOf(type.MustBeSized().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSizeOf(Type type) => LLVM.SizeOf(type.MustBeSized().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNull(Type type) => LLVM.ConstNull(type.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetAllOnes(Type type) => LLVM.ConstAllOnes(type.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNeg(Constant value) => LLVM.ConstNeg(value.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNSWNeg(Constant value) => LLVM.ConstNSWNeg(value.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNUWNeg(Constant value) => LLVM.ConstNUWNeg(value.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFNeg(Constant value) => LLVM.ConstFNeg(value.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNot(Constant value) => LLVM.ConstNot(value.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetAdd(Constant lhs, Constant rhs) => LLVM.ConstAdd(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNSWAdd(Constant lhs, Constant rhs) => LLVM.ConstNSWAdd(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNUWAdd(Constant lhs, Constant rhs) => LLVM.ConstNUWAdd(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFAdd(Constant lhs, Constant rhs) => LLVM.ConstFAdd(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSub(Constant lhs, Constant rhs) => LLVM.ConstSub(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNSWSub(Constant lhs, Constant rhs) => LLVM.ConstNSWSub(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNUWSub(Constant lhs, Constant rhs) => LLVM.ConstNUWSub(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFSub(Constant lhs, Constant rhs) => LLVM.ConstFSub(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetMul(Constant lhs, Constant rhs) => LLVM.ConstMul(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNSWMul(Constant lhs, Constant rhs) => LLVM.ConstNSWMul(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetNUWMul(Constant lhs, Constant rhs) => LLVM.ConstNUWMul(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFMul(Constant lhs, Constant rhs) => LLVM.ConstFMul(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetUDiv(Constant lhs, Constant rhs) => LLVM.ConstUDiv(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSDiv(Constant lhs, Constant rhs) => LLVM.ConstSDiv(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetExactSDiv(Constant lhs, Constant rhs) => LLVM.ConstExactSDiv(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFDiv(Constant lhs, Constant rhs) => LLVM.ConstFDiv(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetURem(Constant lhs, Constant rhs) => LLVM.ConstURem(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSRem(Constant lhs, Constant rhs) => LLVM.ConstSRem(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFRem(Constant lhs, Constant rhs) => LLVM.ConstFRem(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetAnd(Constant lhs, Constant rhs) => LLVM.ConstAnd(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetOr(Constant lhs, Constant rhs) => LLVM.ConstOr(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetXor(Constant lhs, Constant rhs) => LLVM.ConstXor(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetICmp(LLVMIntPredicate predicate, Constant lhs, Constant rhs) => LLVM.ConstICmp(predicate, lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFCmp(LLVMRealPredicate predicate, Constant lhs, Constant rhs) => LLVM.ConstFCmp(predicate, lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetShl(Constant lhs, Constant rhs) => LLVM.ConstShl(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetLShr(Constant lhs, Constant rhs) => LLVM.ConstLShr(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetAShr(Constant lhs, Constant rhs) => LLVM.ConstAShr(lhs.Unwrap(), rhs.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetGEP(Constant constantVal, Constant[] constantIndices) => LLVM.ConstGEP(constantVal.Unwrap(), constantIndices.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetInBoundsGEP(Constant constantVal, Constant[] constantIndices) => LLVM.ConstInBoundsGEP(constantVal.Unwrap(), constantIndices.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetTrunc(Constant constantVal, Type toType) => LLVM.ConstTrunc(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSExt(Constant constantVal, Type toType) => LLVM.ConstSExt(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetZExt(Constant constantVal, Type toType) => LLVM.ConstZExt(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFPTrunc(Constant constantVal, Type toType) => LLVM.ConstFPTrunc(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFPExt(Constant constantVal, Type toType) => LLVM.ConstFPExt(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetUIToFP(Constant constantVal, Type toType) => LLVM.ConstUIToFP(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSIToFP(Constant constantVal, Type toType) => LLVM.ConstSIToFP(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFPToUI(Constant constantVal, Type toType) => LLVM.ConstFPToUI(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFPToSI(Constant constantVal, Type toType) => LLVM.ConstFPToSI(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetPtrToInt(Constant constantVal, Type toType) => LLVM.ConstPtrToInt(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetIntToPtr(Constant constantVal, Type toType) => LLVM.ConstIntToPtr(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetBitCast(Constant constantVal, Type toType) => LLVM.ConstBitCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetAddrSpaceCast(Constant constantVal, Type toType) => LLVM.ConstAddrSpaceCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetZExtOrBitCast(Constant constantVal, Type toType) => LLVM.ConstZExtOrBitCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSExtOrBitCast(Constant constantVal, Type toType) => LLVM.ConstSExtOrBitCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetTruncOrBitCast(Constant constantVal, Type toType) => LLVM.ConstTruncOrBitCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetPointerCast(Constant constantVal, Type toType) => LLVM.ConstPointerCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetIntCast(Constant constantVal, Type toType, bool isSigned) => LLVM.ConstIntCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap(), isSigned).WrapAs<ConstantExpr>();
        public static ConstantExpr GetFPCast(Constant constantVal, Type toType) => LLVM.ConstFPCast(constantVal.Unwrap(), toType.MustHaveConstants().Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetSelect(Constant constantCondition, Constant constantIfTrue, Constant constantIfFalse) => LLVM.ConstSelect(constantCondition.Unwrap(), constantIfTrue.Unwrap(), constantIfFalse.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetExtractElement(Constant vectorConstant, Constant indexConstant) => LLVM.ConstExtractElement(vectorConstant.Unwrap(), indexConstant.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetInsertElement(Constant vectorConstant, Constant elementValueConstant, Constant indexConstant) => LLVM.ConstInsertElement(vectorConstant.Unwrap(), elementValueConstant.Unwrap(), indexConstant.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetShuffleVector(Constant vectorAConstant, Constant vectorBConstant, Constant maskConstant) => LLVM.ConstShuffleVector(vectorAConstant.Unwrap(), vectorBConstant.Unwrap(), maskConstant.Unwrap()).WrapAs<ConstantExpr>();
        public static ConstantExpr GetExtractValue(Constant aggConstant, out uint idxList, uint numIdx) => LLVM.ConstExtractValue(aggConstant.Unwrap(), out idxList, numIdx).WrapAs<ConstantExpr>();
        public static ConstantExpr GetInsertValue(Constant aggConstant, Constant elementValueConstant, out uint idxList, uint numIdx) => LLVM.ConstInsertValue(aggConstant.Unwrap(), elementValueConstant.Unwrap(), out idxList, numIdx).WrapAs<ConstantExpr>();
        public static ConstantExpr GetInlineAsm(Type ty, string asmString, string constraints, bool hasSideEffects, bool isAlignStack) => LLVM.ConstInlineAsm(ty.MustHaveConstants().Unwrap(), asmString, constraints, hasSideEffects, isAlignStack).WrapAs<ConstantExpr>();

        internal ConstantExpr(LLVMValueRef instance)
            : base(instance)
        {
        }

        public Opcode ConstOpcode => LLVM.GetConstOpcode(this.Unwrap()).Wrap();
    }
}