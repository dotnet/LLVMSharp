// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class GlobalIFunc : GlobalIndirectSymbol
{
    internal GlobalIFunc(LLVMValueRef handle) : base(handle.IsAGlobalIFunc, LLVMValueKind.LLVMGlobalIFuncValueKind)
    {
    }

    public Constant? Resolver
    {
        get
        {
            var resolver = Handle.GlobalIFuncResolver;
            return (resolver == null) ? null : Context.GetOrCreate<Constant>(resolver);
        }

        set
        {
            ArgumentNullException.ThrowIfNull(value);
            var handle = Handle;
            handle.GlobalIFuncResolver = value.Handle;
        }
    }
}
