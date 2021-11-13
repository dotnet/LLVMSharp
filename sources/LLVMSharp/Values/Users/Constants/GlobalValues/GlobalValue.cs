// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
