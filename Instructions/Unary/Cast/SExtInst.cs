namespace LLVMSharp
{
    public sealed class SExtInst : CastInst
    {
        internal SExtInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}