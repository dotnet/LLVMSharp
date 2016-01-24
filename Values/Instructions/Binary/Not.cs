namespace LLVMSharp
{
    public sealed class Not : BinaryOperator
    {
        internal Not(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}