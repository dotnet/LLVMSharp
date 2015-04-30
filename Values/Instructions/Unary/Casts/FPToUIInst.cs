namespace LLVMSharp
{
    public sealed class FPToUIInst : CastInst
    {
        internal FPToUIInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}