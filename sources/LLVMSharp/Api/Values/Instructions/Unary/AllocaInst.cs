namespace LLVMSharp.API.Values.Instructions.Unary
{
    public sealed class AllocaInst : UnaryInstruction
    {
        internal AllocaInst(LLVMValueRef instance)
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