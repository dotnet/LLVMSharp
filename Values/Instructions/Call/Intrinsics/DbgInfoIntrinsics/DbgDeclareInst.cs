namespace LLVMSharp
{
    public sealed class DbgDeclareInst : DbgInfoIntrinsic
    {
        internal DbgDeclareInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}