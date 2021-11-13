// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
