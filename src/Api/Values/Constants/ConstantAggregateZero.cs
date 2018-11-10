namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantAggregateZero : Constant
    {
        internal ConstantAggregateZero(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}