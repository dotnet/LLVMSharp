namespace LLVMSharp.Api.Values.Instructions.Cmp
{
    public sealed class ICmpInst : CmpInst
    {
        internal ICmpInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}