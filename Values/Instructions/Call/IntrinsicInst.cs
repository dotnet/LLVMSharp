namespace LLVMSharp
{
    public class IntrinsicInst : CallInst
    {
        internal IntrinsicInst(LLVMValueRef value)
            : base(value)
        {
        }
    }
}