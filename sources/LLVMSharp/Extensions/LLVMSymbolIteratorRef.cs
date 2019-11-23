// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>
    {
        public static bool operator ==(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMSymbolIteratorRef other && Equals(other);

        public bool Equals(LLVMSymbolIteratorRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
