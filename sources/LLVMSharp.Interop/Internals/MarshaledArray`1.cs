// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Buffers;

namespace LLVMSharp.Interop
{
    public unsafe struct MarshaledArray<T, U> : IDisposable
    {
        public MarshaledArray(ReadOnlySpan<T> inputs, Func<T, U> marshal)
        {
            if (inputs.IsEmpty)
            {
                Count = 0;
                Values = null;
            }
            else
            {
                Count = inputs.Length;
                Values = ArrayPool<U>.Shared.Rent(Count);

                for (int i = 0; i < Count; i++)
                {
                    Values[i] = marshal(inputs[i]);
                }
            }
        }

        public int Count { get; private set; }

        public U[] Values { get; private set; }

        public static implicit operator ReadOnlySpan<U>(in MarshaledArray<T, U> value)
        {
            return value.Values;
        }

        public void Dispose()
        {
            if (Values != null)
            {
                ArrayPool<U>.Shared.Return(Values);
            }
        }
    }
}
