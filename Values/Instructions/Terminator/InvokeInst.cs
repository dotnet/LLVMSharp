namespace LLVMSharp
{
    public sealed class InvokeInst : Instruction
    {
        internal InvokeInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}