# LLVMSharp

LLVMSharp is a multi-platform .NET Standard library for accessing the LLVM infrastructure. The bindings are auto-generated using [ClangSharp](https://github.com/dotnet/clangsharp) parsing LLVM-C header files.

![ci](https://github.com/dotnet/clangsharp/workflows/ci/badge.svg?branch=main&event=push)

A nuget package for the project is provided here: https://www.nuget.org/packages/llvmsharp.

A convenience package which provides the native libLLVM library for several platforms is provided here: https://www.nuget.org/packages/libLLVM

Nightly packages are available via the NuGet Feed URL: https://pkgs.clangsharp.dev/index.json

Source browsing is available via: https://source.clangsharp.dev/

## Table of Contents

* [Code of Conduct](#code-of-conduct)
* [License](#license)
* [Features](#features)
* [Building LLVMSharp](#building-llvmsharp)

### Code of Conduct

LLVMSharp and everyone contributing (this includes issues, pull requests, the
wiki, etc) must abide by the .NET Foundation Code of Conduct:
https://dotnetfoundation.org/about/code-of-conduct.

Instances of abusive, harassing, or otherwise unacceptable behavior may be
reported by contacting the project team at conduct@dotnetfoundation.org.

### License

Copyright (c) .NET Foundation and Contributors. All Rights Reserved.
Licensed under the MIT License (MIT).
See [LICENSE.md](LICENSE.md) in the repository root for more information.

### Features

 * Auto-generated using LLVM C headers files, and supports all functionality exposed by them (more than enough to build a full compiler)
 * Type safe (LLVMValueRef and LLVMTypeRef are different types, despite being pointers internally)
 * Nearly identical to LLVM C APIs, e.g. LLVMModuleCreateWithName in C, vs. LLVM.ModuleCreateWithName (notice the . in the C# API)

### Building LLVMSharp

On Linux using .NET Core:

```bash
 $ git clone http://github.com/dotnet/llvmsharp
 $ cd LLVMSharp
 $ dotnet build
```

On Windows using .NET Core

**Note:** - you need to run these commands from the Visual Studio Developer Command Prompt.

```bash
 :> git clone http://github.com/dotnet/LLVMSharp
 :> cd LLVMSharp
 :> dotnet build
```
