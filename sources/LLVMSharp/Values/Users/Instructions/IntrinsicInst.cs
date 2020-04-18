// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class IntrinsicInst : CallInst
    {
        private protected IntrinsicInst(LLVMValueRef handle) : base(handle.IsAIntrinsicInst)
        {
        }

        internal static new IntrinsicInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsADbgInfoIntrinsic != null => DbgInfoIntrinsic.Create(handle),
            _ when handle.IsAMemIntrinsic != null => MemIntrinsic.Create(handle),
            _ => new IntrinsicInst(handle),
        };
    }
}
