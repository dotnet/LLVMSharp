// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace LLVMSharp.Interop;

public readonly struct LLVMValueUsesEnumerable(LLVMValueRef module) : IEnumerable<LLVMUseRef>
{
    public Enumerator GetEnumerator() => new Enumerator(module);

    IEnumerator<LLVMUseRef> IEnumerable<LLVMUseRef>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public struct Enumerator(LLVMValueRef module) : IEnumerator<LLVMUseRef>
    {
        public LLVMUseRef Current { get; private set; }

        readonly object IEnumerator.Current => Current;

        readonly void IDisposable.Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Current.Handle == 0)
            {
                Current = module.FirstUse;
            }
            else
            {
                Current = Current.NextUse;
            }
            return Current.Handle != 0;
        }

        public void Reset() => Current = default;
    }
}
