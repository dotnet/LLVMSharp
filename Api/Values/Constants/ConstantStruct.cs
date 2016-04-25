namespace LLVMSharp.Api.Values.Constants
{
    public sealed class ConstantStruct : Constant
    {
        internal ConstantStruct(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}