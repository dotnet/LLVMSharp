// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;
using NUnit.Framework;
using System;

namespace LLVMSharp.UnitTests
{
    public class Modules
    {
        [Test]
        public void SetsAndGetsDataLayout()
        {
            var module = LLVMModuleRef.CreateWithName("test");
            {
                const string ExampleDataLayout = "e-m:e-p:32:32-f64:32:64-f80:32-n8:16:32-S128";
                module.DataLayout = ExampleDataLayout;
                Assert.AreEqual(ExampleDataLayout, module.DataLayout);
            }
            module.Dispose();
        }

        [Test]
        public void SetsAndGetsTarget()
        {
            var module = LLVMModuleRef.CreateWithName("test");
            {
                const string ExampleTarget = "x86_64-pc-windows-msvc";
                module.Target = ExampleTarget;
                Assert.AreEqual(ExampleTarget, module.Target);
            }
            module.Dispose();
        }

        [Test(Description = "Tests that LLVMModuleFlagBehavior is properly defined as a 0-based enum for use in AddModuleFlag")]
        /// <summary>Verifies that <see cref="LLVMModuleFlagBehavior"/> is defined as expected by <see cref="AddModuleFlag"/>
        /// so that there isn't unexpected behavior when modules with conflicting flags are linked.
        /// This test is relevant because AddModuleFlag expects a 0-based behavior enum (where 1 defines warning),
        /// while AddNamedMetadataOperand(the other method of adding a module flag) expects a 1-based behavior
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
                LLVMModuleRef.LinkModules(module1, module2);
            }
            catch (AccessViolationException)
            {
                // Fail doesn't actually get called. The test will simply be aborted if we reach this point, but the catch block cleans up the error output
                Assert.Fail("Conflicting module flags that were defined with LLVMModuleFlagBehaviorWarning should not have caused an error.");
            }
        }
    }
}
