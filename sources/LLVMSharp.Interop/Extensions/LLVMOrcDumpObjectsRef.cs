// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcDumpObjectsRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcDumpObjectsRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcDumpObjectsRef(LLVMOrcOpaqueDumpObjects* value) => new LLVMOrcDumpObjectsRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueDumpObjects*(LLVMOrcDumpObjectsRef value) => (LLVMOrcOpaqueDumpObjects*)value.Handle;

    public static bool operator ==(LLVMOrcDumpObjectsRef left, LLVMOrcDumpObjectsRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcDumpObjectsRef left, LLVMOrcDumpObjectsRef right) => !(left == right);

    public static LLVMOrcDumpObjectsRef Create(string DumpDir, string IdentifierOverride) => Create(DumpDir.AsSpan(), IdentifierOverride.AsSpan());

    public static LLVMOrcDumpObjectsRef Create(ReadOnlySpan<char> DumpDir, ReadOnlySpan<char> IdentifierOverride)
    {
        using var marshaledDumpDir = new MarshaledString(DumpDir);
        using var marshaledIdentifierOverride = new MarshaledString(IdentifierOverride);
        return LLVM.OrcCreateDumpObjects(marshaledDumpDir, marshaledIdentifierOverride);
    }

    // Dumps ObjBuffer and, on success, returns it (possibly replaced) through the ref parameter.
    public readonly LLVMErrorRef CallOperator(ref LLVMMemoryBufferRef ObjBuffer)
    {
        fixed (LLVMMemoryBufferRef* pObjBuffer = &ObjBuffer)
        {
            return LLVM.OrcDumpObjects_CallOperator(this, (LLVMOpaqueMemoryBuffer**)pObjBuffer);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeDumpObjects(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcDumpObjectsRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcDumpObjectsRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcDumpObjectsRef)}: {Handle:X}";
}
