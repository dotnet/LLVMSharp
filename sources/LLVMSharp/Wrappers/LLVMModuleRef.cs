// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleRef
    {
        public LLVMModuleRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMModuleRef(LLVMOpaqueModule* value)
        {
            return new LLVMModuleRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueModule*(LLVMModuleRef value)
        {
            return (LLVMOpaqueModule*)value.Pointer;
        }
    }
}
