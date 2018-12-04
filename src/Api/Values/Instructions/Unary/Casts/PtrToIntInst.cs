namespace LLVMSharp.API.Values.Instructions.Unary.Casts
{
    public sealed class PtrToIntInst : CastInst
    {
        internal PtrToIntInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}