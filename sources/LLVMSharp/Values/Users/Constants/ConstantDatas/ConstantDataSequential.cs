// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class ConstantDataSequential : ConstantData
    {
        private protected ConstantDataSequential(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAConstantDataSequential, expectedValueKind)
        {
        }

        internal new static ConstantDataSequential Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAConstantDataArray != null => new ConstantDataArray(handle),
            _ when handle.IsAConstantDataVector != null => new ConstantDataVector(handle),
            _ => new ConstantDataSequential(handle, handle.Kind),
        };
    }
}
