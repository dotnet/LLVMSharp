namespace LLVMSharp
{
    public sealed class IntToPtrInst : CastInst
    {
        internal IntToPtrInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}