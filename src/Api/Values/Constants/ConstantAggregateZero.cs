namespace LLVMSharp.API.Values.Constants
{
    public sealed class ConstantAggregateZero : Constant
    {
        internal ConstantAggregateZero(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}