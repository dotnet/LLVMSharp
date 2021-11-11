// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe struct MarshaledStringArray : IDisposable
    {
        public MarshaledStringArray(ReadOnlySpan<string> inputs)
        {
            if (inputs.IsEmpty)
            {
                Count = 0;
                Values = null;
            }
            else
            {
                Count = inputs.Length;
                Values = new MarshaledString[Count];

                for (int i = 0; i < Count; i++)
                {
                    Values[i] = new MarshaledString(inputs[i].AsSpan());
                }
            }
        }

        public int Count { get; private set; }

        public MarshaledString[] Values { get; private set; }

        public void Dispose()
        {
            if (Values != null)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    Values[i].Dispose();
                }

                Values = null;
                Count = 0;
            }
        }

        public void Fill(sbyte** pDestination)
        {
            for (int i = 0; i < Count; i++)
            {
                pDestination[i] = Values[i];
            }
        }
    }
}
