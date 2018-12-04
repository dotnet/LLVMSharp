namespace LLVMSharp.API.Values.Instructions
{
    public sealed class StoreInst : Instruction
    {
        internal StoreInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public uint Alignment
        {
            get => LLVM.GetAlignment(this.Unwrap());
            set => LLVM.SetAlignment(this.Unwrap(), value);
        }
    }
}