// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class ICmpInst : CmpInst
{
    internal ICmpInst(LLVMValueRef handle) : base(handle.IsAICmpInst)
    {
    }

    public bool HasSameSign
    {
        get
        {
            return Handle.ICmpSameSign;
        }

        set
        {
            var handle = Handle;
            handle.ICmpSameSign = value;
        }
    }

    public static new bool IsEquality(Predicate predicate) => predicate is Predicate.ICMP_EQ or Predicate.ICMP_NE;

    public static Predicate GetSignedPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_EQ or Predicate.ICMP_NE or
        Predicate.ICMP_SGT or Predicate.ICMP_SLT or Predicate.ICMP_SGE or Predicate.ICMP_SLE => predicate,
        Predicate.ICMP_UGT => Predicate.ICMP_SGT,
        Predicate.ICMP_ULT => Predicate.ICMP_SLT,
        Predicate.ICMP_UGE => Predicate.ICMP_SGE,
        Predicate.ICMP_ULE => Predicate.ICMP_SLE,
        _ => throw new ArgumentOutOfRangeException(nameof(predicate)),
    };

    public static Predicate GetUnsignedPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_EQ or Predicate.ICMP_NE or
        Predicate.ICMP_UGT or Predicate.ICMP_ULT or Predicate.ICMP_UGE or Predicate.ICMP_ULE => predicate,
        Predicate.ICMP_SGT => Predicate.ICMP_UGT,
        Predicate.ICMP_SLT => Predicate.ICMP_ULT,
        Predicate.ICMP_SGE => Predicate.ICMP_UGE,
        Predicate.ICMP_SLE => Predicate.ICMP_ULE,
        _ => throw new ArgumentOutOfRangeException(nameof(predicate)),
    };
}
