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
            get { return LLVM.GetNumSuccessors(this.InnerValue); }
        }

        public BasicBlock GetSuccessor(uint idx)
        {
            return new BasicBlock(LLVM.GetSuccessor(this.InnerValue, idx));
        }

        public void SetSuccessor(uint idx, BasicBlock b)
        {
            LLVM.SetSuccessor(this.InnerValue, idx, LLVM.ValueAsBasicBlock(b.InnerValue));
        }
    }
}