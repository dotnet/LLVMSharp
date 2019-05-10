using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string LLVMSymbolLookupCallback(IntPtr DisInfo, ulong ReferenceValue, out ulong ReferenceType, ulong ReferencePC, out IntPtr ReferenceName);
}
