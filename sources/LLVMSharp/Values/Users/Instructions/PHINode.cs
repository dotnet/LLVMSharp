// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class PHINode : Instruction
{
    internal PHINode(LLVMValueRef handle) : base(handle.IsAPHINode)
    {
    }

    public uint IncomingCount => Handle.IncomingCount;

    public void AddIncoming(Value incomingValue, BasicBlock incomingBlock)
    {
        ArgumentNullException.ThrowIfNull(incomingValue);
        ArgumentNullException.ThrowIfNull(incomingBlock);

        Span<LLVMValueRef> values = [incomingValue.Handle];
        Span<LLVMBasicBlockRef> blocks = [incomingBlock.Handle];
        Handle.AddIncoming(values, blocks, 1);
    }

    public BasicBlock GetIncomingBlock(uint index) => Context.GetOrCreate(Handle.GetIncomingBlock(index));

    public Value GetIncomingValue(uint index) => Context.GetOrCreate(Handle.GetIncomingValue(index));
}
