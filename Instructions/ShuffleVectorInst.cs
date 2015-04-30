namespace LLVMSharp
{
    public sealed class ShuffleVectorInst : Instruction
    {
        internal ShuffleVectorInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}