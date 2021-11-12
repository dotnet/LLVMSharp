// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
