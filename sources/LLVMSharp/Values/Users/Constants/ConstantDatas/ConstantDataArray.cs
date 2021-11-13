// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class ConstantDataArray : ConstantDataSequential
    {
        internal ConstantDataArray(LLVMValueRef handle) : base(handle.IsAConstantDataArray, LLVMValueKind.LLVMConstantDataArrayValueKind)
        {
        }

        public static Constant GetString(LLVMContext Context, string Initializer, bool AddNull = true) => GetString(Context, Initializer.AsSpan(), AddNull);

        public static Constant GetString(LLVMContext Context, ReadOnlySpan<char> Initializer, bool AddNull)
        {
            var handle = Context.Handle.GetConstString(Initializer, !AddNull);
            return Context.GetOrCreate<Constant>(handle);
        }
    }
}
