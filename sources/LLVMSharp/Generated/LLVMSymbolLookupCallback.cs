using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("const char *")]
    public unsafe delegate sbyte* LLVMSymbolLookupCallback([NativeTypeName("void *")] void* DisInfo, [NativeTypeName("uint64_t")] ulong ReferenceValue, [NativeTypeName("uint64_t *")] ulong* ReferenceType, [NativeTypeName("uint64_t")] ulong ReferencePC, [NativeTypeName("const char **")] sbyte** ReferenceName);
}
