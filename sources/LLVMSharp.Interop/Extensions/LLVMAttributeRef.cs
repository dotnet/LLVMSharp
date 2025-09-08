// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMAttributeRef(IntPtr handle) : IEquatable<LLVMAttributeRef>
{
    public IntPtr Handle = handle;

    /// <summary>
    /// <see href="https://github.com/llvm/llvm-project/blob/a64e6f49284a7ffd5401183d0e94a94a7de39cfb/llvm/include/llvm/IR/Attributes.h#L233"/>
    /// </summary>
    public readonly bool HasKindAsEnum => (Handle != IntPtr.Zero) && (LLVM.IsStringAttribute(this) == 0);

    /// <summary>
    /// <see href="https://github.com/llvm/llvm-project/blob/de7bac6426e7f544189dfba7ae658dcf3d7be5f6/llvm/lib/IR/Core.cpp#L231">This returns true for enum attributes and int attributes.</see>
    /// </summary>
    public readonly bool IsEnumAttribute => Handle != IntPtr.Zero && LLVM.IsEnumAttribute(this) != 0;

    public readonly bool IsStringAttribute => Handle != IntPtr.Zero && LLVM.IsStringAttribute(this) != 0;

    public readonly bool IsTypeAttribute => Handle != IntPtr.Zero && LLVM.IsTypeAttribute(this) != 0;

    public readonly uint KindAsEnum => HasKindAsEnum ? LLVM.GetEnumAttributeKind(this) : default;

    public readonly string KindAsString
    {
        get
        {
            if (!IsStringAttribute)
            {
                return string.Empty;
            }

            uint length = 0;
            var kindPtr = LLVM.GetStringAttributeKind(this, &length);
            if (kindPtr == null)
            {
                return string.Empty;
            }

            return new ReadOnlySpan<byte>(kindPtr, (int)length).AsString();
        }
    }

    /// <summary>
    /// <see href="https://github.com/llvm/llvm-project/blob/a64e6f49284a7ffd5401183d0e94a94a7de39cfb/llvm/lib/IR/Core.cpp#L175"/>
    /// </summary>
    public readonly ulong ValueAsInt => IsEnumAttribute ? LLVM.GetEnumAttributeValue(this) : default;

    public readonly string ValueAsString
    {
        get
        {
            if (!IsStringAttribute)
            {
                return string.Empty;
            }

            uint length = 0;
            var valuePtr = LLVM.GetStringAttributeValue(this, &length);
            if (valuePtr == null)
            {
                return string.Empty;
            }

            return new ReadOnlySpan<byte>(valuePtr, (int)length).AsString();
        }
    }

    public readonly LLVMTypeRef ValueAsType => IsTypeAttribute ? LLVM.GetTypeAttributeValue(this) : default;

    public static implicit operator LLVMAttributeRef(LLVMOpaqueAttributeRef* value) => new LLVMAttributeRef((IntPtr)value);

    public static implicit operator LLVMOpaqueAttributeRef*(LLVMAttributeRef value) => (LLVMOpaqueAttributeRef*)value.Handle;

    public static bool operator ==(LLVMAttributeRef left, LLVMAttributeRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMAttributeRef left, LLVMAttributeRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMAttributeRef other) && Equals(other);

    public readonly bool Equals(LLVMAttributeRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMAttributeRef)}: {Handle:X}";
}
