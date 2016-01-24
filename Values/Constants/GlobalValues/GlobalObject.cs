namespace LLVMSharp
{
    public class GlobalObject : GlobalValue
    {
        internal GlobalObject(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}