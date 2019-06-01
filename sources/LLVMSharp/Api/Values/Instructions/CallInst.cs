namespace LLVMSharp.API.Values.Instructions
{
    public class CallInst : Instruction
    {
        internal CallInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool TailCall
        {
            set => LLVM.SetTailCall(this.Unwrap(), new LLVMBool(value));
            get => LLVM.IsTailCall(this.Unwrap());
        }

        public CallingConv CallingConvention
        {
            get => (CallingConv)LLVM.GetInstructionCallConv(this.Unwrap());
            set => LLVM.SetInstructionCallConv(this.Unwrap(), (uint)value);
        }
    }
}