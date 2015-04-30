namespace LLVMSharp
{
    public sealed class VAArgInst : UnaryInstruction
    {
        internal VAArgInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}