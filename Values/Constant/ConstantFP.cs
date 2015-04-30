namespace LLVMSharp
{
    public sealed class ConstantFP : Constant
    {
        internal ConstantFP(LLVMValueRef value)
            : base(value)
        {
        }
    }
}