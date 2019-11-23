// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMExecutionEngineRef
    {
        public LLVMExecutionEngineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMExecutionEngineRef(LLVMOpaqueExecutionEngine* value)
        {
            return new LLVMExecutionEngineRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueExecutionEngine*(LLVMExecutionEngineRef value)
        {
            return (LLVMOpaqueExecutionEngine*)value.Pointer;
        }
    }
}
