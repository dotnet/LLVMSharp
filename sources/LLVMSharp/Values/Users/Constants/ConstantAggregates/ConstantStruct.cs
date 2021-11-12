// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class ConstantStruct : ConstantAggregate
    {
        internal ConstantStruct(LLVMValueRef handle) : base(handle.IsAConstantStruct, LLVMValueKind.LLVMConstantStructValueKind)
        {
        }

        public static Constant GetAnon(LLVMContext Ctx, Constant[] V, bool Packed = false) => GetAnon(Ctx, V.AsSpan(), Packed);

        public static Constant GetAnon(LLVMContext Ctx, ReadOnlySpan<Constant> V, bool Packed)
        {
            using var marshaledV = new MarshaledArray<Constant, LLVMValueRef>(V, (value) => value.Handle);
            var handle = Ctx.Handle.GetConstStruct(marshaledV, Packed);
            return Ctx.GetOrCreate<Constant>(handle);
        }
    }
}
