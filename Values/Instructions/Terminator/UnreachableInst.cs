namespace LLVMSharp
{
    public sealed class UnreachableInst : Instruction
    {
        internal UnreachableInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}