// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMModuleRef(IntPtr handle) : IDisposable, IEquatable<LLVMModuleRef>
{
    public IntPtr Handle = handle;

    public readonly LLVMContextRef Context => (Handle != IntPtr.Zero) ? LLVM.GetModuleContext(this) : default;

    public readonly string DataLayout
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pDataLayoutStr = LLVM.GetDataLayout(this);

            if (pDataLayoutStr == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pDataLayoutStr);
        }

        set
        {
            using var marshaledDataLayoutStr = new MarshaledString(value.AsSpan());
            LLVM.SetDataLayout(this, marshaledDataLayoutStr);
        }
    }

    public readonly LLVMValueRef FirstFunction => (Handle != IntPtr.Zero) ? LLVM.GetFirstFunction(this) : default;

    public readonly LLVMValueRef FirstGlobal => (Handle != IntPtr.Zero) ? LLVM.GetFirstGlobal(this) : default;

    public readonly LLVMValueRef LastFunction => (Handle != IntPtr.Zero) ? LLVM.GetLastFunction(this) : default;

    public readonly LLVMValueRef LastGlobal => (Handle != IntPtr.Zero) ? LLVM.GetLastGlobal(this) : default;

    public readonly string Target
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pTriple = LLVM.GetTarget(this);

            if (pTriple == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pTriple);
        }

        set
        {
            using var marshaledTriple = new MarshaledString(value.AsSpan());
            LLVM.SetTarget(this, marshaledTriple);
        }
    }

    public static implicit operator LLVMModuleRef(LLVMOpaqueModule* value) => new LLVMModuleRef((IntPtr)value);

    public static implicit operator LLVMOpaqueModule*(LLVMModuleRef value) => (LLVMOpaqueModule*)value.Handle;

    public static bool operator ==(LLVMModuleRef left, LLVMModuleRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMModuleRef left, LLVMModuleRef right) => !(left == right);

    public static LLVMModuleRef CreateWithName(string ModuleID) => CreateWithName(ModuleID.AsSpan());

    public static LLVMModuleRef CreateWithName(ReadOnlySpan<char> ModuleID)
    {
        using var marshaledModuleID = new MarshaledString(ModuleID);
        return LLVM.ModuleCreateWithName(marshaledModuleID);
    }

    public readonly LLVMValueRef AddAlias2(LLVMTypeRef ValueTy, uint AddrSpace, LLVMValueRef Aliasee, string Name) => AddAlias2(ValueTy, AddrSpace, Aliasee, Name.AsSpan());

    public readonly LLVMValueRef AddAlias2(LLVMTypeRef ValueTy, uint AddrSpace, LLVMValueRef Aliasee, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AddAlias2(this, ValueTy, AddrSpace, Aliasee, marshaledName);
    }

    public readonly LLVMValueRef AddFunction(string Name, LLVMTypeRef FunctionTy) => AddFunction(Name.AsSpan(), FunctionTy);

    public readonly LLVMValueRef AddFunction(ReadOnlySpan<char> Name, LLVMTypeRef FunctionTy)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AddFunction(this, marshaledName, FunctionTy);
    }

    public readonly LLVMValueRef AddGlobal(LLVMTypeRef Ty, string Name) => AddGlobal(Ty, Name.AsSpan());

    public readonly LLVMValueRef AddGlobal(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AddGlobal(this, Ty, marshaledName);
    }

    public readonly LLVMValueRef AddGlobalInAddressSpace(LLVMTypeRef Ty, string Name, uint AddressSpace) => AddGlobalInAddressSpace(Ty, Name.AsSpan(), AddressSpace);

    public readonly LLVMValueRef AddGlobalInAddressSpace(LLVMTypeRef Ty, ReadOnlySpan<char> Name, uint AddressSpace)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AddGlobalInAddressSpace(this, Ty, marshaledName, AddressSpace);
    }

    public readonly void AddModuleFlag(string FlagName, LLVMModuleFlagBehavior Behavior, uint ValAsUInt)
    {
        LLVMOpaqueValue* valAsValueRef = LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, ValAsUInt);
        AddModuleFlag(FlagName, Behavior, valAsValueRef);
    }

    public readonly void AddModuleFlag(string FlagName, LLVMModuleFlagBehavior Behavior, LLVMValueRef ValAsValueRef)
    {
        LLVMOpaqueMetadata* valAsMetadata = LLVM.ValueAsMetadata(ValAsValueRef);
        AddModuleFlag(FlagName, Behavior, valAsMetadata);
    }

    public readonly void AddModuleFlag(string FlagName, LLVMModuleFlagBehavior Behavior, LLVMMetadataRef ValAsMetadataRef) => AddModuleFlag(FlagName.AsSpan(), Behavior, ValAsMetadataRef);


    public readonly void AddModuleFlag(ReadOnlySpan<char> FlagName, LLVMModuleFlagBehavior Behavior, LLVMMetadataRef ValAsMetadataRef)
    {
        using var marshaledName = new MarshaledString(FlagName);
        LLVM.AddModuleFlag(this, Behavior, marshaledName, (UIntPtr)FlagName.Length, ValAsMetadataRef);
    }

    public readonly void AddNamedMetadataOperand(string Name, LLVMValueRef Val) => AddNamedMetadataOperand(Name.AsSpan(), Val);

    public readonly void AddNamedMetadataOperand(ReadOnlySpan<char> Name, LLVMValueRef Val)
    {
        using var marshaledName = new MarshaledString(Name);
        LLVM.AddNamedMetadataOperand(this, marshaledName, Val);
    }

    public readonly LLVMDIBuilderRef CreateDIBuilder()
    {
        return new LLVMDIBuilderRef((IntPtr)LLVM.CreateDIBuilder(this));
    }

    public readonly LLVMExecutionEngineRef CreateExecutionEngine()
    {
        if (!TryCreateExecutionEngine(out LLVMExecutionEngineRef EE, out string Error))
        {
            throw new ExternalException(Error);
        }

        return EE;
    }

    public readonly LLVMExecutionEngineRef CreateInterpreter()
    {
        if (!TryCreateInterpreter(out LLVMExecutionEngineRef Interp, out string Error))
        {
            throw new ExternalException(Error);
        }

        return Interp;
    }

    public readonly LLVMExecutionEngineRef CreateMCJITCompiler()
    {
        if (!TryCreateMCJITCompiler(out LLVMExecutionEngineRef JIT, out string Error))
        {
            throw new ExternalException(Error);
        }

        return JIT;
    }

    public readonly LLVMExecutionEngineRef CreateMCJITCompiler(ref LLVMMCJITCompilerOptions Options)
    {
        if (!TryCreateMCJITCompiler(out LLVMExecutionEngineRef JIT, ref Options, out string Error))
        {
            throw new ExternalException(Error);
        }

        return JIT;
    }

    public readonly LLVMModuleRef Clone() => LLVM.CloneModule(this);

    public readonly LLVMPassManagerRef CreateFunctionPassManager() => LLVM.CreateFunctionPassManagerForModule(this);

    public readonly LLVMModuleProviderRef CreateModuleProvider() => LLVM.CreateModuleProviderForExistingModule(this);

    public readonly void AddNamedMetadataOperand(string Name, LLVMMetadataRef CompileUnitMetadata) => AddNamedMetadataOperand(Name.AsSpan(), CompileUnitMetadata);

    public readonly void AddNamedMetadataOperand(ReadOnlySpan<char> Name, LLVMMetadataRef CompileUnitMetadata)
    {
        using var marshaledName = new MarshaledString(Name);
        LLVM.AddNamedMetadataOperand(this, marshaledName, LLVM.MetadataAsValue(Context, CompileUnitMetadata));
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeModule(this);
            Handle = IntPtr.Zero;
        }
    }

    public readonly void Dump() => LLVM.DumpModule(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMModuleRef other) && Equals(other);

    public readonly bool Equals(LLVMModuleRef other) => this == other;

    public readonly LLVMValueRef GetNamedFunction(string Name) => GetNamedFunction(Name.AsSpan());

    public readonly LLVMValueRef GetNamedFunction(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.GetNamedFunction(this, marshaledName);
    }

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMValueRef GetNamedGlobal(string Name) => GetNamedGlobal(Name.AsSpan());

    public readonly LLVMValueRef GetNamedGlobal(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.GetNamedGlobal(this, marshaledName);
    }

    public readonly LLVMValueRef[] GetNamedMetadataOperands(string Name) => GetNamedMetadataOperands(Name.AsSpan());

    public readonly LLVMValueRef[] GetNamedMetadataOperands(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        var Dest = new LLVMValueRef[LLVM.GetNamedMetadataNumOperands(this, marshaledName)];

        fixed (LLVMValueRef* pDest = Dest)
        {
            LLVM.GetNamedMetadataOperands(this, marshaledName, (LLVMOpaqueValue**)pDest);
        }

        return Dest;
    }

    public readonly uint GetNamedMetadataOperandsCount(string Name) => GetNamedMetadataOperandsCount(Name.AsSpan());

    public readonly uint GetNamedMetadataOperandsCount(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.GetNamedMetadataNumOperands(this, marshaledName);
    }

    public readonly LLVMTypeRef GetTypeByName(string Name) => GetTypeByName(Name.AsSpan());

    public readonly LLVMTypeRef GetTypeByName(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.GetTypeByName(this, marshaledName);
    }

    public readonly void PrintToFile(string Filename) => PrintToFile(Filename.AsSpan());

    public readonly void PrintToFile(ReadOnlySpan<char> Filename)
    {
        if (!TryPrintToFile(Filename, out string ErrorMessage))
        {
            throw new ExternalException(ErrorMessage);
        }
    }

    public readonly string PrintToString()
    {
        var pStr = LLVM.PrintModuleToString(this);

        if (pStr == null)
        {
            return string.Empty;
        }

        var result = SpanExtensions.AsString(pStr);
        LLVM.DisposeMessage(pStr);
        return result;
    }

    public readonly void SetModuleInlineAsm(string Asm) => SetModuleInlineAsm(Asm.AsSpan());

    public readonly void SetModuleInlineAsm(ReadOnlySpan<char> Asm)
    {
        using var marshaledAsm = new MarshaledString(Asm);
        LLVM.SetModuleInlineAsm(this, marshaledAsm);
    }

    public override readonly string ToString() => (Handle != IntPtr.Zero) ? PrintToString() : string.Empty;

    public readonly bool TryCreateExecutionEngine(out LLVMExecutionEngineRef OutEE, out string OutError)
    {
        fixed (LLVMExecutionEngineRef* pOutEE = &OutEE)
        {
            sbyte* pError = null;
            var result = LLVM.CreateExecutionEngineForModule((LLVMOpaqueExecutionEngine**)pOutEE, this, &pError);

            if (pError == null)
            {
                OutError = string.Empty;
            }
            else
            {
                OutError = SpanExtensions.AsString(pError);
            }

            return result == 0;
        }
    }

    public readonly bool TryCreateInterpreter(out LLVMExecutionEngineRef OutInterp, out string OutError)
    {
        fixed (LLVMExecutionEngineRef* pOutInterp = &OutInterp)
        {
            sbyte* pError = null;
            var result = LLVM.CreateInterpreterForModule((LLVMOpaqueExecutionEngine**)pOutInterp, this, &pError);

            if (pError == null)
            {
                OutError = string.Empty;
            }
            else
            {
                OutError = SpanExtensions.AsString(pError);
            }

            return result == 0;
        }
    }

    public readonly bool TryCreateMCJITCompiler(out LLVMExecutionEngineRef OutJIT, out string OutError)
    {
        var Options = LLVMMCJITCompilerOptions.Create();
        return TryCreateMCJITCompiler(out OutJIT, ref Options, out OutError);
    }

    public readonly bool TryCreateMCJITCompiler(out LLVMExecutionEngineRef OutJIT, ref LLVMMCJITCompilerOptions Options, out string OutError)
    {
        fixed (LLVMExecutionEngineRef* pOutJIT = &OutJIT)
        fixed (LLVMMCJITCompilerOptions* pOptions = &Options)
        {
            sbyte* pError = null;
            var result = LLVM.CreateMCJITCompilerForModule((LLVMOpaqueExecutionEngine**)pOutJIT, this, pOptions, (uint)sizeof(LLVMMCJITCompilerOptions), &pError);

            if (pError == null)
            {
                OutError = string.Empty;
            }
            else
            {
                OutError = SpanExtensions.AsString(pError);
            }

            return result == 0;
        }
    }

    public readonly bool TryPrintToFile(string Filename, out string ErrorMessage) => TryPrintToFile(Filename.AsSpan(), out ErrorMessage);

    public readonly bool TryPrintToFile(ReadOnlySpan<char> Filename, out string ErrorMessage)
    {
        using var marshaledFilename = new MarshaledString(Filename);

        sbyte* pErrorMessage = null;
        int result = 0;

        try
        {
            result = LLVM.PrintModuleToFile(this, marshaledFilename, &pErrorMessage);
        }
        catch
        {
        }

        if (pErrorMessage is null)
        {
            ErrorMessage = string.Empty;
        }
        else
        {
            ErrorMessage = SpanExtensions.AsString(pErrorMessage);
        }

        return result == 0;
    }

    public readonly bool TryVerify(LLVMVerifierFailureAction Action, out string OutMessage)
    {
        sbyte* pMessage = null;
        var result = LLVM.VerifyModule(this, Action, &pMessage);

        if (pMessage == null)
        {
            OutMessage = string.Empty;
        }
        else
        {
            OutMessage = SpanExtensions.AsString(pMessage);
        }

        return result == 0;
    }

    public readonly void Verify(LLVMVerifierFailureAction Action)
    {
        if (!TryVerify(Action, out string Message))
        {
            throw new ExternalException(Message);
        }
    }

    public readonly int WriteBitcodeToFile(string Path) => WriteBitcodeToFile(Path.AsSpan());

    public readonly int WriteBitcodeToFile(ReadOnlySpan<char> Path)
    {
        using var marshaledPath = new MarshaledString(Path);
        return LLVM.WriteBitcodeToFile(this, marshaledPath);
    }

    public readonly int WriteBitcodeToFD(int FD, int ShouldClose, int Unbuffered) => LLVM.WriteBitcodeToFD(this, FD, ShouldClose, Unbuffered);

    public readonly int WriteBitcodeToFileHandle(int Handle) => LLVM.WriteBitcodeToFileHandle(this, Handle);

    public readonly LLVMMemoryBufferRef WriteBitcodeToMemoryBuffer() => LLVM.WriteBitcodeToMemoryBuffer(this);
}
