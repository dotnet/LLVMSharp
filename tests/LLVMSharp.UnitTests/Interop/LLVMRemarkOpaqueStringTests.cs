// Copyright (c) .NET Foundation and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-12.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="LLVMRemarkOpaqueString" /> struct.</summary>
    public static unsafe class LLVMRemarkOpaqueStringTests
    {
        /// <summary>Validates that the <see cref="LLVMRemarkOpaqueString" /> struct is blittable.</summary>
        [Test]
        public static void IsBlittableTest()
        {
            Assert.That(Marshal.SizeOf<LLVMRemarkOpaqueString>(), Is.EqualTo(sizeof(LLVMRemarkOpaqueString)));
        }

        /// <summary>Validates that the <see cref="LLVMRemarkOpaqueString" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Test]
        public static void IsLayoutSequentialTest()
        {
            Assert.That(typeof(LLVMRemarkOpaqueString).IsLayoutSequential, Is.True);
        }

        /// <summary>Validates that the <see cref="LLVMRemarkOpaqueString" /> struct has the correct size.</summary>
        [Test]
        public static void SizeOfTest()
        {
            Assert.That(sizeof(LLVMRemarkOpaqueString), Is.EqualTo(1));
        }
    }
}
