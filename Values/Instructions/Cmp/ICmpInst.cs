namespace LLVMSharp
{
    public sealed class ICmpInst : CmpInst
    {
        internal ICmpInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}