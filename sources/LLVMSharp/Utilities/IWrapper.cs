namespace LLVMSharp.Utilities
{
    internal interface IWrapper<THandle>
        where THandle : struct 
    {
        THandle ToHandleType { get; }
    }
}
