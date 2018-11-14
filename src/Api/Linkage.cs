namespace LLVMSharp.API
{
    public enum Linkage : int
    {
        External = 0,
        AvailableExternally = 1,
        LinkOnceAny = 2,
        LinkOnceODR = 3,
        LinkOnceODRAutoHide = 4,
        WeakAny = 5,
        WeakODR = 6,
        Appending = 7,
        Internal = 8,
        Private = 9,
        DLLImport = 10,
        DLLExport = 11,
        ExternalWeak = 12,
        Ghost = 13,
        Common = 14,
        LinkerPrivate = 15,
        LinkerPrivateWeak = 16,
    }
}
