// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
