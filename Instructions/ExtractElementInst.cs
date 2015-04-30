namespace LLVMSharp
{
    public sealed class ExtractElementInst : Instruction
    {
        internal ExtractElementInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}