// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class CmpInst : Instruction
    {
        private protected CmpInst(LLVMValueRef handle) : base(handle.IsACmpInst)
        {
        }

        internal static new CmpInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAFCmpInst != null => new FCmpInst(handle),
            _ when handle.IsAICmpInst != null => new ICmpInst(handle),
            _ => new CmpInst(handle),
        };
    }
}
