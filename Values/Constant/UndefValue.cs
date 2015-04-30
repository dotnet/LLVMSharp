namespace LLVMSharp
{
    public sealed class UndefValue : Constant
    {
        internal UndefValue(LLVMValueRef value)
            : base(value)
        {
        }
    }
}