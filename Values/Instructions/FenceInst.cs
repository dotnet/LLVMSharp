namespace LLVMSharp
{
    public sealed class FenceInst : Instruction
    {
        internal FenceInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}