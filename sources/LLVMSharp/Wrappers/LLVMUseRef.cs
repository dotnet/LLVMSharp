// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMUseRef
    {
        public LLVMUseRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMUseRef(LLVMOpaqueUse* Use)
        {
            return new LLVMUseRef((IntPtr)Use);
        }

        public static implicit operator LLVMOpaqueUse*(LLVMUseRef Use)
        {
            return (LLVMOpaqueUse*)Use.Pointer;
        }
    }
}
