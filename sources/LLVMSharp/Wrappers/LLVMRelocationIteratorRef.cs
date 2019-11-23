// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMRelocationIteratorRef
    {
        public LLVMRelocationIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMRelocationIteratorRef(LLVMOpaqueRelocationIterator* value)
        {
            return new LLVMRelocationIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueRelocationIterator*(LLVMRelocationIteratorRef value)
        {
            return (LLVMOpaqueRelocationIterator*)value.Pointer;
        }
    }
}
