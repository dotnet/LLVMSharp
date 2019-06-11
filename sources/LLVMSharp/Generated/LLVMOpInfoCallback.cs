using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int LLVMOpInfoCallback([NativeTypeName("void *")] void* DisInfo, [NativeTypeName("uint64_t")] ulong PC, [NativeTypeName("uint64_t")] ulong Offset, [NativeTypeName("uint64_t")] ulong Size, int TagType, [NativeTypeName("void *")] void* TagBuf);
}
