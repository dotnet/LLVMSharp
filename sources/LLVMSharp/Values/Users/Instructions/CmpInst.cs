// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
