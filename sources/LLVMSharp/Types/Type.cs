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

    public LLVMContext Context => LLVMContext.GetOrCreate(Handle.Context);

    public bool IsAggregateType => Handle.Kind is LLVMTypeKind.LLVMStructTypeKind or LLVMTypeKind.LLVMArrayTypeKind;

    public bool IsArrayTy => Handle.Kind == LLVMTypeKind.LLVMArrayTypeKind;

    public bool IsBFloatTy => Handle.Kind == LLVMTypeKind.LLVMBFloatTypeKind;

    public bool IsDoubleTy => Handle.Kind == LLVMTypeKind.LLVMDoubleTypeKind;

    public bool IsFP128Ty => Handle.Kind == LLVMTypeKind.LLVMFP128TypeKind;

    public bool IsFloatTy => Handle.Kind == LLVMTypeKind.LLVMFloatTypeKind;

    public bool IsFloatingPointTy => Handle.Kind is LLVMTypeKind.LLVMHalfTypeKind or LLVMTypeKind.LLVMBFloatTypeKind or LLVMTypeKind.LLVMFloatTypeKind or LLVMTypeKind.LLVMDoubleTypeKind or LLVMTypeKind.LLVMX86_FP80TypeKind or LLVMTypeKind.LLVMFP128TypeKind or LLVMTypeKind.LLVMPPC_FP128TypeKind;

    public bool IsFunctionTy => Handle.Kind == LLVMTypeKind.LLVMFunctionTypeKind;

    public bool IsHalfTy => Handle.Kind == LLVMTypeKind.LLVMHalfTypeKind;

    public bool IsIntegerTy => Handle.Kind == LLVMTypeKind.LLVMIntegerTypeKind;

    public bool IsLabelTy => Handle.Kind == LLVMTypeKind.LLVMLabelTypeKind;

    public bool IsMetadataTy => Handle.Kind == LLVMTypeKind.LLVMMetadataTypeKind;

    public bool IsPPCFP128Ty => Handle.Kind == LLVMTypeKind.LLVMPPC_FP128TypeKind;

    public bool IsPointerTy => Handle.Kind == LLVMTypeKind.LLVMPointerTypeKind;

    public bool IsSized => Handle.IsSized;

    public bool IsStructTy => Handle.Kind == LLVMTypeKind.LLVMStructTypeKind;

    public bool IsTokenTy => Handle.Kind == LLVMTypeKind.LLVMTokenTypeKind;

    public bool IsVectorTy => Handle.Kind is LLVMTypeKind.LLVMVectorTypeKind or LLVMTypeKind.LLVMScalableVectorTypeKind;

    public bool IsVoidTy => Handle.Kind == LLVMTypeKind.LLVMVoidTypeKind;

    public bool IsX86AMXTy => Handle.Kind == LLVMTypeKind.LLVMX86_AMXTypeKind;

    public bool IsX86FP80Ty => Handle.Kind == LLVMTypeKind.LLVMX86_FP80TypeKind;

    public LLVMTypeKind Kind => Handle.Kind;

    public Type ScalarType => (Handle.Kind is LLVMTypeKind.LLVMVectorTypeKind or LLVMTypeKind.LLVMScalableVectorTypeKind) ? Context.GetOrCreate(Handle.ElementType) : this;

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

    public void Dump() => Handle.Dump();

    public string PrintToString() => Handle.PrintToString();

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
