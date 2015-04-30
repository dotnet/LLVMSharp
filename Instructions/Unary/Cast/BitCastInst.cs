namespace LLVMSharp
{
    public sealed class BitCastInst : CastInst
    {
        internal BitCastInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}