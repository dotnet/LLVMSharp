// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace Kaleidoscope.AST;

/// <summary>Base class for all expression nodes.</summary>
public abstract record ExprAST;

/// <summary>A numeric literal, e.g. <c>1.0</c> (chapter 3).</summary>
public sealed record NumberExprAST(double Value) : ExprAST;

/// <summary>A reference to a variable, e.g. <c>a</c> (chapter 3).</summary>
public sealed record VariableExprAST(string Name) : ExprAST;

/// <summary>A binary operator expression, e.g. <c>a + b</c> (chapter 3; user operators in chapter 6).</summary>
public sealed record BinaryExprAST(char Op, ExprAST Lhs, ExprAST Rhs) : ExprAST;

/// <summary>A unary operator expression, e.g. <c>!a</c> (chapter 6).</summary>
public sealed record UnaryExprAST(char Opcode, ExprAST Operand) : ExprAST;

/// <summary>A function call, e.g. <c>foo(a, b)</c> (chapter 3).</summary>
public sealed record CallExprAST(string Callee, IReadOnlyList<ExprAST> Arguments) : ExprAST;

/// <summary>An <c>if/then/else</c> expression (chapter 5).</summary>
public sealed record IfExprAST(ExprAST Condition, ExprAST Then, ExprAST Else) : ExprAST;

/// <summary>A <c>for/in</c> loop expression; <see cref="Step"/> is null when omitted (chapter 5).</summary>
public sealed record ForExprAST(string VarName, ExprAST Start, ExprAST End, ExprAST? Step, ExprAST Body) : ExprAST;

/// <summary>A <c>var/in</c> expression introducing mutable locals (chapter 7).</summary>
public sealed record VarExprAST(IReadOnlyList<(string Name, ExprAST? Init)> VarNames, ExprAST Body) : ExprAST;
