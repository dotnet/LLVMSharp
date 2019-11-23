// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMValueRef
    {
        public LLVMValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMValueRef(LLVMOpaqueValue* value)
        {
            return new LLVMValueRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueValue*(LLVMValueRef value)
        {
            return (LLVMOpaqueValue*)value.Pointer;
        }
    }
}
