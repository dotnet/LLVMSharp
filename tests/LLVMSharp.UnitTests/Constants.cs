// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Constants
{
    [Test]
    public void CreateConstRealRejectsNonFloatingPointType()
    {
        // Regression for dotnet/LLVMSharp#194: ConstReal on an integer type is invalid usage
        // that previously produced corrupt IR (ppc_fp128) or crashed the raw binding.
        var ex = Assert.Throws<ArgumentException>(() => LLVMValueRef.CreateConstReal(LLVMTypeRef.Int32, 8));
        Assert.That(ex!.ParamName, Is.EqualTo("RealTy"));
    }

    [Test]
    public void CreateConstRealAcceptsFloatingPointType([Values] bool useVector)
    {
        var ty = useVector ? LLVMTypeRef.CreateVector(LLVMTypeRef.Double, 2) : LLVMTypeRef.Double;
        var value = LLVMValueRef.CreateConstReal(ty, 8);
        Assert.That(value.Handle, Is.Not.EqualTo(IntPtr.Zero));
    }
}
