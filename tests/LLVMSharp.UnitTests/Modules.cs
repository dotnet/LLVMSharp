// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;
using NUnit.Framework;

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
    }
}
