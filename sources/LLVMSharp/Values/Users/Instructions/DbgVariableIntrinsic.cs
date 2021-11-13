// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class DbgVariableIntrinsic : DbgInfoIntrinsic
    {
        private protected DbgVariableIntrinsic(LLVMValueRef handle) : base(handle.IsADbgVariableIntrinsic)
        {
        }

        internal static new DbgVariableIntrinsic Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsADbgDeclareInst != null => new DbgDeclareInst(handle),
            _ => new DbgVariableIntrinsic(handle),
        };
    }
}
