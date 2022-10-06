// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp;

// Create extern function //
LLVMValueRef CreateExtern(
    LLVMModuleRef module,
    string name,
    LLVMTypeRef returnType,
    LLVMTypeRef[] parameters,
    bool isVarArg = false
)
{
    var funcTy = LLVM.FunctionType(returnType, parameters, isVarArg);
    var func = LLVM.AddFunction(module, name, funcTy);
    func.SetLinkage(LLVMLinkage.LLVMExternalLinkage);
    return func;
}

// Declare puts() //
LLVMValueRef DeclarePuts(LLVMModuleRef module)
{
    var returnType = LLVM.Int32Type();
    var parameters = new LLVMTypeRef[] { LLVM.PointerType(LLVM.Int8Type(), 0) };
    return CreateExtern(module, "puts", returnType, parameters);
}

// Create function with entry basic block //
// return function and builder of entry basic block
(LLVMValueRef, LLVMBuilderRef) CreateFunction(
    LLVMModuleRef module,
    string name,
    LLVMTypeRef returnType,
    LLVMTypeRef[] parameters,
    bool isVarArgs = false
)
{
    var funcType = LLVM.FunctionType(returnType, parameters, isVarArgs);
    var func = LLVM.AddFunction(module, name, funcType);
    var entry = LLVM.AppendBasicBlock(func, "entry");
    var builder = LLVM.CreateBuilder();
    LLVM.PositionBuilderAtEnd(builder, entry);

    return (func, builder);
}

// Create main function //
(LLVMValueRef, LLVMBuilderRef) CreateMain(LLVMModuleRef module)
{
    return CreateFunction(module, "main", LLVM.Int32Type(), Array.Empty<LLVMTypeRef>());
}

// Run module in JIT Compiler //
// Sometimes crashes with "LLVM ERROR: IMAGE_REL_AMD64_ADDR32NB relocation requires an ordered section layout"
void RunMain(LLVMModuleRef module)
{
    LLVM.LinkInMCJIT();
    LLVM.InitializeX86TargetMC();

    LLVM.InitializeX86Target();
    LLVM.InitializeX86TargetInfo();
    LLVM.InitializeX86AsmParser();
    LLVM.InitializeX86AsmPrinter();

    _ = LLVM.CreateExecutionEngineForModule(out var engine, module, out var _);
    var main = LLVM.GetNamedFunction(module, "main");
    _ = LLVM.RunFunction(engine, main, Array.Empty<LLVMGenericValueRef>());
}

// Context and Module //
var context = LLVM.ContextCreate();
var module = LLVM.ModuleCreateWithNameInContext("Hello World", context);

// Declare puts() and main()
var funcPuts = DeclarePuts(module);
var (_, builder_main) = CreateMain(module);

// Create global string //
var constStr = LLVM.BuildGlobalStringPtr(builder_main, "Hello World!", "");
var parameters = new LLVMValueRef[] { constStr };
var constInt0 = LLVM.ConstInt(LLVM.Int32Type(), 0, true);

// Following is another way to create a global const string 
// LLVM.BuildGlobalStringPtr needs a builder with a function
// This way haven't this limit, but longer and unreadable

//var helloWorldString = "Hello World!";
//var globVar = LLVM.AddGlobal(module, LLVM.ArrayType(LLVM.Int8Type(), (uint)helloWorldString.Length + 1), "");
//LLVM.SetInitializer(globVar, LLVM.ConstString(helloWorldString, (uint)helloWorldString.Length, false));
//var gep = LLVM.ConstGEP(globVar, new LLVMValueRef[] { constInt0, constInt0 });
//var parameters = new LLVMValueRef[] { gep };

// Create function call and return instruction //
_ = LLVM.BuildCall(builder_main, funcPuts, parameters, "");
_ = LLVM.BuildRet(builder_main, constInt0);

// Output LLVM IR //
Console.WriteLine("[Output of LLVM IR]:\n");
LLVM.DumpModule(module);
Console.WriteLine();

// Run in JIT Compiler //
Console.WriteLine("[Output of JIT Compiler]:\n");
RunMain(module);

// Expect console output //
/*
[Output of LLVM IR]:

; ModuleID = 'Hello World'
source_filename = "Hello World"

@0 = private unnamed_addr constant[13 x i8] c "Hello World!\00", align 1

declare i32 @puts(i8* %0)

define i32 @main() {
    entry:
  % 0 = call i32 @puts(i8* getelementptr inbounds ([13 x i8], [13 x i8]* @0, i32 0, i32 0))
  ret i32 0
}

[Output of JIT Compiler]:

Hello World!
*/

