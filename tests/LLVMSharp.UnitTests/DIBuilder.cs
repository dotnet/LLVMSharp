using System.IO;
using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class DIBuilder
{
    [Test(Description = "Exercises some DIBuilder functions, does not test the actual debug information is correct")]
    public void CreateDebugLocation()
    {
        var fileName = Path.GetFileName("DIBuilder.c");
        var directory = Path.GetDirectoryName(".") ?? "";
        var module = LLVMModuleRef.CreateWithName("netscripten");
        module.Target = "asmjs-unknown-emscripten";
        var dIBuilder = module.CreateDIBuilder();
        var builder = module.Context.CreateBuilder();
        var fileMetadata = dIBuilder.CreateFile(fileName, directory);

        var compileUnitMetadata = dIBuilder.CreateCompileUnit(
            LLVMDWARFSourceLanguage.LLVMDWARFSourceLanguageC,
            fileMetadata, "ILC", 0 /* Optimized */, string.Empty, 1, string.Empty,
            LLVMDWARFEmissionKind.LLVMDWARFEmissionFull, 0, 0, 0, string.Empty, string.Empty);
        module.AddNamedMetadataOperand("llvm.dbg.cu", compileUnitMetadata);

        var functionMetaType = dIBuilder.CreateSubroutineType(fileMetadata,
            [], LLVMDIFlags.LLVMDIFlagZero);

        uint lineNumber = 1;
        var debugFunction = dIBuilder.CreateFunction(fileMetadata, "CreateDebugLocation", "CreateDebugLocation",
            fileMetadata,
            lineNumber, functionMetaType, 1, 1, lineNumber, 0, 0);
        var currentLine =
            module.Context.CreateDebugLocation(lineNumber, 0, debugFunction, default);

        LLVMTypeRef[] fooParamTys = [LLVMTypeRef.Int64, LLVMTypeRef.Int64,];
        var fooFuncTy = LLVMTypeRef.CreateFunction(LLVMTypeRef.Int64, fooParamTys);
        var fooFunction = module.AddFunction("foo", fooFuncTy);

        var funcBlock = module.Context.AppendBasicBlock(fooFunction, "foo");
        builder.PositionAtEnd(funcBlock);
        _ = builder.BuildRet(LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, 0));
        builder.CurrentDebugLocation = module.Context.MetadataAsValue(currentLine);
        var dwarfVersion = LLVMValueRef.CreateMDNode(new[]
        {
            LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 2), module.Context.GetMDString("Dwarf Version", 13),
            LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 4)
        });
        var dwarfSchemaVersion = LLVMValueRef.CreateMDNode(new[]
        {
            LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 2),
            module.Context.GetMDString("Debug Info Version", 18),
            LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, 3)
        });
        module.AddNamedMetadataOperand("llvm.module.flags", dwarfVersion);
        module.AddNamedMetadataOperand("llvm.module.flags", dwarfSchemaVersion);
        dIBuilder.DIBuilderFinalize();

        _ = module.TryVerify(LLVMVerifierFailureAction.LLVMPrintMessageAction, out var message);

        Assert.That(message, Is.Empty);
    }
}
