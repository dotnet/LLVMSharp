// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class StructType : CompositeType
    {
        internal StructType(LLVMTypeRef handle) : base(handle, LLVMTypeKind.LLVMStructTypeKind)
        {
        }

        public static StructType Create(LLVMContext Context, string Name) => Create(Context, Name.AsSpan());

        public static StructType Create(LLVMContext Context, ReadOnlySpan<char> Name)
        {
            var handle = Context.Handle.CreateNamedStruct(Name);
            return Context.GetOrCreate<StructType>(handle);
        }
    }
}
