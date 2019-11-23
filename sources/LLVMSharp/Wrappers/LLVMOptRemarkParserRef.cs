// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMOptRemarkParserRef
    {
        public LLVMOptRemarkParserRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMOptRemarkParserRef(LLVMOptRemarkOpaqueParser* value)
        {
            return new LLVMOptRemarkParserRef((IntPtr)value);
        }

        public static implicit operator LLVMOptRemarkOpaqueParser*(LLVMOptRemarkParserRef value)
        {
            return (LLVMOptRemarkOpaqueParser*)value.Pointer;
        }
    }
}
