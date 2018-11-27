namespace LLVMSharp.API.Values.Instructions
{
    public sealed class LandingPadInst : Instruction
    {
        internal LandingPadInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool IsCleanup
        {
            get => LLVM.IsCleanup(this.Unwrap());
            set => LLVM.SetCleanup(this.Unwrap(), value);
        }

        public void AddClause(Value clauseVal) => LLVM.AddClause(this.Unwrap(), clauseVal.Unwrap());
    }
}