// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMObjectFileRef(IntPtr handle) : IDisposable, IEquatable<LLVMObjectFileRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMObjectFileRef(LLVMOpaqueObjectFile* value) => new LLVMObjectFileRef((IntPtr)value);

    public static implicit operator LLVMOpaqueObjectFile*(LLVMObjectFileRef value) => (LLVMOpaqueObjectFile*)value.Handle;

    public static bool operator ==(LLVMObjectFileRef left, LLVMObjectFileRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMObjectFileRef left, LLVMObjectFileRef right) => !(left == right);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeObjectFile(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMObjectFileRef other) && Equals(other);

    public readonly bool Equals(LLVMObjectFileRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMSectionIteratorRef GetSections() => (Handle != IntPtr.Zero) ? LLVM.GetSections(this) : default;

    public readonly LLVMSymbolIteratorRef GetSymbols() => (Handle != IntPtr.Zero) ? LLVM.GetSymbols(this) : default;

    public readonly bool IsSectionIteratorAtEnd(LLVMSectionIteratorRef SI) => (Handle != IntPtr.Zero) && LLVM.IsSectionIteratorAtEnd(this, SI) != 0;

    public readonly bool IsSymbolIteratorAtEnd(LLVMSymbolIteratorRef SI) => (Handle != IntPtr.Zero) && LLVM.IsSymbolIteratorAtEnd(this, SI) != 0;

    public override readonly string ToString() => $"{nameof(LLVMObjectFileRef)}: {Handle:X}";
}
