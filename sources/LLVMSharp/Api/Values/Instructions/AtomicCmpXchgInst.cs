namespace LLVMSharp.API.Values.Instructions
{
    public sealed class AtomicCmpXchgInst : Instruction
    {
        internal AtomicCmpXchgInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public AtomicOrdering SuccessOrdering
        {
            get => LLVM.GetCmpXchgSuccessOrdering(this.Unwrap()).Wrap();
            set => LLVM.SetCmpXchgSuccessOrdering(this.Unwrap(), value.Unwrap());
        }
        public AtomicOrdering FailureOrdering
        {
            get => LLVM.GetCmpXchgFailureOrdering(this.Unwrap()).Wrap();
            set => LLVM.SetCmpXchgFailureOrdering(this.Unwrap(), value.Unwrap());
        }
    }
}