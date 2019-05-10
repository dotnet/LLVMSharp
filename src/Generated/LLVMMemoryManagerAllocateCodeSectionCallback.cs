using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LLVMMemoryManagerAllocateCodeSectionCallback(IntPtr Opaque, UIntPtr Size, uint Alignment, uint SectionID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] string SectionName);
}
