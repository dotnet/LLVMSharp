// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMetadataRef(IntPtr handle) : IEquatable<LLVMMetadataRef>
{
    public IntPtr Handle = handle;

    public readonly uint AlignInBits => IsType ? LLVM.DITypeGetAlignInBits(this) : default;

    public readonly uint Column => Kind switch {
        LLVMMetadataKind.LLVMDILocationMetadataKind => LLVM.DILocationGetColumn(this),
        _ => default,
    };

    public readonly LLVMMetadataRef Expression => Kind switch {
        LLVMMetadataKind.LLVMDIGlobalVariableExpressionMetadataKind => LLVM.DIGlobalVariableExpressionGetExpression(this),
        _ => default,
    };

    public readonly LLVMMetadataRef File => Kind switch {
        LLVMMetadataKind.LLVMDIFileMetadataKind => this,
        LLVMMetadataKind.LLVMDISubprogramMetadataKind => LLVM.DIScopeGetFile(this),
        _ when IsVariable => LLVM.DIVariableGetFile(this),
        _ => default,
    };

    public readonly LLVMDIFlags Flags => IsType ? LLVM.DITypeGetFlags(this) : default;

    public readonly LLVMMetadataRef InlinedAt => Kind switch {
        LLVMMetadataKind.LLVMDILocationMetadataKind => LLVM.DILocationGetInlinedAt(this),
        _ => default,
    };

    public readonly bool IsDINode => Kind is >= LLVMMetadataKind.LLVMDILocationMetadataKind and <= LLVMMetadataKind.LLVMDIAssignIDMetadataKind;

    public readonly bool IsTemplateParameter => Kind switch {
        LLVMMetadataKind.LLVMDITemplateTypeParameterMetadataKind => true,
        LLVMMetadataKind.LLVMDITemplateValueParameterMetadataKind => true,
        _ => false,
    };

    public readonly bool IsType => Kind switch {
        LLVMMetadataKind.LLVMDICompositeTypeMetadataKind => true,
        LLVMMetadataKind.LLVMDIDerivedTypeMetadataKind => true,
        LLVMMetadataKind.LLVMDIStringTypeMetadataKind => true,
        LLVMMetadataKind.LLVMDIBasicTypeMetadataKind => true,
        LLVMMetadataKind.LLVMDISubroutineTypeMetadataKind => true,
        _ => false,
    };

    public readonly bool IsVariable => Kind switch {
        LLVMMetadataKind.LLVMDILocalVariableMetadataKind => true,
        LLVMMetadataKind.LLVMDIGlobalVariableMetadataKind => true,
        _ => false,
    };

    public readonly LLVMMetadataKind Kind => Handle == default
        ? (LLVMMetadataKind)(-1) // 0 is a valid kind, so we use -1 to indicate a null metadata reference
        : (LLVMMetadataKind)LLVM.GetMetadataKind(this);

    public readonly uint Line => Kind switch {
        LLVMMetadataKind.LLVMDISubprogramMetadataKind => LLVM.DISubprogramGetLine(this),
        LLVMMetadataKind.LLVMDILocationMetadataKind => LLVM.DILocationGetLine(this),
        _ when IsType => LLVM.DITypeGetLine(this),
        _ when IsVariable => LLVM.DIVariableGetLine(this),
        _ => default,
    };

    public readonly string Name
    {
        get
        {
            if (!IsType)
            {
                return "";
            }

            nuint nameLength = 0;
            sbyte* namePtr = LLVM.DITypeGetName(this, &nameLength);
            if (namePtr == null)
            {
                return "";
            }

            return new ReadOnlySpan<byte>(namePtr, (int)nameLength).AsString();
        }
    }

    public readonly ulong OffsetInBits => IsType ? LLVM.DITypeGetOffsetInBits(this) : default;

    public readonly LLVMMetadataRef Scope => Kind switch {
        LLVMMetadataKind.LLVMDILocationMetadataKind => LLVM.DILocationGetScope(this),
        _ when IsVariable => LLVM.DIVariableGetScope(this),
        _ => default,
    };

    public readonly ulong SizeInBits => IsType ? LLVM.DITypeGetSizeInBits(this) : default;

    public readonly ushort Tag => IsDINode ? LLVM.GetDINodeTag(this) : default;

    public readonly LLVMMetadataRef Variable => Kind switch {
        LLVMMetadataKind.LLVMDIGlobalVariableExpressionMetadataKind => LLVM.DIGlobalVariableExpressionGetVariable(this),
        _ => default,
    };

    public static implicit operator LLVMMetadataRef(LLVMOpaqueMetadata* value) => new LLVMMetadataRef((IntPtr)value);

    public static implicit operator LLVMOpaqueMetadata*(LLVMMetadataRef value) => (LLVMOpaqueMetadata*)value.Handle;

    public static bool operator ==(LLVMMetadataRef left, LLVMMetadataRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMMetadataRef left, LLVMMetadataRef right) => !(left == right);

    public readonly LLVMValueRef AsValue(LLVMContextRef context) => context.MetadataAsValue(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMMetadataRef other) && Equals(other);

    public readonly bool Equals(LLVMMetadataRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly string GetMDString(LLVMContextRef context, out uint length)
    {
        var value = context.MetadataAsValue(this);
        return value.GetMDString(out length);
    }

    public override readonly string ToString() => $"{nameof(LLVMMetadataRef)}: {Handle:X}";
}
