namespace LLVMSharp
{
    public sealed class ConstantInt : Constant
    {
        internal ConstantInt(LLVMValueRef value)
            : base(value)
        {
        }
    }
}