// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.InteropServices;
using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Examples
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int BinaryInt32Operation(int op1, int op2);

    [Test]
    public void Intro()
    {
        using var module = LLVMModuleRef.CreateWithName("LLVMSharpIntro");

        (_, var def) = module.AddFunction(
            LLVMTypeRef.Int32, "sum", new[] { LLVMTypeRef.Int32, LLVMTypeRef.Int32 }, (f, b) =>
            {
                var p1 = f.Params[0];
                var p2 = f.Params[1];
                var add = b.BuildAdd(p1, p2);
                var ret = b.BuildRet(add);
            });
        module.Verify(LLVMVerifierFailureAction.LLVMPrintMessageAction);

        _ = LLVM.InitializeNativeTarget();
        _ = LLVM.InitializeNativeAsmParser();
        _ = LLVM.InitializeNativeAsmPrinter();

        var engine = module.CreateMCJITCompiler();
        var function = engine.GetPointerToGlobal<BinaryInt32Operation>(def);
        var result = function(2, 2);
        Assert.AreEqual(4, result);
    }
}

