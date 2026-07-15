// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter9;

/// <summary>
/// Chapter 9 code generation delta — DWARF debug information. This builds on chapter 7's mutable
/// variables and adds the metadata a debugger needs: a compile unit and file, a subprogram per
/// function, a local variable per parameter, and a source location on every expression. The frontend
/// already stamps each AST node with a <see cref="SourceLocation"/>; here we translate those into
/// <c>!dbg</c> attachments via the <see cref="LLVMDIBuilderRef"/>.
/// </summary>
public sealed class CodeGenVisitor : Chapter7.CodeGenVisitor
{
    // DWARF attribute encoding for a 4-byte-aligned IEEE float (DW_ATE_float). Kaleidoscope's only
    // type is 'double', so a single basic type covers every value, parameter, and return.
    private const uint DwarfAteFloat = 0x04;

    private LLVMDIBuilderRef _diBuilder;
    private LLVMMetadataRef _file;
    private LLVMMetadataRef _doubleType;
    private LLVMMetadataRef _currentScope;

    /// <summary>
    /// Supplies the debug-info builder and the file all subprograms are scoped to. The compile unit is
    /// created and owned by the program; it references this file, so we only need the file here. Must be
    /// called before the driver generates any code.
    /// </summary>
    public void InitializeDebugInfo(LLVMDIBuilderRef diBuilder, LLVMMetadataRef file)
    {
        _diBuilder = diBuilder;
        _file = file;
    }

    // The debug type for 'double', created lazily so it lands after InitializeDebugInfo.
    private unsafe LLVMMetadataRef DoubleType
    {
        get
        {
            if (_doubleType.Handle == IntPtr.Zero)
            {
                using var name = new MarshaledString("double");
                _doubleType = LLVM.DIBuilderCreateBasicType(_diBuilder, name, (UIntPtr)name.Length, 64, DwarfAteFloat, LLVMDIFlags.LLVMDIFlagZero);
            }

            return _doubleType;
        }
    }

    /// <summary>
    /// Attaches the current expression's source position to the builder so subsequent instructions are
    /// tagged with a <c>!dbg</c> location. Untracked nodes (or code emitted outside a function) clear
    /// the location instead, which is what LLVM expects for prologue and synthetic instructions.
    /// </summary>
    protected override unsafe void EmitLocation(ExprAST node)
    {
        if (_currentScope.Handle == IntPtr.Zero || node.Location.Line == 0)
        {
            LLVM.SetCurrentDebugLocation2(Builder, null);
            return;
        }

        LLVMMetadataRef location = LLVM.DIBuilderCreateDebugLocation(
            Module.Context, (uint)node.Location.Line, (uint)node.Location.Column, _currentScope, null);
        LLVM.SetCurrentDebugLocation2(Builder, location);
    }

    public override unsafe LLVMValueRef CodegenFunction(FunctionAST node)
    {
        // Remember the prototype (so recursive references resolve) then get-or-declare the function.
        RegisterPrototype(node.Proto);
        LLVMValueRef function = GetFunction(node.Proto.Name);

        if (function.BasicBlocksCount != 0)
        {
            throw new InvalidOperationException($"Function '{node.Proto.Name}' cannot be redefined");
        }

        LLVMBasicBlockRef entry = function.AppendBasicBlock("entry");
        Builder.PositionAtEnd(entry);

        // Describe the function to the debugger and make its subprogram the active scope.
        uint line = (uint)(node.Proto.Line == 0 ? 1 : node.Proto.Line);
        LLVMMetadataRef subprogram = CreateFunctionScope(node.Proto, line);
        LLVM.SetSubprogram(function, subprogram);
        _currentScope = subprogram;

        // The prologue (parameter spills) should not have a source location.
        LLVM.SetCurrentDebugLocation2(Builder, null);
        CreateDebugParameterBindings(function, node.Proto, entry, subprogram, line);

        try
        {
            LLVMValueRef body = Codegen(node.Body);
            Builder.BuildRet(body);
            function.VerifyFunction(LLVMVerifierFailureAction.LLVMPrintMessageAction);
            return function;
        }
        catch
        {
            // Remove the half-built function so the driver can keep going after an error.
            function.DeleteFunction();
            throw;
        }
        finally
        {
            _currentScope = default;
        }
    }

    // Creates the DISubprogram (and its subroutine type) describing one function definition.
    private LLVMMetadataRef CreateFunctionScope(PrototypeAST proto, uint line)
    {
        LLVMMetadataRef subroutineType = CreateSubroutineType(proto.Arguments.Count);

        return _diBuilder.CreateFunction(
            _file, proto.Name, LinkageName: "", _file, line, subroutineType,
            IsLocalToUnit: 1, IsDefinition: 1, ScopeLine: line, LLVMDIFlags.LLVMDIFlagPrototyped, IsOptimized: 0);
    }

    // Element 0 is the return type; the rest are the parameters. Every value is a 'double'.
    private LLVMMetadataRef CreateSubroutineType(int argumentCount)
    {
        var parameterTypes = new LLVMMetadataRef[argumentCount + 1];
        Array.Fill(parameterTypes, DoubleType);
        return _diBuilder.CreateSubroutineType(_file, parameterTypes, LLVMDIFlags.LLVMDIFlagZero);
    }

    // Chapter 7 already spills every parameter into an alloca; here we additionally describe each one
    // to the debugger with a DILocalVariable and a dbg.declare record pointing at its slot.
    private unsafe void CreateDebugParameterBindings(LLVMValueRef function, PrototypeAST proto, LLVMBasicBlockRef entry, LLVMMetadataRef scope, uint line)
    {
        NamedValues.Clear();

        LLVMMetadataRef emptyExpression = LLVM.DIBuilderCreateExpression(_diBuilder, null, (UIntPtr)0);
        LLVMMetadataRef declareLocation = LLVM.DIBuilderCreateDebugLocation(Module.Context, line, 0, scope, null);

        for (int i = 0; i < proto.Arguments.Count; i++)
        {
            string name = proto.Arguments[i];

            LLVMValueRef alloca = CreateEntryBlockAlloca(function, name);
            Builder.BuildStore(function.GetParam((uint)i), alloca);

            using var marshaledName = new MarshaledString(name);
            LLVMMetadataRef variable = LLVM.DIBuilderCreateParameterVariable(
                _diBuilder, scope, marshaledName, (UIntPtr)marshaledName.Length, (uint)(i + 1), _file, line,
                DoubleType, AlwaysPreserve: 1, LLVMDIFlags.LLVMDIFlagZero);

            _ = LLVM.DIBuilderInsertDeclareRecordAtEnd(_diBuilder, alloca, variable, emptyExpression, declareLocation, entry);

            NamedValues[name] = alloca;
        }
    }
}
