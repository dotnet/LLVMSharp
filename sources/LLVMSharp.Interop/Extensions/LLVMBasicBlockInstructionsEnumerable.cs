// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace LLVMSharp.Interop;

public readonly struct LLVMBasicBlockInstructionsEnumerable(LLVMBasicBlockRef basicBlock) : IEnumerable<LLVMValueRef>
{
    public Enumerator GetEnumerator() => new Enumerator(basicBlock);

    IEnumerator<LLVMValueRef> IEnumerable<LLVMValueRef>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public struct Enumerator(LLVMBasicBlockRef basicBlock) : IEnumerator<LLVMValueRef>
    {
        public LLVMValueRef Current { get; private set; }

        readonly object IEnumerator.Current => Current;

        readonly void IDisposable.Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Current.Handle == 0)
            {
                Current = basicBlock.FirstInstruction;
            }
            else
            {
                Current = Current.NextInstruction;
            }
            return Current.Handle != 0;
        }

        public void Reset() => Current = default;
    }
}
