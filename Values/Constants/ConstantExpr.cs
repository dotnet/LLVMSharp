namespace LLVMSharp
{
    public sealed class ConstantExpr : Constant
    {
        internal ConstantExpr(LLVMValueRef value)
            : base(value)
        {
        }
    }
}