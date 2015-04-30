namespace LLVMSharp
{
    public sealed class ConstantArray : Constant
    {
        internal ConstantArray(LLVMValueRef value)
            : base(value)
        {
        }
    }
}