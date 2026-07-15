// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class GlobalVariable : GlobalObject
{
    internal GlobalVariable(LLVMValueRef handle) : base(handle.IsAGlobalVariable, LLVMValueKind.LLVMGlobalVariableValueKind)
    {
    }

    public Constant? Initializer
    {
        get
        {
            var initializer = Handle.Initializer;
            return (initializer == null) ? null : Context.GetOrCreate<Constant>(initializer);
        }

        set
        {
            var handle = Handle;
            handle.Initializer = (value is not null) ? value.Handle : default;
        }
    }

    public bool IsConstant
    {
        get
        {
            return Handle.IsGlobalConstant;
        }

        set
        {
            var handle = Handle;
            handle.IsGlobalConstant = value;
        }
    }

    public bool IsExternallyInitialized
    {
        get
        {
            return Handle.IsExternallyInitialized;
        }

        set
        {
            var handle = Handle;
            handle.IsExternallyInitialized = value;
        }
    }

    public bool IsThreadLocal
    {
        get
        {
            return Handle.IsThreadLocal;
        }

        set
        {
            var handle = Handle;
            handle.IsThreadLocal = value;
        }
    }

    public LLVMThreadLocalMode ThreadLocalMode
    {
        get
        {
            return Handle.ThreadLocalMode;
        }

        set
        {
            var handle = Handle;
            handle.ThreadLocalMode = value;
        }
    }

    public void EraseFromParent() => Handle.DeleteGlobal();
}
