namespace LLVMSharp.API.Values
{
    using Constants;
    using Constants.ConstantDataSequentials;
    using Constants.GlobalValues;
    using Constants.GlobalValues.GlobalObjects;

    public class Constant : Value
    {
        internal new static Constant Create(LLVMValueRef v)
        {
            if (LLVM.IsABlockAddress(v).ToBool())
            {
                return new BlockAddress(v);
            }

            if (LLVM.IsAConstantAggregateZero(v).ToBool())
            {
                return new ConstantAggregateZero(v);
            }

            if (LLVM.IsAConstantArray(v).ToBool())
            {
                return new ConstantArray(v);
            }

            if (LLVM.IsAConstantDataSequential(v).ToBool())
            {
                if (LLVM.IsAConstantDataArray(v).ToBool())
                {
                    return new ConstantDataArray(v);
                }

                if (LLVM.IsAConstantDataVector(v).ToBool())
                {
                    return new ConstantDataVector(v);
                }

                return new ConstantDataSequential(v);
            }

            if (LLVM.IsAConstantExpr(v).ToBool())
            {
                return new ConstantExpr(v);
            }

            if (LLVM.IsAConstantFP(v).ToBool())
            {
                return new ConstantFP(v);
            }

            if (LLVM.IsAConstantInt(v).ToBool())
            {
                return new ConstantInt(v);
            }

            if (LLVM.IsAConstantPointerNull(v).ToBool())
            {
                return new ConstantPointerNull(v);
            }

            if (LLVM.IsAConstantStruct(v).ToBool())
            {
                return new ConstantStruct(v);
            }

            if (LLVM.IsAConstantVector(v).ToBool())
            {
                return new ConstantVector(v);
            }

            if (LLVM.IsAGlobalValue(v).ToBool())
            {
                if (LLVM.IsAGlobalAlias(v).ToBool())
                {
                    return new GlobalAlias(v);
                }

                if (LLVM.IsAGlobalObject(v).ToBool())
                {
                    if (LLVM.IsAFunction(v).ToBool())
                    {
                        return new Function(v);
                    }

                    if (LLVM.IsAGlobalVariable(v).ToBool())
                    {
                        return new GlobalVariable(v);
                    }

                    return new GlobalObject(v);
                }

                return new GlobalValue(v);
            }

            if (LLVM.IsAUndefValue(v).ToBool())
            {
                return new UndefValue(v);
            }

            return new Constant(v);
        }

        internal Constant(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool IsNull => LLVM.IsNull(this.Unwrap());
    }
}