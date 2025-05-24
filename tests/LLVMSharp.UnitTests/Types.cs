// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Collections.Generic;
using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Types
{
    [Test]
    public void IntSizes([Values(1, 8, 16, 32, 64)] int width)
    {
        var uWidth = (uint)width;
        var t = LLVMContextRef.Global.GetIntType(uWidth);
        Assert.That(t.IntWidth, Is.EqualTo(uWidth));
    }

    [Test]
    public void FloatingTypes()
    {
        var dic = new Dictionary<LLVMTypeRef, LLVMTypeKind>
        {
            { LLVMContextRef.Global.VoidType, LLVMTypeKind.LLVMVoidTypeKind },
            { LLVMContextRef.Global.Int32Type, LLVMTypeKind.LLVMIntegerTypeKind },
            { LLVMContextRef.Global.LabelType, LLVMTypeKind.LLVMLabelTypeKind },

            { LLVMContextRef.Global.HalfType, LLVMTypeKind.LLVMHalfTypeKind },
            { LLVMContextRef.Global.FloatType, LLVMTypeKind.LLVMFloatTypeKind },
            { LLVMContextRef.Global.DoubleType, LLVMTypeKind.LLVMDoubleTypeKind },
            { LLVMContextRef.Global.FP128Type, LLVMTypeKind.LLVMFP128TypeKind },
            { LLVMContextRef.Global.X86FP80Type, LLVMTypeKind.LLVMX86_FP80TypeKind},
            { LLVMContextRef.Global.PPCFP128Type, LLVMTypeKind.LLVMPPC_FP128TypeKind },
        };
        foreach (var p in dic.Keys)
        {
            Assert.That(p.Kind, Is.EqualTo(dic[p]));
        }
    }
}
