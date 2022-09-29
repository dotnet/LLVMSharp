// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe struct MarshaledArray<T, U> : IDisposable
    where U : unmanaged
{
    public MarshaledArray(ReadOnlySpan<T> inputs, Func<T, U> marshal)
    {
        int length;
        U* value;

        if (inputs.Length == 0)
        {
            length = 0;
            value = null;
        }
        else
        {
            length = inputs.Length;

#if NET6_0_OR_GREATER
            value = (U*)NativeMemory.Alloc((uint)(length * sizeof(U)));
#else
            value = (U*)Marshal.AllocHGlobal(length * sizeof(U));
#endif

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                value[i] = marshal(input);
            }
        }

        Length = length;
        Value = value;
    }

    public ReadOnlySpan<U> AsSpan() => new ReadOnlySpan<U>(Value, Length);

    public int Length { get; private set; }

    public U* Value { get; private set; }

    public static implicit operator U*(MarshaledArray<T, U> value) => value.Value;

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
}
