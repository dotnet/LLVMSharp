using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("uint8_t *")]
    public unsafe delegate byte* LLVMMemoryManagerAllocateDataSectionCallback([NativeTypeName("void *")] void* Opaque, [NativeTypeName("uintptr_t")] UIntPtr Size, [NativeTypeName("unsigned int")] uint Alignment, [NativeTypeName("unsigned int")] uint SectionID, [NativeTypeName("const char *")] sbyte* SectionName, [NativeTypeName("LLVMBool")] int IsReadOnly);
}
