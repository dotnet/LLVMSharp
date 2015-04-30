namespace LLVMSharp
{
    public sealed class MemSetInst : MemIntrinsic
    {
        internal MemSetInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}