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
            get { return LLVM.GetNumSuccessors(this.ToValueRef()); }
        }

        public BasicBlock GetSuccessor(uint idx)
        {
            return new BasicBlock(LLVM.GetSuccessor(this.ToValueRef(), idx));
        }

        public void SetSuccessor(uint idx, BasicBlock b)
        {
            LLVM.SetSuccessor(this.ToValueRef(), idx, LLVM.ValueAsBasicBlock(b.ToValueRef()));
        }
    }
}