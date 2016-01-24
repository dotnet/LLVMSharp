namespace LLVMSharp
{
    public sealed class ReturnInst : TerminatorInst
    {
        internal ReturnInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}