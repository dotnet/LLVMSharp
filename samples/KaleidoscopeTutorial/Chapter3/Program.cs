// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter3;
using LLVMSharp.Interop;

// The built-in operator precedences (higher binds tighter). The lexer and parser share this
// dictionary; from chapter 6 the parser adds user-defined operators to it at run time.
var binaryOpPrecedence = new Dictionary<char, int>
{
    ['<'] = 10,
    ['+'] = 20,
    ['-'] = 20,
    ['*'] = 40,
};

using TextReader reader = args.Length > 0 ? new StreamReader(args[0]) : Console.In;

var lexer = new Lexer(reader, binaryOpPrecedence);
var parser = new Parser(lexer);
var visitor = new CodeGenVisitor();

LLVMContextRef context = LLVMContextRef.Create();
LLVMModuleRef module = context.CreateModuleWithName("KaleidoscopeModule");

var driver = new DumpDriver(lexer, parser, visitor, module);
driver.Run();

Console.WriteLine();
Console.WriteLine("=== Full module IR ===");
Console.Write(module.PrintToString());
