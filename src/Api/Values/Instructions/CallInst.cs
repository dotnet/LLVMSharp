namespace LLVMSharp.Api.Values.Instructions
{
    using Utilities;

    public class CallInst : Instruction
    {
        internal CallInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool TailCall
        {
            set { LLVM.SetTailCall(this.Unwrap(), new LLVMBool(value)); }
            get { return LLVM.IsTailCall(this.Unwrap()); }
        }
    }
}