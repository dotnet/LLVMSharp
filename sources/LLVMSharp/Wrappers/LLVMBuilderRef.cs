// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMBuilderRef
    {
        public LLVMBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMBuilderRef(LLVMOpaqueBuilder* Builder)
        {
            return new LLVMBuilderRef((IntPtr)Builder);
        }

        public static implicit operator LLVMOpaqueBuilder*(LLVMBuilderRef Builder)
        {
            return (LLVMOpaqueBuilder*)Builder.Pointer;
        }
    }
}
