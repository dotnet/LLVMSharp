// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
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
    }
}
