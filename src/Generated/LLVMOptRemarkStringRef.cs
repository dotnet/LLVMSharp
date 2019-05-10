using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public partial struct LLVMOptRemarkStringRef
    {
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Str;
        public uint Len;
    }
}
