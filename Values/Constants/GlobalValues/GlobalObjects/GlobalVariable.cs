namespace LLVMSharp
{
    public sealed class GlobalVariable : GlobalObject
    {
        internal GlobalVariable(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}