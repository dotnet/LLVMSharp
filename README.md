# LLVMSharp
===========

LLVMSharp are strongly-typed safe C# bindings for LLVM's C bindings. They are auto-generated using [ClangSharp](http://www.clangsharp.org) parsing LLVM-C header files.

##### Building LLVMSharp

  git clone http://github.com/mjsabby/LLVMSharp
  cd LLVMSharp
  chmod +x build.sh
  ./build.sh /path/to/libLLVM.so /path/llvm/include

##### Features

 * Auto-generated using LLVM C headers files, and supports every single functionality exposed by them
 * Type safe (LLVMValueRef and LLVMTypeRef are different types, despite being pointers internally)
 * Nearly identical to LLVM C APIs, e.g. LLVMModuleCreateWithName in C, vs. LLVM.ModuleCreateWithName (notice the . in the C# API)

##### Kaleidoscope Tutorial

Much of the tutorial is already implemented here, and has some nice improvements like the Visitor pattern for code generation to make the LLVM code stand out and help you bootstrap your compiler.

The tutorials have been tested to run on Windows and Linux, however the build (using MSBuild) uses the Nuget packages, hence require some editing to run on Linux.

[Chapter 3](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter3)

[Chapter 4](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter4)

[Chapter 5](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter5)


##### Conventions

* Types are exactly how they are defined in the C bindings, for example: LLVMTypeRef

* Functions are put in a C# class called LLVM and the LLVM prefix is removed from the functions, for example: LLVM.ModuleCreateWithName("LLVMSharpIntro");

* For certain functions requiring a pointer to an array, you must pass the array indexed into its first element. If you do not want to pass any element, you can either pass an array with a dummy element, or make a single type and pass it, otherwise you won't be able to compile, for example: LLVM.FunctionType(LLVM.Int32Type(), out typesArr[0], 0, False); is equivalent to LLVM.FunctionType(LLVM.Int32Type(), out type, 0, False);