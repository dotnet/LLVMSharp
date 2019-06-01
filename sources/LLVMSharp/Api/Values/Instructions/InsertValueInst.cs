namespace LLVMSharp.API.Values.Instructions
{
    public sealed class InsertValueInst : Instruction
    {
        internal InsertValueInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}