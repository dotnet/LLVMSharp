// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class UnaryInstruction : Instruction
    {
        private protected UnaryInstruction(LLVMValueRef handle) : base(handle.IsAUnaryInstruction)
        {
        }

        internal static new UnaryInstruction Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAAllocaInst != null => new AllocaInst(handle),
            _ when handle.IsACastInst != null => CastInst.Create(handle),
            _ when handle.IsAExtractValueInst != null => new ExtractValueInst(handle),
            _ when handle.IsALoadInst != null => new LoadInst(handle),
            _ when handle.IsAVAArgInst != null => new VAArgInst(handle),
            _ when handle.IsAFreezeInst != null => new FreezeInst(handle),
            _ => new UnaryInstruction(handle),
        };
    }
}
