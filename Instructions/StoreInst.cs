namespace LLVMSharp
{
    public sealed class StoreInst : Instruction
    {
        internal StoreInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}