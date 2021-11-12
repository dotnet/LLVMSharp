// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
