// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class Function : GlobalObject
{
    internal Function(LLVMValueRef handle) : base(handle.IsAFunction, LLVMValueKind.LLVMFunctionValueKind)
    {
    }

    public LLVMCallConv CallingConvention
    {
        get
        {
            return (LLVMCallConv)Handle.FunctionCallConv;
        }

        set
        {
            var handle = Handle;
            handle.FunctionCallConv = (uint)value;
        }
    }

    public void AddAttributeAtIndex(LLVMAttributeIndex index, Attribute attribute)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        Handle.AddAttributeAtIndex(index, attribute.Handle);
    }

    public Attribute[] GetAttributesAtIndex(LLVMAttributeIndex index)
    {
        var handles = Handle.GetAttributesAtIndex(index);
        var attributes = new Attribute[handles.Length];

        for (var i = 0; i < handles.Length; i++)
        {
            attributes[i] = new Attribute(handles[i]);
        }

        return attributes;
    }

    public void RemoveEnumAttributeAtIndex(LLVMAttributeIndex index, uint kindId) => Handle.RemoveEnumAttributeAtIndex(index, kindId);
}
