// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Diagnostics;

namespace LLVMSharp.Interop;

/// <summary>Defines the type of a member as it was used in the native signature.</summary>
/// <remarks>Initializes a new instance of the <see cref="NativeTypeNameAttribute" /> class.</remarks>
/// <param name="name">The name of the type that was used in the native signature.</param>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
[Conditional("DEBUG")]
internal sealed partial class NativeTypeNameAttribute(string name) : Attribute
{
    private readonly string _name = name;

    /// <summary>Gets the name of the type that was used in the native signature.</summary>
    public string Name => _name;
}
