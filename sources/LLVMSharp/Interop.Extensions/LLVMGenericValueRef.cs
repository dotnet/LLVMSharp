// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMGenericValueRef : IEquatable<LLVMGenericValueRef>
    {
        public LLVMGenericValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMGenericValueRef(LLVMOpaqueGenericValue* GenericValue)
        {
            return new LLVMGenericValueRef((IntPtr)GenericValue);
        }

        public static implicit operator LLVMOpaqueGenericValue*(LLVMGenericValueRef GenericValue)
        {
            return (LLVMOpaqueGenericValue*)GenericValue.Pointer;
        }

        public static bool operator ==(LLVMGenericValueRef left, LLVMGenericValueRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMGenericValueRef left, LLVMGenericValueRef right) => !(left == right);

        public LLVMGenericValueRef CreateInt(LLVMTypeRef Ty, ulong N, bool IsSigned) => LLVM.CreateGenericValueOfInt(Ty, N, IsSigned ? 1 : 0);

        public LLVMGenericValueRef CreateFloat(LLVMTypeRef Ty, double N) => LLVM.CreateGenericValueOfFloat(Ty, N);

        public override bool Equals(object obj) => obj is LLVMGenericValueRef other && Equals(other);

        public bool Equals(LLVMGenericValueRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
