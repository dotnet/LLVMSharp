// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class ConstantStruct : ConstantAggregate
    {
        internal ConstantStruct(LLVMValueRef handle) : base(handle.IsAConstantStruct, LLVMValueKind.LLVMConstantStructValueKind)
        {
        }
    }
}
