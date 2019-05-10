using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate LLVMBool LLVMMemoryManagerFinalizeMemoryCallback(IntPtr Opaque, out IntPtr ErrMsg);
}
