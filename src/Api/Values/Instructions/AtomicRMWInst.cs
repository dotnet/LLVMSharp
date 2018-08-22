namespace LLVMSharp.Api.Values.Instructions
{
    public sealed class AtomicRMWInst : Instruction
    {
        internal AtomicRMWInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}