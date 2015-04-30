namespace LLVMSharp
{
    public class GlobalValue : Constant
    {
        internal GlobalValue(LLVMValueRef value)
            : base(value)
        {
        }
    }
}