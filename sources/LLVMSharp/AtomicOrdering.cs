// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public enum AtomicOrdering
    {
        NotAtomic = LLVMAtomicOrdering.LLVMAtomicOrderingNotAtomic,
        Unordered = LLVMAtomicOrdering.LLVMAtomicOrderingUnordered,
        Monotonic = LLVMAtomicOrdering.LLVMAtomicOrderingMonotonic,
        Acquire = LLVMAtomicOrdering.LLVMAtomicOrderingAcquire,
        Release = LLVMAtomicOrdering.LLVMAtomicOrderingRelease,
        AcquireRelease = LLVMAtomicOrdering.LLVMAtomicOrderingAcquireRelease,
        SequentiallyConsistent = LLVMAtomicOrdering.LLVMAtomicOrderingSequentiallyConsistent,
    }
}
