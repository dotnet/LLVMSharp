namespace LLVMSharp
{
    public sealed class ExtractValueInst : UnaryInstruction
    {
        internal ExtractValueInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}