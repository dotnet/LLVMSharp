// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public partial class CmpInst
{
    public enum Predicate
    {
        FCMP_FALSE = LLVMRealPredicate.LLVMRealPredicateFalse,
        FCMP_OEQ = LLVMRealPredicate.LLVMRealOEQ,
        FCMP_OGT = LLVMRealPredicate.LLVMRealOGT,
        FCMP_OGE = LLVMRealPredicate.LLVMRealOGE,
        FCMP_OLT = LLVMRealPredicate.LLVMRealOLT,
        FCMP_OLE = LLVMRealPredicate.LLVMRealOLE,
        FCMP_ONE = LLVMRealPredicate.LLVMRealONE,
        FCMP_ORD = LLVMRealPredicate.LLVMRealORD,
        FCMP_UNO = LLVMRealPredicate.LLVMRealUNO,
        FCMP_UEQ = LLVMRealPredicate.LLVMRealUEQ,
        FCMP_UGT = LLVMRealPredicate.LLVMRealUGT,
        FCMP_UGE = LLVMRealPredicate.LLVMRealUGE,
        FCMP_ULT = LLVMRealPredicate.LLVMRealULT,
        FCMP_ULE = LLVMRealPredicate.LLVMRealULE,
        FCMP_UNE = LLVMRealPredicate.LLVMRealUNE,
        FCMP_TRUE = LLVMRealPredicate.LLVMRealPredicateTrue,

        ICMP_EQ = LLVMIntPredicate.LLVMIntEQ,
        ICMP_NE = LLVMIntPredicate.LLVMIntNE,
        ICMP_UGT = LLVMIntPredicate.LLVMIntUGT,
        ICMP_UGE = LLVMIntPredicate.LLVMIntUGE,
        ICMP_ULT = LLVMIntPredicate.LLVMIntULT,
        ICMP_ULE = LLVMIntPredicate.LLVMIntULE,
        ICMP_SGT = LLVMIntPredicate.LLVMIntSGT,
        ICMP_SGE = LLVMIntPredicate.LLVMIntSGE,
        ICMP_SLT = LLVMIntPredicate.LLVMIntSLT,
        ICMP_SLE = LLVMIntPredicate.LLVMIntSLE,
    }

    public static bool IsFPPredicate(Predicate predicate) => predicate <= Predicate.FCMP_TRUE;

    public static bool IsIntPredicate(Predicate predicate) => predicate is >= Predicate.ICMP_EQ and <= Predicate.ICMP_SLE;

    public static Predicate GetInversePredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_EQ => Predicate.ICMP_NE,
        Predicate.ICMP_NE => Predicate.ICMP_EQ,
        Predicate.ICMP_UGT => Predicate.ICMP_ULE,
        Predicate.ICMP_ULT => Predicate.ICMP_UGE,
        Predicate.ICMP_UGE => Predicate.ICMP_ULT,
        Predicate.ICMP_ULE => Predicate.ICMP_UGT,
        Predicate.ICMP_SGT => Predicate.ICMP_SLE,
        Predicate.ICMP_SLT => Predicate.ICMP_SGE,
        Predicate.ICMP_SGE => Predicate.ICMP_SLT,
        Predicate.ICMP_SLE => Predicate.ICMP_SGT,
        Predicate.FCMP_OEQ => Predicate.FCMP_UNE,
        Predicate.FCMP_ONE => Predicate.FCMP_UEQ,
        Predicate.FCMP_OGT => Predicate.FCMP_ULE,
        Predicate.FCMP_OLT => Predicate.FCMP_UGE,
        Predicate.FCMP_OGE => Predicate.FCMP_ULT,
        Predicate.FCMP_OLE => Predicate.FCMP_UGT,
        Predicate.FCMP_UEQ => Predicate.FCMP_ONE,
        Predicate.FCMP_UNE => Predicate.FCMP_OEQ,
        Predicate.FCMP_UGT => Predicate.FCMP_OLE,
        Predicate.FCMP_ULT => Predicate.FCMP_OGE,
        Predicate.FCMP_UGE => Predicate.FCMP_OLT,
        Predicate.FCMP_ULE => Predicate.FCMP_OGT,
        Predicate.FCMP_ORD => Predicate.FCMP_UNO,
        Predicate.FCMP_UNO => Predicate.FCMP_ORD,
        Predicate.FCMP_TRUE => Predicate.FCMP_FALSE,
        Predicate.FCMP_FALSE => Predicate.FCMP_TRUE,
        _ => throw new ArgumentOutOfRangeException(nameof(predicate)),
    };

    public static Predicate GetOrderedPredicate(Predicate predicate) => (Predicate)((int)predicate & (int)Predicate.FCMP_ORD);

    public static Predicate GetUnorderedPredicate(Predicate predicate) => (Predicate)((int)predicate | (int)Predicate.FCMP_UNO);

    public static Predicate GetSwappedPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_SGT => Predicate.ICMP_SLT,
        Predicate.ICMP_SLT => Predicate.ICMP_SGT,
        Predicate.ICMP_SGE => Predicate.ICMP_SLE,
        Predicate.ICMP_SLE => Predicate.ICMP_SGE,
        Predicate.ICMP_UGT => Predicate.ICMP_ULT,
        Predicate.ICMP_ULT => Predicate.ICMP_UGT,
        Predicate.ICMP_UGE => Predicate.ICMP_ULE,
        Predicate.ICMP_ULE => Predicate.ICMP_UGE,
        Predicate.FCMP_OGT => Predicate.FCMP_OLT,
        Predicate.FCMP_OLT => Predicate.FCMP_OGT,
        Predicate.FCMP_OGE => Predicate.FCMP_OLE,
        Predicate.FCMP_OLE => Predicate.FCMP_OGE,
        Predicate.FCMP_UGT => Predicate.FCMP_ULT,
        Predicate.FCMP_ULT => Predicate.FCMP_UGT,
        Predicate.FCMP_UGE => Predicate.FCMP_ULE,
        Predicate.FCMP_ULE => Predicate.FCMP_UGE,
        _ => predicate,
    };

    public static bool IsStrictPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_SGT or Predicate.ICMP_SLT or Predicate.ICMP_UGT or Predicate.ICMP_ULT or
        Predicate.FCMP_OGT or Predicate.FCMP_OLT or Predicate.FCMP_UGT or Predicate.FCMP_ULT => true,
        _ => false,
    };

    public static Predicate GetStrictPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_SGE => Predicate.ICMP_SGT,
        Predicate.ICMP_SLE => Predicate.ICMP_SLT,
        Predicate.ICMP_UGE => Predicate.ICMP_UGT,
        Predicate.ICMP_ULE => Predicate.ICMP_ULT,
        Predicate.FCMP_OGE => Predicate.FCMP_OGT,
        Predicate.FCMP_OLE => Predicate.FCMP_OLT,
        Predicate.FCMP_UGE => Predicate.FCMP_UGT,
        Predicate.FCMP_ULE => Predicate.FCMP_ULT,
        _ => predicate,
    };

    public static Predicate GetNonStrictPredicate(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_SGT => Predicate.ICMP_SGE,
        Predicate.ICMP_SLT => Predicate.ICMP_SLE,
        Predicate.ICMP_UGT => Predicate.ICMP_UGE,
        Predicate.ICMP_ULT => Predicate.ICMP_ULE,
        Predicate.FCMP_OGT => Predicate.FCMP_OGE,
        Predicate.FCMP_OLT => Predicate.FCMP_OLE,
        Predicate.FCMP_UGT => Predicate.FCMP_UGE,
        Predicate.FCMP_ULT => Predicate.FCMP_ULE,
        _ => predicate,
    };

    public static bool IsEquality(Predicate predicate)
    {
        if (IsIntPredicate(predicate))
        {
            return ICmpInst.IsEquality(predicate);
        }

        if (IsFPPredicate(predicate))
        {
            return FCmpInst.IsEquality(predicate);
        }

        throw new ArgumentOutOfRangeException(nameof(predicate));
    }

    public static bool IsRelational(Predicate predicate) => !IsEquality(predicate);

    public static bool IsSigned(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_SLT or Predicate.ICMP_SLE or Predicate.ICMP_SGT or Predicate.ICMP_SGE => true,
        _ => false,
    };

    public static bool IsUnsigned(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_ULT or Predicate.ICMP_ULE or Predicate.ICMP_UGT or Predicate.ICMP_UGE => true,
        _ => false,
    };

    public static bool IsOrdered(Predicate predicate) => predicate switch
    {
        Predicate.FCMP_OEQ or Predicate.FCMP_ONE or Predicate.FCMP_OGT or
        Predicate.FCMP_OLT or Predicate.FCMP_OGE or Predicate.FCMP_OLE or Predicate.FCMP_ORD => true,
        _ => false,
    };

    public static bool IsUnordered(Predicate predicate) => predicate switch
    {
        Predicate.FCMP_UEQ or Predicate.FCMP_UNE or Predicate.FCMP_UGT or
        Predicate.FCMP_ULT or Predicate.FCMP_UGE or Predicate.FCMP_ULE or Predicate.FCMP_UNO => true,
        _ => false,
    };

    public static bool IsTrueWhenEqual(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_EQ or Predicate.ICMP_UGE or Predicate.ICMP_ULE or Predicate.ICMP_SGE or Predicate.ICMP_SLE or
        Predicate.FCMP_TRUE or Predicate.FCMP_UEQ or Predicate.FCMP_UGE or Predicate.FCMP_ULE => true,
        _ => false,
    };

    public static bool IsFalseWhenEqual(Predicate predicate) => predicate switch
    {
        Predicate.ICMP_NE or Predicate.ICMP_UGT or Predicate.ICMP_ULT or Predicate.ICMP_SGT or Predicate.ICMP_SLT or
        Predicate.FCMP_FALSE or Predicate.FCMP_ONE or Predicate.FCMP_OGT or Predicate.FCMP_OLT => true,
        _ => false,
    };
}
