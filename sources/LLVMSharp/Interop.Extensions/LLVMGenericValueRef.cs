// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMGenericValueRef : IEquatable<LLVMGenericValueRef>
    {
        public IntPtr Handle;

        public LLVMGenericValueRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMGenericValueRef(LLVMOpaqueGenericValue* GenericValue) => new LLVMGenericValueRef((IntPtr)GenericValue);

        public static implicit operator LLVMOpaqueGenericValue*(LLVMGenericValueRef GenericValue) => (LLVMOpaqueGenericValue*)GenericValue.Handle;

        public static bool operator ==(LLVMGenericValueRef left, LLVMGenericValueRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMGenericValueRef left, LLVMGenericValueRef right) => !(left == right);

        public LLVMGenericValueRef CreateInt(LLVMTypeRef Ty, ulong N, bool IsSigned) => LLVM.CreateGenericValueOfInt(Ty, N, IsSigned ? 1 : 0);

        public LLVMGenericValueRef CreateFloat(LLVMTypeRef Ty, double N) => LLVM.CreateGenericValueOfFloat(Ty, N);

        public override bool Equals(object obj) => (obj is LLVMGenericValueRef other) && Equals(other);

        public bool Equals(LLVMGenericValueRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMGenericValueRef)}: {Handle:X}";
    }
}
