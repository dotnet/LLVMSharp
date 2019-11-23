// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetDataRef
    {
        public LLVMTargetDataRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetDataRef(LLVMOpaqueTargetData* TargetData)
        {
            return new LLVMTargetDataRef((IntPtr)TargetData);
        }

        public static implicit operator LLVMOpaqueTargetData*(LLVMTargetDataRef TargetData)
        {
            return (LLVMOpaqueTargetData*)TargetData.Pointer;
        }
    }
}
