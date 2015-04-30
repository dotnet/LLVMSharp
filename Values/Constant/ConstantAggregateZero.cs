namespace LLVMSharp
{
    public sealed class ConstantAggregateZero : Constant
    {
        internal ConstantAggregateZero(LLVMValueRef value)
            : base(value)
        {
        }
    }
}