namespace LLVMSharp.Api.Values.Instructions.Unary
{
    public sealed class ExtractValueInst : UnaryInstruction
    {
        internal ExtractValueInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}