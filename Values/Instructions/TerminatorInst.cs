namespace LLVMSharp
{
    public abstract class TerminatorInst : Instruction
    {
        protected TerminatorInst(LLVMValueRef value)
            : base(value)
        {
        }

        public uint NumSuccessors
        {
            get { return LLVM.GetNumSuccessors(this.value); }
        }

        public BasicBlock GetSuccessor(uint idx)
        {
            return new BasicBlock(LLVM.GetSuccessor(this.value, idx));
        }

        public void SetSuccessor(uint idx, BasicBlock b)
        {
            LLVM.SetSuccessor(this.value, idx, LLVM.ValueAsBasicBlock(b.InnerValue));
        }
    }
}