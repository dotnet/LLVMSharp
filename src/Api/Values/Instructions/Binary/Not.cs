namespace LLVMSharp.Api.Values.Instructions.Binary
{
    public sealed class Not : BinaryOperator
    {
        internal Not(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}