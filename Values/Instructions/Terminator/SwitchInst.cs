namespace LLVMSharp
{
    public sealed class SwitchInst : TerminatorInst
    {
        internal SwitchInst(LLVMValueRef instance)
            : base(instance)
        {
        }

        public BasicBlock GetSwitchDefaultDest(Value switchInstr)
        {
            return LLVM.GetSwitchDefaultDest(this.Unwrap()).Wrap();
        }
    }
}