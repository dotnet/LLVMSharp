// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Diagnostics;
using System.Text;

namespace LLVMSharp.Interop;

public static unsafe partial class llvmsharp
{
    public static ReadOnlySpan<byte> ConstantDataArray_getData(LLVMValueRef array)
    {
        int length = 0;
        byte* buffer = (byte*)ConstantDataArray_getData(array, &length);
        return new ReadOnlySpan<byte>(buffer, (int)length);
    }

    public static LLVMMetadataRef[] DICompositeType_getElements(LLVMMetadataRef type)
    {
        LLVMMetadataRef* buffer = null;
        int size = 0;
        DICompositeType_getElements(type, (LLVMOpaqueMetadata***)&buffer, &size);
        var result = new ReadOnlySpan<LLVMMetadataRef>(buffer, size).ToArray();
        Free(buffer);
        return result;
    }

    public static string DICompositeType_getIdentifier(LLVMMetadataRef type)
    {
        int length = 0;
        sbyte* identifier = DICompositeType_getIdentifier(type, &length);
        if (identifier == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(identifier, length).AsString();
    }

    public static string DIEnumerator_getName(LLVMMetadataRef enumerator)
    {
        int length = 0;
        sbyte* name = DIEnumerator_getName(enumerator, &length);
        if (name == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(name, length).AsString();
    }

    public static string DINamespace_getName(LLVMMetadataRef node)
    {
        int length = 0;
        sbyte* name = DINamespace_getName(node, &length);
        if (name == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(name, length).AsString();
    }

    public static string DINode_getTagString(LLVMMetadataRef node)
    {
        int length = 0;
        sbyte* tagString = DINode_getTagString(node, &length);
        if (tagString == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(tagString, length).AsString();
    }

    public static string DISubprogram_getLinkageName(LLVMMetadataRef subprogram)
    {
        int length = 0;
        sbyte* name = DISubprogram_getLinkageName(subprogram, &length);
        if (name == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(name, length).AsString();
    }

    public static string DISubprogram_getName(LLVMMetadataRef subprogram)
    {
        int length = 0;
        sbyte* name = DISubprogram_getName(subprogram, &length);
        if (name == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(name, length).AsString();
    }

    public static LLVMMetadataRef[] DISubprogram_getTemplateParams(LLVMMetadataRef type)
    {
        LLVMMetadataRef* buffer = null;
        int size = 0;
        DISubprogram_getTemplateParams(type, (LLVMOpaqueMetadata***)&buffer, &size);
        var result = new ReadOnlySpan<LLVMMetadataRef>(buffer, size).ToArray();
        Free(buffer);
        return result;
    }

    public static LLVMMetadataRef[] DISubroutineType_getTypeArray(LLVMMetadataRef type)
    {
        LLVMMetadataRef* buffer = null;
        int size = 0;
        DISubroutineType_getTypeArray(type, (LLVMOpaqueMetadata***)&buffer, &size);
        var result = new ReadOnlySpan<LLVMMetadataRef>(buffer, size).ToArray();
        Free(buffer);
        return result;
    }

    public static string DIVariable_getName(LLVMMetadataRef variable)
    {
        int length = 0;
        sbyte* name = DIVariable_getName(variable, &length);
        if (name == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(name, length).AsString();
    }

    public static string MDString_getString(LLVMMetadataRef mdstring)
    {
        int length = 0;
        sbyte* stringPtr = MDString_getString(mdstring, &length);
        if (stringPtr == null)
        {
            return "";
        }
        return new ReadOnlySpan<byte>(stringPtr, length).AsString();
    }

    public static LLVMTypeRef[] Module_GetIdentifiedStructTypes(LLVMModuleRef module)
    {
        LLVMOpaqueType** buffer;
        int size;
        Module_GetIdentifiedStructTypes(module, &buffer, &size);
        var result = new ReadOnlySpan<LLVMTypeRef>(buffer, size).ToArray();
        Free(buffer);
        return result;
    }

    public static int Demangle(ReadOnlySpan<byte> mangled_string, Span<byte> buffer)
    {
        fixed (byte* mangledPtr = mangled_string)
        fixed (byte* bufferPtr = buffer)
        {
            return Demangle((sbyte*)mangledPtr, mangled_string.Length, (sbyte*)bufferPtr, buffer.Length);
        }
    }

    public static string Demangle(ReadOnlySpan<byte> mangledString)
    {
        const int MaxLength = 4096;
        Span<byte> buffer = stackalloc byte[MaxLength];
        int length = Demangle(mangledString, buffer);
        if (length > MaxLength)
        {
            buffer = new byte[length];
            length = Demangle(mangledString, buffer);
        }
        return Encoding.UTF8.GetString(buffer[..length]);
    }

    public static string Demangle(string mangledString)
    {
        int byteCount = Encoding.UTF8.GetByteCount(mangledString);
        Span<byte> mangledBytes = byteCount <= 4096 ? stackalloc byte[byteCount] : new byte[byteCount];
        int bytesWritten = Encoding.UTF8.GetBytes(mangledString, mangledBytes);
        Debug.Assert(bytesWritten == byteCount);
        return Demangle(mangledBytes);
    }
}
