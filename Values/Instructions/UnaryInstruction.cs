namespace LLVMSharp
{
    public class UnaryInstruction : Instruction
    {
        internal UnaryInstruction(LLVMValueRef value)
            : base(value)
        {
        }
    }
}