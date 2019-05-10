namespace LLVMSharp
{
    public enum LLVMThreadLocalMode
    {
        LLVMNotThreadLocal = 0,
        LLVMGeneralDynamicTLSModel = 1,
        LLVMLocalDynamicTLSModel = 2,
        LLVMInitialExecTLSModel = 3,
        LLVMLocalExecTLSModel = 4,
    }
}
