namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial class LLVM
    {
        [DllImport(libraryPath, EntryPoint = "LLVMGetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetValueNameAsPtr(LLVMValueRef @Val);
    }
}
