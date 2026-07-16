// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using LLVMSharp.Interop;

namespace LLVMSharp;

public partial class CmpInst : Instruction
{
    private protected CmpInst(LLVMValueRef handle) : base(handle.IsACmpInst)
    {
    }

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getPredicate(); the 'Predicate' name is the nested predicate enum type.")]
    public Predicate GetPredicate() => (Handle.IsAICmpInst != null) ? (Predicate)Handle.ICmpPredicate : (Predicate)Handle.FCmpPredicate;

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getInversePredicate(); overloads the static predicate transform.")]
    public Predicate GetInversePredicate() => GetInversePredicate(GetPredicate());

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getSwappedPredicate(); overloads the static predicate transform.")]
    public Predicate GetSwappedPredicate() => GetSwappedPredicate(GetPredicate());

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getOrderedPredicate(); overloads the static predicate transform.")]
    public Predicate GetOrderedPredicate() => GetOrderedPredicate(GetPredicate());

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getUnorderedPredicate(); overloads the static predicate transform.")]
    public Predicate GetUnorderedPredicate() => GetUnorderedPredicate(GetPredicate());

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getStrictPredicate(); overloads the static predicate transform.")]
    public Predicate GetStrictPredicate() => GetStrictPredicate(GetPredicate());

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Mirrors C++ CmpInst::getNonStrictPredicate(); overloads the static predicate transform.")]
    public Predicate GetNonStrictPredicate() => GetNonStrictPredicate(GetPredicate());

    public bool IsFPPredicate() => IsFPPredicate(GetPredicate());

    public bool IsIntPredicate() => IsIntPredicate(GetPredicate());

    public bool IsStrictPredicate() => IsStrictPredicate(GetPredicate());

    public bool IsEquality() => IsEquality(GetPredicate());

    public bool IsRelational() => IsRelational(GetPredicate());

    public bool IsSigned() => IsSigned(GetPredicate());

    public bool IsUnsigned() => IsUnsigned(GetPredicate());

    public bool IsTrueWhenEqual() => IsTrueWhenEqual(GetPredicate());

    public bool IsFalseWhenEqual() => IsFalseWhenEqual(GetPredicate());

    internal static new CmpInst Create(LLVMValueRef handle) => handle switch
    {
        _ when handle.IsAFCmpInst != null => new FCmpInst(handle),
        _ when handle.IsAICmpInst != null => new ICmpInst(handle),
        _ => new CmpInst(handle),
    };
}
