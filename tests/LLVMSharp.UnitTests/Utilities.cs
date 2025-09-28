// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LLVMSharp.Interop;

namespace LLVMSharp.UnitTests;

public static class Utilities
{
    public static void EnsurePropertiesWork(this object obj, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] System.Type type)
    {
        ArgumentNullException.ThrowIfNull(obj);
        ArgumentNullException.ThrowIfNull(type);

        var map = new Dictionary<string, object?>();

        foreach(var p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            map.Add(p.Name, p.GetValue(obj));
        }
    }

    public static (LLVMTypeRef functionType, LLVMValueRef function) AddFunction(this LLVMModuleRef module, LLVMTypeRef returnType, string name, LLVMTypeRef[] parameterTypes, Action<LLVMValueRef, LLVMBuilderRef> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var type = LLVMTypeRef.CreateFunction(returnType, parameterTypes);
        var func = module.AddFunction(name, type);
        var block = func.AppendBasicBlock(string.Empty);
        var builder = module.Context.CreateBuilder();
        builder.PositionAtEnd(block);
        action(func, builder);
        return (type, func);
    }
}
