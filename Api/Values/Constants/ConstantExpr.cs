namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantExpr : Constant
    {
        internal ConstantExpr(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}