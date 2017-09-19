namespace LLVMSharp.Api.Values.Instructions.Unary
{
    public sealed class LoadInst : UnaryInstruction
    {
        internal LoadInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}