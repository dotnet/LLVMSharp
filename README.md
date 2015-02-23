# LLVMSharp

LLVMSharp are strongly-typed safe LLVM bindings written in C# for .NET and Mono, tested on Linux and Windows. They are auto-generated using [ClangSharp](http://www.clangsharp.org) parsing LLVM-C header files.

If you're on Windows, consider using the [**LLVMSharp 3.6 NuGet Package**](http://www.nuget.org/packages/LLVMSharp/3.6.0) - built from LLVM 3.6 Release.

## Building LLVMSharp

On Linux using Mono:

```bash
 $ git clone http://github.com/mjsabby/LLVMSharp
 $ cd LLVMSharp
 $ chmod +x build.sh
 $ ./build.sh /path/to/libLLVM.so /path/llvm/include
```

On Windows using Microsoft.NET:

**Note:** - you need to run from the Visual Studio Command Prompt of the architecture you want to target.

```bash
 :> cd c:\path\to\llvm_source\{Release|Debug}\lib
 :> git clone http://github.com/mjsabby/LLVMSharp
 :> cd LLVMSharp
 :> powershell ./LLVMSharp/GenLLVMDLL.ps1
 :> build.bat C:\path\llvm.dll C:\path\to\llvm\include
```

## Features

 * Auto-generated using LLVM C headers files, and supports all functionality exposed by them (more than enough to build a full compiler)
 * Type safe (LLVMValueRef and LLVMTypeRef are different types, despite being pointers internally)
 * Nearly identical to LLVM C APIs, e.g. LLVMModuleCreateWithName in C, vs. LLVM.ModuleCreateWithName (notice the . in the C# API)

## Kaleidoscope Tutorial

Much of the tutorial is already implemented here, and has some nice improvements like the Visitor pattern for code generation to make the LLVM code stand out and help you bootstrap your compiler.

The tutorials have been tested to run on Windows and Linux, however the build (using MSBuild) uses the Nuget packages, hence require some editing to run on Linux.

[Chapter 3](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter3)

[Chapter 4](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter4)

[Chapter 5](https://github.com/mjsabby/LLVMSharp/tree/master/KaleidoscopeTutorial/Chapter5)

## Conventions

* Types are exactly how they are defined in the C bindings, for example: LLVMTypeRef

* Functions are put in a C# class called LLVM and the LLVM prefix is removed from the functions, for example: LLVM.ModuleCreateWithName("LLVMSharpIntro");

* For certain functions requiring a pointer to an array, you must pass the array indexed into its first element. If you do not want to pass any element, you can either pass an array with a dummy element, or make a single type and pass it, otherwise you won't be able to compile, for example: LLVM.FunctionType(LLVM.Int32Type(), out typesArr[0], 0, False); is equivalent to LLVM.FunctionType(LLVM.Int32Type(), out type, 0, False);

## Example application

Main:

```csharp
LLVMBool False = new LLVMBool(0);
LLVMModuleRef mod = LLVM.ModuleCreateWithName("LLVMSharpIntro");
 
LLVMTypeRef[] param_types = {LLVM.Int32Type(), LLVM.Int32Type()};
LLVMTypeRef ret_type = LLVM.FunctionType(LLVM.Int32Type(), out param_types[0], 2, False);
LLVMValueRef sum = LLVM.AddFunction(mod, "sum", ret_type);
 
LLVMBasicBlockRef entry = LLVM.AppendBasicBlock(sum, "entry");
 
LLVMBuilderRef builder = LLVM.CreateBuilder();
LLVM.PositionBuilderAtEnd(builder, entry);
LLVMValueRef tmp = LLVM.BuildAdd(builder, LLVM.GetParam(sum, 0), LLVM.GetParam(sum, 1), "tmp");
LLVM.BuildRet(builder, tmp);
 
IntPtr error;
LLVM.VerifyModule(mod, LLVMVerifierFailureAction.LLVMAbortProcessAction, out error);
LLVM.DisposeMessage(error);
 
LLVMExecutionEngineRef engine;
 
LLVM.LinkInMCJIT();
LLVM.InitializeX86Target();
LLVM.InitializeX86TargetInfo();
LLVM.InitializeX86TargetMC();
 
if (!LLVM.CreateExecutionEngineForModule(out engine, mod, out error).Equals(False))
{
    if (error != IntPtr.Zero)
    {
        Console.WriteLine("error: {0}", Marshal.PtrToStringAnsi(error));
        LLVM.DisposeMessage(error);
        return;
    }
}
 
var addMethod = (Add) Marshal.GetDelegateForFunctionPointer(LLVM.GetPointerToGlobal(engine, sum), typeof (Add));
 
Console.WriteLine(addMethod(10, 10));
 
if (LLVM.WriteBitcodeToFile(mod, "sum.bc") != 0)
{
    Console.WriteLine("error writing bitcode to file, skipping");
}
 
LLVM.DumpModule(mod);
 
LLVM.DisposeBuilder(builder);
LLVM.DisposeExecutionEngine(engine);
````

Delegate definition:

```csharp
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int Add(int a, int b);
```
