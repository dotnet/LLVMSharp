namespace LLVMSharp
{
    public sealed class ReturnInst : TerminatorInst
    {
        internal ReturnInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}