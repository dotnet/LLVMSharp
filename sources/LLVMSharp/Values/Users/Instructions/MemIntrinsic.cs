// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class MemIntrinsic : MemIntrinsicBase
    {
        private protected MemIntrinsic(LLVMValueRef handle) : base(handle.IsAMemIntrinsic)
        {
        }

        internal static new MemIntrinsic Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAMemCpyInst != null => new MemCpyInst(handle),
            _ when handle.IsAMemMoveInst != null => new MemMoveInst(handle),
            _ when handle.IsAMemSetInst != null => new MemSetInst(handle),
            _ => new MemIntrinsic(handle),
        };
    }
}
