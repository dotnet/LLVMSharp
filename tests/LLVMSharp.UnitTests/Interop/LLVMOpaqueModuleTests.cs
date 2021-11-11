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

        /// <summary>Validates that the <see cref="LLVMOpaqueModule" /> struct has the correct size.</summary>
        [Test]
        public static void SizeOfTest()
        {
            TestContext.WriteLine("Testing");
            Assert.That(sizeof(LLVMOpaqueModule), Is.EqualTo(1));
        }

        [Test(Description = "Tests LLVMModuleFlagBehavior")]
        /// <summary>Validates that <see cref="LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning"/> does not cause an error.</summary>
        public static void TestLLVMModuleFlagBehavior()
        {
            // set up two modules
            LLVMModuleRef module1 = LLVMModuleRef.CreateWithName("module1");
            LLVMModuleRef module2 = LLVMModuleRef.CreateWithName("module2");

            // Add conflicting module flags to module and module2 using LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning
            // which should only cause a warning, and not an error
            string flagName = "flagname";
            LLVMValueRef value1 = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 1);
            LLVMValueRef value2 = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 2);
            ulong enumBasedBehavior = (ulong)LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning;

            var flagNode1 = LLVMValueRef.CreateMDNode(new[]
            {
                LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, enumBasedBehavior),
                module1.Context.GetMDString(flagName, (uint)flagName.Length),
                value1,
            });
            module1.AddNamedMetadataOperand("llvm.module.flags", flagNode1);

            var flagNode2 = LLVMValueRef.CreateMDNode(new[]
            {
                LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, enumBasedBehavior),
                module1.Context.GetMDString(flagName, (uint)flagName.Length),
                value2
            });
            module2.AddNamedMetadataOperand("llvm.module.flags", flagNode2);

            // linking the modules should cause a warning, not an error
            try
            {
                LLVM.LinkModules2(module1, module2);
            }
            catch (AccessViolationException)
            {
                Assert.Fail(); //  Doesn't actually get called. See note below.
            }

            // Would be nice to actually see if an error is thrown and Fail instead of crashing on an error.
            // Also would be nice to actually see if a warning is thrown. However, using a try/catch block isn't enough.
            // The warning doesn't even get caught as an Exception. And the error can be caught but not handled.
            // I'm not sure the proper way to do that.
            // Having this try catch block at least causes the output to just say
            // "The active test run was aborted. Reason: Test host process crashed :
            // error: linking module flags 'flagname': IDs have conflicting values in 'module2' and 'module1'"
            // in the case of an error instead of crashing with a giant stack trace.
        }
    }
}
