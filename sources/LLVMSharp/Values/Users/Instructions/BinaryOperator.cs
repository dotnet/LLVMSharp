// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class BinaryOperator : Instruction
{
    internal BinaryOperator(LLVMValueRef handle) : base(handle.IsABinaryOperator)
    {
    }

    public bool HasNoSignedWrap
    {
        get
        {
            return Handle.HasNoSignedWrap;
        }

        set
        {
            var handle = Handle;
            handle.HasNoSignedWrap = value;
        }
    }

    public bool HasNoUnsignedWrap
    {
        get
        {
            return Handle.HasNoUnsignedWrap;
        }

        set
        {
            var handle = Handle;
            handle.HasNoUnsignedWrap = value;
        }
    }

    public bool IsDisjoint
    {
        get
        {
            return Handle.IsDisjoint;
        }

        set
        {
            var handle = Handle;
            handle.IsDisjoint = value;
        }
    }

    public bool IsExact
    {
        get
        {
            return Handle.Exact;
        }

        set
        {
            var handle = Handle;
            handle.Exact = value;
        }
    }
}
