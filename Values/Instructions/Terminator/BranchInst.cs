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
            get { return LLVM.IsConditional(this.value); }
        }

        public bool IsUnconditional
        {
            get { return !this.IsConditional; }
        }

        public Value Condition
        {
            get
            {
                return LLVM.GetCondition(this.value);
            }
            set
            {
                LLVM.SetCondition(this.value, value.InnerValue);
            }
        }

        public void SetCondition(Value condition)
        {
            LLVM.SetCondition(this.value, condition.InnerValue);
        }
    }
}