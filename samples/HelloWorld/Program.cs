// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using HelloWorld;
using LLVMSharp.Interop;

unsafe
{

    // Context and Module //
    var context = LLVM.ContextCreate();
    var module = LLVM.ModuleCreateWithNameInContext("Hello World".ToSbytePointer(), context);

    // Declare puts() and main()
    LLVMSharpUtil.DeclarePuts(
        out var putsFunc, out var putsFuncTy,
        module
    );
    LLVMSharpUtil.CreateMain(
        out var _, out var mainBuilder,
        module
    );

    // Create global string //
    var constStr = LLVM.BuildGlobalStringPtr(mainBuilder, "Hello World!".ToSbytePointer(), "".ToSbytePointer());
    var parameters = LLVMSharpUtil.CreateLLVMOpaqueValueList(constStr);

    // Following is another way to create a global const string 
    // LLVM.BuildGlobalStringPtr needs a builder with a function
    // The following way haven't this limit, but longer and unreadable
    // You can try to comment above part and uncomment the following part

    //const string helloWorldString = "Hello World!";
    //var globVarTy = LLVM.ArrayType(LLVM.Int8Type(), (uint)(helloWorldString.Length + 1));
    //var globVar = LLVM.AddGlobal(module, globVarTy, "".ToSbytePointer());
    //var initializerValue = LLVM.ConstString(helloWorldString.ToSbytePointer(), (uint)helloWorldString.Length, 0);
    //LLVM.SetInitializer(globVar, initializerValue);
    //var constantIndices = LLVMSharpUtil.CreateLLVMOpaqueValueList(LLVMSharpUtil.constInt0, LLVMSharpUtil.constInt0);
    //var gep = LLVM.ConstGEP2(globVarTy, globVar, constantIndices, 2);
    //var parameters = LLVMSharpUtil.CreateLLVMOpaqueValueList(gep);

    // Create function call and return instruction //
    _ = LLVM.BuildCall2(mainBuilder, putsFuncTy, putsFunc, parameters, 1, "".ToSbytePointer());
    _ = LLVM.BuildRet(mainBuilder, LLVMSharpUtil.ConstInt0);

    // Output LLVM IR //
    Console.WriteLine("[Output of LLVM IR]:\n");
    LLVM.DumpModule(module);
    Console.WriteLine();

    // Run in JIT Compiler //
    Console.WriteLine("[Output of JIT Compiler]:\n");
    LLVMSharpUtil.RunMain(module);

    // Expect console output //
    /*
    [Output of LLVM IR]:

    ; ModuleID = 'Hello World'
    source_filename = "Hello World"

    @0 = private unnamed_addr constant [13 x i8] c"Hello World!\00", align 1

    declare i32 @puts(ptr %0)

    define i32 @main() {
    entry:
      %0 = call i32 @puts(ptr @0)
      ret i32 0
    }

    [Output of JIT Compiler]:

    Hello World!
    */

}
