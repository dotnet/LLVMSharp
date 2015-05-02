namespace LLVMSharp
{
    public sealed class Neg : BinaryOperator
    {
        internal Neg(LLVMValueRef value)
            : base(value)
        {
        }
    }
}