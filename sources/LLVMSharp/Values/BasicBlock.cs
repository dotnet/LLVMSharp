// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class BasicBlock : Value
{
    private BasicBlock(LLVMBasicBlockRef handle) : this(handle.AsValue())
    {
    }

    internal BasicBlock(LLVMValueRef handle) : base(handle.IsABasicBlock, LLVMValueKind.LLVMBasicBlockValueKind)
    {
        Handle = handle.AsBasicBlock();
    }

    public static BasicBlock Create(LLVMContext context, string name) => Create(context, name.AsSpan());

    public static BasicBlock Create(LLVMContext context, ReadOnlySpan<char> name)
    {
        ArgumentNullException.ThrowIfNull(context);
        var handle = LLVMBasicBlockRef.CreateInContext(context.Handle, name);
        return new BasicBlock(handle);
    }

    public static BasicBlock Create(LLVMContext context, string name, Function parent) => Create(context, name.AsSpan(), parent);

    public static BasicBlock Create(LLVMContext context, ReadOnlySpan<char> name, Function parent)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(parent);

        var handle = LLVMBasicBlockRef.AppendInContext(context.Handle, parent.Handle, name);
        return new BasicBlock(handle);
    }

    public static BasicBlock Create(LLVMContext context, string name, BasicBlock insertBefore) => Create(context, name.AsSpan(), insertBefore);

    public static BasicBlock Create(LLVMContext context, ReadOnlySpan<char> name, BasicBlock insertBefore)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(insertBefore);

        var handle = LLVMBasicBlockRef.InsertInContext(context.Handle, insertBefore.Handle, name);
        return new BasicBlock(handle);
    }

    public new LLVMBasicBlockRef Handle { get; }

    public LLVMValueRef ValueHandle => base.Handle;
}
