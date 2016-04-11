namespace LLVMSharp.Api.Values.Instructions.Unary
{
    public sealed class AllocaInst : UnaryInstruction
    {
        internal AllocaInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}