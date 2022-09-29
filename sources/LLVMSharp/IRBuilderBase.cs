// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public unsafe class IRBuilderBase : IEquatable<IRBuilderBase>
{
    private protected IRBuilderBase(LLVMContext c)
    {
        Context = c;
        Handle = LLVMBuilderRef.Create(c.Handle);
    }

    public LLVMContext Context { get; }

    public LLVMBuilderRef Handle { get; }

    public BasicBlock InsertBlock
    {
        get
        {
            var handle = Handle.InsertBlock;
            return Context.GetOrCreate(handle);
        }
    }

    public static bool operator ==(IRBuilderBase? left, IRBuilderBase? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(IRBuilderBase? left, IRBuilderBase? right) => !(left == right);

    public void ClearInsertionPoint() => Handle.ClearInsertionPosition();

    public GlobalVariable CreateGlobalString(string str, string name = "") => CreateGlobalString(str.AsSpan(), name.AsSpan());

    public GlobalVariable CreateGlobalString(ReadOnlySpan<char> str, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildGlobalString(str, name);
        return Context.GetOrCreate<GlobalVariable>(handle);
    }

    public override bool Equals(object? obj) => (obj is IRBuilderBase other) && Equals(other);

    public bool Equals(IRBuilderBase? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public void SetInsertPoint(BasicBlock theBB) => Handle.PositionAtEnd(theBB.Handle);

    public void SetInstDebugLocation(Instruction i) => Handle.SetInstDebugLocation(i.Handle);

    public override string ToString() => Handle.ToString();
}
