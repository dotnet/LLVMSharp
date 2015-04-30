namespace LLVMSharp
{
    public class Constant : Value
    {
        internal Constant(LLVMValueRef value)
            : base(value)
        {
        }
    }
}