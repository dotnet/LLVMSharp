// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>
    {
        public LLVMTargetDataRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static LLVMTargetDataRef FromStringRepresentation(ReadOnlySpan<char> stringRep)
        {
            return LLVM.CreateTargetData(new MarshaledString(stringRep));
        }

        public IntPtr Handle;

        public static implicit operator LLVMTargetDataRef(LLVMOpaqueTargetData* TargetData)
        {
            return new LLVMTargetDataRef((IntPtr)TargetData);
        }

        public static implicit operator LLVMOpaqueTargetData*(LLVMTargetDataRef TargetData)
        {
            return (LLVMOpaqueTargetData*)TargetData.Handle;
        }

        public static bool operator ==(LLVMTargetDataRef left, LLVMTargetDataRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMTargetDataRef left, LLVMTargetDataRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetDataRef other && Equals(other);

        public bool Equals(LLVMTargetDataRef other) => Handle == other.Handle;

        public override int GetHashCode() => Handle.GetHashCode();

        public ulong OffsetOfElement(LLVMTypeRef type, uint element)
        {
            return LLVM.OffsetOfElement(this, type, element);
        }

        public ulong ElementAtOffset(LLVMTypeRef type, ulong offset)
        {
            return LLVM.ElementAtOffset(this, type, offset);
        }

        public ulong SizeOfTypeInBits(LLVMTypeRef type)
        {
            return LLVM.SizeOfTypeInBits(this, type);
        }

        public ulong StoreSizeOfType(LLVMTypeRef type)
        {
            return LLVM.StoreSizeOfType(this, type);
        }

        public ulong ABISizeOfType(LLVMTypeRef type)
        {
            return LLVM.ABISizeOfType(this, type);
        }

        public uint ABIAlignmentOfType(LLVMTypeRef type)
        {
            return LLVM.ABIAlignmentOfType(this, type);
        }

        public uint CallFrameAlignmentOfType(LLVMTypeRef type)
        {
            return LLVM.CallFrameAlignmentOfType(this, type);
        }

        public uint PreferredAlignmentOfType(LLVMTypeRef type)
        {
            return LLVM.PreferredAlignmentOfType(this, type);
        }

        public uint PreferredAlignmentOfGlobal(LLVMValueRef globalVar)
        {
            return LLVM.PreferredAlignmentOfGlobal(this, globalVar);
        }
    }
}
