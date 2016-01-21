namespace LLVMSharp
{
    public sealed class UnreachableInst : Instruction
    {
        internal UnreachableInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}