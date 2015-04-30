namespace LLVMSharp
{
    public sealed class DbgValueInst : DbgInfoIntrinsic
    {
        internal DbgValueInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}