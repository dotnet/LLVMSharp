namespace LLVMSharp
{
    public sealed class ConstantPointerNull : Constant
    {
        internal ConstantPointerNull(LLVMValueRef value)
            : base(value)
        {
        }
    }
}