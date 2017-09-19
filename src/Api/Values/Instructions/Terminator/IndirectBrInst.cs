namespace LLVMSharp.Api.Values.Instructions.Terminator
{
    public sealed class IndirectBrInst : TerminatorInst
    {
        internal IndirectBrInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}