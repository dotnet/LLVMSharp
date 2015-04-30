namespace LLVMSharp
{
    public sealed class GlobalVariable : GlobalObject
    {
        internal GlobalVariable(LLVMValueRef value)
            : base(value)
        {
        }
    }
}