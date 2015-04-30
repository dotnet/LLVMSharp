namespace LLVMSharp
{
    public class MemTransferInst : MemIntrinsic
    {
        internal MemTransferInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}