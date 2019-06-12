using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void LLVMFatalErrorHandler([NativeTypeName("const char *")] sbyte* Reason);
}
