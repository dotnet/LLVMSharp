namespace LLVMSharp
{
    public sealed class FPExtInst : CastInst
    {
        internal FPExtInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}