// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
