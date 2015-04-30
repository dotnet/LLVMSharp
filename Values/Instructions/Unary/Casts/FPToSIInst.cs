namespace LLVMSharp
{
    public sealed class FPToSIInst : CastInst
    {
        internal FPToSIInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}