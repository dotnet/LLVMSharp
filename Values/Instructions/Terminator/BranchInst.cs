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

        public Value Condition
        {
            get
            {
                return LLVM.GetCondition(this.InnerValue).ToValue();
            }
            set
            {
                LLVM.SetCondition(this.InnerValue, value.InnerValue);
            }
        }

        public void SetCondition(Value condition)
        {
            LLVM.SetCondition(this.InnerValue, condition.InnerValue);
        }
    }
}