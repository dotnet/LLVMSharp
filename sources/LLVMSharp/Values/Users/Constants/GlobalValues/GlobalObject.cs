// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class GlobalObject : GlobalValue
    {
        private protected GlobalObject(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAGlobalObject, expectedValueKind)
        {
        }

        internal new static GlobalObject Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAFunction != null => new Function(handle),
            _ when handle.IsAGlobalVariable != null => new GlobalVariable(handle),
            _ => new GlobalObject(handle, handle.Kind),
        };
    }
}
