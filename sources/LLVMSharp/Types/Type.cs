// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public class Type : IEquatable<Type>
{
    private protected Type(LLVMTypeRef handle, LLVMTypeKind expectedTypeKind)
    {
        if (handle.Kind != expectedTypeKind)
        {
            throw new ArgumentOutOfRangeException(nameof(handle));
        }
        Handle = handle;
    }

    public LLVMTypeRef Handle { get; }

    public static bool operator ==(Type? left, Type? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(Type? left, Type? right) => !(left == right);

    public static Type GetBFloatTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.BFloatType;
        return c.GetOrCreate(handle);
    }

    public static Type GetDoubleTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.DoubleType;
        return c.GetOrCreate(handle);
    }

    public static Type GetFloatTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.FloatType;
        return c.GetOrCreate(handle);
    }

    public static Type GetHalfTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.HalfType;
        return c.GetOrCreate(handle);
    }

    public static IntegerType GetInt1Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.Int1Type;
        return c.GetOrCreate<IntegerType>(handle);
    }

    public static IntegerType GetInt8Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.Int8Type;
        return c.GetOrCreate<IntegerType>(handle);
    }

    public static IntegerType GetInt16Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.Int16Type;
        return c.GetOrCreate<IntegerType>(handle);
    }

    public static IntegerType GetInt32Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.Int32Type;
        return c.GetOrCreate<IntegerType>(handle);
    }

    public static IntegerType GetInt64Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.Int64Type;
        return c.GetOrCreate<IntegerType>(handle);
    }

    public static Type GetFP128Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.FP128Type;
        return c.GetOrCreate(handle);
    }

    public static Type GetLabelTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.LabelType;
        return c.GetOrCreate(handle);
    }

    public static Type GetPPC_FP128Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.PPCFP128Type;
        return c.GetOrCreate(handle);
    }

    public static Type GetVoidTy(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.VoidType;
        return c.GetOrCreate(handle);
    }

    public static Type GetX86_FP80Ty(LLVMContext c)
    {
        ArgumentNullException.ThrowIfNull(c);
        var handle = c.Handle.X86FP80Type;
        return c.GetOrCreate(handle);
    }

    public override bool Equals(object? obj) => (obj is Type other) && Equals(other);

    public bool Equals(Type? other) => this == other;

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
        LLVMTypeKind.LLVMTokenTypeKind => new Type(handle, LLVMTypeKind.LLVMTokenTypeKind),
        LLVMTypeKind.LLVMScalableVectorTypeKind => new Type(handle, LLVMTypeKind.LLVMScalableVectorTypeKind),
        LLVMTypeKind.LLVMBFloatTypeKind => new Type(handle, LLVMTypeKind.LLVMBFloatTypeKind),
        LLVMTypeKind.LLVMX86_AMXTypeKind => new Type(handle, LLVMTypeKind.LLVMX86_AMXTypeKind),
        LLVMTypeKind.LLVMTargetExtTypeKind => new Type(handle, LLVMTypeKind.LLVMTargetExtTypeKind),
        _ => new Type(handle, handle.Kind),
    };
}
