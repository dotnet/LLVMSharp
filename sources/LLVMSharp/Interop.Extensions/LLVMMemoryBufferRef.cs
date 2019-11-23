// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMMemoryBufferRef : IEquatable<LLVMMemoryBufferRef>
    {
        public LLVMMemoryBufferRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMMemoryBufferRef(LLVMOpaqueMemoryBuffer* MemoryBuffer)
        {
            return new LLVMMemoryBufferRef((IntPtr)MemoryBuffer);
        }

        public static implicit operator LLVMOpaqueMemoryBuffer*(LLVMMemoryBufferRef MemoryBuffer)
        {
            return (LLVMOpaqueMemoryBuffer*)MemoryBuffer.Pointer;
        }

        public static bool operator ==(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMMemoryBufferRef other && Equals(other);

        public bool Equals(LLVMMemoryBufferRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
