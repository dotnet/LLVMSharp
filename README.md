# LLVMSharp

LLVMSharp is a multi-platform .NET Standard library for accessing the LLVM infrastructure. The bindings are auto-generated using [ClangSharp](https://github.com/dotnet/clangsharp) parsing LLVM-C header files.

![ci](https://github.com/dotnet/llvmsharp/workflows/ci/badge.svg?branch=main&event=push)

A nuget package for the project is provided here: https://www.nuget.org/packages/llvmsharp.

A convenience package which provides the native libLLVM library for several platforms is provided here: https://www.nuget.org/packages/libLLVM

Source browsing is available via: https://source.clangsharp.dev/

## Table of Contents

* [Code of Conduct](#code-of-conduct)
* [License](#license)
* [Features](#features)
* [Building LLVMSharp](#building-llvmsharp)
* [Regenerating native binaries](#regenerating-native-binaries)

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

### Regenerating native binaries

The native runtime packages are produced by CI (`.github/workflows/regenerate-native.yml`) rather than by hand:

* `libLLVM.runtime.*` (and the `libLLVM` meta-package) — the prebuilt shared `libLLVM` library.
* `libLLVMSharp.runtime.*` (and the `libLLVMSharp` meta-package) — the `libLLVMSharp` helper, compiled from `sources/libLLVMSharp` against the matching LLVM release.

The tracked LLVM version is the `project(LLVMSharp VERSION X.Y.Z)` value in the top-level `CMakeLists.txt`, which maps to the `llvmorg-X.Y.Z` release tag. For each runtime (`win-x64`, `win-arm64`, `linux-x64`, `linux-arm64`, `osx-arm64`) the download-and-stage step is handled by `scripts/build.ps1`/`scripts/build.sh`:

```
# lift the prebuilt libLLVM (win-* on Windows)
./scripts/build.ps1 -regeneratenative -target libLLVM -rid win-x64

# lift the prebuilt libLLVM (linux-*/osx-* on the matching runner)
./scripts/build.sh --regeneratenative --target libLLVM --rid linux-x64

# compile libLLVMSharp against the matching LLVM release
./scripts/build.sh --regeneratenative --target libLLVMSharp --rid linux-x64
```

The staged binary is written to `artifacts/native/<rid>/`. Unlike ClangSharp — which lifts the shared `libclang` that ships for every platform — the official LLVM releases only ship a shared `libLLVM` on Windows (as `LLVM-C.dll`, shipped under that official name). The managed resolver in `sources/LLVMSharp.Interop/LLVM.cs` maps the logical `libLLVM` P/Invoke name to the per-platform file (`LLVM-C.dll` on Windows; `libLLVM.so`/`libLLVM.dylib` elsewhere), which is also why `libLLVMSharp.dll`'s static `LLVM-C.dll` import resolves without an extra copy. Linux and macOS are lifted from the most-official prebuilt source per platform: [apt.llvm.org](https://apt.llvm.org/) (the LLVM project's own Debian/Ubuntu repository, `libllvm<major>`) on Linux and [Homebrew](https://formulae.brew.sh/formula/llvm) (`llvm`) on macOS, both of which link the standard system C++ runtime. `libLLVMSharp` is compiled per-runtime against the LLVM release distribution, which bundles the `lib/cmake/{llvm,clang}` config, headers, and import libraries used as `PATH_TO_LLVM`, so no from-source LLVM build is required.

The jobs run when:

* **libLLVM** — the tracked LLVM major/minor version changes, or the workflow is dispatched manually with the `libllvm` input set.
* **libLLVMSharp** — the same LLVM version change, or anything under `sources/libLLVMSharp/` changes, or the workflow is dispatched manually with the `libllvmsharp` input set.

Before anything is downloaded, the workflow verifies the `packages/**/*.nuspec` and `packages/**/runtime.json` versions match the tracked LLVM version (libLLVM exactly; libLLVMSharp as `<llvm-version>.<revision>`), so a version bump that forgot to update a package fails fast. Each job uploads the resulting `.nupkg` files as build artifacts and signs them; publishing them to NuGet.org is a manual step. To move to a new LLVM release, bump the version in `CMakeLists.txt` alongside the `<version>` in the affected `packages/**/*.nuspec` files (and the versions in `packages/**/runtime.json` and this README); pushing that change regenerates the packages.
