// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTypeRef(IntPtr handle) : IEquatable<LLVMTypeRef>
{
    public IntPtr Handle = handle;

    public static LLVMTypeRef BFloat => LLVM.BFloatType();

    public static LLVMTypeRef Double => LLVM.DoubleType();

    public static LLVMTypeRef Float => LLVM.FloatType();

    public static LLVMTypeRef FP128 => LLVM.FP128Type();

    public static LLVMTypeRef Half => LLVM.HalfType();

    public static LLVMTypeRef Int1 => LLVM.Int1Type();

    public static LLVMTypeRef Int8 => LLVM.Int8Type();

    public static LLVMTypeRef Int16 => LLVM.Int16Type();

    public static LLVMTypeRef Int32 => LLVM.Int32Type();

    public static LLVMTypeRef Int64 => LLVM.Int64Type();

    public static LLVMTypeRef Label => LLVM.LabelType();

    public static LLVMTypeRef PPCFP128 => LLVM.PPCFP128Type();

    public static LLVMTypeRef Void => LLVM.VoidType();

    public static LLVMTypeRef X86FP80 => LLVM.X86FP80Type();

    public static LLVMTypeRef X86MMX => LLVM.X86MMXType();

    public static LLVMTypeRef X86AMX => LLVM.X86AMXType();

    public readonly LLVMValueRef AlignOf => (Handle != IntPtr.Zero) ? LLVM.AlignOf(this) : default;

    public readonly uint ArrayLength => (Kind == LLVMTypeKind.LLVMArrayTypeKind) ? LLVM.GetArrayLength(this) : default;

    public readonly ulong ArrayLength2 => (Kind == LLVMTypeKind.LLVMArrayTypeKind) ? LLVM.GetArrayLength2(this) : default;

    public readonly LLVMContextRef Context => (Handle != IntPtr.Zero) ? LLVM.GetTypeContext(this) : default;

    public readonly LLVMTypeRef ElementType => (((Kind == LLVMTypeKind.LLVMPointerTypeKind) && (SubtypesCount != 0)) || (Kind == LLVMTypeKind.LLVMArrayTypeKind) || (Kind == LLVMTypeKind.LLVMVectorTypeKind)) ? LLVM.GetElementType(this) : default;

    public readonly uint IntWidth => (Kind == LLVMTypeKind.LLVMIntegerTypeKind) ? LLVM.GetIntTypeWidth(this) : default;

    public readonly bool IsFunctionVarArg => (Kind == LLVMTypeKind.LLVMFunctionTypeKind) && LLVM.IsFunctionVarArg(this) != 0;

    public readonly bool IsOpaqueStruct => (Kind == LLVMTypeKind.LLVMStructTypeKind) && LLVM.IsOpaqueStruct(this) != 0;

    public readonly bool IsPackedStruct => (Kind == LLVMTypeKind.LLVMStructTypeKind) && LLVM.IsPackedStruct(this) != 0;

    public readonly bool IsSized => (Handle != IntPtr.Zero) && LLVM.TypeIsSized(this) != 0;

    public readonly LLVMTypeKind Kind => (Handle != IntPtr.Zero) ? LLVM.GetTypeKind(this) : default;

    public readonly uint ParamTypesCount => (Kind == LLVMTypeKind.LLVMFunctionTypeKind) ? LLVM.CountParamTypes(this) : default;

    public readonly uint PointerAddressSpace => (Kind == LLVMTypeKind.LLVMPointerTypeKind) ? LLVM.GetPointerAddressSpace(this) : default;

    public readonly LLVMValueRef Poison => (Handle != IntPtr.Zero) ? LLVM.GetPoison(this) : default;

    public readonly LLVMTypeRef ReturnType => (Kind == LLVMTypeKind.LLVMFunctionTypeKind) ? LLVM.GetReturnType(this) : default;

    public readonly LLVMValueRef SizeOf => (Handle != IntPtr.Zero) ? LLVM.SizeOf(this) : default;

    public readonly uint StructElementTypesCount => (Kind == LLVMTypeKind.LLVMStructTypeKind) ? LLVM.CountStructElementTypes(this) : default;

    public readonly string StructName
    {
        get
        {
            if (Kind != LLVMTypeKind.LLVMStructTypeKind)
            {
                return string.Empty;
            }

            var pStructName = LLVM.GetStructName(this);

            if (pStructName == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pStructName);
        }
    }

    public readonly uint SubtypesCount => (Handle != IntPtr.Zero) ? LLVM.GetNumContainedTypes(this) : default;

    public readonly LLVMValueRef Undef => (Handle != IntPtr.Zero) ? LLVM.GetUndef(this) : default;

    public readonly uint VectorSize => (Kind == LLVMTypeKind.LLVMVectorTypeKind) ? LLVM.GetVectorSize(this) : default;

    public static implicit operator LLVMTypeRef(LLVMOpaqueType* value) => new LLVMTypeRef((IntPtr)value);

    public static implicit operator LLVMOpaqueType*(LLVMTypeRef value) => (LLVMOpaqueType*)value.Handle;

    public static bool operator ==(LLVMTypeRef left, LLVMTypeRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTypeRef left, LLVMTypeRef right) => !(left == right);

    public static LLVMTypeRef CreateFunction(LLVMTypeRef ReturnType, LLVMTypeRef[] ParamTypes, bool IsVarArg = false) => CreateFunction(ReturnType, ParamTypes.AsSpan(), IsVarArg);

    public static LLVMTypeRef CreateFunction(LLVMTypeRef ReturnType, ReadOnlySpan<LLVMTypeRef> ParamTypes, bool IsVarArg)
    {
        fixed (LLVMTypeRef* pParamTypes = ParamTypes)
        {
            return LLVM.FunctionType(ReturnType, (LLVMOpaqueType**)pParamTypes, (uint)ParamTypes.Length, IsVarArg ? 1 : 0);
        }
    }

    public static LLVMTypeRef CreateArray(LLVMTypeRef ElementType, uint ElementCount) => LLVM.ArrayType(ElementType, ElementCount);

    public static LLVMTypeRef CreateArray2(LLVMTypeRef ElementType, ulong ElementCount) => LLVM.ArrayType2(ElementType, ElementCount);

    public static LLVMTypeRef CreateInt(uint NumBits) => LLVM.IntType(NumBits);

    public static LLVMTypeRef CreateIntPtr(LLVMTargetDataRef TD) => LLVM.IntPtrType(TD);

    public static LLVMTypeRef CreateIntPtrForAS(LLVMTargetDataRef TD, uint AS) => LLVM.IntPtrTypeForAS(TD, AS);

    public static LLVMTypeRef CreatePointer(LLVMTypeRef ElementType, uint AddressSpace) => LLVM.PointerType(ElementType, AddressSpace);

    public static LLVMTypeRef CreateStruct(LLVMTypeRef[] ElementTypes, bool Packed) => CreateStruct(ElementTypes.AsSpan(), Packed);

    public static LLVMTypeRef CreateStruct(ReadOnlySpan<LLVMTypeRef> ElementTypes, bool Packed)
    {
        fixed (LLVMTypeRef* pElementTypes = ElementTypes)
        {
            return LLVM.StructType((LLVMOpaqueType**)pElementTypes, (uint)ElementTypes.Length, Packed ? 1 : 0);
        }
    }

    public static LLVMTypeRef CreateVector(LLVMTypeRef ElementType, uint ElementCount) => LLVM.VectorType(ElementType, ElementCount);

    public static LLVMTypeRef CreateScalableVector(LLVMTypeRef ElementType, uint ElementCount) => LLVM.ScalableVectorType(ElementType, ElementCount);

    public readonly void Dump() => LLVM.DumpType(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMTypeRef other) && Equals(other);

    public readonly bool Equals(LLVMTypeRef other) => this == other;

    public readonly double GenericValueToFloat(LLVMGenericValueRef GenVal) => LLVM.GenericValueToFloat(this, GenVal);

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMTypeRef[] GetParamTypes()
    {
        if (Kind != LLVMTypeKind.LLVMFunctionTypeKind)
        {
            return [];
        }

        var destination = new LLVMTypeRef[ParamTypesCount];
        GetParamTypes(destination);
        return destination;
    }

    public readonly void GetParamTypes(Span<LLVMTypeRef> destination)
    {
        if (Kind != LLVMTypeKind.LLVMFunctionTypeKind)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, ParamTypesCount);

        fixed (LLVMTypeRef* pDest = destination)
        {
            LLVM.GetParamTypes(this, (LLVMOpaqueType**)pDest);
        }
    }

    public readonly LLVMTypeRef[] GetStructElementTypes()
    {
        if (Kind != LLVMTypeKind.LLVMStructTypeKind)
        {
            return [];
        }

        var destination = new LLVMTypeRef[StructElementTypesCount];
        GetStructElementTypes(destination);
        return destination;
    }

    public readonly void GetStructElementTypes(Span<LLVMTypeRef> destination)
    {
        if (Kind != LLVMTypeKind.LLVMStructTypeKind)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, StructElementTypesCount);

        fixed (LLVMTypeRef* pDest = destination)
        {
            LLVM.GetStructElementTypes(this, (LLVMOpaqueType**)pDest);
        }
    }

    public readonly LLVMTypeRef[] GetSubtypes()
    {
        if (Handle == IntPtr.Zero)
        {
            return [];
        }

        var destination = new LLVMTypeRef[SubtypesCount];
        GetSubtypes(destination);
        return destination;
    }

    public readonly void GetSubtypes(Span<LLVMTypeRef> destination)
    {
        if (Handle == IntPtr.Zero)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, SubtypesCount);

        fixed (LLVMTypeRef* pArr = destination)
        {
            LLVM.GetSubtypes(this, (LLVMOpaqueType**)pArr);
        }
    }

    public readonly string PrintToString()
    {
        var pStr = LLVM.PrintTypeToString(this);

        if (pStr == null)
        {
            return string.Empty;
        }

        var result = SpanExtensions.AsString(pStr);
        LLVM.DisposeMessage(pStr);
        return result;
    }

    public readonly LLVMTypeRef StructGetTypeAtIndex(uint index) => LLVM.StructGetTypeAtIndex(this, index);

    public readonly void StructSetBody(LLVMTypeRef[] ElementTypes, bool Packed) => StructSetBody(ElementTypes.AsSpan(), Packed);

    public readonly void StructSetBody(ReadOnlySpan<LLVMTypeRef> ElementTypes, bool Packed)
    {
        fixed (LLVMTypeRef* pElementTypes = ElementTypes)
        {
            LLVM.StructSetBody(this, (LLVMOpaqueType**)pElementTypes, (uint)ElementTypes.Length, Packed ? 1 : 0);
        }
    }

    public override readonly string ToString() => (Handle != IntPtr.Zero) ? PrintToString() : string.Empty;
}
