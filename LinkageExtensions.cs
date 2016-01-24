namespace LLVMSharp
{
    public static class LinkageExtensions
    {
        public static bool IsExternalLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMExternalLinkage;
        }

        public static bool IsAvailableExternallyLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMAvailableExternallyLinkage;
        }

        public static bool IsLinkOnceODRLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMLinkOnceODRLinkage;
        }

        public static bool IsLinkOnceLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMLinkOnceAnyLinkage || linkage == LLVMLinkage.LLVMLinkOnceODRLinkage;
        }

        public static bool IsWeakAnyLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMWeakAnyLinkage;
        }

        public static bool IsWeakODRLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMWeakODRLinkage;
        }

        public static bool IsWeakLinkage(this LLVMLinkage linkage)
        {
            return linkage.IsWeakAnyLinkage() || linkage.IsWeakODRLinkage();
        }

        public static bool IsAppendingLinkage(LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMAppendingLinkage;
        }

        public static bool IsInternalLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMInternalLinkage;
        }

        public static bool IsPrivateLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMPrivateLinkage;
        }

        public static bool IsLocalLinkage(this LLVMLinkage linkage)
        {
            return linkage.IsInternalLinkage() || linkage.IsPrivateLinkage();
        }

        public static bool IsExternalWeakLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMExternalWeakLinkage;
        }

        public static bool IsCommonLinkage(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMCommonLinkage;
        }

        public static bool IsDiscardableIfUnused(this LLVMLinkage linkage)
        {
            return linkage.IsLinkOnceLinkage() || linkage.IsLocalLinkage();
        }

        public static bool MayBeOverridden(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMWeakAnyLinkage || linkage == LLVMLinkage.LLVMLinkOnceAnyLinkage ||
                   linkage == LLVMLinkage.LLVMCommonLinkage || linkage == LLVMLinkage.LLVMExternalWeakLinkage;
        }

        public static bool IsWeakForLinker(this LLVMLinkage linkage)
        {
            return linkage == LLVMLinkage.LLVMAvailableExternallyLinkage || linkage == LLVMLinkage.LLVMWeakAnyLinkage ||
                   linkage == LLVMLinkage.LLVMWeakODRLinkage || linkage == LLVMLinkage.LLVMLinkOnceAnyLinkage ||
                   linkage == LLVMLinkage.LLVMLinkOnceODRLinkage || linkage == LLVMLinkage.LLVMCommonLinkage ||
                   linkage == LLVMLinkage.LLVMExternalWeakLinkage;
        }
    }
}
