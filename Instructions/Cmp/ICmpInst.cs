namespace LLVMSharp
{
    public sealed class ICmpInst : CmpInst
    {
        internal ICmpInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}