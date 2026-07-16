// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOperandBundleRef(IntPtr handle) : IEquatable<LLVMOperandBundleRef>, IDisposable
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOperandBundleRef(LLVMOpaqueOperandBundle* value) => new LLVMOperandBundleRef((IntPtr)value);

    public static implicit operator LLVMOpaqueOperandBundle*(LLVMOperandBundleRef value) => (LLVMOpaqueOperandBundle*)value.Handle;

    public static bool operator ==(LLVMOperandBundleRef left, LLVMOperandBundleRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOperandBundleRef left, LLVMOperandBundleRef right) => !(left == right);

    public readonly uint NumArgs => (Handle != IntPtr.Zero) ? LLVM.GetNumOperandBundleArgs(this) : default;

    public readonly string Tag
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            nuint length = 0;
            var pTag = LLVM.GetOperandBundleTag(this, &length);
            return (pTag != null) ? new ReadOnlySpan<byte>(pTag, (int)length).AsString() : string.Empty;
        }
    }

    public static LLVMOperandBundleRef Create(string Tag, LLVMValueRef[] Args) => Create(Tag.AsSpan(), Args.AsSpan());

    public static LLVMOperandBundleRef Create(ReadOnlySpan<char> Tag, ReadOnlySpan<LLVMValueRef> Args)
    {
        using var marshaledTag = new MarshaledString(Tag);
        fixed (LLVMValueRef* pArgs = Args)
        {
            return LLVM.CreateOperandBundle(marshaledTag, (nuint)marshaledTag.Length, (LLVMOpaqueValue**)pArgs, (uint)Args.Length);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeOperandBundle(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOperandBundleRef other) && Equals(other);

    public readonly bool Equals(LLVMOperandBundleRef other) => this == other;

    public readonly LLVMValueRef GetArgAtIndex(uint Index) => LLVM.GetOperandBundleArgAtIndex(this, Index);

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOperandBundleRef)}: {Handle:X}";
}
