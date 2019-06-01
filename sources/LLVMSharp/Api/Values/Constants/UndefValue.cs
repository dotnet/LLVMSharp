namespace LLVMSharp.API.Values.Constants
{
    public sealed class UndefValue : Constant
    {
        public static UndefValue Get(Type type) => LLVM.GetUndef(type.Unwrap()).WrapAs<UndefValue>();

        internal UndefValue(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}