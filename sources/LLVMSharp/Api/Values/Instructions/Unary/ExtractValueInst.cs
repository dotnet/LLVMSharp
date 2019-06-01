namespace LLVMSharp.API.Values.Instructions.Unary
{
    public sealed class ExtractValueInst : UnaryInstruction
    {
        internal ExtractValueInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}