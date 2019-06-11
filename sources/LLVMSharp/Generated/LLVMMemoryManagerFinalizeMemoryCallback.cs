using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("LLVMBool")]
    public unsafe delegate int LLVMMemoryManagerFinalizeMemoryCallback([NativeTypeName("void *")] void* Opaque, [NativeTypeName("char **")] sbyte** ErrMsg);
}
