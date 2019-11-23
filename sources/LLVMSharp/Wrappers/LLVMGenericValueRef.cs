// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMGenericValueRef
    {
        public LLVMGenericValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMGenericValueRef(LLVMOpaqueGenericValue* GenericValue)
        {
            return new LLVMGenericValueRef((IntPtr)GenericValue);
        }

        public static implicit operator LLVMOpaqueGenericValue*(LLVMGenericValueRef GenericValue)
        {
            return (LLVMOpaqueGenericValue*)GenericValue.Pointer;
        }
    }
}
