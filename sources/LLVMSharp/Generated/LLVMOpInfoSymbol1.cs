using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public partial struct LLVMOpInfoSymbol1
    {
        public ulong Present;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))] public string Name;
        public ulong Value;
    }
}
