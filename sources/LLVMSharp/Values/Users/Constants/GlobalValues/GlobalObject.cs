// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public class GlobalObject : GlobalValue
{
    private protected GlobalObject(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAGlobalObject, expectedValueKind)
    {
    }

    public Comdat? Comdat
    {
        get
        {
            var comdat = Handle.Comdat;
            return (comdat.Handle != IntPtr.Zero) ? new Comdat(comdat) : null;
        }

        set
        {
            var handle = Handle;
            handle.Comdat = (value is not null) ? value.Handle : default;
        }
    }

    public bool HasComdat => Handle.Comdat.Handle != IntPtr.Zero;

    public string Section
    {
        get
        {
            return Handle.Section;
        }

        set
        {
            var handle = Handle;
            handle.Section = value;
        }
    }

    internal static new GlobalObject Create(LLVMValueRef handle) => handle switch
    {
        _ when handle.IsAFunction != null => new Function(handle),
        _ when handle.IsAGlobalVariable != null => new GlobalVariable(handle),
        _ => new GlobalObject(handle, handle.Kind),
    };
}
