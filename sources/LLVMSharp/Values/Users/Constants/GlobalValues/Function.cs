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

    public uint BasicBlocksCount => Handle.BasicBlocksCount;

    public BasicBlock EntryBasicBlock => Context.GetOrCreate(Handle.EntryBasicBlock);

    public FunctionType FunctionType => Context.GetOrCreate<FunctionType>(Handle.GlobalValueType);

    public string GC
    {
        get
        {
            return Handle.GC;
        }

        set
        {
            var handle = Handle;
            handle.GC = value;
        }
    }

    public uint IntrinsicID => Handle.IntrinsicID;

    public bool IsIntrinsic => Handle.IntrinsicID != 0;

    public uint NumParams => Handle.ParamsCount;

    public Constant? PersonalityFn
    {
        get
        {
            var personalityFn = Handle.PersonalityFn;
            return (personalityFn == null) ? null : Context.GetOrCreate<Constant>(personalityFn);
        }

        set
        {
            var handle = Handle;
            handle.PersonalityFn = (value is not null) ? value.Handle : default;
        }
    }

    public Type ReturnType => FunctionType.ReturnType;

    public BasicBlock AppendBasicBlock(ReadOnlySpan<char> name) => Context.GetOrCreate(Handle.AppendBasicBlock(name));

    public void EraseFromParent() => Handle.DeleteFunction();

    public BasicBlock[] GetBasicBlocks()
    {
        var handles = Handle.GetBasicBlocks();

        if (handles.Length == 0)
        {
            return [];
        }

        var context = Context;
        var result = new BasicBlock[handles.Length];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = context.GetOrCreate(handles[i]);
        }

        return result;
    }

    public Argument GetParam(uint index) => Context.GetOrCreate<Argument>(Handle.GetParam(index));

    public Argument[] GetParams()
    {
        var handles = Handle.GetParams();

        if (handles.Length == 0)
        {
            return [];
        }

        var context = Context;
        var result = new Argument[handles.Length];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = context.GetOrCreate<Argument>(handles[i]);
        }

        return result;
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

    public bool Verify(LLVMVerifierFailureAction action) => Handle.VerifyFunction(action);
}
