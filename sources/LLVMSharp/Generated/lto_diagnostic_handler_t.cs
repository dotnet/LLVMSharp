using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void lto_diagnostic_handler_t(lto_codegen_diagnostic_severity_t severity, [NativeTypeName("const char *")] sbyte* diag, [NativeTypeName("void *")] void* ctxt);
}
