// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LLVMSharp.Interop;

public unsafe struct MarshaledString : IDisposable
{
    public MarshaledString(string? input) : this(input.AsSpan())
    {
    }

    public MarshaledString(ReadOnlySpan<char> input)
    {
        int length = input.Length;
        sbyte* value;

        if (length != 0)
        {
            length = Encoding.UTF8.GetMaxByteCount(input.Length);
        }

#if NET6_0_OR_GREATER
        value = (sbyte*)NativeMemory.Alloc((uint)(length) + 1);
#else
        value = (sbyte*)Marshal.AllocHGlobal(length + 1);
#endif

        if (length != 0)
        {
            fixed (char* pInput = input)
            {
                length = Encoding.UTF8.GetBytes(pInput, input.Length, (byte*)value, length);
            }
        }
        value[length] = 0;

        Length = length;
        Value = value;
    }

    public ReadOnlySpan<byte> AsSpan() => new ReadOnlySpan<byte>(Value, Length);

    public int Length { get; private set; }

    public sbyte* Value { get; private set; }

    public static implicit operator sbyte*(MarshaledString value) => value.Value;

    public void Dispose()
    {
        if (Value != null)
        {
#if NET6_0_OR_GREATER
            NativeMemory.Free(Value);
#else
            Marshal.FreeHGlobal((IntPtr)Value);
#endif

            Value = null;
            Length = 0;
        }
    }

    public override string ToString()
    {
        var span = new ReadOnlySpan<byte>(Value, Length);
        return span.AsString();
    }
}
