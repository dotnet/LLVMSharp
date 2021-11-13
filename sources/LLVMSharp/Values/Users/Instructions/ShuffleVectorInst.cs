// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class ShuffleVectorInst : Instruction
    {
        internal ShuffleVectorInst(LLVMValueRef handle) : base(handle.IsAShuffleVectorInst)
        {
        }
    }
}
