namespace LLVMSharp
{
    public sealed class TruncInst : CastInst
    {
        internal TruncInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}