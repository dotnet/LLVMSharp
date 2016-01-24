namespace LLVMSharp
{
    public sealed class ConstantStruct : Constant
    {
        internal ConstantStruct(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}