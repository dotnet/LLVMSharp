// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public class CallBase : Instruction
{
    private protected CallBase(LLVMValueRef handle) : base(handle)
    {
    }

    public uint ArgOperandsCount => Handle.ArgOperandsCount;

    public LLVMCallConv CallingConvention
    {
        get
        {
            return (LLVMCallConv)Handle.InstructionCallConv;
        }

        set
        {
            var handle = Handle;
            handle.InstructionCallConv = (uint)value;
        }
    }

    public void AddAttributeAtIndex(LLVMAttributeIndex index, Attribute attribute)
    {
        ArgumentNullException.ThrowIfNull(attribute);
        Handle.AddAttributeAtIndex(index, attribute.Handle);
    }

    public Attribute[] GetAttributesAtIndex(LLVMAttributeIndex index)
    {
        var handles = Handle.GetCallSiteAttributes(index);
        var attributes = new Attribute[handles.Length];

        for (var i = 0; i < handles.Length; i++)
        {
            attributes[i] = new Attribute(handles[i]);
        }

        return attributes;
    }

    public FunctionType CalledFunctionType => Context.GetOrCreate<FunctionType>(Handle.CalledFunctionType);

    public Value CalledOperand => Context.GetOrCreate(Handle.CalledValue);

    public Value GetArgOperand(uint index) => Context.GetOrCreate(Handle.GetArgOperand(index));
}
