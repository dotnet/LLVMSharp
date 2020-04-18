// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class Constant : User
    {
        private protected Constant(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAConstant, expectedValueKind)
        {
        }

        internal new static Constant Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsABlockAddress != null => new BlockAddress(handle),
            _ when handle.IsAConstantAggregateZero != null => new ConstantAggregateZero(handle),
            _ when handle.IsAConstantArray != null => new ConstantArray(handle),
            _ when handle.IsAConstantDataSequential != null => ConstantDataSequential.Create(handle),
            _ when handle.IsAConstantExpr != null => ConstantExpr.Create(handle),
            _ when handle.IsAConstantFP != null => new ConstantFP(handle),
            _ when handle.IsAConstantInt != null => new ConstantInt(handle),
            _ when handle.IsAConstantPointerNull != null => new ConstantPointerNull(handle),
            _ when handle.IsAConstantStruct != null => new ConstantStruct(handle),
            _ when handle.IsAConstantTokenNone != null => new ConstantTokenNone(handle),
            _ when handle.IsAConstantVector != null => new ConstantVector(handle),
            _ when handle.IsAGlobalValue != null => GlobalValue.Create(handle),
            _ when handle.IsAUndefValue != null => new UndefValue(handle),
            _ => new Constant(handle, handle.Kind),
        };
    }
}
