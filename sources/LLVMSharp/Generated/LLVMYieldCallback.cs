using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void LLVMYieldCallback([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* param0, [NativeTypeName("void *")] void* param1);
}
