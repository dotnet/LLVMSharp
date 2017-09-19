namespace LLVMSharp.Api.Values.Instructions
{
    public sealed class StoreInst : Instruction
    {
        internal StoreInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}