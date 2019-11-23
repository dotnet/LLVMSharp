// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    partial struct LLVMTargetLibraryInfoRef : IEquatable<LLVMTargetLibraryInfoRef>
    {
        public static bool operator ==(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetLibraryInfoRef other && Equals(other);

        public bool Equals(LLVMTargetLibraryInfoRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
