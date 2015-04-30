namespace LLVMSharp
{
    public sealed class PHINode : Instruction
    {
        internal PHINode(LLVMValueRef value)
            : base(value)
        {
        }
    }
}