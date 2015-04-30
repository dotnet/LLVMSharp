namespace LLVMSharp
{
    public sealed class InsertValueInst : Instruction
    {
        internal InsertValueInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}