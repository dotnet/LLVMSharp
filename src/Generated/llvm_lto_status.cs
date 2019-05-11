namespace LLVMSharp
{
    public enum llvm_lto_status
    {
        LLVM_LTO_UNKNOWN,
        LLVM_LTO_OPT_SUCCESS,
        LLVM_LTO_READ_SUCCESS,
        LLVM_LTO_READ_FAILURE,
        LLVM_LTO_WRITE_FAILURE,
        LLVM_LTO_NO_TARGET,
        LLVM_LTO_NO_WORK,
        LLVM_LTO_MODULE_MERGE_FAILURE,
        LLVM_LTO_ASM_FAILURE,
        LLVM_LTO_NULL_OBJECT,
    }
}
