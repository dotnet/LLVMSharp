// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-12.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using NUnit.Framework;
using System.Runtime.InteropServices;
using System;

namespace LLVMSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="LLVMOpaqueModule" /> struct.</summary>
    public static unsafe class LLVMOpaqueModuleTests
    {
        /// <summary>Validates that the <see cref="LLVMOpaqueModule" /> struct is blittable.</summary>
        [Test]
        public static void IsBlittableTest()
        {
            Assert.That(Marshal.SizeOf<LLVMOpaqueModule>(), Is.EqualTo(sizeof(LLVMOpaqueModule)));
        }

        /// <summary>Validates that the <see cref="LLVMOpaqueModule" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Test]
        public static void IsLayoutSequentialTest()
        {
            Assert.That(typeof(LLVMOpaqueModule).IsLayoutSequential, Is.True);
        }

        /// <summary><see cref="LLVMOpaqueModule" /> struct should have the correct size of 1.</summary>
        [Test]
        public static void SizeOfTest()
        {
            Assert.That(sizeof(LLVMOpaqueModule), Is.EqualTo(1), "LLVMOpaqueModule struct should have the correct size 1");
        }

        [Test(Description = "Tests that LLVMModuleFlagBehavior is properly defined as a 0-based enum for use in AddModuleFlag")]
        /// <summary>Verifies that <see cref="LLVMModuleFlagBehavior"/> is defined as expected by <see cref="AddModuleFlag"/>
        /// so that there isn't unexpected behavior when modules with conflicting flags are linked.
        /// This test is relevant because AddModuleFlag expects a 0-based behavior enum (where 1 defines warning),
        /// while the other method of adding a module flag (AddNamedMetadataOperand) expects a 1-based behavior
        /// (where 1 defines error).</summary>
        public static void TestBehaviorOfLinkingConflictingModules()
        {
            // set up two modules
            LLVMModuleRef module1 = LLVMModuleRef.CreateWithName("module1");
            LLVMModuleRef module2 = LLVMModuleRef.CreateWithName("module2");

            // Add conflicting module flags to module1 and module2 using LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning
            // which should only cause a warning, and not an error
            string flagName = "madeUpFlagName";
            uint value1 = 1;
            uint value2 = 2;

            module1.AddModuleFlag(flagName, LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning, value1);
            module2.AddModuleFlag(flagName, LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning, value2);

            // linking the modules should cause a warning, not an error
            try
            {
                LLVM.LinkModules2(module1, module2);
            }
            catch (AccessViolationException)
            {
                // Fail doesn't actually get called. The test will simply be aborted if we reach this point, but the catch block cleans up the error output
                Assert.Fail("Conflicting module flags that were defined with LLVMModuleFlagBehaviorWarning should not have caused an error.");
            }
        }
    }
}
