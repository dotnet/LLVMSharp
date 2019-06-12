using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("uint64_t")]
    public unsafe delegate ulong LLVMOrcSymbolResolverFn([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("void *")] void* LookupCtx);
}
