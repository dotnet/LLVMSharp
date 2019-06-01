namespace LLVMSharp.API.Values.Instructions.Terminator
{
    public sealed class ReturnInst : TerminatorInst
    {
        internal ReturnInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}