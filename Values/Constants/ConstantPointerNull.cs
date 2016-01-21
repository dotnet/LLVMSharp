namespace LLVMSharp
{
    public sealed class ConstantPointerNull : Constant
    {
        internal ConstantPointerNull(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}