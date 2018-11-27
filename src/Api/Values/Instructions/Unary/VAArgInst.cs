namespace LLVMSharp.API.Values.Instructions.Unary
{
    public sealed class VAArgInst : UnaryInstruction
    {
        internal VAArgInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}