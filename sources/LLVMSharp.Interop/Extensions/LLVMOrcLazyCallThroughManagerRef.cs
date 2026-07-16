// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcLazyCallThroughManagerRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcLazyCallThroughManagerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcLazyCallThroughManagerRef(LLVMOrcOpaqueLazyCallThroughManager* value) => new LLVMOrcLazyCallThroughManagerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueLazyCallThroughManager*(LLVMOrcLazyCallThroughManagerRef value) => (LLVMOrcOpaqueLazyCallThroughManager*)value.Handle;

    public static bool operator ==(LLVMOrcLazyCallThroughManagerRef left, LLVMOrcLazyCallThroughManagerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcLazyCallThroughManagerRef left, LLVMOrcLazyCallThroughManagerRef right) => !(left == right);

    public static LLVMErrorRef CreateLocal(string TargetTriple, LLVMOrcExecutionSessionRef ES, ulong ErrorHandlerAddr, out LLVMOrcLazyCallThroughManagerRef Result) => CreateLocal(TargetTriple.AsSpan(), ES, ErrorHandlerAddr, out Result);

    public static LLVMErrorRef CreateLocal(ReadOnlySpan<char> TargetTriple, LLVMOrcExecutionSessionRef ES, ulong ErrorHandlerAddr, out LLVMOrcLazyCallThroughManagerRef Result)
    {
        using var marshaledTriple = new MarshaledString(TargetTriple);

        fixed (LLVMOrcLazyCallThroughManagerRef* pResult = &Result)
        {
            return LLVM.OrcCreateLocalLazyCallThroughManager(marshaledTriple, ES, ErrorHandlerAddr, (LLVMOrcOpaqueLazyCallThroughManager**)pResult);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeLazyCallThroughManager(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcLazyCallThroughManagerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcLazyCallThroughManagerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcLazyCallThroughManagerRef)}: {Handle:X}";
}
