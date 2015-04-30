namespace LLVMSharp
{
    public abstract class Instruction : Value
    {
        protected Instruction(LLVMValueRef value) : base(value)
        {
        }
    }
}