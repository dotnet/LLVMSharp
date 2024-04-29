// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class StructType : CompositeType
{
    internal StructType(LLVMTypeRef handle) : base(handle, LLVMTypeKind.LLVMStructTypeKind)
    {
    }

    public static StructType Create(LLVMContext context, string name) => Create(context, name.AsSpan());

    public static StructType Create(LLVMContext context, ReadOnlySpan<char> name)
    {
        ArgumentNullException.ThrowIfNull(context);
        var handle = context.Handle.CreateNamedStruct(name);
        return context.GetOrCreate<StructType>(handle);
    }
}
