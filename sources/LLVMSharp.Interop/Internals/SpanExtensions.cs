// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LLVMSharp.Interop;

public static unsafe class SpanExtensions
{
    public static string AsString(sbyte* pStr)
    {
        var span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)(pStr));
        return span.AsString();
    }

    public static string AsString(this Span<byte> self) => AsString((ReadOnlySpan<byte>)self);

    public static string AsString(this ReadOnlySpan<byte> self)
    {
        if (self.IsEmpty)
        {
            return string.Empty;
        }

        fixed (byte* pSelf = self)
        {
            return Encoding.UTF8.GetString(pSelf, self.Length);
        }
    }

    public static string AsString(this ReadOnlySpan<ushort> self)
    {
        if (self.IsEmpty)
        {
            return string.Empty;
        }

        fixed (ushort* pSelf = self)
        {
            return Encoding.Unicode.GetString((byte*)pSelf, self.Length * 2);
        }
    }

    public static string AsString(this ReadOnlySpan<uint> self)
    {
        if (self.IsEmpty)
        {
            return string.Empty;
        }

        fixed (uint* pSelf = self)
        {
            return Encoding.UTF32.GetString((byte*)pSelf, self.Length * 4);
        }
    }
}
