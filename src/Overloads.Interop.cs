namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial class LLVM
    {
        [DllImport(libraryPath, EntryPoint = "LLVMGetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetValueNameAsPtr(LLVMValueRef @Val);
        public static string GetValueName(LLVMValueRef @Val) => Marshal.PtrToStringAnsi(GetValueNameAsPtr(@Val));

        [DllImport(libraryPath, EntryPoint = "LLVMGetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDataLayoutAsPtr(LLVMModuleRef M);
        public static string GetDataLayout(LLVMModuleRef M) => Marshal.PtrToStringAnsi(GetDataLayoutAsPtr(M));

        [DllImport(libraryPath, EntryPoint = "LLVMGetTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetAsPtr(LLVMModuleRef M);
        public static string GetTarget(LLVMModuleRef M) => Marshal.PtrToStringAnsi(GetTargetAsPtr(M));

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetNameAsPtr(LLVMTargetRef @T);
        public static string GetTargetName(LLVMTargetRef @T) => Marshal.PtrToStringAnsi(GetTargetNameAsPtr(@T));

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTargetDescriptionAsPtr(LLVMTargetRef @T);
        public static string GetTargetDescription(LLVMTargetRef @T) => Marshal.PtrToStringAnsi(GetTargetDescriptionAsPtr(@T));

        [DllImport(libraryPath, EntryPoint = "LLVMGetBasicBlockName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetBasicBlockNameAsPtr(LLVMBasicBlockRef @BB);
        public static string GetBasicBlockName(LLVMBasicBlockRef @BB) => Marshal.PtrToStringAnsi(GetBasicBlockNameAsPtr(@BB));        
    }
}
