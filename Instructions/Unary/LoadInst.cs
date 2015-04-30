namespace LLVMSharp
{
    public sealed class LoadInst : UnaryInstruction
    {
        internal LoadInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}