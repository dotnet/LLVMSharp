namespace Tests
{
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Delegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate long Int64Delegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Int32Int32Delegate(int a, int b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate byte Int32Int32Int8Delegate(int a, int b);
}
