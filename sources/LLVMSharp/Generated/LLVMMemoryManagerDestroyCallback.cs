using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void LLVMMemoryManagerDestroyCallback([NativeTypeName("void *")] void* Opaque);
}
