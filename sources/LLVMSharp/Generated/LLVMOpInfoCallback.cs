using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LLVMOpInfoCallback(IntPtr DisInfo, ulong PC, ulong Offset, ulong Size, int TagType, IntPtr TagBuf);
}
