// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace LLVMSharp;

public partial class Instruction
{
    public enum TermOps
    {
        Unknown = 0,
        Ret = 1,
        UncondBr = 2,
        CondBr = 3,
        Switch = 4,
        IndirectBr = 5,
        Invoke = 6,
        Resume = 7,
        Unreachable = 8,
        CleanupRet = 9,
        CatchRet = 10,
        CatchSwitch = 11,
        CallBr = 12,
    }
}
