// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class ConstantDataArray : ConstantDataSequential
{
    internal ConstantDataArray(LLVMValueRef handle) : base(handle.IsAConstantDataArray, LLVMValueKind.LLVMConstantDataArrayValueKind)
    {
    }

    public static Constant GetString(LLVMContext context, string initializer, bool addNull = true) => GetString(context, initializer.AsSpan(), addNull);

    public static Constant GetString(LLVMContext context, ReadOnlySpan<char> initializer, bool addNull)
    {
        ArgumentNullException.ThrowIfNull(context);
        var handle = context.Handle.GetConstString(initializer, !addNull);
        return context.GetOrCreate<Constant>(handle);
    }
}
