// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMSymbolIteratorRef(IntPtr handle) : IDisposable, IEquatable<LLVMSymbolIteratorRef>
{
    public IntPtr Handle = handle;

    public readonly ulong Address => (Handle != IntPtr.Zero) ? LLVM.GetSymbolAddress(this) : default;

    public readonly string Name
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pName = LLVM.GetSymbolName(this);
            return (pName != null) ? SpanExtensions.AsString(pName) : string.Empty;
        }
    }

    public readonly ulong Size => (Handle != IntPtr.Zero) ? LLVM.GetSymbolSize(this) : default;

    public static implicit operator LLVMSymbolIteratorRef(LLVMOpaqueSymbolIterator* value) => new LLVMSymbolIteratorRef((IntPtr)value);

    public static implicit operator LLVMOpaqueSymbolIterator*(LLVMSymbolIteratorRef value) => (LLVMOpaqueSymbolIterator*)value.Handle;

    public static bool operator ==(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => !(left == right);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeSymbolIterator(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMSymbolIteratorRef other) && Equals(other);

    public readonly bool Equals(LLVMSymbolIteratorRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void MoveToNextSymbol()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.MoveToNextSymbol(this);
        }
    }

    public override readonly string ToString() => $"{nameof(LLVMSymbolIteratorRef)}: {Handle:X}";
}
