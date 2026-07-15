// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class LandingPadInst : Instruction
{
    internal LandingPadInst(LLVMValueRef handle) : base(handle.IsALandingPadInst)
    {
    }

    public bool IsCleanup
    {
        get
        {
            return Handle.IsCleanup;
        }

        set
        {
            var handle = Handle;
            handle.IsCleanup = value;
        }
    }

    public uint NumClauses => Handle.NumClauses;

    public void AddClause(Constant clauseVal)
    {
        ArgumentNullException.ThrowIfNull(clauseVal);
        Handle.AddClause(clauseVal.Handle);
    }

    public Constant GetClause(uint index) => Context.GetOrCreate<Constant>(Handle.GetClause(index));
}
