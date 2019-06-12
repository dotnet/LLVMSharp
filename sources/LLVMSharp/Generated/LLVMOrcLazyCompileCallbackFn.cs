using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("uint64_t")]
    public unsafe delegate ulong LLVMOrcLazyCompileCallbackFn([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("void *")] void* CallbackCtx);
}
