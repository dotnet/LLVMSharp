// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Text;

namespace LLVMSharp.Interop;

public static unsafe partial class llvmsharp
{
    public static LLVMTypeRef[] Module_GetIdentifiedStructTypes(LLVMModuleRef module)
    {
        LLVMOpaqueType** buffer;
        int size;
        Module_GetIdentifiedStructTypes(module, &buffer, &size);
        var result = new ReadOnlySpan<LLVMTypeRef>(buffer, size).ToArray();
        FreeTypeBuffer(buffer);
        return result;
    }

    public static int Value_getDemangledName(LLVMValueRef value, Span<byte> buffer)
    {
        fixed (byte* bufferPtr = buffer)
        {
            return Value_getDemangledName(value, (sbyte*)bufferPtr, buffer.Length);
        }
    }

    public static string? Value_getDemangledName(LLVMValueRef value)
    {
        const int MaxLength = 4096;
        Span<byte> buffer = stackalloc byte[MaxLength];
        int length = Value_getDemangledName(value, buffer);
        if (length == 0)
        {
            return null;
        }
        return Encoding.UTF8.GetString(buffer[..length]);
    }
}
