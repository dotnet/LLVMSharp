namespace LLVMSharp
{
    public sealed class ConstantAggregateZero : Constant
    {
        internal ConstantAggregateZero(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}