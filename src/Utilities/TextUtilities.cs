namespace LLVMSharp.Utilities
{
    using System;
    using System.Runtime.InteropServices;

    internal static class TextUtilities
    {
        public static void Throw(IntPtr error) => throw new Exception(error.MessageToString());
        public static bool Failed(this LLVMBool status) => status;

        public static string MessageToString(this IntPtr ptr)
        {
            var str = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return str;
        }
        
        public static string ValueRefToString(this LLVMValueRef value)
        {
            if(value.Pointer == IntPtr.Zero)
            {
                return string.Empty;
            }
            var ptr = LLVM.PrintValueToString(value);
            if(ptr == IntPtr.Zero)
            {
                return string.Empty;
            }
            var str = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return str;
        }
    }
}
