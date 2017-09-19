namespace LLVMSharp.Api.Values.Instructions
{
    public sealed class AtomicCmpXchgInst : Instruction
    {
        internal AtomicCmpXchgInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}