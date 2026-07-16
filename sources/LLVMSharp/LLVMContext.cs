// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class LLVMContext : IEquatable<LLVMContext>
{
    private static readonly ConcurrentDictionary<LLVMContextRef, WeakReference<LLVMContext>> s_createdContexts = new ConcurrentDictionary<LLVMContextRef, WeakReference<LLVMContext>>();

    private static readonly Lock s_createContextLock = new Lock();

    private readonly Dictionary<LLVMValueRef, WeakReference<Value>> _createdValues = [];
    private readonly Dictionary<LLVMTypeRef, WeakReference<Type>> _createdTypes = [];
    private readonly Dictionary<LLVMModuleRef, WeakReference<Module>> _createdModules = [];

    public LLVMContext() : this(LLVMContextRef.Create())
    {
    }

    private LLVMContext(LLVMContextRef handle)
    {
        Handle = handle;
        s_createdContexts.GetOrAdd(handle, static (_) => new WeakReference<LLVMContext>(null!)).SetTarget(this);
    }

    public LLVMContextRef Handle { get; }

    public Attribute CreateEnumAttribute(uint kindId, ulong value) => new Attribute(Handle.CreateEnumAttribute(kindId, value));

    public Attribute CreateEnumAttribute(ReadOnlySpan<char> name, ulong value) => new Attribute(Handle.CreateEnumAttribute(name, value));

    public Attribute CreateStringAttribute(ReadOnlySpan<char> kind, ReadOnlySpan<char> value) => new Attribute(Handle.CreateStringAttribute(kind, value));

    public static uint GetEnumAttributeKindForName(ReadOnlySpan<char> name) => LLVMContextRef.GetEnumAttributeKindForName(name);

    public static bool operator ==(LLVMContext? left, LLVMContext? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(LLVMContext? left, LLVMContext? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is LLVMContext other) && Equals(other);

    public bool Equals(LLVMContext? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();

    internal static LLVMContext GetOrCreate(LLVMContextRef handle)
    {
        if (handle == null)
        {
            Debug.Assert(handle != null);
            return null!;
        }

        var contextRef = s_createdContexts.GetOrAdd(handle, static (_) => new WeakReference<LLVMContext>(null!));

        if (!contextRef.TryGetTarget(out var context))
        {
            lock (s_createContextLock)
            {
                if (!contextRef.TryGetTarget(out context))
                {
                    context = new LLVMContext(handle);
                    contextRef.SetTarget(context);
                }
            }
        }
        return context;
    }

    internal BasicBlock GetOrCreate(LLVMBasicBlockRef handle) => GetOrCreate<BasicBlock>(handle.AsValue());

    internal TType GetOrCreate<TType>(LLVMTypeRef handle)
        where TType : Type
    {
        WeakReference<Type>? typeRef;

        if (handle == null)
        {
            Debug.Assert(handle != null);
            return null!;
        }
        else if (!_createdTypes.TryGetValue(handle, out typeRef))
        {
            typeRef = new WeakReference<Type>(null!);
            _createdTypes.Add(handle, typeRef);
        }

        if (!typeRef.TryGetTarget(out var type))
        {
            type = Type.Create(handle);
            typeRef.SetTarget(type);
        }
        return (TType)type;
    }

    internal TValue GetOrCreate<TValue>(LLVMValueRef handle)
        where TValue : Value
    {
        WeakReference<Value>? valueRef;

        if (handle == null)
        {
            Debug.Assert(handle != null);
            return null!;
        }
        else if (!_createdValues.TryGetValue(handle, out valueRef))
        {
            valueRef = new WeakReference<Value>(null!);
            _createdValues.Add(handle, valueRef);
        }

        if (!valueRef.TryGetTarget(out var value))
        {
            value = Value.Create(handle);
            valueRef.SetTarget(value);
        }
        return (TValue)value;
    }

    internal Type GetOrCreate(LLVMTypeRef handle) => GetOrCreate<Type>(handle);

    internal Value GetOrCreate(LLVMValueRef handle) => GetOrCreate<Value>(handle);

    internal Module GetOrCreate(LLVMModuleRef handle)
    {
        WeakReference<Module>? moduleRef;

        if (handle == null)
        {
            return null!;
        }
        else if (!_createdModules.TryGetValue(handle, out moduleRef))
        {
            moduleRef = new WeakReference<Module>(null!);
            _createdModules.Add(handle, moduleRef);
        }

        if (!moduleRef.TryGetTarget(out var module))
        {
            module = new Module(handle);
            moduleRef.SetTarget(module);
        }
        return module;
    }
}
