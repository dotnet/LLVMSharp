// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMRelocationIteratorRef(IntPtr handle) : IDisposable, IEquatable<LLVMRelocationIteratorRef>
{
    public IntPtr Handle = handle;

    public readonly ulong Offset => (Handle != IntPtr.Zero) ? LLVM.GetRelocationOffset(this) : default;

    public readonly LLVMSymbolIteratorRef Symbol => (Handle != IntPtr.Zero) ? LLVM.GetRelocationSymbol(this) : default;

    public readonly ulong Type => (Handle != IntPtr.Zero) ? LLVM.GetRelocationType(this) : default;

    public readonly string TypeName
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pTypeName = LLVM.GetRelocationTypeName(this);
            return (pTypeName != null) ? SpanExtensions.AsString(pTypeName) : string.Empty;
        }
    }

    public readonly string ValueString
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pValueString = LLVM.GetRelocationValueString(this);
            return (pValueString != null) ? SpanExtensions.AsString(pValueString) : string.Empty;
        }
    }

    public static implicit operator LLVMRelocationIteratorRef(LLVMOpaqueRelocationIterator* value) => new LLVMRelocationIteratorRef((IntPtr)value);

    public static implicit operator LLVMOpaqueRelocationIterator*(LLVMRelocationIteratorRef value) => (LLVMOpaqueRelocationIterator*)value.Handle;

    public static bool operator ==(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => !(left == right);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeRelocationIterator(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMRelocationIteratorRef other) && Equals(other);

    public readonly bool Equals(LLVMRelocationIteratorRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void MoveToNextRelocation()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.MoveToNextRelocation(this);
        }
    }

    public override readonly string ToString() => $"{nameof(LLVMRelocationIteratorRef)}: {Handle:X}";
}
