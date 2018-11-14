namespace LLVMSharp.API.Values.Instructions.Cmp
{
    public sealed class ICmpInst : CmpInst
    {
        internal ICmpInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public IntPredicate ICmpPredicate => LLVM.GetICmpPredicate(this.Unwrap()).Wrap();
    }
}