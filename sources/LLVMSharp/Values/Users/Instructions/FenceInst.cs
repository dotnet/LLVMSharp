// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class FenceInst : Instruction
{
    internal FenceInst(LLVMValueRef handle) : base(handle.IsAFenceInst)
    {
    }

    public AtomicOrdering Ordering
    {
        get
        {
            return (AtomicOrdering)Handle.Ordering;
        }

        set
        {
            var handle = Handle;
            handle.Ordering = (LLVMAtomicOrdering)value;
        }
    }
}
