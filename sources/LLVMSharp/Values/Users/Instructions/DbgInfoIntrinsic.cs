// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class DbgInfoIntrinsic : IntrinsicInst
    {
        private protected DbgInfoIntrinsic(LLVMValueRef handle) : base(handle.IsADbgInfoIntrinsic)
        {
        }

        internal static new DbgInfoIntrinsic Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsADbgVariableIntrinsic != null => DbgVariableIntrinsic.Create(handle),
            _ when handle.IsADbgLabelInst != null => new DbgLabelInst(handle),
            _ => new DbgInfoIntrinsic(handle),
        };
    }
}
