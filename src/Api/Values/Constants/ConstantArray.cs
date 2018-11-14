namespace LLVMSharp.API.Values.Constants
{
    public sealed class ConstantArray : Constant
    {
        public static ConstantArray Get(Type type, Constant[] values) => LLVM.ConstArray(type.Unwrap(), values.Unwrap()).WrapAs<ConstantArray>();

        internal ConstantArray(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}