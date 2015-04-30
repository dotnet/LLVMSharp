namespace LLVMSharp
{
    public sealed class MemMoveInst : MemTransferInst
    {
        internal MemMoveInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}