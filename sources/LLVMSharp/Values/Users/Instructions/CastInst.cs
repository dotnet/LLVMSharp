// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class CastInst : UnaryInstruction
    {
        private protected CastInst(LLVMValueRef handle) : base(handle.IsACastInst)
        {
        }

        internal static new CastInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAAddrSpaceCastInst != null => new AddrSpaceCastInst(handle),
            _ when handle.IsABitCastInst != null => new BitCastInst(handle),
            _ when handle.IsAFPExtInst != null => new FPExtInst(handle),
            _ when handle.IsAFPToSIInst != null => new FPToSIInst(handle),
            _ when handle.IsAFPToUIInst != null => new FPToUIInst(handle),
            _ when handle.IsAFPTruncInst != null => new FPTruncInst(handle),
            _ when handle.IsAIntToPtrInst != null => new IntToPtrInst(handle),
            _ when handle.IsAPtrToIntInst != null => new PtrToIntInst(handle),
            _ when handle.IsASExtInst != null => new SExtInst(handle),
            _ when handle.IsASIToFPInst != null => new SIToFPInst(handle),
            _ when handle.IsATruncInst != null => new TruncInst(handle),
            _ when handle.IsAUIToFPInst != null => new UIToFPInst(handle),
            _ when handle.IsAZExtInst != null => new ZExtInst(handle),
            _ => new CastInst(handle),
        };
    }
}
