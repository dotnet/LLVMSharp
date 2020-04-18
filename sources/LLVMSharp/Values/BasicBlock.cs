// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class BasicBlock : Value
    {
        private BasicBlock(LLVMBasicBlockRef handle) : this(handle.AsValue())
        {
        }

        internal BasicBlock(LLVMValueRef handle) : base(handle.IsABasicBlock, LLVMValueKind.LLVMBasicBlockValueKind)
        {
            Handle = handle.AsBasicBlock();
        }

        public new LLVMBasicBlockRef Handle { get; }

        public LLVMValueRef ValueHandle => base.Handle;
    }
}
