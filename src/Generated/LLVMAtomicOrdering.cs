namespace LLVMSharp
{
    public enum LLVMAtomicOrdering
    {
        LLVMAtomicOrderingNotAtomic = 0,
        LLVMAtomicOrderingUnordered = 1,
        LLVMAtomicOrderingMonotonic = 2,
        LLVMAtomicOrderingAcquire = 4,
        LLVMAtomicOrderingRelease = 5,
        LLVMAtomicOrderingAcquireRelease = 6,
        LLVMAtomicOrderingSequentiallyConsistent = 7,
    }
}
