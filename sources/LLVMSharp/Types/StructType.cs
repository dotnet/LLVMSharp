// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
