namespace LLVMSharp
{
    public sealed class MemSetInst : MemIntrinsic
    {
        internal MemSetInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}