// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class ConstantByte : ConstantData
{
    internal ConstantByte(LLVMValueRef handle) : base(handle.IsAConstantByte, LLVMValueKind.LLVMConstantByteValueKind)
    {
    }

    public long SExtValue => Handle.ConstByteSExt;

    public ulong ZExtValue => Handle.ConstByteZExt;
}
