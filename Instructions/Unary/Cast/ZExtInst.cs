namespace LLVMSharp
{
    public sealed class ZExtInst : CastInst
    {
        internal ZExtInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}