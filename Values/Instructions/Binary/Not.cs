namespace LLVMSharp
{
    public sealed class Not : BinaryOperator
    {
        internal Not(LLVMValueRef value)
            : base(value)
        {
        }
    }
}