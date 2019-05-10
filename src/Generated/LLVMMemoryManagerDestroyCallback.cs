using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMMemoryManagerDestroyCallback(IntPtr Opaque);
}
