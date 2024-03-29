// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class LoadInst : UnaryInstruction
{
    internal LoadInst(LLVMValueRef handle) : base(handle.IsALoadInst)
    {
    }

    public uint Alignment
    {
        get
        {
            return Handle.Alignment;
        }

        set
        {
            Handle.SetAlignment(value);
        }
    }
}
