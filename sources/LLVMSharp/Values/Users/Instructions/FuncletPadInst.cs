// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class FuncletPadInst : Instruction
    {
        private protected FuncletPadInst(LLVMValueRef handle) : base(handle.IsAFuncletPadInst)
        {
        }

        internal static new FuncletPadInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsACatchPadInst != null => new CatchPadInst(handle),
            _ when handle.IsACleanupPadInst != null => new CleanupPadInst(handle),
            _ => new FuncletPadInst(handle),
        };
    }
}
