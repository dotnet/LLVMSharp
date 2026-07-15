// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace Kaleidoscope;

/// <summary>
/// Small helpers over the raw LLVM-C API that every JIT/codegen chapter needs: one-time native
/// target initialization, a host <see cref="LLVMTargetMachineRef"/>, and turning an
/// <c>LLVMErrorRef</c> into a managed exception. Kept here so the chapters read like the tutorial.
/// </summary>
public static unsafe class LlvmSupport
{
    private static bool s_targetsInitialized;

    /// <summary>Initializes the native targets (idempotent). Required before JIT or object emission.</summary>
    public static void EnsureTargetsInitialized()
    {
        if (s_targetsInitialized)
        {
            return;
        }

        LLVM.InitializeAllTargetInfos();
        LLVM.InitializeAllTargets();
        LLVM.InitializeAllTargetMCs();
        LLVM.InitializeAllAsmPrinters();
        LLVM.InitializeAllAsmParsers();

        s_targetsInitialized = true;
    }

    /// <summary>Creates a target machine for the host, used by the optimizer and object emitter.</summary>
    public static LLVMTargetMachineRef CreateHostTargetMachine()
    {
        EnsureTargetsInitialized();

        string triple = LLVMTargetRef.DefaultTriple;
        LLVMTargetRef target = LLVMTargetRef.GetTargetFromTriple(triple);

        return target.CreateTargetMachine(
            triple,
            cpu: "generic",
            features: "",
            LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault,
            LLVMRelocMode.LLVMRelocDefault,
            LLVMCodeModel.LLVMCodeModelDefault);
    }

    /// <summary>Stamps a module with the target triple and data layout for object-file emission.</summary>
    public static void PrepareModuleForEmit(LLVMModuleRef module, LLVMTargetMachineRef targetMachine)
    {
        module.Target = LLVMTargetRef.DefaultTriple;
        LLVM.SetModuleDataLayout(module, targetMachine.CreateTargetDataLayout());
    }

    /// <summary>Throws if <paramref name="error"/> is non-null, consuming and freeing the error message.</summary>
    public static void ThrowIfError(LLVMOpaqueError* error, string context)
    {
        if (error is null)
        {
            return;
        }

        sbyte* message = LLVM.GetErrorMessage(error);
        string text = new(message);
        LLVM.DisposeErrorMessage(message);

        throw new InvalidOperationException($"{context}: {text}");
    }
}
