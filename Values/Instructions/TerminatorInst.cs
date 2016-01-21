namespace LLVMSharp
{
    public abstract class TerminatorInst : Instruction
    {
        protected TerminatorInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public uint NumSuccessors
        {
            get { return LLVM.GetNumSuccessors(this.Unwrap()); }
        }

        public BasicBlock GetSuccessor(uint idx)
        {
            return LLVM.GetSuccessor(this.Unwrap(), idx).Wrap();
        }

        public void SetSuccessor(uint idx, BasicBlock b)
        {
            LLVM.SetSuccessor(this.Unwrap(), idx, b.Unwrap<LLVMBasicBlockRef>());
        }
    }
}