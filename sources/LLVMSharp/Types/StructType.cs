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

    public bool IsOpaque => Handle.IsOpaqueStruct;

    public bool IsPacked => Handle.IsPackedStruct;

    public string Name => Handle.StructName;

    public uint NumElements => Handle.StructElementTypesCount;

    public Type GetElementType(uint index) => Context.GetOrCreate(Handle.StructGetTypeAtIndex(index));

    public Type[] GetElementTypes()
    {
        var handles = Handle.GetStructElementTypes();

        if (handles.Length == 0)
        {
            return [];
        }

        var context = Context;
        var result = new Type[handles.Length];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = context.GetOrCreate(handles[i]);
        }

        return result;
    }

    public void SetBody(Type[] elementTypes, bool packed)
    {
        ArgumentNullException.ThrowIfNull(elementTypes);
        SetBody(elementTypes.AsSpan(), packed);
    }

    public void SetBody(ReadOnlySpan<Type> elementTypes, bool packed)
    {
        var handles = new LLVMTypeRef[elementTypes.Length];

        for (var i = 0; i < handles.Length; i++)
        {
            var elementType = elementTypes[i];
            ArgumentNullException.ThrowIfNull(elementType);
            handles[i] = elementType.Handle;
        }

        Handle.StructSetBody(handles, packed);
    }
}
