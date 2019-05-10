namespace LLVMSharp
{
    public enum LLVMLinkage
    {
        LLVMExternalLinkage = 0,
        LLVMAvailableExternallyLinkage = 1,
        LLVMLinkOnceAnyLinkage = 2,
        LLVMLinkOnceODRLinkage = 3,
        LLVMLinkOnceODRAutoHideLinkage = 4,
        LLVMWeakAnyLinkage = 5,
        LLVMWeakODRLinkage = 6,
        LLVMAppendingLinkage = 7,
        LLVMInternalLinkage = 8,
        LLVMPrivateLinkage = 9,
        LLVMDLLImportLinkage = 10,
        LLVMDLLExportLinkage = 11,
        LLVMExternalWeakLinkage = 12,
        LLVMGhostLinkage = 13,
        LLVMCommonLinkage = 14,
        LLVMLinkerPrivateLinkage = 15,
        LLVMLinkerPrivateWeakLinkage = 16,
    }
}
