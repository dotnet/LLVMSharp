// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class GlobalAlias : GlobalIndirectSymbol
{
    internal GlobalAlias(LLVMValueRef handle) : base(handle.IsAGlobalAlias, LLVMValueKind.LLVMGlobalAliasValueKind)
    {
    }

    public Constant? Aliasee
    {
        get
        {
            var aliasee = Handle.Aliasee;
            return (aliasee == null) ? null : Context.GetOrCreate<Constant>(aliasee);
        }

        set
        {
            ArgumentNullException.ThrowIfNull(value);
            var handle = Handle;
            handle.Aliasee = value.Handle;
        }
    }
}
