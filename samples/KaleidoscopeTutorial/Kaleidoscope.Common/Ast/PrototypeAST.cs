// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace Kaleidoscope.AST;

/// <summary>
/// The "prototype" for a function — its name and argument names. From chapter 6 a prototype can
/// also declare a user-defined operator, in which case it carries the operator precedence.
/// </summary>
public sealed record PrototypeAST(
    string Name,
    IReadOnlyList<string> Arguments,
    bool IsOperator = false,
    int Precedence = 0)
{
    public bool IsUnaryOperator => IsOperator && Arguments.Count == 1;

    public bool IsBinaryOperator => IsOperator && Arguments.Count == 2;

    /// <summary>The operator character for an operator prototype (the last char of the name).</summary>
    public char OperatorName => Name[^1];
}

/// <summary>A function definition: a prototype plus the body expression it evaluates to.</summary>
public sealed record FunctionAST(PrototypeAST Proto, ExprAST Body);
