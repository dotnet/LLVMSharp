namespace LLVMSharp
{
    public sealed class FenceInst : Instruction
    {
        internal FenceInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}