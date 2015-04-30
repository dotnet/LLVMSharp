namespace LLVMSharp
{
    public sealed class IndirectBrInst : TerminatorInst
    {
        internal IndirectBrInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}