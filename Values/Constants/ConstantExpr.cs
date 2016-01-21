namespace LLVMSharp
{
    public sealed class ConstantExpr : Constant
    {
        internal ConstantExpr(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}