// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
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

    public Instruction? FirstInstruction
    {
        get
        {
            var handle = Handle.FirstInstruction;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<Instruction>(handle) : null;
        }
    }

    public Instruction? LastInstruction
    {
        get
        {
            var handle = Handle.LastInstruction;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<Instruction>(handle) : null;
        }
    }

    public BasicBlock? Next
    {
        get
        {
            var handle = Handle.Next;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate(handle) : null;
        }
    }

    public Function? Parent
    {
        get
        {
            var handle = Handle.Parent;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<Function>(handle) : null;
        }
    }

    public BasicBlock? Previous
    {
        get
        {
            var handle = Handle.Previous;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate(handle) : null;
        }
    }

    public Instruction? Terminator
    {
        get
        {
            var handle = Handle.Terminator;
            return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<Instruction>(handle) : null;
        }
    }

    public void EraseFromParent() => Handle.Delete();

    public Instruction[] GetInstructions()
    {
        var result = new List<Instruction>();
        var context = Context;

        foreach (var handle in Handle.Instructions)
        {
            result.Add(context.GetOrCreate<Instruction>(handle));
        }

        return [.. result];
    }

    public void MoveAfter(BasicBlock target)
    {
        ArgumentNullException.ThrowIfNull(target);
        Handle.MoveAfter(target.Handle);
    }

    public void MoveBefore(BasicBlock target)
    {
        ArgumentNullException.ThrowIfNull(target);
        Handle.MoveBefore(target.Handle);
    }

    public void RemoveFromParent() => Handle.RemoveFromParent();
}
