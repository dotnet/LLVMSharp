using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public partial struct LTOObjectBuffer
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Buffer;
        public IntPtr Size;
    }
}
