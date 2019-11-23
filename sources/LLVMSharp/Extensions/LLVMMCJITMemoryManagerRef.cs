// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public partial struct LLVMMCJITMemoryManagerRef : IEquatable<LLVMMCJITMemoryManagerRef>
    {
        public static bool operator ==(LLVMMCJITMemoryManagerRef left, LLVMMCJITMemoryManagerRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMMCJITMemoryManagerRef left, LLVMMCJITMemoryManagerRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMMCJITMemoryManagerRef other && Equals(other);

        public bool Equals(LLVMMCJITMemoryManagerRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
