namespace LLVMSharp
{
    public sealed class FNeg : BinaryOperator
    {
        internal FNeg(LLVMValueRef value)
            : base(value)
        {
        }
    }
}