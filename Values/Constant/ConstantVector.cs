namespace LLVMSharp
{
    public sealed class ConstantVector : Constant
    {
        internal ConstantVector(LLVMValueRef value)
            : base(value)
        {
        }
    }
}