namespace LLVMSharp
{
    public class IntrinsicInst : CallInst
    {
        internal IntrinsicInst(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}