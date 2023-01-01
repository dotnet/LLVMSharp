// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Text;
using LLVMSharp.Interop;

namespace HelloWorld;

public static class LLVMSharpUtil
{

    // Constant //
    public static readonly unsafe LLVMOpaqueValue* ConstInt0 = LLVM.ConstInt(LLVM.Int32Type(), 0, 1);

    // Convert string to sbyte* //
    public static unsafe sbyte* ToSbytePointer(this string value)
    {
        var bytes = new byte[Encoding.Default.GetByteCount(value) + 1];
        _ = Encoding.Default.GetBytes(value, 0, value.Length, bytes, 0);
        fixed (byte* b = bytes)
        {
            return (sbyte*)b;
        }
    }

    // Convert LLVMOpaqueType*[] to LLVMOpaqueType** //
    public static unsafe LLVMOpaqueType** CreateLLVMOpaqueTypeList(params LLVMOpaqueType*[] values)
    {
        fixed (LLVMOpaqueType** temp = values)
        {
            return temp;
        }
    }

    // Convert LLVMOpaqueValue*[] to LLVMOpaqueValue** //
    public static unsafe LLVMOpaqueValue** CreateLLVMOpaqueValueList(params LLVMOpaqueValue*[] values)
    {
        fixed (LLVMOpaqueValue** temp = values)
        {
            return temp;
        }
    }

    // Create extern function //
    public static unsafe void CreateExtern(
        out LLVMValueRef func,
        out LLVMOpaqueType* funcTy,

        LLVMOpaqueModule* module,
        sbyte* name,
        LLVMOpaqueType* returnType,
        LLVMOpaqueType** parameters,
        uint paramCount = 0,
        int isVarArg = 0
    )
    {
        funcTy = LLVM.FunctionType(returnType, parameters, paramCount, isVarArg);
        func = LLVM.AddFunction(module, name, funcTy);
        LLVM.SetLinkage(func, LLVMLinkage.LLVMExternalLinkage);
    }

    // Declare puts() //
    public static unsafe void DeclarePuts(
        out LLVMValueRef putsFunc,
        out LLVMOpaqueType* putsFuncTy,

        LLVMOpaqueModule* module
    )
    {
        var returnType = LLVM.Int32Type();
        var name = "puts".ToSbytePointer();
        var parameters = CreateLLVMOpaqueTypeList(LLVM.PointerType(LLVM.Int8Type(), 0));
        CreateExtern(
            out putsFunc, out putsFuncTy,
            module, name, returnType, parameters, 1
        );
    }

    // Create function with entry basic block //
    // return function and builder of entry basic block
    public static unsafe void CreateFunction(
        out LLVMOpaqueValue* func,
        out LLVMOpaqueBuilder* builder,

        LLVMOpaqueModule* module,
        string name,
        LLVMOpaqueType* returnType,
        LLVMOpaqueType** parameters,
        uint paramCount = 0,
        int isVarArgs = 0
    )
    {
        var funcTy = LLVM.FunctionType(returnType, parameters, paramCount, isVarArgs);
        func = LLVM.AddFunction(module, name.ToSbytePointer(), funcTy);
        var entry = LLVM.AppendBasicBlock(func, "entry".ToSbytePointer());
        builder = LLVM.CreateBuilder();
        LLVM.PositionBuilderAtEnd(builder, entry);
    }

    // Create main function //
    public static unsafe void CreateMain(
        out LLVMOpaqueValue* mainFunc,
        out LLVMOpaqueBuilder* mainBuilder,

        LLVMOpaqueModule* module
    )
    {
        CreateFunction(
            out mainFunc, out mainBuilder,
            module, "main", LLVM.Int32Type(), CreateLLVMOpaqueTypeList(), 0
        );
    }

    // Create ExecutionEngine for Module //
    public static unsafe void CreateExecutionEngineForModule(
        out LLVMOpaqueExecutionEngine* engine,
        out sbyte* error,
        LLVMOpaqueModule* module
    )
    {
        LLVMOpaqueExecutionEngine* outEE = null;
        sbyte* outError = null;
        _ = LLVM.CreateExecutionEngineForModule(&outEE, module, &outError);
        engine = outEE;
        error = outError;
    }

    // Run module in JIT Compiler //
    // Sometimes crashes with "LLVM ERROR: IMAGE_REL_AMD64_ADDR32NB relocation requires an ordered section layout"
    public static unsafe void RunMain(LLVMOpaqueModule* module)
    {
        LLVM.LinkInMCJIT();
        LLVM.InitializeX86TargetMC();

        LLVM.InitializeX86Target();
        LLVM.InitializeX86TargetInfo();
        LLVM.InitializeX86AsmParser();
        LLVM.InitializeX86AsmPrinter();

        CreateExecutionEngineForModule(
            out var engine, out _,
            module
        );
        var main = LLVM.GetNamedFunction(module, "main".ToSbytePointer());
        _ = LLVM.RunFunction(engine, main, 0, null);
    }

}
