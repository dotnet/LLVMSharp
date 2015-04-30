namespace LLVMSharp
{
    public sealed class GlobalAlias : GlobalValue
    {
        internal GlobalAlias(LLVMValueRef value)
            : base(value)
        {   
        }
    }
}