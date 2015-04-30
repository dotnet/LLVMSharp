namespace LLVMSharp
{
    public class Instruction : Value
    {
        internal Instruction(LLVMValueRef value)
            : base(value)
        {
        }
    }
}