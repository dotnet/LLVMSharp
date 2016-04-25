namespace LLVMSharp.Api.Values.Instructions.Binary
{
    public sealed class Neg : BinaryOperator
    {
        internal Neg(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}