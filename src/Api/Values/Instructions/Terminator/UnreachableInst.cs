namespace LLVMSharp.Api.Values.Instructions.Terminator
{
    public sealed class UnreachableInst : Instruction
    {
        internal UnreachableInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}