// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMRemarkDebugLocRef
    {
        public LLVMRemarkDebugLocRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMRemarkDebugLocRef(LLVMRemarkOpaqueDebugLoc* value)
        {
            return new LLVMRemarkDebugLocRef((IntPtr)value);
        }

        public static implicit operator LLVMRemarkOpaqueDebugLoc*(LLVMRemarkDebugLocRef value)
        {
            return (LLVMRemarkOpaqueDebugLoc*)value.Pointer;
        }
    }
}
