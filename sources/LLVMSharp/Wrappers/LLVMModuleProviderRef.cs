// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleProviderRef
    {
        public LLVMModuleProviderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMModuleProviderRef(LLVMOpaqueModuleProvider* value)
        {
            return new LLVMModuleProviderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueModuleProvider*(LLVMModuleProviderRef value)
        {
            return (LLVMOpaqueModuleProvider*)value.Pointer;
        }
    }
}
