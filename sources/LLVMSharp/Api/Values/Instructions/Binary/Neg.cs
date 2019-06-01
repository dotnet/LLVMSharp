namespace LLVMSharp.API.Values.Instructions.Binary
{
    public sealed class Neg : BinaryOperator
    {
        internal Neg(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}