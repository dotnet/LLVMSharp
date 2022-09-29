// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public static unsafe partial class LLVM
{
    public static event DllImportResolver? ResolveLibrary;

    static LLVM()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
    }

    private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        return TryResolveLibrary(libraryName, assembly, searchPath, out var nativeLibrary)
            ? nativeLibrary
            : libraryName.Equals("libLLVM") && TryResolveLLVM(assembly, searchPath, out nativeLibrary)
            ? nativeLibrary
            : IntPtr.Zero;
    }

    private static bool TryResolveLLVM(Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
    {
        return (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && NativeLibrary.TryLoad("libLLVM.so.14", assembly, searchPath, out nativeLibrary))
            || (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && NativeLibrary.TryLoad("libLLVM-14", assembly, searchPath, out nativeLibrary))
            || (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && NativeLibrary.TryLoad("libLLVM.so.1", assembly, searchPath, out nativeLibrary))
            || (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && NativeLibrary.TryLoad("LLVM-C.dll", assembly, searchPath, out nativeLibrary))
            || NativeLibrary.TryLoad("libLLVM", assembly, searchPath, out nativeLibrary);
    }

    private static bool TryResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
    {
        var resolveLibrary = ResolveLibrary;

        if (resolveLibrary != null)
        {
            var resolvers = resolveLibrary.GetInvocationList();

            foreach (DllImportResolver resolver in resolvers.Cast<DllImportResolver>())
            {
                nativeLibrary = resolver(libraryName, assembly, searchPath);

                if (nativeLibrary != IntPtr.Zero)
                {
                    return true;
                }
            }
        }

        nativeLibrary = IntPtr.Zero;
        return false;
    }
}
