namespace LLVMSharp
{
    public sealed class MemCpyInst : MemTransferInst
    {
        internal MemCpyInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}