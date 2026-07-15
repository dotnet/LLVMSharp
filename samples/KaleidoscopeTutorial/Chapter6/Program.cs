// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter4;
using Kaleidoscope.Chapter6;

// Chapter 6 reuses chapter 4's JIT driver and swaps in a parser/code generator that understand
// user-defined unary and binary operators.
var binaryOpPrecedence = new Dictionary<char, int>
{
    ['<'] = 10,
    ['+'] = 20,
    ['-'] = 20,
    ['*'] = 40,
};

using TextReader reader = args.Length > 0 ? new StreamReader(args[0]) : Console.In;

var lexer = new Lexer(reader, binaryOpPrecedence);
var parser = new Kaleidoscope.Chapter6.Parser(lexer, binaryOpPrecedence);
var visitor = new CodeGenVisitor();

using var driver = new JitReplDriver(lexer, parser, visitor);
driver.Run();
