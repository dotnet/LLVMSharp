// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMBasicBlockRef(IntPtr handle) : IEquatable<LLVMBasicBlockRef>
{
    public IntPtr Handle = handle;

    public readonly LLVMValueRef FirstInstruction => (Handle != IntPtr.Zero) ? LLVM.GetFirstInstruction(this) : default;

    public readonly LLVMValueRef LastInstruction => (Handle != IntPtr.Zero) ? LLVM.GetLastInstruction(this) : default;

    public readonly LLVMBasicBlockRef Next => (Handle != IntPtr.Zero) ? LLVM.GetNextBasicBlock(this) : default;

    public readonly LLVMValueRef Parent => (Handle != IntPtr.Zero) ? LLVM.GetBasicBlockParent(this) : default;

    public readonly LLVMBasicBlockRef Previous => (Handle != IntPtr.Zero) ? LLVM.GetPreviousBasicBlock(this) : default;

    public readonly LLVMValueRef Terminator => (Handle != IntPtr.Zero) ? LLVM.GetBasicBlockTerminator(this) : default;

    public static explicit operator LLVMBasicBlockRef(LLVMOpaqueValue* value) => new LLVMBasicBlockRef((IntPtr)value);

    public static implicit operator LLVMBasicBlockRef(LLVMOpaqueBasicBlock* value) => new LLVMBasicBlockRef((IntPtr)value);

    public static implicit operator LLVMOpaqueBasicBlock*(LLVMBasicBlockRef value) => (LLVMOpaqueBasicBlock*)value.Handle;

    public static implicit operator LLVMOpaqueValue*(LLVMBasicBlockRef value) => (LLVMOpaqueValue*)value.Handle;

    public static bool operator ==(LLVMBasicBlockRef left, LLVMBasicBlockRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMBasicBlockRef left, LLVMBasicBlockRef right) => !(left == right);

    public static LLVMBasicBlockRef AppendInContext(LLVMContextRef C, LLVMValueRef Fn, string Name) => AppendInContext(C, Fn, Name.AsSpan());

    public static LLVMBasicBlockRef AppendInContext(LLVMContextRef C, LLVMValueRef Fn, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AppendBasicBlockInContext(C, Fn, marshaledName);
    }

    public static LLVMBasicBlockRef CreateInContext(LLVMContextRef C, string Name) => CreateInContext(C, Name.AsSpan());

    public static LLVMBasicBlockRef CreateInContext(LLVMContextRef C, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.CreateBasicBlockInContext(C, marshaledName);
    }

    public static LLVMBasicBlockRef InsertInContext(LLVMContextRef C, LLVMBasicBlockRef BB, string Name) => InsertInContext(C, BB, Name.AsSpan());

    public static LLVMBasicBlockRef InsertInContext(LLVMContextRef C, LLVMBasicBlockRef BB, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.InsertBasicBlockInContext(C, BB, marshaledName);
    }

    public readonly LLVMValueRef AsValue() => LLVM.BasicBlockAsValue(this);

    public readonly void Delete() => LLVM.DeleteBasicBlock(this);

    public readonly void Dump() => LLVM.DumpValue(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMBasicBlockRef other) && Equals(other);

    public readonly bool Equals(LLVMBasicBlockRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMBasicBlockRef InsertBasicBlock(string Name) => InsertBasicBlock(Name.AsSpan());

    public readonly LLVMBasicBlockRef InsertBasicBlock(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.InsertBasicBlock(this, marshaledName);
    }

    public readonly void MoveAfter(LLVMBasicBlockRef MovePos) => LLVM.MoveBasicBlockAfter(this, MovePos);

    public readonly void MoveBefore(LLVMBasicBlockRef MovePos) => LLVM.MoveBasicBlockBefore(this, MovePos);

    public readonly string PrintToString()
    {
        var pStr = LLVM.PrintValueToString(this);

        if (pStr == null)
        {
            return string.Empty;
        }

        var result = SpanExtensions.AsString(pStr);
        LLVM.DisposeMessage(pStr);
        return result;
    }

    public readonly void RemoveFromParent() => LLVM.RemoveBasicBlockFromParent(this);

    public override readonly string ToString() => (Handle != IntPtr.Zero) ? PrintToString() : string.Empty;
}
