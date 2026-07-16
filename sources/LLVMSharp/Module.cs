// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class Module : IEquatable<Module>
{
    internal Module(LLVMModuleRef handle)
    {
        Handle = handle;
    }

    public LLVMModuleRef Handle { get; }

    public LLVMContext Context => LLVMContext.GetOrCreate(Handle.Context);

    public string DataLayoutString
    {
        get
        {
            return Handle.DataLayout;
        }

        set
        {
            var handle = Handle;
            handle.DataLayout = value;
        }
    }

    public string InlineAsm
    {
        get
        {
            return Handle.InlineAsm;
        }

        set
        {
            var handle = Handle;
            handle.InlineAsm = value;
        }
    }

    public string ModuleIdentifier
    {
        get
        {
            return Handle.ModuleIdentifier;
        }

        set
        {
            var handle = Handle;
            handle.ModuleIdentifier = value;
        }
    }

    public string SourceFileName
    {
        get
        {
            return Handle.SourceFileName;
        }

        set
        {
            var handle = Handle;
            handle.SourceFileName = value;
        }
    }

    public string TargetTriple
    {
        get
        {
            return Handle.Target;
        }

        set
        {
            var handle = Handle;
            handle.Target = value;
        }
    }

    public static Module Create(LLVMContext context, string name)
    {
        ArgumentNullException.ThrowIfNull(context);
        return context.GetOrCreate(context.Handle.CreateModuleWithName(name));
    }

    public Module Clone() => Context.GetOrCreate(Handle.Clone());

    public Function AddFunction(string name, FunctionType functionType)
    {
        ArgumentNullException.ThrowIfNull(functionType);
        return Context.GetOrCreate<Function>(Handle.AddFunction(name, functionType.Handle));
    }

    public GlobalAlias AddAlias(Type valueType, uint addressSpace, Constant aliasee, string name)
    {
        ArgumentNullException.ThrowIfNull(valueType);
        ArgumentNullException.ThrowIfNull(aliasee);
        return Context.GetOrCreate<GlobalAlias>(Handle.AddAlias2(valueType.Handle, addressSpace, aliasee.Handle, name));
    }

    public GlobalVariable AddGlobal(Type type, string name)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Context.GetOrCreate<GlobalVariable>(Handle.AddGlobal(type.Handle, name));
    }

    public GlobalVariable AddGlobalInAddressSpace(Type type, string name, uint addressSpace)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Context.GetOrCreate<GlobalVariable>(Handle.AddGlobalInAddressSpace(type.Handle, name, addressSpace));
    }

    public void Dump() => Handle.Dump();

    public Function? GetFunction(string name)
    {
        var handle = Handle.GetNamedFunction(name);
        return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<Function>(handle) : null;
    }

    public Function[] GetFunctions()
    {
        var result = new List<Function>();
        var context = Context;

        foreach (var handle in Handle.Functions)
        {
            result.Add(context.GetOrCreate<Function>(handle));
        }

        return [.. result];
    }

    public GlobalAlias[] GetGlobalAliases()
    {
        var result = new List<GlobalAlias>();
        var context = Context;

        foreach (var handle in Handle.GlobalAliases)
        {
            result.Add(context.GetOrCreate<GlobalAlias>(handle));
        }

        return [.. result];
    }

    public GlobalIFunc[] GetGlobalIFuncs()
    {
        var result = new List<GlobalIFunc>();
        var context = Context;

        foreach (var handle in Handle.GlobalIFuncs)
        {
            result.Add(context.GetOrCreate<GlobalIFunc>(handle));
        }

        return [.. result];
    }

    public GlobalVariable? GetGlobalVariable(string name)
    {
        var handle = Handle.GetNamedGlobal(name);
        return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<GlobalVariable>(handle) : null;
    }

    public GlobalVariable[] GetGlobalVariables()
    {
        var result = new List<GlobalVariable>();
        var context = Context;

        foreach (var handle in Handle.Globals)
        {
            result.Add(context.GetOrCreate<GlobalVariable>(handle));
        }

        return [.. result];
    }

    public StructType[] GetIdentifiedStructTypes()
    {
        var handles = Handle.GetIdentifiedStructTypes();

        if (handles.Length == 0)
        {
            return [];
        }

        var context = Context;
        var result = new StructType[handles.Length];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = context.GetOrCreate<StructType>(handles[i]);
        }

        return result;
    }

    public Function GetOrInsertFunction(string name, FunctionType functionType)
    {
        ArgumentNullException.ThrowIfNull(functionType);
        return GetFunction(name) ?? AddFunction(name, functionType);
    }

    public Comdat GetOrInsertComdat(string name) => new Comdat(Handle.GetOrInsertComdat(name));

    public StructType? GetTypeByName(string name)
    {
        var handle = Handle.GetTypeByName(name);
        return (handle.Handle != IntPtr.Zero) ? Context.GetOrCreate<StructType>(handle) : null;
    }

    public void PrintToFile(string filename) => Handle.PrintToFile(filename);

    public string PrintToString() => Handle.PrintToString();

    public bool TryPrintToFile(string filename, out string errorMessage) => Handle.TryPrintToFile(filename, out errorMessage);

    public bool TryVerify(LLVMVerifierFailureAction action, out string message) => Handle.TryVerify(action, out message);

    public void Verify(LLVMVerifierFailureAction action) => Handle.Verify(action);

    public int WriteBitcodeToFile(string path) => Handle.WriteBitcodeToFile(path);

    public static bool operator ==(Module? left, Module? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(Module? left, Module? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is Module other) && Equals(other);

    public bool Equals(Module? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();
}
