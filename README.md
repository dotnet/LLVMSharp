# LLVMSharp

LLVMSharp is a multi-platform .NET Standard library for accessing the LLVM infrastructure. The bindings are auto-generated using [ClangSharp](https://github.com/Microsoft/ClangSharp) parsing LLVM-C header files.

| Job | Debug Status | Release Status |
| --- | ------------ | -------------- |
| Windows x86 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_debug_x86)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_release_x86)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| Windows x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=windows_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| Ubuntu 16.04 x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=ubuntu_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=ubuntu_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |
| MacOS x64 | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=macos_debug_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) | [![Build Status](https://dev.azure.com/ms/LLVMSharp/_apis/build/status/microsoft.LLVMSharp?branchName=main&jobName=macos_release_x64)](https://dev.azure.com/ms/LLVMSharp/_build/latest?definitionId=156&branchName=main) |

A nuget package for the project is provided here: https://www.nuget.org/packages/llvmsharp.

A convenience package which provides the native libLLVM library for several platforms is provided here: https://www.nuget.org/packages/libLLVM

NOTE: These may be out of date as compared to the latest sources. New versions are published as appropriate and a nightly feed is not currently available.

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
