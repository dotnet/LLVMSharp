// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
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

        public static BasicBlock Create(LLVMContext Context, string Name) => Create(Context, Name.AsSpan());

        public static BasicBlock Create(LLVMContext Context, ReadOnlySpan<char> Name)
        {
            var handle = LLVMBasicBlockRef.CreateInContext(Context.Handle, Name);
            return new BasicBlock(handle);
        }

        public static BasicBlock Create(LLVMContext Context, string Name, Function Parent) => Create(Context, Name.AsSpan(), Parent);

        public static BasicBlock Create(LLVMContext Context, ReadOnlySpan<char> Name, Function Parent)
        {
            var handle = LLVMBasicBlockRef.AppendInContext(Context.Handle, Parent.Handle, Name);
            return new BasicBlock(handle);
        }

        public static BasicBlock Create(LLVMContext Context, string Name, BasicBlock InsertBefore) => Create(Context, Name.AsSpan(), InsertBefore);

        public static BasicBlock Create(LLVMContext Context, ReadOnlySpan<char> Name, BasicBlock InsertBefore)
        {
            var handle = LLVMBasicBlockRef.InsertInContext(Context.Handle, InsertBefore.Handle, Name);
            return new BasicBlock(handle);
        }

        public new LLVMBasicBlockRef Handle { get; }

        public LLVMValueRef ValueHandle => base.Handle;
    }
}
