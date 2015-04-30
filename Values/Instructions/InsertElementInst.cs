namespace LLVMSharp
{
    public sealed class InsertElementInst : Instruction
    {
        internal InsertElementInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}