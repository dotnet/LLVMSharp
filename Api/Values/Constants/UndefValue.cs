namespace LLVMSharp.Api.Values.Constants
{
    public sealed class UndefValue : Constant
    {
        internal UndefValue(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}