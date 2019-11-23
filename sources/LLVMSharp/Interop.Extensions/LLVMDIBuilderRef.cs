// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMDIBuilderRef
    {
        public LLVMDIBuilderRef(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle;

        public static implicit operator LLVMDIBuilderRef(LLVMOpaqueDIBuilder* value)
        {
            return new LLVMDIBuilderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueDIBuilder*(LLVMDIBuilderRef value)
        {
            return (LLVMOpaqueDIBuilder*)value.Handle;
        }
    }
}
