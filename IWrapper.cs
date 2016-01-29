namespace LLVMSharp
{
    internal interface IWrapper<THandle>
        where THandle : struct 
    {
        THandle ToHandleType();
    }
}
