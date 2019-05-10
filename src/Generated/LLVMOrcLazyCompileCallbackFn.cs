using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong LLVMOrcLazyCompileCallbackFn(LLVMOrcJITStackRef JITStack, IntPtr CallbackCtx);
}
