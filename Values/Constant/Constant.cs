namespace LLVMSharp
{
    public abstract class Constant : Value
    {
        protected Constant(LLVMValueRef value) : base(value)
        {
        }
    }
}