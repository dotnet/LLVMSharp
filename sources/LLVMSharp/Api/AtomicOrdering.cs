namespace LLVMSharp.API
{
    public enum AtomicOrdering : int
    {
        NotAtomic = 0,
        Unordered = 1,
        Monotonic = 2,
        Acquire = 4,
        Release = 5,
        AcquireRelease = 6,
        SequentiallyConsistent = 7,
    }
}
