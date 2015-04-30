namespace LLVMSharp
{
    public class CastInst : UnaryInstruction
    {
        internal CastInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}