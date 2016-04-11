namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantPointerNull : Constant
    {
        internal ConstantPointerNull(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}