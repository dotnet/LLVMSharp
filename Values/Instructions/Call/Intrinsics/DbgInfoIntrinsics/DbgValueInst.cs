namespace LLVMSharp
{
    public sealed class DbgValueInst : DbgInfoIntrinsic
    {
        internal DbgValueInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}