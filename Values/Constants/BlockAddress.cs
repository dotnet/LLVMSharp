namespace LLVMSharp
{
    public sealed class BlockAddress : Constant
    {
        internal BlockAddress(LLVMValueRef value)
            : base(value)
        {
        }
    }
}