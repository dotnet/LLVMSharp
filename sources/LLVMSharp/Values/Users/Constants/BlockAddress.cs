// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class BlockAddress : Constant
{
    internal BlockAddress(LLVMValueRef handle) : base(handle.IsABlockAddress, LLVMValueKind.LLVMBlockAddressValueKind)
    {
    }

    public BasicBlock BasicBlock => Context.GetOrCreate(Handle.BlockAddressBasicBlock);

    public Function Function => Context.GetOrCreate<Function>(Handle.BlockAddressFunction);
}
