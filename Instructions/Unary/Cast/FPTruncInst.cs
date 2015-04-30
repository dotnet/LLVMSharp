namespace LLVMSharp
{
    public sealed class FPTruncInst : CastInst
    {
        internal FPTruncInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}