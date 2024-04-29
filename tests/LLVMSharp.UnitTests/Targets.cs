// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Linq;
using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Targets
{
    [Test]
    public void InitializeX86Targets() => InitializeTargets(() =>
    {
        LLVM.InitializeX86TargetInfo();
        LLVM.InitializeX86Target();
        LLVM.InitializeX86TargetMC();
        LLVM.InitializeX86AsmParser();
        LLVM.InitializeX86AsmPrinter();
    }, ["x86"]);

    [Test]
    public void InitializeARMTargets() => InitializeTargets(() =>
    {
        LLVM.InitializeARMTargetInfo();
        LLVM.InitializeARMTarget();
        LLVM.InitializeARMTargetMC();
        LLVM.InitializeARMAsmParser();
        LLVM.InitializeARMAsmPrinter();
    }, ["arm"]);
   
    private static void InitializeTargets(Action init, string[] expectedTargets)
    {
        init();

        foreach (var u in LLVMTargetRef.Targets)
        {
            u.EnsurePropertiesWork();
        }
        foreach (var t in expectedTargets)
        {
            Assert.IsTrue(LLVMTargetRef.Targets.Any(x => x.Name == t));
        }
    }

    [Test]
    public void DefaultTargetTriple()
    {
        var str = LLVMTargetRef.DefaultTriple;
        Assert.Greater(str.Length, 0);
    }
}
