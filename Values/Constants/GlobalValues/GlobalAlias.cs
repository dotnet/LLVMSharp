namespace LLVMSharp
{
    public sealed class GlobalAlias : GlobalValue
    {
        internal GlobalAlias(LLVMValueRef instance)
            : base(instance)
        {   
        }
    }
}