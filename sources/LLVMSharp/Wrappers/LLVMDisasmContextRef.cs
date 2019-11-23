// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMDisasmContextRef
    {
        public LLVMDisasmContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static explicit operator LLVMDisasmContextRef(void* value)
        {
            return new LLVMDisasmContextRef((IntPtr)value);
        }

        public static implicit operator void*(LLVMDisasmContextRef value)
        {
            return (void*)value.Pointer;
        }
    }
}
