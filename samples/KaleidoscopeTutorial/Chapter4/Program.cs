// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter4;

// Chapter 4 keeps chapter 3's frontend and code generator verbatim and only swaps the dump driver for
// a JIT driver, so a top-level expression is compiled and executed instead of just printed.
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
var visitor = new Kaleidoscope.Chapter3.CodeGenVisitor();

using var driver = new JitReplDriver(lexer, parser, visitor);
driver.Run();
