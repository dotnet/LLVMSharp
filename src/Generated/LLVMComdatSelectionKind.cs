namespace LLVMSharp
{
    public enum LLVMComdatSelectionKind
    {
        LLVMAnyComdatSelectionKind = 0,
        LLVMExactMatchComdatSelectionKind = 1,
        LLVMLargestComdatSelectionKind = 2,
        LLVMNoDuplicatesComdatSelectionKind = 3,
        LLVMSameSizeComdatSelectionKind = 4,
    }
}
