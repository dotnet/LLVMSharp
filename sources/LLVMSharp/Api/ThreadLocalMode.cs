namespace LLVMSharp.API
{
    public enum ThreadLocalMode : int
    {
        NotThreadLocal = 0,
        GeneralDynamicTLSModel = 1,
        LocalDynamicTLSModel = 2,
        InitialExecTLSModel = 3,
        LocalExecTLSModel = 4,
    }
}
