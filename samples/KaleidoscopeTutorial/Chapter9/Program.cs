// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter8;
using Kaleidoscope.Chapter9;
using LLVMSharp.Interop;

// Chapter 9 is chapter 8's batch compiler with DWARF debug information layered on top. It reads a whole
// Kaleidoscope program, generates every definition into one module — now carrying a compile unit, a
// subprogram per function, local variables for parameters, and a source location on every expression —
// and emits a native object file that a debugger can step through.
var binaryOpPrecedence = new Dictionary<char, int>
{
    ['='] = 2,
    ['<'] = 10,
    ['+'] = 20,
    ['-'] = 20,
    ['*'] = 40,
};

string sourceName = args.Length > 0 ? Path.GetFileName(args[0]) : "stdin.ks";
string sourceDirectory = args.Length > 0 ? (Path.GetDirectoryName(Path.GetFullPath(args[0])) ?? ".") : ".";
string outputPath = args.Length > 1 ? args[1] : "output.o";

using TextReader reader = args.Length > 0 ? new StreamReader(args[0]) : Console.In;

var lexer = new Lexer(reader, binaryOpPrecedence);
var parser = new Kaleidoscope.Chapter7.Parser(lexer, binaryOpPrecedence);
var visitor = new CodeGenVisitor();

LlvmSupport.EnsureTargetsInitialized();
LLVMTargetMachineRef targetMachine = LlvmSupport.CreateHostTargetMachine();

LLVMContextRef context = LLVMContextRef.Create();
LLVMModuleRef module = context.CreateModuleWithName("KaleidoscopeModule");
LlvmSupport.PrepareModuleForEmit(module, targetMachine);

// Tell the backend a module-level debug-info version is present. DWARF is the default on the tutorial's
// targets; on Windows/CodeView these flags are still valid and harmless.
module.AddModuleFlag("Debug Info Version", LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning, LLVM.DebugMetadataVersion());
module.AddModuleFlag("Dwarf Version", LLVMModuleFlagBehavior.LLVMModuleFlagBehaviorWarning, 4u);

LLVMDIBuilderRef diBuilder = module.CreateDIBuilder();
LLVMMetadataRef file = diBuilder.CreateFile(sourceName, sourceDirectory);

// Kaleidoscope has no notion of C, but claiming C lets debuggers apply sensible defaults, matching the
// upstream tutorial.
LLVMMetadataRef compileUnit = diBuilder.CreateCompileUnit(
    LLVMDWARFSourceLanguage.LLVMDWARFSourceLanguageC, file, "Kaleidoscope Compiler",
    IsOptimized: 0, Flags: "", RuntimeVersion: 0, SplitName: "", LLVMDWARFEmissionKind.LLVMDWARFEmissionFull,
    DWOld: 0, SplitDebugInlining: 0, DebugInfoForProfiling: 0, SysRoot: "", SDK: "");

visitor.InitializeDebugInfo(diBuilder, file);

var driver = new ObjectFileDriver(lexer, parser, visitor, module);
driver.Run();

// Resolve all temporary debug metadata now that every function has been generated.
diBuilder.DIBuilderFinalize();

Console.WriteLine("=== Module IR ===");
Console.Write(module.PrintToString());
Console.WriteLine();

if (targetMachine.TryEmitToFile(module, outputPath, LLVMCodeGenFileType.LLVMObjectFile, out string message))
{
    Console.WriteLine($"Wrote object file to '{outputPath}' (target {module.Target}).");
}
else
{
    Console.Error.WriteLine($"Failed to emit object file: {message}");
    Environment.Exit(1);
}
