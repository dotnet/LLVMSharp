# LLVMSharp

LLVMSharp is a multi-platform .NET Standard library for accessing the LLVM infrastructure. The bindings are auto-generated using [ClangSharp](https://github.com/Microsoft/ClangSharp) parsing LLVM-C header files.

| Job | Debug Status | Release Status |
| --- | ------------ | -------------- |
| Windows x86 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_debug_x86)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_release_x86)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| Windows x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| Ubuntu 16.04 x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=ubuntu_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=ubuntu_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| MacOS x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=macos_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=macos_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |

[![Join the chat at https://gitter.im/mjsabby/LLVMSharp](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/mjsabby/LLVMSharp?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[**LLVMSharp NuGet Package**](http://www.nuget.org/packages/LLVMSharp) for .NET Core 2.0+ (Linux, macOS, Windows) and .NET Framework 4+ - each version is built from the corresponding LLVM Release.

## Building LLVMSharp

On Linux using .NET Core:

```bash
 $ git clone http://github.com/Microsoft/LLVMSharp
 $ cd LLVMSharp
 $ dotnet build
```

On Windows using .NET Core

**Note:** - you need to run these commands from the Visual Studio Developer Command Prompt.

```bash
 :> git clone http://github.com/mjsabby/LLVMSharp
 :> cd LLVMSharp
 :> dotnet build
```

## Features

 * Auto-generated using LLVM C headers files, and supports all functionality exposed by them (more than enough to build a full compiler)
 * Type safe (LLVMValueRef and LLVMTypeRef are different types, despite being pointers internally)
 * Nearly identical to LLVM C APIs, e.g. LLVMModuleCreateWithName in C, vs. LLVM.ModuleCreateWithName (notice the . in the C# API)

## Kaleidoscope Tutorials

There's a [C# translation of the LLVM official Kaleidoscope Tutorial](http://ice1000.org/llvm-cs/en/).

Much of the tutorial is already implemented here, and has some nice improvements like the Visitor pattern for code generation to make the LLVM code stand out and help you bootstrap your compiler.

The tutorials have been tested to run on Windows and Linux, however the build (using MSBuild) uses the Nuget packages, hence require some editing to run on Linux.

[Chapter 3](samples/KaleidoscopeTutorial/Chapter3)

[Chapter 4](samples/KaleidoscopeTutorial/Chapter4)

[Chapter 5](samples/KaleidoscopeTutorial/Chapter5)

## Conventions

* Types are exactly how they are defined in the C bindings, for example: LLVMTypeRef

* Functions are put in a C# class called LLVM and the LLVM prefix is removed from the functions, for example: LLVM.ModuleCreateWithName("LLVMSharpIntro");

## Example application

```csharp
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp.Interop;

    internal sealed class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Add(int a, int b);

        private static void Main(string[] args)
        {
            LLVMModuleRef mod = LLVMModuleRef.CreateWithName("LLVMSharpIntro");

            LLVMTypeRef[] param_types = new LLVMTypeRef[2] { LLVMTypeRef.Int32, LLVMTypeRef.Int32 };
            LLVMTypeRef ret_type = LLVMTypeRef.CreateFunction(LLVMTypeRef.Int32, param_types);
            LLVMValueRef sum = mod.AddFunction("sum", ret_type);

            LLVMBasicBlockRef entry = sum.AppendBasicBlock("entry");

            LLVMBuilderRef builder = LLVMBuilderRef.Create(mod.Context);
            builder.PositionAtEnd(entry);
            LLVMValueRef tmp = builder.BuildAdd(sum.Params[0], sum.Params[1], "tmp");
            builder.BuildRet(tmp);

            if (!mod.TryVerify(LLVMVerifierFailureAction.LLVMPrintMessageAction, out var error))
            {
                Console.WriteLine($"Error: {error}");
            }

            LLVM.LinkInMCJIT();

            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86AsmParser();
            LLVM.InitializeX86AsmPrinter();

            LLVMMCJITCompilerOptions options = new LLVMMCJITCompilerOptions { NoFramePointerElim = 1 };
            if (!mod.TryCreateMCJITCompiler(out var engine, ref options, out error))
            {
                Console.WriteLine($"Error: {error}");
            }

            var addMethod = (Add)Marshal.GetDelegateForFunctionPointer(engine.GetPointerToGlobal(sum), typeof(Add));
            int result = addMethod(10, 10);

            Console.WriteLine("Result of sum is: " + result);

            if (mod.WriteBitcodeToFile("sum.bc") != 0)
            {
                Console.WriteLine("error writing bitcode to file, skipping");
            }

            mod.Dump();
            builder.Dispose();
            engine.Dispose();
        }
    }
````

## Microsoft Open Source Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
