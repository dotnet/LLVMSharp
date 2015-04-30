namespace LLVMSharp
{
    public abstract class ConstantDataSequential : Constant
    {
        protected ConstantDataSequential(LLVMValueRef value) : base(value)
        {
        }
    }
}