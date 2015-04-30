namespace LLVMSharp
{
    public sealed class IntToPtrInst : CastInst
    {
        internal IntToPtrInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}