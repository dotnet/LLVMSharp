namespace LLVMSharp.API.Values.Constants
{
    using LLVMSharp.API.Types;
    using global::System;
    using Type = LLVMSharp.API.Type;

    public sealed class ConstantFP : Constant
    {
        public static ConstantFP Get(FPType type, double value) => LLVM.ConstReal(type.Unwrap(), value).WrapAs<ConstantFP>();
        public static ConstantFP Get(Type type, string text) => LLVM.ConstRealOfString(type.Unwrap(), text).WrapAs<ConstantFP>();

        internal ConstantFP(LLVMValueRef instance)
            : base(instance)
        {
        }

        public Tuple<double, bool> DoubleValue => new Tuple<double, bool>(LLVM.ConstRealGetDouble(this.Unwrap(), out LLVMBool li), li);
    }
}