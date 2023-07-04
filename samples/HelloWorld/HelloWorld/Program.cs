// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

// Create extern function
static (LLVMValueRef, LLVMTypeRef) CreateExtern(
    LLVMModuleRef module,
    string name,
    LLVMTypeRef returnTy,
    LLVMTypeRef[] parameters,
    bool isVarArg = false
)
{
    var funcTy = LLVMTypeRef.CreateFunction(returnTy, parameters, isVarArg);
    var func = module.AddFunction(name, funcTy);
    func.Linkage = LLVMLinkage.LLVMExternalLinkage;
    return (func, funcTy);
}

// Declare puts()
static (LLVMValueRef, LLVMTypeRef) DeclarePuts(LLVMModuleRef module)
{
    var name = "puts";
    var returnType = LLVMTypeRef.Int32;
    var parameters = new[] { LLVMTypeRef.CreatePointer(LLVMTypeRef.Int8, 0) };
    return CreateExtern(module, name, returnType, parameters);
}

// Create function with entry basic block
// return function and builder of entry basic block
static (LLVMValueRef, LLVMBuilderRef) CreateFunction(
    LLVMModuleRef module,
    string name,
    LLVMTypeRef returnTy,
    LLVMTypeRef[] parameters,
    bool isVarArg = false
)
{
    var funcTy = LLVMTypeRef.CreateFunction(returnTy, parameters, isVarArg);
    var func = module.AddFunction(name, funcTy);
    var entry = func.AppendBasicBlock("entry");
    var builder = LLVMBuilderRef.Create(module.Context);
    builder.PositionAtEnd(entry);
    return (func, builder);
}

// Create main()
static (LLVMValueRef, LLVMBuilderRef) CreateMain(LLVMModuleRef module)
{
    return CreateFunction(
        module, "main", LLVMTypeRef.Int32, Array.Empty<LLVMTypeRef>()
    );
}


// Context and Module
var context = LLVMContextRef.Create();
var module = context.CreateModuleWithName("Hello World");

// Declare puts() and main()
var (putsFunc, putsFuncTy) = DeclarePuts(module);
var (_, mainBuilder) = CreateMain(module);

// Create global string
var constStr = mainBuilder.BuildGlobalStringPtr("Hello World!");
var parameters = new[] { constStr };

// Create function call and return instruction
_ = mainBuilder.BuildCall2(putsFuncTy, putsFunc, parameters);
_ = mainBuilder.BuildRet(LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 0, true));

// Output LLVM IR //
Console.WriteLine("[Output of LLVM IR]:\n");
module.Dump();
Console.WriteLine();


// Run main() in module
static void RunMain(LLVMModuleRef module)
{
    LLVM.InitializeAllTargets();
    LLVM.InitializeAllTargetMCs();
    LLVM.InitializeAllTargetInfos();
    LLVM.InitializeAllAsmParsers();
    LLVM.InitializeAllAsmPrinters();
    LLVM.InitializeAllDisassemblers();

    var engine = module.CreateExecutionEngine();
    var main = module.GetNamedFunction("main");
    _ = engine.RunFunction(main, Array.Empty<LLVMGenericValueRef>());
}

Console.WriteLine("[Output of Execution Engine]:\n");
RunMain(module);


/*
[Output of LLVM IR]:

;
ModuleID = 'Hello World'
source_filename = "Hello World"

@0 = private unnamed_addr constant[13 x i8] c"Hello World!\00", align 1

declare i32 @puts(ptr %0)

define i32 @main() {
entry:
  % 0 = call i32 @puts(ptr @0)
  ret i32 0
}

[Output of Execution Engine]:

Hello World!
*/
