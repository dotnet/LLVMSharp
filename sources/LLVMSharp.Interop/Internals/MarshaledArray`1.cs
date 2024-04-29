// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe ref struct MarshaledArray<T, U>
    where U : unmanaged
{
    public MarshaledArray(ReadOnlySpan<T> inputs, Func<T, U> marshal)
    {
        ArgumentNullException.ThrowIfNull(marshal);

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

            value = (U*)NativeMemory.Alloc((uint)(length * sizeof(U)));

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                value[i] = marshal(input);
            }
        }

        Length = length;
        Value = value;
    }

    public readonly ReadOnlySpan<U> AsSpan() => new ReadOnlySpan<U>(Value, Length);

    public int Length { get; private set; }

    public U* Value { get; private set; }

    public static implicit operator U*(MarshaledArray<T, U> value) => value.Value;

    public void Dispose()
    {
        if (Value is not null)
        {
            NativeMemory.Free(Value);
            Value = null;
            Length = 0;
        }
    }
}
