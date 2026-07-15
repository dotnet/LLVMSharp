// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope;
using Kaleidoscope.Chapter4;
using Kaleidoscope.Chapter7;

// Chapter 7 reuses chapter 4's JIT driver and swaps in a parser/code generator that support mutable
// variables. Assignment is a low-precedence binary operator, so '=' is added to the precedence table.
var binaryOpPrecedence = new Dictionary<char, int>
{
    ['='] = 2,
    ['<'] = 10,
    ['+'] = 20,
    ['-'] = 20,
    ['*'] = 40,
};

using TextReader reader = args.Length > 0 ? new StreamReader(args[0]) : Console.In;

var lexer = new Lexer(reader, binaryOpPrecedence);
var parser = new Kaleidoscope.Chapter7.Parser(lexer, binaryOpPrecedence);
var visitor = new CodeGenVisitor();

using var driver = new JitReplDriver(lexer, parser, visitor);
driver.Run();
