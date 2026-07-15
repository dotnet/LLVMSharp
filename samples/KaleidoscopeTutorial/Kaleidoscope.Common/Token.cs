// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace Kaleidoscope;

/// <summary>
/// The token kinds produced by the <see cref="Lexer"/>. Any positive value returned by the
/// lexer is a literal character (an operator or punctuation); the negative values below are
/// the "known" tokens. The full set for every chapter lives here so a single lexer can serve
/// all of them — early chapters simply never ask the parser to accept the later keywords.
/// </summary>
public enum Token
{
    Eof = -1,

    // commands
    Def = -2,
    Extern = -3,

    // primary
    Identifier = -4,
    Number = -5,

    // control flow (chapter 5)
    If = -6,
    Then = -7,
    Else = -8,
    For = -9,
    In = -10,

    // user-defined operators (chapter 6)
    Binary = -11,
    Unary = -12,

    // mutable variables (chapter 7)
    Var = -13,
}
