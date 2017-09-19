namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantVector : Constant
    {
        internal ConstantVector(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}