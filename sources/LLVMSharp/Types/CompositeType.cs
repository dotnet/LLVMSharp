// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class CompositeType : Type
    {
        private protected CompositeType(LLVMTypeRef handle, LLVMTypeKind expectedTypeKind) : base(handle, expectedTypeKind)
        {
        }
    }
}
