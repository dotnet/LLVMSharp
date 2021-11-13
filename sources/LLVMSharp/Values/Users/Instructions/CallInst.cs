// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class CallInst : CallBase
    {
        private protected CallInst(LLVMValueRef handle) : base(handle.IsACallInst)
        {
        }

        internal static new CallInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAIntrinsicInst != null => IntrinsicInst.Create(handle),
            _ => new CallInst(handle),
        };
    }
}
