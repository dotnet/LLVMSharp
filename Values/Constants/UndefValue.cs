namespace LLVMSharp
{
    public sealed class UndefValue : Constant
    {
        internal UndefValue(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}