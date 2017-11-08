namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial class LLVM
    {
        [DllImport(libraryPath, EntryPoint = "LLVMGetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetValueNameAsPtr(LLVMValueRef @Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetAsPtr(LLVMModuleRef M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDataLayoutAsPtr(LLVMModuleRef M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetNameAsPtr(LLVMTargetRef @T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetDescriptionAsPtr(LLVMTargetRef @T);
    }
}
