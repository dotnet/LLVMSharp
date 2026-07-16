// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMBinaryRef(IntPtr handle) : IDisposable, IEquatable<LLVMBinaryRef>
{
    public IntPtr Handle = handle;

    public readonly LLVMBinaryType BinaryType => (Handle != IntPtr.Zero) ? LLVM.BinaryGetType(this) : default;

    public static implicit operator LLVMBinaryRef(LLVMOpaqueBinary* Comdat) => new LLVMBinaryRef((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueBinary*(LLVMBinaryRef Comdat) => (LLVMOpaqueBinary*)Comdat.Handle;

    public static bool operator ==(LLVMBinaryRef left, LLVMBinaryRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMBinaryRef left, LLVMBinaryRef right) => !(left == right);

    public static LLVMBinaryRef Create(LLVMMemoryBufferRef MemBuf, LLVMContextRef Context)
    {
        if (!TryCreate(MemBuf, Context, out LLVMBinaryRef Binary, out string Message))
        {
            throw new ExternalException(Message);
        }

        return Binary;
    }

    public readonly LLVMMemoryBufferRef CopyMemoryBuffer() => (Handle != IntPtr.Zero) ? LLVM.BinaryCopyMemoryBuffer(this) : default;

    public readonly LLVMSectionIteratorRef CopySectionIterator() => (Handle != IntPtr.Zero) ? LLVM.ObjectFileCopySectionIterator(this) : default;

    public readonly LLVMSymbolIteratorRef CopySymbolIterator() => (Handle != IntPtr.Zero) ? LLVM.ObjectFileCopySymbolIterator(this) : default;

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeBinary(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMBinaryRef other) && Equals(other);

    public readonly bool Equals(LLVMBinaryRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly bool IsSectionIteratorAtEnd(LLVMSectionIteratorRef SI) => (Handle != IntPtr.Zero) && LLVM.ObjectFileIsSectionIteratorAtEnd(this, SI) != 0;

    public readonly bool IsSymbolIteratorAtEnd(LLVMSymbolIteratorRef SI) => (Handle != IntPtr.Zero) && LLVM.ObjectFileIsSymbolIteratorAtEnd(this, SI) != 0;

    public readonly LLVMBinaryRef MachOUniversalBinaryCopyObjectForArch(ReadOnlySpan<char> Arch)
    {
        if (!TryMachOUniversalBinaryCopyObjectForArch(Arch, out LLVMBinaryRef Binary, out string Message))
        {
            throw new ExternalException(Message);
        }

        return Binary;
    }

    public override readonly string ToString() => $"{nameof(LLVMBinaryRef)}: {Handle:X}";

    public static bool TryCreate(LLVMMemoryBufferRef MemBuf, LLVMContextRef Context, out LLVMBinaryRef OutBinary, out string OutMessage)
    {
        sbyte* pMessage = null;
        OutBinary = LLVM.CreateBinary(MemBuf, Context, &pMessage);

        if (pMessage == null)
        {
            OutMessage = string.Empty;
        }
        else
        {
            OutMessage = SpanExtensions.AsString(pMessage);
            LLVM.DisposeMessage(pMessage);
        }

        return OutBinary.Handle != IntPtr.Zero;
    }

    public readonly bool TryMachOUniversalBinaryCopyObjectForArch(ReadOnlySpan<char> Arch, out LLVMBinaryRef OutBinary, out string OutMessage)
    {
        using var marshaledArch = new MarshaledString(Arch);

        sbyte* pMessage = null;
        OutBinary = LLVM.MachOUniversalBinaryCopyObjectForArch(this, marshaledArch, (nuint)marshaledArch.Length, &pMessage);

        if (pMessage == null)
        {
            OutMessage = string.Empty;
        }
        else
        {
            OutMessage = SpanExtensions.AsString(pMessage);
            LLVM.DisposeMessage(pMessage);
        }

        return OutBinary.Handle != IntPtr.Zero;
    }
}
