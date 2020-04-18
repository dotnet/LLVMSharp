// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class ConstantExpr : Constant
    {
        private protected ConstantExpr(LLVMValueRef handle) : base(handle.IsAConstantExpr, LLVMValueKind.LLVMConstantExprValueKind)
        {
        }

        internal static new ConstantExpr Create(LLVMValueRef handle) => handle switch
        {
            _ => new ConstantExpr(handle),
        };
    }
}
