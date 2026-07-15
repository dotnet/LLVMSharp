// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class SwitchInst : Instruction
{
    internal SwitchInst(LLVMValueRef handle) : base(handle.IsASwitchInst)
    {
    }

    public Value Condition => GetOperand(0);

    public BasicBlock DefaultDest => Context.GetOrCreate(Handle.SwitchDefaultDest);

    public void AddCase(ConstantInt onVal, BasicBlock dest)
    {
        ArgumentNullException.ThrowIfNull(onVal);
        ArgumentNullException.ThrowIfNull(dest);
        Handle.AddCase(onVal.Handle, dest.Handle);
    }
}
