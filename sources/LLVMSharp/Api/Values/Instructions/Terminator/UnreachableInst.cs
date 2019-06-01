namespace LLVMSharp.API.Values.Instructions.Terminator
{
    public sealed class UnreachableInst : Instruction
    {
        internal UnreachableInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}