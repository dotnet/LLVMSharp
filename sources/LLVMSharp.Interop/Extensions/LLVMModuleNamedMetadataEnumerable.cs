// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace LLVMSharp.Interop;

public readonly struct LLVMModuleNamedMetadataEnumerable(LLVMModuleRef module) : IEnumerable<LLVMNamedMDNodeRef>
{
    public Enumerator GetEnumerator() => new Enumerator(module);

    IEnumerator<LLVMNamedMDNodeRef> IEnumerable<LLVMNamedMDNodeRef>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public struct Enumerator(LLVMModuleRef module) : IEnumerator<LLVMNamedMDNodeRef>
    {
        public LLVMNamedMDNodeRef Current { get; private set; }

        readonly object IEnumerator.Current => Current;

        readonly void IDisposable.Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Current.Handle == 0)
            {
                Current = module.FirstNamedMetadata;
            }
            else
            {
                Current = Current.NextNamedMetadata;
            }
            return Current.Handle != 0;
        }

        public void Reset() => Current = default;
    }
}
