namespace LLVMSharp
{
    public sealed class ConstantInt : Constant
    {
        internal ConstantInt(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}