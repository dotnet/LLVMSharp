namespace LLVMSharp
{
    public sealed class BranchInst : TerminatorInst
    {
        internal BranchInst(LLVMValueRef value)
            : base(value)
        {
        }

        public bool IsConditional
        {
            get { return LLVM.IsConditional(this.InnerValue); }
        }

        public bool IsUnconditional
        {
            get { return !this.IsConditional; }
        }
    }
}