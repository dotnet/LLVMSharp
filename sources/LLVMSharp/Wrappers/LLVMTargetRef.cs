// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetRef
    {
        public LLVMTargetRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetRef(LLVMTarget* value)
        {
            return new LLVMTargetRef((IntPtr)value);
        }

        public static implicit operator LLVMTarget*(LLVMTargetRef value)
        {
            return (LLVMTarget*)value.Pointer;
        }
    }
}
