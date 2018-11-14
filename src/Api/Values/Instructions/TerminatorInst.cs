namespace LLVMSharp.API.Values.Instructions
{
    public abstract class TerminatorInst : Instruction
    {
        protected TerminatorInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public uint NumSuccessors => LLVM.GetNumSuccessors(this.Unwrap());
        public BasicBlock GetSuccessor(uint idx) => LLVM.GetSuccessor(this.Unwrap(), idx).Wrap();
        public void SetSuccessor(uint idx, BasicBlock b) => LLVM.SetSuccessor(this.Unwrap(), idx, b.Unwrap<LLVMBasicBlockRef>());
    }
}