namespace LLVMSharp
{
    public enum llvm_lto_status
    {
        LLVM_LTO_UNKNOWN = 0,
        LLVM_LTO_OPT_SUCCESS = 1,
        LLVM_LTO_READ_SUCCESS = 2,
        LLVM_LTO_READ_FAILURE = 3,
        LLVM_LTO_WRITE_FAILURE = 4,
        LLVM_LTO_NO_TARGET = 5,
        LLVM_LTO_NO_WORK = 6,
        LLVM_LTO_MODULE_MERGE_FAILURE = 7,
        LLVM_LTO_ASM_FAILURE = 8,
        LLVM_LTO_NULL_OBJECT = 9,
    }
}
