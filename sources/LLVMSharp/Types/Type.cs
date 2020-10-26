// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class Type : IEquatable<Type>
    {
        private protected Type(LLVMTypeRef handle, LLVMTypeKind expectedTypeKind)
        {
            if (handle.Kind != expectedTypeKind)
            {
                throw new ArgumentException(nameof(handle));
            }
            Handle = handle;
        }

        public LLVMTypeRef Handle { get; }

        public static bool operator ==(Type left, Type right) => ReferenceEquals(left, right) || (left.Handle == right.Handle);

        public static bool operator !=(Type left, Type right) => !(left == right);

        public static Type GetBFloatTy(LLVMContext C)
        {
            var handle = C.Handle.BFloatType;
            return C.GetOrCreate(handle);
        }

        public static Type GetDoubleTy(LLVMContext C)
        {
            var handle = C.Handle.DoubleType;
            return C.GetOrCreate(handle);
        }

        public static Type GetFloatTy(LLVMContext C)
        {
            var handle = C.Handle.FloatType;
            return C.GetOrCreate(handle);
        }

        public static Type GetHalfTy(LLVMContext C)
        {
            var handle = C.Handle.HalfType;
            return C.GetOrCreate(handle);
        }

        public static IntegerType GetInt1Ty(LLVMContext C)
        {
            var handle = C.Handle.Int1Type;
            return C.GetOrCreate<IntegerType>(handle);
        }

        public static IntegerType GetInt8Ty(LLVMContext C)
        {
            var handle = C.Handle.Int8Type;
            return C.GetOrCreate<IntegerType>(handle);
        }

        public static IntegerType GetInt16Ty(LLVMContext C)
        {
            var handle = C.Handle.Int16Type;
            return C.GetOrCreate<IntegerType>(handle);
        }

        public static IntegerType GetInt32Ty(LLVMContext C)
        {
            var handle = C.Handle.Int32Type;
            return C.GetOrCreate<IntegerType>(handle);
        }

        public static IntegerType GetInt64Ty(LLVMContext C)
        {
            var handle = C.Handle.Int64Type;
            return C.GetOrCreate<IntegerType>(handle);
        }

        public static Type GetFP128Ty(LLVMContext C)
        {
            var handle = C.Handle.FP128Type;
            return C.GetOrCreate(handle);
        }

        public static Type GetLabelTy(LLVMContext C)
        {
            var handle = C.Handle.LabelType;
            return C.GetOrCreate(handle);
        }

        public static Type GetPPC_FP128Ty(LLVMContext C)
        {
            var handle = C.Handle.PPCFP128Type;
            return C.GetOrCreate(handle);
        }

        public static Type GetVoidTy(LLVMContext C)
        {
            var handle = C.Handle.VoidType;
            return C.GetOrCreate(handle);
        }

        public static Type GetX86_FP80Ty(LLVMContext C)
        {
            var handle = C.Handle.X86FP80Type;
            return C.GetOrCreate(handle);
        }

        public static Type GetX86_MMXTy(LLVMContext C)
        {
            var handle = C.Handle.X86MMXType;
            return C.GetOrCreate(handle);
        }

        public override bool Equals(object obj) => (obj is Type other) && Equals(other);

        public bool Equals(Type other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();

        internal static Type Create(LLVMTypeRef handle) => handle.Kind switch
        {
            LLVMTypeKind.LLVMVoidTypeKind => new Type(handle, LLVMTypeKind.LLVMVoidTypeKind),
            LLVMTypeKind.LLVMHalfTypeKind => new Type(handle, LLVMTypeKind.LLVMHalfTypeKind),
            LLVMTypeKind.LLVMFloatTypeKind => new Type(handle, LLVMTypeKind.LLVMFloatTypeKind),
            LLVMTypeKind.LLVMDoubleTypeKind => new Type(handle, LLVMTypeKind.LLVMDoubleTypeKind),
            LLVMTypeKind.LLVMX86_FP80TypeKind => new Type(handle, LLVMTypeKind.LLVMX86_FP80TypeKind),
            LLVMTypeKind.LLVMFP128TypeKind => new Type(handle, LLVMTypeKind.LLVMFP128TypeKind),
            LLVMTypeKind.LLVMPPC_FP128TypeKind => new Type(handle, LLVMTypeKind.LLVMPPC_FP128TypeKind),
            LLVMTypeKind.LLVMLabelTypeKind => new Type(handle, LLVMTypeKind.LLVMLabelTypeKind),
            LLVMTypeKind.LLVMIntegerTypeKind => new IntegerType(handle),
            LLVMTypeKind.LLVMFunctionTypeKind => new FunctionType(handle),
            LLVMTypeKind.LLVMStructTypeKind => new StructType(handle),
            LLVMTypeKind.LLVMArrayTypeKind => new ArrayType(handle),
            LLVMTypeKind.LLVMPointerTypeKind => new PointerType(handle),
            LLVMTypeKind.LLVMVectorTypeKind => new VectorType(handle),
            LLVMTypeKind.LLVMMetadataTypeKind => new Type(handle, LLVMTypeKind.LLVMMetadataTypeKind),
            LLVMTypeKind.LLVMX86_MMXTypeKind => new Type(handle, LLVMTypeKind.LLVMX86_MMXTypeKind),
            LLVMTypeKind.LLVMTokenTypeKind => new Type(handle, LLVMTypeKind.LLVMTokenTypeKind),
            _ => new Type(handle, handle.Kind),
        };
    }
}
