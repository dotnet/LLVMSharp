// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMPassManagerRef
    {
        public LLVMPassManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMPassManagerRef(LLVMOpaquePassManager* value)
        {
            return new LLVMPassManagerRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaquePassManager*(LLVMPassManagerRef value)
        {
            return (LLVMOpaquePassManager*)value.Pointer;
        }
    }
}
