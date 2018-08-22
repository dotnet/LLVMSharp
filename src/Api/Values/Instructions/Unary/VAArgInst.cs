namespace LLVMSharp.Api.Values.Instructions.Unary
{
    public sealed class VAArgInst : UnaryInstruction
    {
        internal VAArgInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}