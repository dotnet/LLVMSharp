namespace LLVMSharp.API.Values.Instructions.Terminator
{
    public sealed class BranchInst : TerminatorInst
    {
        internal BranchInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool IsConditional => LLVM.IsConditional(this.Unwrap());
        public bool IsUnconditional => !this.IsConditional;

        public Value Condition
        {
            get => LLVM.GetCondition(this.Unwrap()).Wrap();
            set => LLVM.SetCondition(this.Unwrap(), value.Unwrap());
        }
    }
}