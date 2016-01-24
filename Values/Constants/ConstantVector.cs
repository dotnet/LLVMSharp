namespace LLVMSharp
{
    public sealed class ConstantVector : Constant
    {
        internal ConstantVector(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}