// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-12.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="LTOObjectBuffer" /> struct.</summary>
    public static unsafe class LTOObjectBufferTests
    {
        /// <summary>Validates that the <see cref="LTOObjectBuffer" /> struct is blittable.</summary>
        [Test]
        public static void IsBlittableTest()
        {
            Assert.That(Marshal.SizeOf<LTOObjectBuffer>(), Is.EqualTo(sizeof(LTOObjectBuffer)));
        }

        /// <summary>Validates that the <see cref="LTOObjectBuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Test]
        public static void IsLayoutSequentialTest()
        {
            Assert.That(typeof(LTOObjectBuffer).IsLayoutSequential, Is.True);
        }

        /// <summary>Validates that the <see cref="LTOObjectBuffer" /> struct has the correct size.</summary>
        [Test]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.That(sizeof(LTOObjectBuffer), Is.EqualTo(16));
            }
            else
            {
                Assert.That(sizeof(LTOObjectBuffer), Is.EqualTo(8));
            }
        }
    }
}
