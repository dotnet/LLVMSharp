namespace LLVMSharp
{
    public sealed class AddrSpaceCastInst : CastInst
    {
        internal AddrSpaceCastInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}