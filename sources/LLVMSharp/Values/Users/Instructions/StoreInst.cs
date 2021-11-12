// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class StoreInst : Instruction
    {
        internal StoreInst(LLVMValueRef handle) : base(handle.IsAStoreInst)
        {
        }

        public uint Alignment
        {
            get => Handle.Alignment;
            set => Handle.SetAlignment(value);
        }
    }
}
