# LLVMSharp

[![Join the chat at https://gitter.im/mjsabby/LLVMSharp](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/mjsabby/LLVMSharp?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

LLVMSharp is a multi-platform .NET Standard library for accessing the LLVM infrastructure. The bindings are auto-generated using [ClangSharp](http://www.clangsharp.org) parsing LLVM-C header files.

[**LLVMSharp 5.0 NuGet Package**](http://www.nuget.org/packages/LLVMSharp/5.0.0) for .NET Core 2.0+ (Linux, macOS, Windows) and .NET Framework 4+ - built from the LLVM 5.0.0 Release.

## Building LLVMSharp

On Linux using .NET Core:

```bash
 $ git clone http://github.com/Microsoft/LLVMSharp
 $ cd LLVMSharp/src
 $ dotnet build
```

On Windows using .NET Core

**Note:** - you need to run these commands from the Visual Studio Developer Command Prompt.

```bash
 :> git clone http://github.com/mjsabby/LLVMSharp
 :> cd LLVMSharp\src
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

[Chapter 3](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter3)

[Chapter 4](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter4)

[Chapter 5](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter5)

## Conventions

* Types are exactly how they are defined in the C bindings, for example: LLVMTypeRef

* Functions are put in a C# class called LLVM and the LLVM prefix is removed from the functions, for example: LLVM.ModuleCreateWithName("LLVMSharpIntro");

## Example application

```csharp
using LLVMSharp.Api;
using System.Runtime.InteropServices;

static class Program
{
    [UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    delegate int BinaryInt32Operation(int op1, int op2);

    static void Main(string[] args)
    {
        using(var module = Module.Create("LLVMSharpIntro"))
        {
            var def = module.AddFunction(
                Type.Int32, "sum", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                {
                    var p1 = f.Parameters[0];
                    var p2 = f.Parameters[1];
                    var add = b.CreateAdd(p1, p2);
                    var ret = b.CreateRet(add);
                });
            module.Verify();

            Initialize.X86.All();
            using (var engine = module.CreateMCJITCompilerForModule())
            {
                var function = engine.GetDelegate<BinaryInt32Operation>(def);
                var result = function(2, 2);
                Assert.Equal(4, result);
            }
        }
    }
}
````

## Microsoft Open Source Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
