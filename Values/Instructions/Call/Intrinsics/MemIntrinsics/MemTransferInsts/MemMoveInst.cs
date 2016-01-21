namespace LLVMSharp
{
    public sealed class MemMoveInst : MemTransferInst
    {
        internal MemMoveInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}