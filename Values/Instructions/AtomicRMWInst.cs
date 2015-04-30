namespace LLVMSharp
{
    public class AtomicRMWInst : Instruction
    {
        internal AtomicRMWInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}