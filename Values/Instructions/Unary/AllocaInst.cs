namespace LLVMSharp
{
    public sealed class AllocaInst : UnaryInstruction
    {
        internal AllocaInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}