// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.InteropServices;

namespace LLVMSharp.UnitTests;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Delegate();
[UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate long Int64Delegate();
[UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate int Int32Int32Int32Delegate(int a, int b);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)] public delegate byte Int32Int32Int8Delegate(int a, int b);
