namespace LLVMSharp.API.Values.Constants
{
    public sealed class ConstantPointerNull : Constant
    {
        public static ConstantPointerNull Get(Type type) => LLVM.ConstPointerNull(type.Unwrap()).WrapAs<ConstantPointerNull>();

        internal ConstantPointerNull(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}