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

    [Test]
    public void CreateConstIntRejectsNonIntegerType()
    {
        // Integer-side analogue of #194: ConstInt on a non-integer type silently produced 'i0 0'.
        var ex = Assert.Throws<ArgumentException>(() => LLVMValueRef.CreateConstInt(LLVMTypeRef.Double, 8));
        Assert.That(ex!.ParamName, Is.EqualTo("IntTy"));
    }

    [Test]
    public void CreateConstIntAcceptsIntegerType()
    {
        var value = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 8);
        Assert.That(value.Handle, Is.Not.EqualTo(IntPtr.Zero));
    }

    [Test]
    public void CreateConstIntToPtrRejectsNonIntegerSource()
    {
        // Mirrors ConstantExpr::getIntToPtr's "source must be integer" assert.
        var ptrTy = LLVMTypeRef.CreatePointer(LLVMTypeRef.Int8, 0);
        var notAnInt = LLVMValueRef.CreateConstNull(ptrTy);
        var ex = Assert.Throws<ArgumentException>(() => LLVMValueRef.CreateConstIntToPtr(notAnInt, ptrTy));
        Assert.That(ex!.ParamName, Is.EqualTo("ConstantVal"));
    }

    [Test]
    public void CreateConstIntToPtrRejectsNonPointerDestination()
    {
        // Mirrors ConstantExpr::getIntToPtr's "destination must be a pointer" assert.
        var intVal = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, 0);
        var ex = Assert.Throws<ArgumentException>(() => LLVMValueRef.CreateConstIntToPtr(intVal, LLVMTypeRef.Int32));
        Assert.That(ex!.ParamName, Is.EqualTo("ToType"));
    }

    [Test]
    public void CreateConstPtrToIntRejectsNonPointerSource()
    {
        // Mirrors ConstantExpr::getPtrToInt's "source must be pointer" assert.
        var intVal = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, 0);
        var ex = Assert.Throws<ArgumentException>(() => LLVMValueRef.CreateConstPtrToInt(intVal, LLVMTypeRef.Int32));
        Assert.That(ex!.ParamName, Is.EqualTo("ConstantVal"));
    }

    [Test]
    public void CreateConstPtrToIntAcceptsPointerSourceAndIntegerDestination()
    {
        var ptrTy = LLVMTypeRef.CreatePointer(LLVMTypeRef.Int8, 0);
        var ptrVal = LLVMValueRef.CreateConstNull(ptrTy);
        var value = LLVMValueRef.CreateConstPtrToInt(ptrVal, LLVMTypeRef.Int64);
        Assert.That(value.Handle, Is.Not.EqualTo(IntPtr.Zero));
    }
}
