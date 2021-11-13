// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests
{
    class TargetData
    {
        [Test]
        public void OffsetTest()
        {
            LLVMModuleRef m = LLVMModuleRef.CreateWithName("netscripten");
            LLVMExecutionEngineRef engineRef = m.CreateExecutionEngine();
            LLVMTargetDataRef target = engineRef.TargetData;
            LLVMTypeRef testStruct = LLVMTypeRef.CreateStruct(
                new[]
                {
                    LLVMTypeRef.Int16,
                    LLVMTypeRef.Int32
                }, true);

            Assert.AreEqual(0, target.OffsetOfElement(testStruct, 0));
            Assert.AreEqual(2, target.OffsetOfElement(testStruct, 1));

            Assert.AreEqual(target.ElementAtOffset(testStruct, 0), 0);
            Assert.AreEqual(target.ElementAtOffset(testStruct, 2), 1);
        }

        [Test]
        public void SizeTest()
        {
            LLVMModuleRef m = LLVMModuleRef.CreateWithName("netscripten");
            LLVMExecutionEngineRef engineRef = m.CreateExecutionEngine();
            LLVMTargetDataRef target = engineRef.TargetData;
            LLVMTypeRef testStruct = LLVMTypeRef.CreateStruct(
                new[]
                {
                    LLVMTypeRef.Int16,
                    LLVMTypeRef.Int32
                }, true);

            Assert.AreEqual(48, target.SizeOfTypeInBits(testStruct));
            Assert.AreEqual(6, target.StoreSizeOfType(testStruct));
            Assert.AreEqual(6, target.ABISizeOfType(testStruct));
        }

        [Test]
        public void AlignmentTest()
        {
            LLVMModuleRef m = LLVMModuleRef.CreateWithName("netscripten");
            m.Target = "wasm32-unknown-unknown-wasm";
            m.DataLayout = "e-m:e-p:32:32-i64:64-n32:64-S128";
            LLVMExecutionEngineRef engineRef = m.CreateExecutionEngine();
            LLVMTargetDataRef target = engineRef.TargetData;
            LLVMTypeRef testStruct = LLVMTypeRef.CreateStruct(
                new[]
                {
                    LLVMTypeRef.Int16,
                    LLVMTypeRef.Int32
                }, true);

            Assert.AreEqual(1, target.ABIAlignmentOfType(testStruct));
            Assert.AreEqual(1, target.CallFrameAlignmentOfType(testStruct));
            Assert.AreEqual(8, target.PreferredAlignmentOfType(testStruct));

            LLVMValueRef global = m.AddGlobal(LLVMTypeRef.CreatePointer(LLVMTypeRef.Int8, 0), "someGlobal");
            Assert.AreEqual(4, target.PreferredAlignmentOfGlobal(global));
        }

        private LLVMTargetDataRef TargetDataFromTriple(string triple)
        {
            LLVMTargetRef target = LLVMTargetRef.GetTargetFromTriple(triple);
            LLVMTargetMachineRef targetMachine = target.CreateTargetMachine(triple, "", "",
                LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault, LLVMRelocMode.LLVMRelocDefault,
                LLVMCodeModel.LLVMCodeModelDefault);
            return targetMachine.CreateTargetDataLayout();
        }

        [Test]
        public void MachineTest()
        {
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetMC();

            LLVMTypeRef pointerType = LLVMTypeRef.CreatePointer(LLVMTypeRef.Int32, 0);
            LLVMTargetDataRef x86 = TargetDataFromTriple("i386-unknown-unknown");
            LLVMTargetDataRef x86_64 = TargetDataFromTriple("amd64-unknown-unknown");

            Assert.AreEqual(4, x86.ABISizeOfType(pointerType));
            Assert.AreEqual(8, x86_64.ABISizeOfType(pointerType));
        }
    }
}
