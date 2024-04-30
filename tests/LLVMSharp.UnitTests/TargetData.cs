// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public sealed class TargetData
{
    [Test]
    public void OffsetTest()
    {
        var m = LLVMModuleRef.CreateWithName("netscripten");
        var engineRef = m.CreateExecutionEngine();
        var target = engineRef.TargetData;
        var testStruct = LLVMTypeRef.CreateStruct(
            new[]
            {
                LLVMTypeRef.Int16,
                LLVMTypeRef.Int32
            }, true);

        Assert.That(target.OffsetOfElement(testStruct, 0), Is.EqualTo(0));
        Assert.That(target.OffsetOfElement(testStruct, 1), Is.EqualTo(2));

        Assert.That(target.ElementAtOffset(testStruct, 0), Is.EqualTo(0));
        Assert.That(target.ElementAtOffset(testStruct, 2), Is.EqualTo(1));
    }

    [Test]
    public void SizeTest()
    {
        var m = LLVMModuleRef.CreateWithName("netscripten");
        var engineRef = m.CreateExecutionEngine();
        var target = engineRef.TargetData;
        var testStruct = LLVMTypeRef.CreateStruct(
            new[]
            {
                LLVMTypeRef.Int16,
                LLVMTypeRef.Int32
            }, true);

        Assert.That(target.SizeOfTypeInBits(testStruct), Is.EqualTo(48));
        Assert.That(target.StoreSizeOfType(testStruct), Is.EqualTo(6));
        Assert.That(target.ABISizeOfType(testStruct), Is.EqualTo(6));
    }

    [Test]
    public void AlignmentTest()
    {
        var m = LLVMModuleRef.CreateWithName("netscripten");
        m.Target = "wasm32-unknown-unknown-wasm";
        m.DataLayout = "e-m:e-p:32:32-i64:64-n32:64-S128";
        var engineRef = m.CreateExecutionEngine();
        var target = engineRef.TargetData;
        var testStruct = LLVMTypeRef.CreateStruct(
            new[]
            {
                LLVMTypeRef.Int16,
                LLVMTypeRef.Int32
            }, true);

        Assert.That(target.ABIAlignmentOfType(testStruct), Is.EqualTo(1));
        Assert.That(target.CallFrameAlignmentOfType(testStruct), Is.EqualTo(1));
        Assert.That(target.PreferredAlignmentOfType(testStruct), Is.EqualTo(8));

        var global = m.AddGlobal(LLVMTypeRef.CreatePointer(LLVMTypeRef.Int8, 0), "someGlobal");
        Assert.That(target.PreferredAlignmentOfGlobal(global), Is.EqualTo(4));
    }

    private static LLVMTargetDataRef TargetDataFromTriple(string triple)
    {
        var target = LLVMTargetRef.GetTargetFromTriple(triple);
        var targetMachine = target.CreateTargetMachine(triple, "", "",
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

        var pointerType = LLVMTypeRef.CreatePointer(LLVMTypeRef.Int32, 0);
        var x86 = TargetDataFromTriple("i386-unknown-unknown");
        var x86_64 = TargetDataFromTriple("amd64-unknown-unknown");

        Assert.That(x86.ABISizeOfType(pointerType), Is.EqualTo(4));
        Assert.That(x86_64.ABISizeOfType(pointerType), Is.EqualTo(8));
    }
}
