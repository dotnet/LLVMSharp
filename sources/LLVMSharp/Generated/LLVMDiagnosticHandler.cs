using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void LLVMDiagnosticHandler([NativeTypeName("LLVMDiagnosticInfoRef")] LLVMOpaqueDiagnosticInfo* param0, [NativeTypeName("void *")] void* param1);
}
