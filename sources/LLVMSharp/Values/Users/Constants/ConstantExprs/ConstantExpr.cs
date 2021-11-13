// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
