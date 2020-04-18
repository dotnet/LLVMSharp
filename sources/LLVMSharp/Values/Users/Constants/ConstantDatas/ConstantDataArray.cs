// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class ConstantDataArray : ConstantDataSequential
    {
        internal ConstantDataArray(LLVMValueRef handle) : base(handle.IsAConstantDataArray, LLVMValueKind.LLVMConstantDataArrayValueKind)
        {
        }
    }
}
