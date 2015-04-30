namespace LLVMSharp
{
    public sealed class FCmpInst : CmpInst
    {
        internal FCmpInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}