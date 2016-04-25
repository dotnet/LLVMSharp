namespace LLVMSharp.Api.Values.Instructions
{
    public sealed class FenceInst : Instruction
    {
        internal FenceInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}