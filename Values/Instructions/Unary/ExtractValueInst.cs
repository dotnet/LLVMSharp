namespace LLVMSharp
{
    public sealed class ExtractValueInst : UnaryInstruction
    {
        internal ExtractValueInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}