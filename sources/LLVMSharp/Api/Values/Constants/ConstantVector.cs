namespace LLVMSharp.API.Values.Constants
{
    public sealed class ConstantVector : Constant
    {
        public static ConstantVector Get(Constant[] scalarValues) => LLVM.ConstVector(scalarValues.Unwrap()).WrapAs<ConstantVector>();

        internal ConstantVector(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}