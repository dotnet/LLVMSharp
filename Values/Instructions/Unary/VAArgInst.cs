namespace LLVMSharp
{
    public sealed class VAArgInst : UnaryInstruction
    {
        internal VAArgInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}