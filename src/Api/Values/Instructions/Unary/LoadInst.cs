namespace LLVMSharp.API.Values.Instructions.Unary
{
    public sealed class LoadInst : UnaryInstruction, IMemoryAccessInstruction
    {
        internal LoadInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool IsVolatile
        {
            get => LLVM.GetVolatile(this.Unwrap());
            set => LLVM.SetVolatile(this.Unwrap(), value);
        }

        public uint Alignment
        {
            get => LLVM.GetAlignment(this.Unwrap());
            set => LLVM.SetAlignment(this.Unwrap(), value);
        }
    }
}