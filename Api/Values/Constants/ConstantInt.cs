namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantInt : Constant
    {
        internal ConstantInt(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}