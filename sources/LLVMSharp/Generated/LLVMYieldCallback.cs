using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LLVMYieldCallback(LLVMContextRef param0, IntPtr param1);
}
