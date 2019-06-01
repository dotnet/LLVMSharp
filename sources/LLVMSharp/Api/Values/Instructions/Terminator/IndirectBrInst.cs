namespace LLVMSharp.API.Values.Instructions.Terminator
{
    public sealed class IndirectBrInst : TerminatorInst
    {
        internal IndirectBrInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public void AddDestination(BasicBlock dest) => LLVM.AddDestination(this.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>());
    }
}