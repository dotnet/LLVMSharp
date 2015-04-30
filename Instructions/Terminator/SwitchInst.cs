namespace LLVMSharp
{
    public sealed class SwitchInst : TerminatorInst
    {
        internal SwitchInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}