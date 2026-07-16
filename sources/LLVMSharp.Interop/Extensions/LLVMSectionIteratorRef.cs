// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMSectionIteratorRef(IntPtr handle) : IDisposable, IEquatable<LLVMSectionIteratorRef>
{
    public IntPtr Handle = handle;

    public readonly ulong Address => (Handle != IntPtr.Zero) ? LLVM.GetSectionAddress(this) : default;

    public readonly IntPtr Contents => (Handle != IntPtr.Zero) ? (IntPtr)LLVM.GetSectionContents(this) : IntPtr.Zero;

    public readonly string Name
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pName = LLVM.GetSectionName(this);
            return (pName != null) ? SpanExtensions.AsString(pName) : string.Empty;
        }
    }

    public readonly ulong Size => (Handle != IntPtr.Zero) ? LLVM.GetSectionSize(this) : default;

    public static implicit operator LLVMSectionIteratorRef(LLVMOpaqueSectionIterator* value) => new LLVMSectionIteratorRef((IntPtr)value);

    public static implicit operator LLVMOpaqueSectionIterator*(LLVMSectionIteratorRef value) => (LLVMOpaqueSectionIterator*)value.Handle;

    public static bool operator ==(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => !(left == right);

    public readonly bool ContainsSymbol(LLVMSymbolIteratorRef Sym) => (Handle != IntPtr.Zero) && LLVM.GetSectionContainsSymbol(this, Sym) != 0;

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeSectionIterator(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMSectionIteratorRef other) && Equals(other);

    public readonly bool Equals(LLVMSectionIteratorRef other) => this == other;

    public readonly LLVMRelocationIteratorRef GetRelocations() => (Handle != IntPtr.Zero) ? LLVM.GetRelocations(this) : default;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly bool IsRelocationIteratorAtEnd(LLVMRelocationIteratorRef RI) => (Handle != IntPtr.Zero) && LLVM.IsRelocationIteratorAtEnd(this, RI) != 0;

    public readonly void MoveToContainingSection(LLVMSymbolIteratorRef Sym)
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.MoveToContainingSection(this, Sym);
        }
    }

    public readonly void MoveToNextSection()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.MoveToNextSection(this);
        }
    }

    public override readonly string ToString() => $"{nameof(LLVMSectionIteratorRef)}: {Handle:X}";
}
