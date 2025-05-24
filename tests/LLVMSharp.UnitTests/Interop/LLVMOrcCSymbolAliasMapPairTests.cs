// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-20.1.2/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop.UnitTests;

/// <summary>Provides validation of the <see cref="LLVMOrcCSymbolAliasMapPair" /> struct.</summary>
public static unsafe partial class LLVMOrcCSymbolAliasMapPairTests
{
    /// <summary>Validates that the <see cref="LLVMOrcCSymbolAliasMapPair" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<LLVMOrcCSymbolAliasMapPair>(), Is.EqualTo(sizeof(LLVMOrcCSymbolAliasMapPair)));
    }

    /// <summary>Validates that the <see cref="LLVMOrcCSymbolAliasMapPair" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(LLVMOrcCSymbolAliasMapPair).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="LLVMOrcCSymbolAliasMapPair" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(LLVMOrcCSymbolAliasMapPair), Is.EqualTo(24));
        }
        else
        {
            Assert.That(sizeof(LLVMOrcCSymbolAliasMapPair), Is.EqualTo(12));
        }
    }
}
