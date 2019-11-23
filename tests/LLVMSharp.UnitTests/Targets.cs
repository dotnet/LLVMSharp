// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using System.Linq;
using NUnit.Framework;

namespace LLVMSharp.UnitTests
{
    public class Targets
    {
        [Test]
        public void InitializeX86Targets() => this.InitializeTargets(() =>
        {
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86AsmParser();
            LLVM.InitializeX86AsmPrinter();
        }, new[] { "x86" });

        [Test]
        public void InitializeARMTargets() => this.InitializeTargets(() =>
        {
            LLVM.InitializeARMTargetInfo();
            LLVM.InitializeARMTarget();
            LLVM.InitializeARMTargetMC();
            LLVM.InitializeARMAsmParser();
            LLVM.InitializeARMAsmPrinter();
        }, new[] { "arm" });
       
        private void InitializeTargets(Action init, string[] expectedTargets)
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
}
