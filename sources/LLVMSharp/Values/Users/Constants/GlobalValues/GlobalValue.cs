// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class GlobalValue : Constant
    {
        private protected GlobalValue(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAGlobalValue, expectedValueKind)
        {
        }

        public uint Alignment
        {
            get => Handle.Alignment;
            set => Handle.SetAlignment(value);
        }

        internal new static GlobalValue Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAGlobalAlias != null => new GlobalAlias(handle),
            _ when handle.IsAGlobalIFunc != null => new GlobalIFunc(handle),
            _ when handle.IsAGlobalObject != null => GlobalObject.Create(handle),
            _ => new GlobalValue(handle, handle.Kind),
        };
    }
}
