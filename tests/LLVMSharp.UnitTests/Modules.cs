// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Modules
{
    [Test]
    public void SetsAndGetsDataLayout()
    {
        var module = LLVMModuleRef.CreateWithName("test");
        {
            const string ExampleDataLayout = "e-m:e-p:32:32-f64:32:64-f80:32-n8:16:32-S128";
            module.DataLayout = ExampleDataLayout;
            Assert.That(module.DataLayout, Is.EqualTo(ExampleDataLayout));
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
            Assert.That(module.Target, Is.EqualTo(ExampleTarget));
        }
        module.Dispose();
    }
}
