namespace LLVMSharp
{
    public sealed class PtrToIntInst : CastInst
    {
        internal PtrToIntInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}