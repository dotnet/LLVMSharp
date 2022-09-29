// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-15.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop.UnitTests;

/// <summary>Provides validation of the <see cref="LLVMJITSymbolFlags" /> struct.</summary>
public static unsafe partial class LLVMJITSymbolFlagsTests
{
    /// <summary>Validates that the <see cref="LLVMJITSymbolFlags" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<LLVMJITSymbolFlags>(), Is.EqualTo(sizeof(LLVMJITSymbolFlags)));
    }

    /// <summary>Validates that the <see cref="LLVMJITSymbolFlags" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(LLVMJITSymbolFlags).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="LLVMJITSymbolFlags" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(LLVMJITSymbolFlags), Is.EqualTo(2));
    }
}
