// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LLVMSharp.UnitTests;

[Platform(Exclude = "32-bit")]
public class IR
{
    [Test]
    public void AddsSigned()
    {
        var op1 = 0;
        var op2 = 0;
        using var module = LLVMModuleRef.CreateWithName("test_add");

        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int32, "add", [LLVMTypeRef.Int32, LLVMTypeRef.Int32], (f, b) =>
            {
            var p1 = f.GetParam(0);
            var p2 = f.GetParam(1);
            var add = b.BuildAdd(p1, p2);
            var ret = b.BuildRet(add);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Int32Int32Delegate>(def);
        var result = op1 + op2;
        Assert.AreEqual(result, func(op1, op2));
    }

    [Test]
    public void ShiftsRight([Range(0, 256)] int op1, [Range(0, 8)] int op2)
    {
        using var module = LLVMModuleRef.CreateWithName("test_lshift");

        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int32, "lshift", [LLVMTypeRef.Int32, LLVMTypeRef.Int32], (f, b) =>
            {
            var p1 = f.GetParam(0);
            var p2 = f.GetParam(1);
            var shift = b.BuildLShr(p1, p2);
            var ret = b.BuildRet(shift);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Int32Int32Delegate>(def);
        var result = op1 >> op2;
        Assert.AreEqual(result, func(op1, op2));
    }

    [Test]
    public void ComparesGreaterThan([Range(0, 10)] int op1, [Range(0, 10)] int op2)
    {
        using var module = LLVMModuleRef.CreateWithName("test_greaterthan");

        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int1, "greaterthan", [LLVMTypeRef.Int32, LLVMTypeRef.Int32], (f, b) =>
            {
            var p1 = f.GetParam(0);
            var p2 = f.GetParam(1);
            var cmp = b.BuildICmp(LLVMIntPredicate.LLVMIntSGT, p1, p2);
            var ret = b.BuildRet(cmp);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Int32Int8Delegate>(def);
        var result = op1 > op2 ? 1 : 0;
        Assert.AreEqual(result, func(op1, op2));
    }

    [Test]
    public void CallsFunction([Range(0, 10)] int op1, [Range(0, 10)] int op2)
    {
        using var module = LLVMModuleRef.CreateWithName("test_call");

        (var addType, var addDef) = module.AddFunction(
            LLVMTypeRef.Int32, "add", [LLVMTypeRef.Int32, LLVMTypeRef.Int32], (f, b) =>
            {
            var p1 = f.GetParam(0);
            var p2 = f.GetParam(1);
            var add = b.BuildAdd(p1, p2);
            var ret = b.BuildRet(add);
            });
        (_, var entryDef) = module.AddFunction(
            LLVMTypeRef.Int32, "entry", [LLVMTypeRef.Int32, LLVMTypeRef.Int32], (f, b) =>
            {
                var call = b.BuildCall2(addType, addDef, f.GetParams(), "");
                var ret = b.BuildRet(call);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Int32Int32Delegate>(entryDef);
        var result = op1 + op2;
        Assert.AreEqual(result, func(op1, op2));
    }

    [Test]
    public void ReturnsConstant([Range(0, 10)] int input)
    {
        var uInput = (uint)input;
        using var module = LLVMModuleRef.CreateWithName("test_constant");

        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int32, "constant", [], (f, b) =>
            {
            var value = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, uInput);
            var ret = b.BuildRet(value);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Delegate>(def);
        Assert.AreEqual(input, func());
    }

    [Test]
    public void ReturnsSizeOf()
    {
        using var module = LLVMModuleRef.CreateWithName("test_sizeof");

        var str = LLVMTypeRef.CreateStruct(new[] { LLVMTypeRef.Int32, LLVMTypeRef.Int32 }, true);
        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int32, "structure", [], (f, b) =>
            {
                var sz = str.SizeOf;
                var sz32 = b.BuildIntCast(sz, LLVMTypeRef.Int32);
                var ret = b.BuildRet(sz32);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var func = engine.GetPointerToGlobal<Int32Delegate>(def);
        Assert.AreEqual(8, func());
    }
}
