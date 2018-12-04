namespace LLVMSharp.API.Values.Instructions.Cmp
{
    public sealed class FCmpInst : CmpInst
    {
        internal FCmpInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public RealPredicate FCmpPredicate => LLVM.GetFCmpPredicate(this.Unwrap()).Wrap();
    }
}