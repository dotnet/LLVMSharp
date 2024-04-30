// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassBuilderOptionsRef(IntPtr handle) : IEquatable<LLVMPassBuilderOptionsRef>, IDisposable
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassBuilderOptionsRef(LLVMOpaquePassBuilderOptions* value) => new LLVMPassBuilderOptionsRef((IntPtr)value);

    public static implicit operator LLVMOpaquePassBuilderOptions*(LLVMPassBuilderOptionsRef value) => (LLVMOpaquePassBuilderOptions*)value.Handle;

    public static bool operator ==(LLVMPassBuilderOptionsRef left, LLVMPassBuilderOptionsRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassBuilderOptionsRef left, LLVMPassBuilderOptionsRef right) => !(left == right);

    public static LLVMPassBuilderOptionsRef Create() => LLVM.CreatePassBuilderOptions();

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposePassBuilderOptions(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMPassBuilderOptionsRef other) && Equals(other);

    public readonly bool Equals(LLVMPassBuilderOptionsRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void SetCallGraphProfile(bool CallGraphProfile) => LLVM.PassBuilderOptionsSetCallGraphProfile(this, CallGraphProfile ? 1 : 0);

    public readonly void SetDebugLogging(bool DebugLogging) => LLVM.PassBuilderOptionsSetDebugLogging(this, DebugLogging ? 1 : 0);

    public readonly void SetForgetAllSCEVInLoopUnroll(bool ForgetAllSCEVInLoopUnroll) => LLVM.PassBuilderOptionsSetForgetAllSCEVInLoopUnroll(this, ForgetAllSCEVInLoopUnroll ? 1 : 0);

    public readonly void SetInlinerThreshold(int Threshold) => LLVM.PassBuilderOptionsSetInlinerThreshold(this, Threshold);

    public readonly void SetLicmMssaNoAccForPromotionCap(uint LicmMssaNoAccForPromotionCap) => LLVM.PassBuilderOptionsSetLicmMssaNoAccForPromotionCap(this, LicmMssaNoAccForPromotionCap);

    public readonly void SetLicmMssaOptCap(uint LicmMssaOptCap) => LLVM.PassBuilderOptionsSetLicmMssaOptCap(this, LicmMssaOptCap);

    public readonly void SetLoopInterleaving(bool LoopInterleaving) => LLVM.PassBuilderOptionsSetLoopInterleaving(this, LoopInterleaving ? 1 : 0);

    public readonly void SetLoopUnrolling(bool LoopUnrolling) => LLVM.PassBuilderOptionsSetLoopUnrolling(this, LoopUnrolling ? 1 : 0);

    public readonly void SetLoopVectorization(bool LoopVectorization) => LLVM.PassBuilderOptionsSetLoopVectorization(this, LoopVectorization ? 1 : 0);

    public readonly void SetMergeFunctions(bool MergeFunctions) => LLVM.PassBuilderOptionsSetMergeFunctions(this, MergeFunctions ? 1 : 0);

    public readonly void SetSLPVectorization(bool SLPVectorization) => LLVM.PassBuilderOptionsSetSLPVectorization(this, SLPVectorization ? 1 : 0);

    public readonly void SetVerifyEach(bool VerifyEach) => LLVM.PassBuilderOptionsSetVerifyEach(this, VerifyEach ? 1 : 0);
}
