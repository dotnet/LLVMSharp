// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace Kaleidoscope.AST;

/// <summary>
/// A 1-based source position (chapter 9). A <see cref="Line"/> of 0 means "no location was recorded",
/// which is how the code generator tells tracked nodes apart from untracked ones.
/// </summary>
public readonly record struct SourceLocation(int Line, int Column);
