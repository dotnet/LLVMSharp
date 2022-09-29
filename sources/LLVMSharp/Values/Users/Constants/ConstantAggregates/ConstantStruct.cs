// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class ConstantStruct : ConstantAggregate
{
    internal ConstantStruct(LLVMValueRef handle) : base(handle.IsAConstantStruct, LLVMValueKind.LLVMConstantStructValueKind)
    {
    }

    public static Constant GetAnon(LLVMContext ctx, Constant[] v, bool packed = false) => GetAnon(ctx, v.AsSpan(), packed);

    public static Constant GetAnon(LLVMContext ctx, ReadOnlySpan<Constant> v, bool packed)
    {
        using var marshaledV = new MarshaledArray<Constant, LLVMValueRef>(v, (value) => value.Handle);
        var handle = ctx.Handle.GetConstStruct(marshaledV.AsSpan(), packed);
        return ctx.GetOrCreate<Constant>(handle);
    }
}
