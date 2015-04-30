namespace LLVMSharp
{
    public sealed class ConstantDataVector : ConstantDataSequential
    {
        internal ConstantDataVector(LLVMValueRef v)
            : base(v)
        {
        }
    }
}