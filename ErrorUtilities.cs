namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    internal static class ErrorUtilities
    {
        public static void Throw(IntPtr error)
        {
            var errorMessage = error.IntPtrToString();
            LLVM.DisposeMessage(error);
            throw new Exception(errorMessage);
        }

        public static bool Failed(this LLVMBool status)
        {
            return status;
        }
        
        public static string IntPtrToString(this IntPtr message)
        {
            return Marshal.PtrToStringAnsi(message);
        }
    }
}
