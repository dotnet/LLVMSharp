namespace LLVMSharp
{
    public sealed class ConstantStruct : Constant
    {
        internal ConstantStruct(LLVMValueRef value)
            : base(value)
        {
        }
    }
}