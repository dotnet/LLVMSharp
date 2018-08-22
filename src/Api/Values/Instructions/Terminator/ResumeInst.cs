namespace LLVMSharp.Api.Values.Instructions.Terminator
{
    public sealed class ResumeInst : Instruction
    {
        internal ResumeInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}