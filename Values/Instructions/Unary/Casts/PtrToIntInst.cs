namespace LLVMSharp
{
    public sealed class PtrToIntInst : CastInst
    {
        internal PtrToIntInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}