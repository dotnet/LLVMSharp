// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter8;
using LLVMSharp.Interop;

// Chapter 8 is a batch compiler rather than a REPL: it reads a whole Kaleidoscope program, generates
// every definition into one module, and emits a native object file that a C driver can link against.
var binaryOpPrecedence = new Dictionary<char, int>
{
    ['='] = 2,
    ['<'] = 10,
    ['+'] = 20,
    ['-'] = 20,
    ['*'] = 40,
};

string outputPath = args.Length > 1 ? args[1] : "output.o";

using TextReader reader = args.Length > 0 ? new StreamReader(args[0]) : Console.In;

var lexer = new Lexer(reader, binaryOpPrecedence);
var parser = new Kaleidoscope.Chapter7.Parser(lexer, binaryOpPrecedence);
var visitor = new Kaleidoscope.Chapter7.CodeGenVisitor();

LlvmSupport.EnsureTargetsInitialized();
LLVMTargetMachineRef targetMachine = LlvmSupport.CreateHostTargetMachine();

LLVMContextRef context = LLVMContextRef.Create();
LLVMModuleRef module = context.CreateModuleWithName("KaleidoscopeModule");
LlvmSupport.PrepareModuleForEmit(module, targetMachine);

var driver = new ObjectFileDriver(lexer, parser, visitor, module);
driver.Run();

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
