namespace LLVMSharp
{
    public sealed class TruncInst : CastInst
    {
        internal TruncInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}