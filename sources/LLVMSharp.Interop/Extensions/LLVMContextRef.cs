// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMContextRef(IntPtr handle) : IDisposable, IEquatable<LLVMContextRef>
{
    public IntPtr Handle = handle;

    public static LLVMContextRef Global => LLVM.GetGlobalContext();

    public readonly LLVMTypeRef BFloatType => (Handle != IntPtr.Zero) ? LLVM.BFloatTypeInContext(this) : default;

    public readonly LLVMTypeRef DoubleType => (Handle != IntPtr.Zero) ? LLVM.DoubleTypeInContext(this) : default;

    public readonly LLVMTypeRef FloatType => (Handle != IntPtr.Zero) ? LLVM.FloatTypeInContext(this) : default;

    public readonly LLVMTypeRef HalfType => (Handle != IntPtr.Zero) ? LLVM.HalfTypeInContext(this) : default;

    public readonly LLVMTypeRef Int1Type => (Handle != IntPtr.Zero) ? LLVM.Int1TypeInContext(this) : default;

    public readonly LLVMTypeRef Int8Type => (Handle != IntPtr.Zero) ? LLVM.Int8TypeInContext(this) : default;

    public readonly LLVMTypeRef Int16Type => (Handle != IntPtr.Zero) ? LLVM.Int16TypeInContext(this) : default;

    public readonly LLVMTypeRef Int32Type => (Handle != IntPtr.Zero) ? LLVM.Int32TypeInContext(this) : default;

    public readonly LLVMTypeRef Int64Type => (Handle != IntPtr.Zero) ? LLVM.Int64TypeInContext(this) : default;

    public readonly LLVMTypeRef FP128Type => (Handle != IntPtr.Zero) ? LLVM.FP128TypeInContext(this) : default;

    public readonly LLVMTypeRef LabelType => (Handle != IntPtr.Zero) ? LLVM.LabelTypeInContext(this) : default;

    public readonly LLVMTypeRef PPCFP128Type => (Handle != IntPtr.Zero) ? LLVM.PPCFP128TypeInContext(this) : default;

    public readonly LLVMTypeRef VoidType => (Handle != IntPtr.Zero) ? LLVM.VoidTypeInContext(this) : default;

    public readonly LLVMTypeRef X86FP80Type => (Handle != IntPtr.Zero) ? LLVM.X86FP80TypeInContext(this) : default;

    public readonly LLVMTypeRef X86MMXType => (Handle != IntPtr.Zero) ? LLVM.X86MMXTypeInContext(this) : default;

    public readonly LLVMTypeRef X86AMXType => (Handle != IntPtr.Zero) ? LLVM.X86AMXTypeInContext(this) : default;

    public static implicit operator LLVMContextRef(LLVMOpaqueContext* value) => new LLVMContextRef((IntPtr)value);

    public static implicit operator LLVMOpaqueContext*(LLVMContextRef value) => (LLVMOpaqueContext*)value.Handle;

    public static bool operator ==(LLVMContextRef left, LLVMContextRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMContextRef left, LLVMContextRef right) => !(left == right);

    public static LLVMContextRef Create() => LLVM.ContextCreate();

    public readonly LLVMBasicBlockRef AppendBasicBlock(LLVMValueRef Fn, string Name) => AppendBasicBlock(Fn, Name.AsSpan());

    public readonly LLVMBasicBlockRef AppendBasicBlock(LLVMValueRef Fn, ReadOnlySpan<char> Name) => LLVMBasicBlockRef.AppendInContext(this, Fn, Name);

    public readonly LLVMBasicBlockRef CreateBasicBlock(string Name) => CreateBasicBlock(Name.AsSpan());

    public readonly LLVMBasicBlockRef CreateBasicBlock(ReadOnlySpan<char> Name) => LLVMBasicBlockRef.CreateInContext(this, Name);

    public readonly LLVMBuilderRef CreateBuilder() => LLVMBuilderRef.Create(this);

    public readonly LLVMMetadataRef CreateDebugLocation(uint Line, uint Column, LLVMMetadataRef Scope, LLVMMetadataRef InlinedAt) => LLVM.DIBuilderCreateDebugLocation(this, Line, Column, Scope, InlinedAt);

    public readonly LLVMModuleRef CreateModuleWithName(string ModuleID) => CreateModuleWithName(ModuleID.AsSpan());

    public readonly LLVMModuleRef CreateModuleWithName(ReadOnlySpan<char> ModuleID)
    {
        using var marshaledModuleID = new MarshaledString(ModuleID);
        return LLVM.ModuleCreateWithNameInContext(marshaledModuleID, this);
    }

    public readonly LLVMTypeRef CreateNamedStruct(string Name) => CreateNamedStruct(Name.AsSpan());

    public readonly LLVMTypeRef CreateNamedStruct(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.StructCreateNamed(this, marshaledName);
    }

    public readonly LLVMAttributeRef CreateEnumAttribute(uint KindId, ulong Val)
    {
        return LLVM.CreateEnumAttribute(this, KindId, Val);
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.ContextDispose(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMContextRef other) && Equals(other);

    public readonly bool Equals(LLVMContextRef other) => this == other;

    public readonly LLVMModuleRef GetBitcodeModule(LLVMMemoryBufferRef MemBuf)
    {
        if (!TryGetBitcodeModule(MemBuf, out LLVMModuleRef M, out string Message))
        {
            throw new ExternalException(Message);
        }

        return M;
    }

    public readonly LLVMValueRef GetConstString(string Str, bool DontNullTerminate) => GetConstString(Str.AsSpan(), DontNullTerminate);

    public readonly LLVMValueRef GetConstString(ReadOnlySpan<char> Str, bool DontNullTerminate)
    {
        using var marshaledStr = new MarshaledString(Str);
        return LLVM.ConstStringInContext(this, marshaledStr, (uint)marshaledStr.Length, DontNullTerminate ? 1 : 0);
    }

    public readonly LLVMValueRef GetConstStruct(LLVMValueRef[] ConstantVals, bool Packed) => GetConstStruct(ConstantVals.AsSpan(), Packed);

    public readonly LLVMValueRef GetConstStruct(ReadOnlySpan<LLVMValueRef> ConstantVals, bool Packed)
    {
        fixed (LLVMValueRef* pConstantVals = ConstantVals)
        {
            return LLVM.ConstStructInContext(this, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length, Packed ? 1 : 0);
        }
    }

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMTypeRef GetIntPtrType(LLVMTargetDataRef TD) => LLVM.IntPtrTypeInContext(this, TD);

    public readonly LLVMTypeRef GetIntPtrTypeForAS(LLVMTargetDataRef TD, uint AS) => LLVM.IntPtrTypeForASInContext(this, TD, AS);

    public readonly LLVMTypeRef GetIntType(uint NumBits) => LLVM.IntTypeInContext(this, NumBits);

    public readonly uint GetMDKindID(string Name, uint SLen) => GetMDKindID(Name.AsSpan(0, (int)SLen));

    public readonly uint GetMDKindID(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.GetMDKindIDInContext(this, marshaledName, (uint)marshaledName.Length);
    }

    public readonly LLVMValueRef GetMDNode(LLVMValueRef[] Vals) => GetMDNode(Vals.AsSpan());

    public readonly LLVMValueRef GetMDNode(ReadOnlySpan<LLVMValueRef> Vals)
    {
        fixed (LLVMValueRef* pVals = Vals)
        {
            return LLVM.MDNodeInContext(this, (LLVMOpaqueValue**)pVals, (uint)Vals.Length);
        }
    }

    public readonly LLVMValueRef GetMDString(string Str, uint SLen) => GetMDString(Str.AsSpan(0, (int)SLen));

    public readonly LLVMValueRef GetMDString(ReadOnlySpan<char> Str)
    {
        using var marshaledStr = new MarshaledString(Str);
        return LLVM.MDStringInContext(this, marshaledStr, (uint)marshaledStr.Length);
    }

    public readonly LLVMTypeRef GetStructType(LLVMTypeRef[] ElementTypes, bool Packed) => GetStructType(ElementTypes.AsSpan(), Packed);

    public readonly LLVMTypeRef GetStructType(ReadOnlySpan<LLVMTypeRef> ElementTypes, bool Packed)
    {
        fixed (LLVMTypeRef* pElementTypes = ElementTypes)
        {
            return LLVM.StructTypeInContext(this, (LLVMOpaqueType**)pElementTypes, (uint)ElementTypes.Length, Packed ? 1 : 0);
        }
    }

    public readonly LLVMBasicBlockRef InsertBasicBlock(LLVMBasicBlockRef BB, string Name) => LLVMBasicBlockRef.InsertInContext(this, BB, Name);

    public readonly LLVMValueRef MetadataAsValue(LLVMMetadataRef MD) => LLVM.MetadataAsValue(this, MD);

    public readonly LLVMModuleRef ParseBitcode(LLVMMemoryBufferRef MemBuf)
    {
        if (!TryParseBitcode(MemBuf, out LLVMModuleRef M, out string Message))
        {
            throw new ExternalException(Message);
        }

        return M;
    }

    public readonly LLVMModuleRef ParseIR(LLVMMemoryBufferRef MemBuf)
    {
        if (!TryParseIR(MemBuf, out LLVMModuleRef M, out string Message))
        {
            throw new ExternalException(Message);
        }

        return M;
    }

    public readonly void SetDiagnosticHandler(LLVMDiagnosticHandler Handler, void* DiagnosticContext)
    {
        var pHandler = (delegate* unmanaged[Cdecl] < LLVMOpaqueDiagnosticInfo *, void *, void > )Marshal.GetFunctionPointerForDelegate(Handler);
        SetDiagnosticHandler(pHandler, DiagnosticContext);
    }

    public readonly void SetDiagnosticHandler(delegate* unmanaged[Cdecl]<LLVMOpaqueDiagnosticInfo*, void*, void> Handler, void* DiagnosticContext)
    {
        LLVM.ContextSetDiagnosticHandler(this, Handler, DiagnosticContext);
    }

    public readonly void SetYieldCallback(LLVMYieldCallback Callback, void* OpaqueHandle)
    {
        var pCallback = (delegate* unmanaged[Cdecl] < LLVMOpaqueContext *, void *, void>)Marshal.GetFunctionPointerForDelegate(Callback);
        SetYieldCallback(pCallback, OpaqueHandle);
    }

    public readonly void SetYieldCallback(delegate* unmanaged[Cdecl]<LLVMOpaqueContext*, void*, void> Callback, void* OpaqueHandle)
    {
        LLVM.ContextSetYieldCallback(this, Callback, OpaqueHandle);
    }

    public override readonly string ToString() => $"{nameof(LLVMContextRef)}: {Handle:X}";

    public readonly bool TryGetBitcodeModule(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
    {
        fixed (LLVMModuleRef* pOutM = &OutM)
        {
            sbyte* pMessage = null;
            var result = LLVM.GetBitcodeModuleInContext(this, MemBuf, (LLVMOpaqueModule**)pOutM, &pMessage);

            if (pMessage == null)
            {
                OutMessage = string.Empty;
            }
            else
            {
                OutMessage = SpanExtensions.AsString(pMessage);
            }

            return result == 0;
        }
    }

    public readonly bool TryParseBitcode(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutModule, out string OutMessage)
    {
        fixed (LLVMModuleRef* pOutModule = &OutModule)
        {
            sbyte* pMessage = null;
            var result = LLVM.ParseBitcodeInContext(this, MemBuf, (LLVMOpaqueModule**)pOutModule, &pMessage);

            if (pMessage == null)
            {
                OutMessage = string.Empty;
            }
            else
            {
                OutMessage = SpanExtensions.AsString(pMessage);
            }

            return result == 0;
        }
    }

    public readonly bool TryParseIR(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
    {
        fixed (LLVMModuleRef* pOutM = &OutM)
        {
            sbyte* pMessage = null;
            var result = LLVM.ParseIRInContext(this, MemBuf, (LLVMOpaqueModule**)pOutM, &pMessage);

            if (pMessage == null)
            {
                OutMessage = string.Empty;
            }
            else
            {
                OutMessage = SpanExtensions.AsString(pMessage);
            }

            return result == 0;
        }
    }
}
