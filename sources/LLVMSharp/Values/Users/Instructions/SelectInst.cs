// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class SelectInst : Instruction
{
    internal SelectInst(LLVMValueRef handle) : base(handle.IsASelectInst)
    {
    }

    public Value Condition => GetOperand(0);

    public Value FalseValue => GetOperand(2);

    public Value TrueValue => GetOperand(1);
}
