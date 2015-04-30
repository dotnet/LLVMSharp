namespace LLVMSharp
{
    public class GlobalObject : GlobalValue
    {
        internal GlobalObject(LLVMValueRef value)
            : base(value)
        {
        }
    }
}