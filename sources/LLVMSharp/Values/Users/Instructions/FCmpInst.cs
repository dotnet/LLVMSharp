// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class FCmpInst : CmpInst
{
    internal FCmpInst(LLVMValueRef handle) : base(handle.IsAFCmpInst)
    {
    }

    public static new bool IsEquality(Predicate predicate) => predicate is Predicate.FCMP_OEQ or Predicate.FCMP_ONE or Predicate.FCMP_UEQ or Predicate.FCMP_UNE;

    public bool IsOrdered() => IsOrdered(GetPredicate());

    public bool IsUnordered() => IsUnordered(GetPredicate());
}
