namespace LLVMSharp
{
    public enum LLVMRelocMode
    {
        LLVMRelocDefault = 0,
        LLVMRelocStatic = 1,
        LLVMRelocPIC = 2,
        LLVMRelocDynamicNoPic = 3,
        LLVMRelocROPI = 4,
        LLVMRelocRWPI = 5,
        LLVMRelocROPI_RWPI = 6,
    }
}
