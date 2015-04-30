namespace LLVMSharp
{
    public sealed class ConstantDataArray : ConstantDataSequential
    {
        internal ConstantDataArray(LLVMValueRef v)
            : base(v)
        {
        }
    }
}