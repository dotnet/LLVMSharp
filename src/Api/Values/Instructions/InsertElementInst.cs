namespace LLVMSharp.API.Values.Instructions
{
    public sealed class InsertElementInst : Instruction
    {
        internal InsertElementInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}