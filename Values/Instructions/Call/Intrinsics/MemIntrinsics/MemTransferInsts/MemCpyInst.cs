namespace LLVMSharp
{
    public sealed class MemCpyInst : MemTransferInst
    {
        internal MemCpyInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}