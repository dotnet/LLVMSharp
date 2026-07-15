// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp;

public class GlobalValue : Constant
{
    private protected GlobalValue(LLVMValueRef handle, LLVMValueKind expectedValueKind) : base(handle.IsAGlobalValue, expectedValueKind)
    {
    }

    public uint Alignment
    {
        get
        {
            return Handle.Alignment;
        }

        set
        {
            Handle.SetAlignment(value);
        }
    }

    public LLVMDLLStorageClass DLLStorageClass
    {
        get
        {
            return Handle.DLLStorageClass;
        }

        set
        {
            var handle = Handle;
            handle.DLLStorageClass = value;
        }
    }

    public bool IsDeclaration => Handle.IsDeclaration;

    public LLVMLinkage Linkage
    {
        get
        {
            return Handle.Linkage;
        }

        set
        {
            var handle = Handle;
            handle.Linkage = value;
        }
    }

    public LLVMUnnamedAddr UnnamedAddress
    {
        get
        {
            return Handle.UnnamedAddress;
        }

        set
        {
            var handle = Handle;
            handle.UnnamedAddress = value;
        }
    }

    public Type ValueType => Context.GetOrCreate(Handle.GlobalValueType);

    public LLVMVisibility Visibility
    {
        get
        {
            return Handle.Visibility;
        }

        set
        {
            var handle = Handle;
            handle.Visibility = value;
        }
    }

    internal static new GlobalValue Create(LLVMValueRef handle) => handle switch
    {
        _ when handle.IsAGlobalAlias != null => new GlobalAlias(handle),
        _ when handle.IsAGlobalIFunc != null => new GlobalIFunc(handle),
        _ when handle.IsAGlobalObject != null => GlobalObject.Create(handle),
        _ => new GlobalValue(handle, handle.Kind),
    };
}
