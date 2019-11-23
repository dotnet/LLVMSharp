// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace LLVMSharp.UnitTests
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Delegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate long Int64Delegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Int32Int32Delegate(int a, int b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate byte Int32Int32Int8Delegate(int a, int b);
}
