namespace LLVMSharp
{
    public sealed class AllocaInst : UnaryInstruction
    {
        internal AllocaInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}