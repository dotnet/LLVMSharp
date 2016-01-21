namespace LLVMSharp
{
    public sealed class LoadInst : UnaryInstruction
    {
        internal LoadInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}