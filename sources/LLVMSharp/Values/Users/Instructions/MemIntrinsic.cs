// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
