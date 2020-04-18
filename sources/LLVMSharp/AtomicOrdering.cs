// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
