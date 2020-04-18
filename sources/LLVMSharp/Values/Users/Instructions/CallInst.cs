// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class CallInst : CallBase
    {
        private protected CallInst(LLVMValueRef handle) : base(handle.IsACallInst)
        {
        }

        internal static new CallInst Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAIntrinsicInst != null => IntrinsicInst.Create(handle),
            _ => new CallInst(handle),
        };
    }
}
