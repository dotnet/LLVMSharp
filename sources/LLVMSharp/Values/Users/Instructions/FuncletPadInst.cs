// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
