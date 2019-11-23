// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMBasicBlockRef
    {
        public LLVMBasicBlockRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static explicit operator LLVMBasicBlockRef(LLVMOpaqueValue* value)
        {
            return new LLVMBasicBlockRef((IntPtr)value);
        }

        public static implicit operator LLVMBasicBlockRef(LLVMOpaqueBasicBlock* value)
        {
            return new LLVMBasicBlockRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueBasicBlock*(LLVMBasicBlockRef value)
        {
            return (LLVMOpaqueBasicBlock*)value.Pointer;
        }

        public static implicit operator LLVMOpaqueValue*(LLVMBasicBlockRef value)
        {
            return (LLVMOpaqueValue*)value.Pointer;
        }
    }
}
