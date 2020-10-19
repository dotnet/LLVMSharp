// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMContextRef : IDisposable, IEquatable<LLVMContextRef>
    {
        public IntPtr Handle;

        public LLVMContextRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static LLVMContextRef Global => LLVM.GetGlobalContext();

        public LLVMTypeRef BFloatType => (Handle != IntPtr.Zero) ? LLVM.BFloatTypeInContext(this) : default;

        public LLVMTypeRef DoubleType => (Handle != IntPtr.Zero) ? LLVM.DoubleTypeInContext(this) : default;

        public LLVMTypeRef FloatType => (Handle != IntPtr.Zero) ? LLVM.FloatTypeInContext(this) : default;

        public LLVMTypeRef HalfType => (Handle != IntPtr.Zero) ? LLVM.HalfTypeInContext(this) : default;

        public LLVMTypeRef Int1Type => (Handle != IntPtr.Zero) ? LLVM.Int1TypeInContext(this) : default;

        public LLVMTypeRef Int8Type => (Handle != IntPtr.Zero) ? LLVM.Int8TypeInContext(this) : default;

        public LLVMTypeRef Int16Type => (Handle != IntPtr.Zero) ? LLVM.Int16TypeInContext(this) : default;

        public LLVMTypeRef Int32Type => (Handle != IntPtr.Zero) ? LLVM.Int32TypeInContext(this) : default;

        public LLVMTypeRef Int64Type => (Handle != IntPtr.Zero) ? LLVM.Int64TypeInContext(this) : default;

        public LLVMTypeRef FP128Type => (Handle != IntPtr.Zero) ? LLVM.FP128TypeInContext(this) : default;

        public LLVMTypeRef LabelType => (Handle != IntPtr.Zero) ? LLVM.LabelTypeInContext(this) : default;

        public LLVMTypeRef PPCFP128Type => (Handle != IntPtr.Zero) ? LLVM.PPCFP128TypeInContext(this) : default;

        public LLVMTypeRef VoidType => (Handle != IntPtr.Zero) ? LLVM.VoidTypeInContext(this) : default;

        public LLVMTypeRef X86FP80Type => (Handle != IntPtr.Zero) ? LLVM.X86FP80TypeInContext(this) : default;

        public LLVMTypeRef X86MMXType => (Handle != IntPtr.Zero) ? LLVM.X86MMXTypeInContext(this) : default;

        public static implicit operator LLVMContextRef(LLVMOpaqueContext* value) => new LLVMContextRef((IntPtr)value);

        public static implicit operator LLVMOpaqueContext*(LLVMContextRef value) => (LLVMOpaqueContext*)value.Handle;

        public static bool operator ==(LLVMContextRef left, LLVMContextRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMContextRef left, LLVMContextRef right) => !(left == right);

        public static LLVMContextRef Create() => LLVM.ContextCreate();

        public LLVMBasicBlockRef AppendBasicBlock(LLVMValueRef Fn, string Name) => AppendBasicBlock(Fn, Name.AsSpan());

        public LLVMBasicBlockRef AppendBasicBlock(LLVMValueRef Fn, ReadOnlySpan<char> Name) => LLVMBasicBlockRef.AppendInContext(this, Fn, Name);

        public LLVMBasicBlockRef CreateBasicBlock(string Name) => CreateBasicBlock(Name.AsSpan());

        public LLVMBasicBlockRef CreateBasicBlock(ReadOnlySpan<char> Name) => LLVMBasicBlockRef.CreateInContext(this, Name);

        public LLVMBuilderRef CreateBuilder() => LLVMBuilderRef.Create(this);

        public LLVMMetadataRef CreateDebugLocation(uint Line, uint Column, LLVMMetadataRef Scope, LLVMMetadataRef InlinedAt) => LLVM.DIBuilderCreateDebugLocation(this, Line, Column, Scope, InlinedAt);

        public LLVMModuleRef CreateModuleWithName(string ModuleID) => CreateModuleWithName(ModuleID.AsSpan());

        public LLVMModuleRef CreateModuleWithName(ReadOnlySpan<char> ModuleID)
        {
            using var marshaledModuleID = new MarshaledString(ModuleID);
            return LLVM.ModuleCreateWithNameInContext(marshaledModuleID, this);
        }

        public LLVMTypeRef CreateNamedStruct(string Name) => CreateNamedStruct(Name.AsSpan());

        public LLVMTypeRef CreateNamedStruct(ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.StructCreateNamed(this, marshaledName);
        }

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                LLVM.ContextDispose(this);
                Handle = IntPtr.Zero;
            }
        }

        public override bool Equals(object obj) => (obj is LLVMContextRef other) && Equals(other);

        public bool Equals(LLVMContextRef other) => this == other;

        public LLVMModuleRef GetBitcodeModule(LLVMMemoryBufferRef MemBuf)
        {
            if (!TryGetBitcodeModule(MemBuf, out LLVMModuleRef M, out string Message))
            {
                throw new ExternalException(Message);
            }

            return M;
        }

        public LLVMValueRef GetConstString(string Str, bool DontNullTerminate) => GetConstString(Str.AsSpan(), DontNullTerminate);

        public LLVMValueRef GetConstString(ReadOnlySpan<char> Str, bool DontNullTerminate)
        {
            using var marshaledStr = new MarshaledString(Str);
            return LLVM.ConstStringInContext(this, marshaledStr, (uint)marshaledStr.Length, DontNullTerminate ? 1 : 0);
        }

        public LLVMValueRef GetConstStruct(LLVMValueRef[] ConstantVals, bool Packed) => GetConstStruct(ConstantVals.AsSpan(), Packed);

        public LLVMValueRef GetConstStruct(ReadOnlySpan<LLVMValueRef> ConstantVals, bool Packed)
        {
            fixed (LLVMValueRef* pConstantVals = ConstantVals)
            {
                return LLVM.ConstStructInContext(this, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length, Packed ? 1 : 0);
            }
        }

        public override int GetHashCode() => Handle.GetHashCode();

        public LLVMTypeRef GetIntPtrType(LLVMTargetDataRef TD) => LLVM.IntPtrTypeInContext(this, TD);

        public LLVMTypeRef GetIntPtrTypeForAS(LLVMTargetDataRef TD, uint AS) => LLVM.IntPtrTypeForASInContext(this, TD, AS);

        public LLVMTypeRef GetIntType(uint NumBits) => LLVM.IntTypeInContext(this, NumBits);

        public uint GetMDKindID(string Name, uint SLen) => GetMDKindID(Name.AsSpan(0, (int)SLen));

        public uint GetMDKindID(ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.GetMDKindIDInContext(this, marshaledName, (uint)marshaledName.Length);
        }

        public LLVMValueRef GetMDNode(LLVMValueRef[] Vals) => GetMDNode(Vals.AsSpan());

        public LLVMValueRef GetMDNode(ReadOnlySpan<LLVMValueRef> Vals)
        {
            fixed (LLVMValueRef* pVals = Vals)
            {
                return LLVM.MDNodeInContext(this, (LLVMOpaqueValue**)pVals, (uint)Vals.Length);
            }
        }

        public LLVMValueRef GetMDString(string Str, uint SLen) => GetMDString(Str.AsSpan(0, (int)SLen));

        public LLVMValueRef GetMDString(ReadOnlySpan<char> Str)
        {
            using var marshaledStr = new MarshaledString(Str);
            return LLVM.MDStringInContext(this, marshaledStr, (uint)marshaledStr.Length);
        }

        public LLVMTypeRef GetStructType(LLVMTypeRef[] ElementTypes, bool Packed) => GetStructType(ElementTypes.AsSpan(), Packed);

        public LLVMTypeRef GetStructType(ReadOnlySpan<LLVMTypeRef> ElementTypes, bool Packed)
        {
            fixed (LLVMTypeRef* pElementTypes = ElementTypes)
            {
                return LLVM.StructTypeInContext(this, (LLVMOpaqueType**)pElementTypes, (uint)ElementTypes.Length, Packed ? 1 : 0);
            }
        }

        public LLVMBasicBlockRef InsertBasicBlock(LLVMBasicBlockRef BB, string Name) => LLVMBasicBlockRef.InsertInContext(this, BB, Name);

        public LLVMValueRef MetadataAsValue(LLVMMetadataRef MD) => LLVM.MetadataAsValue(this, MD);

        public LLVMModuleRef ParseBitcode(LLVMMemoryBufferRef MemBuf)
        {
            if (!TryParseBitcode(MemBuf, out LLVMModuleRef M, out string Message))
            {
                throw new ExternalException(Message);
            }

            return M;
        }

        public LLVMModuleRef ParseIR(LLVMMemoryBufferRef MemBuf)
        {
            if (!TryParseIR(MemBuf, out LLVMModuleRef M, out string Message))
            {
                throw new ExternalException(Message);
            }

            return M;
        }

        public void SetDiagnosticHandler(LLVMDiagnosticHandler Handler, IntPtr DiagnosticContext)
        {
            var pHandler = Marshal.GetFunctionPointerForDelegate(Handler);
            LLVM.ContextSetDiagnosticHandler(this, pHandler, (void*)DiagnosticContext);
        }

        public void SetYieldCallback(LLVMYieldCallback Callback, IntPtr OpaqueHandle)
        {
            var pCallback = Marshal.GetFunctionPointerForDelegate(Callback);
            LLVM.ContextSetYieldCallback(this, pCallback, (void*)OpaqueHandle);
        }

        public override string ToString() => $"{nameof(LLVMContextRef)}: {Handle:X}";

        public bool TryGetBitcodeModule(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
        {
            fixed (LLVMModuleRef* pOutM = &OutM)
            {
                sbyte* pMessage;
                var result = LLVM.GetBitcodeModuleInContext(this, MemBuf, (LLVMOpaqueModule**)pOutM, &pMessage);

                if (pMessage is null)
                {
                    OutMessage = string.Empty;
                }
                else
                {
                    var span = new ReadOnlySpan<byte>(pMessage, int.MaxValue);
                    OutMessage = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
                }

                return result == 0;
            }
        }

        public bool TryParseBitcode(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutModule, out string OutMessage)
        {
            fixed (LLVMModuleRef* pOutModule = &OutModule)
            {
                sbyte* pMessage;
                var result = LLVM.ParseBitcodeInContext(this, MemBuf, (LLVMOpaqueModule**)pOutModule, &pMessage);

                if (pMessage is null)
                {
                    OutMessage = string.Empty;
                }
                else
                {
                    var span = new ReadOnlySpan<byte>(pMessage, int.MaxValue);
                    OutMessage = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
                }

                return result == 0;
            }
        }

        public bool TryParseIR(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
        {
            fixed (LLVMModuleRef* pOutM = &OutM)
            {
                sbyte* pMessage;
                var result = LLVM.ParseIRInContext(this, MemBuf, (LLVMOpaqueModule**)pOutM, &pMessage);

                if (pMessage is null)
                {
                    OutMessage = string.Empty;
                }
                else
                {
                    var span = new ReadOnlySpan<byte>(pMessage, int.MaxValue);
                    OutMessage = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
                }

                return result == 0;
            }
        }
    }
}
