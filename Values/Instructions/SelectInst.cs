namespace LLVMSharp
{
    public sealed class SelectInst : Instruction
    {
        internal SelectInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}