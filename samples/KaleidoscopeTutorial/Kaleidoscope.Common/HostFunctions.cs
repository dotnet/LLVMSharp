// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Kaleidoscope;

/// <summary>
/// The host functions the tutorial exposes to JIT'd Kaleidoscope code — <c>putchard</c> (print a
/// character) and <c>printd</c> (print a value). Declaring them with <c>extern</c> in Kaleidoscope and
/// having them resolve to these managed methods is how the tutorial does I/O (upstream issues #69 and
/// #133). They are registered as absolute symbols in <see cref="KaleidoscopeJit.DefineSymbol"/>.
/// </summary>
public static unsafe class HostFunctions
{
    /// <summary>putchard(x): prints the character whose code is <paramref name="value"/>; returns 0.</summary>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static double Putchard(double value)
    {
        Console.Write((char)(int)value);
        return 0.0;
    }

    /// <summary>printd(x): prints <paramref name="value"/> followed by a newline; returns 0.</summary>
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static double Printd(double value)
    {
        Console.WriteLine(value);
        return 0.0;
    }

    /// <summary>Registers every host function with <paramref name="jit"/> so <c>extern</c>s resolve.</summary>
    public static void DefineAll(KaleidoscopeJit jit)
    {
        jit.DefineSymbol("putchard", (nint)(delegate* unmanaged[Cdecl]<double, double>)&Putchard);
        jit.DefineSymbol("printd", (nint)(delegate* unmanaged[Cdecl]<double, double>)&Printd);
    }
}
