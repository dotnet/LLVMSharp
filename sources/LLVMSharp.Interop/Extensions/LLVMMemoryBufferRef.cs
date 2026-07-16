// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMemoryBufferRef(IntPtr handle) : IDisposable, IEquatable<LLVMMemoryBufferRef>
{
    public IntPtr Handle = handle;

    public readonly UIntPtr BufferSize => (Handle != IntPtr.Zero) ? LLVM.GetBufferSize(this) : default;

    public readonly IntPtr BufferStart => (Handle != IntPtr.Zero) ? (IntPtr)LLVM.GetBufferStart(this) : IntPtr.Zero;

    public static implicit operator LLVMMemoryBufferRef(LLVMOpaqueMemoryBuffer* MemoryBuffer) => new LLVMMemoryBufferRef((IntPtr)MemoryBuffer);

    public static implicit operator LLVMOpaqueMemoryBuffer*(LLVMMemoryBufferRef MemoryBuffer) => (LLVMOpaqueMemoryBuffer*)MemoryBuffer.Handle;

    public static bool operator ==(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => !(left == right);

    public static LLVMMemoryBufferRef CreateWithContentsOfFile(string Path) => CreateWithContentsOfFile(Path.AsSpan());

    public static LLVMMemoryBufferRef CreateWithContentsOfFile(ReadOnlySpan<char> Path)
    {
        if (!TryCreateWithContentsOfFile(Path, out LLVMMemoryBufferRef MemBuf, out string Message))
        {
            throw new ExternalException(Message);
        }

        return MemBuf;
    }

    public static LLVMMemoryBufferRef CreateWithMemoryRange(ReadOnlySpan<byte> InputData, ReadOnlySpan<char> BufferName, bool RequiresNullTerminator)
    {
        using var marshaledBufferName = new MarshaledString(BufferName);

        fixed (byte* pInputData = InputData)
        {
            return LLVM.CreateMemoryBufferWithMemoryRange((sbyte*)pInputData, (nuint)InputData.Length, marshaledBufferName, RequiresNullTerminator ? 1 : 0);
        }
    }

    public static LLVMMemoryBufferRef CreateWithMemoryRangeCopy(ReadOnlySpan<byte> InputData, ReadOnlySpan<char> BufferName)
    {
        using var marshaledBufferName = new MarshaledString(BufferName);

        fixed (byte* pInputData = InputData)
        {
            return LLVM.CreateMemoryBufferWithMemoryRangeCopy((sbyte*)pInputData, (nuint)InputData.Length, marshaledBufferName);
        }
    }

    public static LLVMMemoryBufferRef CreateWithSTDIN()
    {
        if (!TryCreateWithSTDIN(out LLVMMemoryBufferRef MemBuf, out string Message))
        {
            throw new ExternalException(Message);
        }

        return MemBuf;
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeMemoryBuffer(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMMemoryBufferRef other) && Equals(other);

    public readonly bool Equals(LLVMMemoryBufferRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMMemoryBufferRef)}: {Handle:X}";

    public static bool TryCreateWithContentsOfFile(ReadOnlySpan<char> Path, out LLVMMemoryBufferRef OutMemBuf, out string OutMessage)
    {
        using var marshaledPath = new MarshaledString(Path);

        fixed (LLVMMemoryBufferRef* pOutMemBuf = &OutMemBuf)
        {
            sbyte* pMessage = null;
            var result = LLVM.CreateMemoryBufferWithContentsOfFile(marshaledPath, (LLVMOpaqueMemoryBuffer**)pOutMemBuf, &pMessage);

            if (pMessage == null)
            {
                OutMessage = string.Empty;
            }
            else
            {
                OutMessage = SpanExtensions.AsString(pMessage);
                LLVM.DisposeMessage(pMessage);
            }

            return result == 0;
        }
    }

    public static bool TryCreateWithSTDIN(out LLVMMemoryBufferRef OutMemBuf, out string OutMessage)
    {
        fixed (LLVMMemoryBufferRef* pOutMemBuf = &OutMemBuf)
        {
            sbyte* pMessage = null;
            var result = LLVM.CreateMemoryBufferWithSTDIN((LLVMOpaqueMemoryBuffer**)pOutMemBuf, &pMessage);

            if (pMessage == null)
            {
                OutMessage = string.Empty;
            }
            else
            {
                OutMessage = SpanExtensions.AsString(pMessage);
                LLVM.DisposeMessage(pMessage);
            }

            return result == 0;
        }
    }
}
