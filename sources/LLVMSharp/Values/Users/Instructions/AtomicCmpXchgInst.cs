// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class AtomicCmpXchgInst : Instruction
{
    internal AtomicCmpXchgInst(LLVMValueRef handle) : base(handle.IsAAtomicCmpXchgInst)
    {
    }

    public AtomicOrdering FailureOrdering
    {
        get
        {
            return (AtomicOrdering)Handle.CmpXchgFailureOrdering;
        }

        set
        {
            var handle = Handle;
            handle.CmpXchgFailureOrdering = (LLVMAtomicOrdering)value;
        }
    }

    public AtomicOrdering SuccessOrdering
    {
        get
        {
            return (AtomicOrdering)Handle.CmpXchgSuccessOrdering;
        }

        set
        {
            var handle = Handle;
            handle.CmpXchgSuccessOrdering = (LLVMAtomicOrdering)value;
        }
    }

    public bool Volatile
    {
        get
        {
            return Handle.Volatile;
        }

        set
        {
            var handle = Handle;
            handle.Volatile = value;
        }
    }

    public bool Weak
    {
        get
        {
            return Handle.Weak;
        }

        set
        {
            var handle = Handle;
            handle.Weak = value;
        }
    }
}
