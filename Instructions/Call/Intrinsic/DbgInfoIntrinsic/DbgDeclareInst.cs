namespace LLVMSharp
{
    public sealed class DbgDeclareInst : DbgInfoIntrinsic
    {
        internal DbgDeclareInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}