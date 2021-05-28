// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>
    {
        public IntPtr Handle;

        public LLVMTargetDataRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMTargetDataRef(LLVMOpaqueTargetData* TargetData) => new LLVMTargetDataRef((IntPtr)TargetData);

        public static implicit operator LLVMOpaqueTargetData*(LLVMTargetDataRef TargetData) => (LLVMOpaqueTargetData*)TargetData.Handle;

        public static bool operator ==(LLVMTargetDataRef left, LLVMTargetDataRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMTargetDataRef left, LLVMTargetDataRef right) => !(left == right);

        public static LLVMTargetDataRef FromStringRepresentation(ReadOnlySpan<char> stringRep) => LLVM.CreateTargetData(new MarshaledString(stringRep));

        public override bool Equals(object obj) => (obj is LLVMTargetDataRef other) && Equals(other);

        public bool Equals(LLVMTargetDataRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public ulong OffsetOfElement(LLVMTypeRef type, uint element) => LLVM.OffsetOfElement(this, type, element);

        public ulong ElementAtOffset(LLVMTypeRef type, ulong offset) => LLVM.ElementAtOffset(this, type, offset);

        public ulong SizeOfTypeInBits(LLVMTypeRef type) => LLVM.SizeOfTypeInBits(this, type);

        public ulong StoreSizeOfType(LLVMTypeRef type) => LLVM.StoreSizeOfType(this, type);

        public ulong ABISizeOfType(LLVMTypeRef type) => LLVM.ABISizeOfType(this, type);

        public uint ABIAlignmentOfType(LLVMTypeRef type) => LLVM.ABIAlignmentOfType(this, type);

        public uint CallFrameAlignmentOfType(LLVMTypeRef type) => LLVM.CallFrameAlignmentOfType(this, type);

        public uint PreferredAlignmentOfType(LLVMTypeRef type) => LLVM.PreferredAlignmentOfType(this, type);

        public uint PreferredAlignmentOfGlobal(LLVMValueRef globalVar) => LLVM.PreferredAlignmentOfGlobal(this, globalVar);

        public override string ToString() => $"{nameof(LLVMTargetDataRef)}: {Handle:X}";
    }
}
