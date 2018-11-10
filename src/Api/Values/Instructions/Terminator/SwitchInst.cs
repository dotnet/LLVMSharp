namespace LLVMSharp.Api.Values.Instructions.Terminator
{
    using LLVMSharp.Api.Values.Constants;

    public sealed class SwitchInst : TerminatorInst
    {
        internal SwitchInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public BasicBlock GetSwitchDefaultDest(Value switchInstr) => LLVM.GetSwitchDefaultDest(this.Unwrap()).Wrap();

        public void AddCase(ConstantInt onVal, BasicBlock dest) => LLVM.AddCase(this.Unwrap(), onVal.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>());
    }
}