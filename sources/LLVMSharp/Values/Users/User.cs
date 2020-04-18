// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class User : Value
    {
        private protected User(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAUser, expectedValueKind)
        {
        }

        internal new static User Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAConstant != null => Constant.Create(handle),
            _ when handle.IsAInstruction != null => Instruction.Create(handle),
            _ when handle.Kind == LLVMValueKind.LLVMMemoryDefValueKind => new MemoryDef(handle),
            _ when handle.Kind == LLVMValueKind.LLVMMemoryPhiValueKind => new MemoryPhi(handle),
            _ when handle.Kind == LLVMValueKind.LLVMMemoryUseValueKind => new MemoryUse(handle),
            _ => new User(handle, handle.Kind),
        };
    }
}
