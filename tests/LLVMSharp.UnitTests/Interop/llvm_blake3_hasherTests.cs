// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-18.1.3/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop.UnitTests;

/// <summary>Provides validation of the <see cref="llvm_blake3_hasher" /> struct.</summary>
public static unsafe partial class @llvm_blake3_hasherTests
{
    /// <summary>Validates that the <see cref="llvm_blake3_hasher" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<llvm_blake3_hasher>(), Is.EqualTo(sizeof(llvm_blake3_hasher)));
    }

    /// <summary>Validates that the <see cref="llvm_blake3_hasher" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(llvm_blake3_hasher).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="llvm_blake3_hasher" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(llvm_blake3_hasher), Is.EqualTo(1912));
    }
}
