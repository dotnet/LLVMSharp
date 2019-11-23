// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMAttributeRef
    {
        public LLVMAttributeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMAttributeRef(LLVMOpaqueAttributeRef* value)
        {
            return new LLVMAttributeRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueAttributeRef*(LLVMAttributeRef value)
        {
            return (LLVMOpaqueAttributeRef*)value.Pointer;
        }
    }
}
