// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static LLVMSharp.Interop.LLVMTailCallKind;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMValueRef(IntPtr handle) : IEquatable<LLVMValueRef>
{
    public IntPtr Handle = handle;

    public readonly LLVMValueRef Aliasee
    {
        get
        {
            return (IsAGlobalAlias != null) ? LLVM.AliasGetAliasee(this) : default;
        }

        set
        {
            LLVM.AliasSetAliasee(this, value);
        }
    }

    public readonly uint Alignment
    {
        get
        {
            return ((IsAGlobalValue != null) || (IsAAllocaInst != null) || (IsALoadInst != null) || (IsAStoreInst != null)) ? LLVM.GetAlignment(this) : default;
        }

        set
        {
            LLVM.SetAlignment(this, value);
        }
    }

    public readonly LLVMAtomicRMWBinOp AtomicRMWBinOp
    {
        get
        {
            return (IsAAtomicRMWInst != null) ? LLVM.GetAtomicRMWBinOp(this) : default;
        }

        set
        {
            LLVM.SetAtomicRMWBinOp(this, value);
        }
    }

    public readonly uint BasicBlocksCount => (IsAFunction != null) ? LLVM.CountBasicBlocks(this) : default;

    public readonly LLVMBasicBlockRef BlockAddressBasicBlock => (IsABlockAddress != null) ? LLVM.GetBlockAddressBasicBlock(this) : default;

    public readonly LLVMValueRef BlockAddressFunction => (IsABlockAddress != null) ? LLVM.GetBlockAddressFunction(this) : default;

    public readonly LLVMValueRef Condition
    {
        get
        {
            return (IsABranchInst != null) ? LLVM.GetCondition(this) : default;
        }

        set
        {
            LLVM.SetCondition(this, value);
        }
    }

    public readonly ulong ConstIntZExt => (IsAConstantInt != null) ? LLVM.ConstIntGetZExtValue(this) : default;

    public readonly long ConstIntSExt => (IsAConstantInt != null) ? LLVM.ConstIntGetSExtValue(this) : default;

    public readonly LLVMOpcode ConstOpcode => (IsAConstantExpr != null) ? LLVM.GetConstOpcode(this) : default;

    public readonly double ConstRealDouble => (IsAConstantFP != null) ? GetConstRealDouble(out _) : default;

    public readonly LLVMContextRef Context => (Handle != IntPtr.Zero) ? LLVM.GetValueContext(this) : default;

    public readonly ReadOnlySpan<byte> Data => (IsAConstantDataArray != null) ? llvmsharp.ConstantDataArray_getData(this) : default;

    public readonly string? DemangledName
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return null;
            }

            nuint length = 0;
            sbyte* ptr = LLVM.GetValueName2(this, &length);
            if (ptr is null || length == 0)
            {
                return "";
            }

            return llvmsharp.Demangle(new ReadOnlySpan<byte>(ptr, (int)length));
        }
    }

    public readonly LLVMDLLStorageClass DLLStorageClass
    {
        get
        {
            return (IsAGlobalValue != null) ? LLVM.GetDLLStorageClass(this) : default;
        }

        set
        {
            LLVM.SetDLLStorageClass(this, value);
        }
    }

    public readonly LLVMBasicBlockRef EntryBasicBlock => ((IsAFunction != null) && (BasicBlocksCount != 0)) ? LLVM.GetEntryBasicBlock(this) : default;

    public readonly LLVMRealPredicate FCmpPredicate => (Handle != IntPtr.Zero) ? LLVM.GetFCmpPredicate(this) : default;

    public readonly LLVMBasicBlockRef FirstBasicBlock => (IsAFunction != null) ? LLVM.GetFirstBasicBlock(this) : default;

    public readonly LLVMValueRef FirstParam => (IsAFunction != null) ? LLVM.GetFirstParam(this) : default;

    public readonly LLVMUseRef FirstUse => (Handle != IntPtr.Zero) ? LLVM.GetFirstUse(this) : default;

    public readonly uint FunctionCallConv
    {
        get
        {
            return (IsAFunction != null) ? LLVM.GetFunctionCallConv(this) : default;
        }

        set
        {
            LLVM.SetFunctionCallConv(this, value);
        }
    }

    public readonly LLVMTypeRef FunctionType => (IsAFunction != null) ? llvmsharp.Function_getFunctionType(this) : default;

    public readonly string GC
    {
        get
        {
            if (IsAFunction == null)
            {
                return string.Empty;
            }

            var pName = LLVM.GetGC(this);

            if (pName == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pName);
        }

        set
        {
            using var marshaledName = new MarshaledString(value.AsSpan());
            LLVM.SetGC(this, marshaledName);
        }
    }

    public readonly LLVMValueRef GlobalIFuncResolver
    {
        get
        {
            return (IsAGlobalIFunc != null) ? LLVM.GetGlobalIFuncResolver(this) : default;
        }

        set
        {
            LLVM.SetGlobalIFuncResolver(this, value);
        }
    }

    public readonly LLVMModuleRef GlobalParent => (IsAGlobalValue != null) ? LLVM.GetGlobalParent(this) : default;

    public readonly LLVMTypeRef GlobalValueType => (IsAGlobalValue != null) ? LLVM.GlobalGetValueType(this) : default;

    public readonly LLVMMetadataRef GlobalVariableExpression => (IsAGlobalVariable != null) ? llvmsharp.GlobalVariable_getGlobalVariableExpression(this) : default;

    public readonly bool HasMetadata => (IsAInstruction != null) && LLVM.HasMetadata(this) != 0;

    public readonly bool HasNoSignedWrap => (IsAInstruction != null) && llvmsharp.Instruction_hasNoSignedWrap(this) != 0;

    public readonly bool HasNoUnsignedWrap => (IsAInstruction != null) && llvmsharp.Instruction_hasNoUnsignedWrap(this) != 0;

    public readonly bool HasPersonalityFn => (IsAFunction != null) && LLVM.HasPersonalityFn(this) != 0;

    public readonly bool HasUnnamedAddr
    {
        get
        {
            return (IsAGlobalValue != null) && LLVM.HasUnnamedAddr(this) != 0;
        }

        set
        {
            LLVM.SetUnnamedAddr(this, value ? 1 : 0);
        }
    }

    public readonly LLVMIntPredicate ICmpPredicate => (Handle != IntPtr.Zero) ? LLVM.GetICmpPredicate(this) : default;

    public readonly uint IncomingCount => (IsAPHINode != null) ? LLVM.CountIncoming(this) : default;

    public readonly LLVMValueRef Initializer
    {
        get
        {
            return (IsAGlobalVariable != null) ? LLVM.GetInitializer(this) : default;
        }

        set
        {
            LLVM.SetInitializer(this, value);
        }
    }

    public readonly uint InstructionCallConv
    {
        get
        {
            return ((IsACallBrInst != null) || (IsACallInst != null) || (IsAInvokeInst != null)) ? LLVM.GetInstructionCallConv(this) : default;
        }

        set
        {
            LLVM.SetInstructionCallConv(this, value);
        }
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)] // Justification: causes native allocation
    public readonly LLVMValueRef InstructionClone => (Handle != IntPtr.Zero) ? LLVM.InstructionClone(this) : default;

    public readonly LLVMOpcode InstructionOpcode => (Handle != IntPtr.Zero) ? LLVM.GetInstructionOpcode(this) : default;

    public readonly LLVMBasicBlockRef InstructionParent => (IsAInstruction != null) ? LLVM.GetInstructionParent(this) : default;

    public readonly uint IntrinsicID => (Handle != IntPtr.Zero) ? LLVM.GetIntrinsicID(this) : default;

    public readonly LLVMValueRef IsAAddrSpaceCastInst => LLVM.IsAAddrSpaceCastInst(this);

    public readonly LLVMValueRef IsAAllocaInst => LLVM.IsAAllocaInst(this);

    public readonly LLVMValueRef IsAArgument => LLVM.IsAArgument(this);

    public readonly LLVMValueRef IsAAtomicCmpXchgInst => LLVM.IsAAtomicCmpXchgInst(this);

    public readonly LLVMValueRef IsAAtomicRMWInst => LLVM.IsAAtomicRMWInst(this);

    public readonly LLVMValueRef IsABasicBlock => LLVM.IsABasicBlock(this);

    public readonly LLVMValueRef IsABinaryOperator => LLVM.IsABinaryOperator(this);

    public readonly LLVMValueRef IsABitCastInst => LLVM.IsABitCastInst(this);

    public readonly LLVMValueRef IsABlockAddress => LLVM.IsABlockAddress(this);

    public readonly LLVMValueRef IsABranchInst => LLVM.IsABranchInst(this);

    public readonly LLVMValueRef IsACallBrInst => LLVM.IsACallBrInst(this);

    public readonly LLVMValueRef IsACallInst => LLVM.IsACallInst(this);

    public readonly LLVMValueRef IsACastInst => LLVM.IsACastInst(this);

    public readonly LLVMValueRef IsACatchPadInst => LLVM.IsACatchPadInst(this);

    public readonly LLVMValueRef IsACatchReturnInst => LLVM.IsACatchReturnInst(this);

    public readonly LLVMValueRef IsACatchSwitchInst => LLVM.IsACatchSwitchInst(this);

    public readonly LLVMValueRef IsACleanupPadInst => LLVM.IsACleanupPadInst(this);

    public readonly LLVMValueRef IsACleanupReturnInst => LLVM.IsACleanupReturnInst(this);

    public readonly LLVMValueRef IsACmpInst => LLVM.IsACmpInst(this);

    public readonly LLVMValueRef IsAConstant => LLVM.IsAConstant(this);

    public readonly LLVMValueRef IsAConstantAggregateZero => LLVM.IsAConstantAggregateZero(this);

    public readonly LLVMValueRef IsAConstantArray => LLVM.IsAConstantArray(this);

    public readonly LLVMValueRef IsAConstantDataArray => LLVM.IsAConstantDataArray(this);

    public readonly LLVMValueRef IsAConstantDataSequential => LLVM.IsAConstantDataSequential(this);

    public readonly LLVMValueRef IsAConstantDataVector => LLVM.IsAConstantDataVector(this);

    public readonly LLVMValueRef IsAConstantExpr => LLVM.IsAConstantExpr(this);

    public readonly LLVMValueRef IsAConstantFP => LLVM.IsAConstantFP(this);

    public readonly LLVMValueRef IsAConstantInt => LLVM.IsAConstantInt(this);

    public readonly LLVMValueRef IsAConstantPointerNull => LLVM.IsAConstantPointerNull(this);

    public readonly LLVMValueRef IsAConstantStruct => LLVM.IsAConstantStruct(this);

    public readonly LLVMValueRef IsAConstantTokenNone => LLVM.IsAConstantTokenNone(this);

    public readonly LLVMValueRef IsAConstantVector => LLVM.IsAConstantVector(this);

    public readonly LLVMValueRef IsADbgDeclareInst => LLVM.IsADbgDeclareInst(this);

    public readonly LLVMValueRef IsADbgInfoIntrinsic => LLVM.IsADbgInfoIntrinsic(this);

    public readonly LLVMValueRef IsADbgLabelInst => LLVM.IsADbgLabelInst(this);

    public readonly LLVMValueRef IsADbgVariableIntrinsic => LLVM.IsADbgVariableIntrinsic(this);

    public readonly LLVMValueRef IsAExtractElementInst => LLVM.IsAExtractElementInst(this);

    public readonly LLVMValueRef IsAExtractValueInst => LLVM.IsAExtractValueInst(this);

    public readonly LLVMValueRef IsAFCmpInst => LLVM.IsAFCmpInst(this);

    public readonly LLVMValueRef IsAFenceInst => LLVM.IsAFenceInst(this);

    public readonly LLVMValueRef IsAFPExtInst => LLVM.IsAFPExtInst(this);

    public readonly LLVMValueRef IsAFPToSIInst => LLVM.IsAFPToSIInst(this);

    public readonly LLVMValueRef IsAFPToUIInst => LLVM.IsAFPToUIInst(this);

    public readonly LLVMValueRef IsAFPTruncInst => LLVM.IsAFPTruncInst(this);

    public readonly LLVMValueRef IsAFreezeInst => LLVM.IsAFreezeInst(this);

    public readonly LLVMValueRef IsAFuncletPadInst => LLVM.IsAFuncletPadInst(this);

    public readonly LLVMValueRef IsAFunction => LLVM.IsAFunction(this);

    public readonly LLVMValueRef IsAGetElementPtrInst => LLVM.IsAGetElementPtrInst(this);

    public readonly LLVMValueRef IsAGlobalAlias => LLVM.IsAGlobalAlias(this);

    public readonly LLVMValueRef IsAGlobalIFunc => LLVM.IsAGlobalIFunc(this);

    public readonly LLVMValueRef IsAGlobalObject => LLVM.IsAGlobalObject(this);

    public readonly LLVMValueRef IsAGlobalValue => LLVM.IsAGlobalValue(this);

    public readonly LLVMValueRef IsAGlobalVariable => LLVM.IsAGlobalVariable(this);

    public readonly LLVMValueRef IsAICmpInst => LLVM.IsAICmpInst(this);

    public readonly LLVMValueRef IsAIndirectBrInst => LLVM.IsAIndirectBrInst(this);

    public readonly LLVMValueRef IsAInlineAsm => LLVM.IsAInlineAsm(this);

    public readonly LLVMValueRef IsAInsertElementInst => LLVM.IsAInsertElementInst(this);

    public readonly LLVMValueRef IsAInsertValueInst => LLVM.IsAInsertValueInst(this);

    public readonly LLVMValueRef IsAInstruction => LLVM.IsAInstruction(this);

    public readonly LLVMValueRef IsAIntrinsicInst => LLVM.IsAIntrinsicInst(this);

    public readonly LLVMValueRef IsAIntToPtrInst => LLVM.IsAIntToPtrInst(this);

    public readonly LLVMValueRef IsAInvokeInst => LLVM.IsAInvokeInst(this);

    public readonly LLVMValueRef IsALandingPadInst => LLVM.IsALandingPadInst(this);

    public readonly LLVMValueRef IsALoadInst => LLVM.IsALoadInst(this);

    public readonly LLVMValueRef IsAMDNode => LLVM.IsAMDNode(this);

    public readonly LLVMValueRef IsAMDString => LLVM.IsAMDString(this);

    public readonly LLVMValueRef IsAMemCpyInst => LLVM.IsAMemCpyInst(this);

    public readonly LLVMValueRef IsAMemIntrinsic => LLVM.IsAMemIntrinsic(this);

    public readonly LLVMValueRef IsAMemMoveInst => LLVM.IsAMemMoveInst(this);

    public readonly LLVMValueRef IsAMemSetInst => LLVM.IsAMemSetInst(this);

    public readonly LLVMValueRef IsAPHINode => LLVM.IsAPHINode(this);

    public readonly LLVMValueRef IsAPoisonValue => LLVM.IsAPoisonValue(this);

    public readonly LLVMValueRef IsAPtrToIntInst => LLVM.IsAPtrToIntInst(this);

    public readonly LLVMValueRef IsAResumeInst => LLVM.IsAResumeInst(this);

    public readonly LLVMValueRef IsAReturnInst => LLVM.IsAReturnInst(this);

    public readonly LLVMValueRef IsASelectInst => LLVM.IsASelectInst(this);

    public readonly LLVMValueRef IsASExtInst => LLVM.IsASExtInst(this);

    public readonly LLVMValueRef IsAShuffleVectorInst => LLVM.IsAShuffleVectorInst(this);

    public readonly LLVMValueRef IsASIToFPInst => LLVM.IsASIToFPInst(this);

    public readonly LLVMValueRef IsAStoreInst => LLVM.IsAStoreInst(this);

    public readonly LLVMValueRef IsASwitchInst => LLVM.IsASwitchInst(this);

    public readonly LLVMValueRef IsATerminatorInst => (IsAInstruction != null) ? LLVM.IsATerminatorInst(this) : default;

    public readonly LLVMValueRef IsATruncInst => LLVM.IsATruncInst(this);

    public readonly LLVMValueRef IsAUIToFPInst => LLVM.IsAUIToFPInst(this);

    public readonly LLVMValueRef IsAUnaryInstruction => LLVM.IsAUnaryInstruction(this);

    public readonly LLVMValueRef IsAUnaryOperator => LLVM.IsAUnaryOperator(this);

    public readonly LLVMValueRef IsAUndefValue => LLVM.IsAUndefValue(this);

    public readonly LLVMValueRef IsAUnreachableInst => LLVM.IsAUnreachableInst(this);

    public readonly LLVMValueRef IsAUser => LLVM.IsAUser(this);

    public readonly LLVMValueRef IsAVAArgInst => LLVM.IsAVAArgInst(this);

    public readonly LLVMValueRef IsAValueAsMetadata => LLVM.IsAValueAsMetadata(this);

    public readonly LLVMValueRef IsAZExtInst => LLVM.IsAZExtInst(this);

    public readonly bool IsBasicBlock => (Handle != IntPtr.Zero) && LLVM.ValueIsBasicBlock(this) != 0;

    public readonly bool IsCleanup
    {
        get
        {
            return (IsALandingPadInst != null) && LLVM.IsCleanup(this) != 0;
        }

        set
        {
            LLVM.SetCleanup(this, value ? 1 : 0);
        }
    }

    public readonly bool IsConditional => (IsABranchInst != null) && LLVM.IsConditional(this) != 0;

    public readonly bool IsConstant => (Handle != IntPtr.Zero) && LLVM.IsConstant(this) != 0;

    public readonly bool IsConstantString => (IsAConstantDataSequential != null) && LLVM.IsConstantString(this) != 0;

    public readonly bool IsDeclaration => (IsAGlobalValue != null) && LLVM.IsDeclaration(this) != 0;

    public readonly bool IsExternallyInitialized
    {
        get
        {
            return (IsAGlobalVariable != null) && LLVM.IsExternallyInitialized(this) != 0;
        }

        set
        {
            LLVM.SetExternallyInitialized(this, value ? 1 : 0);
        }
    }

    public readonly bool IsGlobalConstant
    {
        get
        {
            return (IsAGlobalVariable != null) && LLVM.IsGlobalConstant(this) != 0;
        }

        set
        {
            LLVM.SetGlobalConstant(this, value ? 1 : 0);
        }
    }

    public readonly bool IsNull => (Handle != IntPtr.Zero) && LLVM.IsNull(this) != 0;

    public readonly bool IsPoison => (Handle != IntPtr.Zero) && LLVM.IsPoison(this) != 0;

    public readonly bool IsTailCall
    {
        get
        {
            return (IsACallInst != null) && LLVM.IsTailCall(this) != 0;
        }

        set
        {
            LLVM.SetTailCall(this, value ? 1 : 0);
        }
    }

    public readonly bool IsThreadLocal
    {
        get
        {
            return (IsAGlobalVariable != null) && LLVM.IsThreadLocal(this) != 0;
        }

        set
        {
            LLVM.SetThreadLocal(this, value ? 1 : 0);
        }
    }

    public readonly bool IsUndef => (Handle != IntPtr.Zero) && LLVM.IsUndef(this) != 0;

    public readonly LLVMValueKind Kind => (Handle != IntPtr.Zero) ? LLVM.GetValueKind(this) : default;

    public readonly LLVMBasicBlockRef LastBasicBlock => (IsAFunction != null) ? LLVM.GetLastBasicBlock(this) : default;

    public readonly LLVMValueRef LastParam => (IsAFunction != null) ? LLVM.GetLastParam(this) : default;

    public readonly LLVMLinkage Linkage
    {
        get
        {
            return (IsAGlobalValue != null) ? LLVM.GetLinkage(this) : default;
        }

        set
        {
            LLVM.SetLinkage(this, value);
        }
    }

    public readonly uint MDNodeOperandsCount => (IsAMDNode == null) ? LLVM.GetMDNodeNumOperands(this) : default;

    public readonly string Name
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pStr = LLVM.GetValueName(this);

            if (pStr == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pStr);
        }

        set
        {
            using var marshaledName = new MarshaledString(value.AsSpan());
            LLVM.SetValueName(this, marshaledName);
        }
    }

    public readonly LLVMValueRef NextFunction => (IsAFunction != null) ? LLVM.GetNextFunction(this) : default;

    public readonly LLVMValueRef NextGlobal => (IsAGlobalVariable != null) ? LLVM.GetNextGlobal(this) : default;

    public readonly LLVMValueRef NextGlobalAlias => (IsAGlobalAlias != null) ? LLVM.GetNextGlobalAlias(this) : default;

    public readonly LLVMValueRef NextGlobalIFunc => (IsAGlobalIFunc != null) ? LLVM.GetNextGlobalIFunc(this) : default;

    public readonly LLVMValueRef NextInstruction => (IsAInstruction != null) ? LLVM.GetNextInstruction(this) : default;

    public readonly LLVMValueRef NextParam => (IsAArgument != null) ? LLVM.GetNextParam(this) : default;

    public readonly LLVMOpcode Opcode => Kind is LLVMValueKind.LLVMInstructionValueKind ? InstructionOpcode : ConstOpcode;

    public readonly int OperandCount => ((Kind == LLVMValueKind.LLVMMetadataAsValueValueKind) || (IsAUser != null)) ? LLVM.GetNumOperands(this) : default;

    public readonly uint ParamsCount => (IsAFunction != null) ? LLVM.CountParams(this) : default;

    public readonly LLVMValueRef ParamParent => (IsAArgument != null) ? LLVM.GetParamParent(this) : default;

    public readonly LLVMValueRef PersonalityFn
    {
        get
        {
            return HasPersonalityFn ? LLVM.GetPersonalityFn(this) : default;
        }

        set
        {
            LLVM.SetPersonalityFn(this, value);
        }
    }

    public readonly LLVMValueRef PreviousGlobal => (IsAGlobalVariable != null) ? LLVM.GetPreviousGlobal(this) : default;

    public readonly LLVMValueRef PreviousGlobalAlias => (IsAGlobalAlias != null) ? LLVM.GetPreviousGlobalAlias(this) : default;

    public readonly LLVMValueRef PreviousGlobalIFunc => (IsAGlobalIFunc != null) ? LLVM.GetPreviousGlobalIFunc(this) : default;

    public readonly LLVMValueRef PreviousInstruction => (IsAInstruction != null) ? LLVM.GetPreviousInstruction(this) : default;

    public readonly LLVMValueRef PreviousParam => (IsAArgument != null) ? LLVM.GetPreviousParam(this) : default;

    public readonly LLVMValueRef PreviousFunction => (IsAFunction != null) ? LLVM.GetPreviousFunction(this) : default;

    public readonly LLVMTypeRef ReturnType => (IsAFunction != null) ? llvmsharp.Function_getReturnType(this) : default;

    public readonly string Section
    {
        get
        {
            if (IsAGlobalValue == null)
            {
                return string.Empty;
            }

            var pSection = LLVM.GetSection(this);

            if (pSection == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pSection);
        }

        set
        {
            using var marshaledSection = new MarshaledString(value.AsSpan());
            LLVM.SetSection(this, marshaledSection);
        }
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)] // Justification: can throw
    public readonly LLVMMetadataRef Subprogram => (IsAFunction != null) ? LLVM.GetSubprogram(this) : default;

    public readonly uint SuccessorsCount => (IsAInstruction != null) ? LLVM.GetNumSuccessors(this) : default;

    public readonly LLVMBasicBlockRef SwitchDefaultDest => (IsASwitchInst != null) ? LLVM.GetSwitchDefaultDest(this) : default;

    public readonly LLVMTailCallKind TailCallKind
    {
        get
        {
            return (IsACallInst != null) ? LLVM.GetTailCallKind(this) : LLVMTailCallKindNone;
        }

        set
        {
            LLVM.SetTailCallKind(this, value);
        }
    }

    public readonly LLVMThreadLocalMode ThreadLocalMode
    {
        get
        {
            return (IsAGlobalVariable != null) ? LLVM.GetThreadLocalMode(this) : default;
        }

        set
        {
            LLVM.SetThreadLocalMode(this, value);
        }
    }

    public readonly LLVMTypeRef TypeOf => (Handle != IntPtr.Zero) ? LLVM.TypeOf(this) : default;

    public readonly LLVMUnnamedAddr UnnamedAddress
    {
        get
        {
            return (IsAGlobalValue != null) ? LLVM.GetUnnamedAddress(this) : default;
        }

        set
        {
            LLVM.SetUnnamedAddress(this, value);
        }
    }

    public readonly LLVMValueUsesEnumerable Uses => new LLVMValueUsesEnumerable(this);

    public readonly LLVMVisibility Visibility
    {
        get
        {
            return (IsAGlobalValue != null) ? LLVM.GetVisibility(this) : default;
        }

        set
        {
            LLVM.SetVisibility(this, value);
        }
    }

    public readonly bool Volatile
    {
        get
        {
            return ((IsALoadInst != null) || (IsAStoreInst != null) || (IsAAtomicRMWInst != null) || (IsAAtomicCmpXchgInst != null)) && LLVM.GetVolatile(this) != 0;
        }

        set
        {
            LLVM.SetVolatile(this, value ? 1 : 0);
        }
    }

    public readonly bool Weak
    {
        get
        {
            return (IsAAtomicCmpXchgInst != null) && LLVM.GetWeak(this) != 0;
        }

        set
        {
            LLVM.SetWeak(this, value ? 1 : 0);
        }
    }

    public static implicit operator LLVMValueRef(LLVMOpaqueValue* value) => new LLVMValueRef((IntPtr)value);

    public static implicit operator LLVMOpaqueValue*(LLVMValueRef value) => (LLVMOpaqueValue*)value.Handle;

    public static bool operator ==(LLVMValueRef left, LLVMValueRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMValueRef left, LLVMValueRef right) => !(left == right);

    public static LLVMValueRef CreateConstAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstAdd(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstAddrSpaceCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstAddrSpaceCast(ConstantVal, ToType);

    public static LLVMValueRef CreateConstAllOnes(LLVMTypeRef Ty) => LLVM.ConstAllOnes(Ty);

    public static LLVMValueRef CreateConstArray(LLVMTypeRef ElementTy, LLVMValueRef[] ConstantVals) => CreateConstArray(ElementTy, ConstantVals.AsSpan());

    public static LLVMValueRef CreateConstArray(LLVMTypeRef ElementTy, ReadOnlySpan<LLVMValueRef> ConstantVals)
    {
        fixed (LLVMValueRef* pConstantVals = ConstantVals)
        {
            return LLVM.ConstArray(ElementTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length);
        }
    }

    public static LLVMValueRef CreateConstBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstBitCast(ConstantVal, ToType);

    public static LLVMValueRef CreateConstExtractElement(LLVMValueRef VectorConstant, LLVMValueRef IndexConstant) => LLVM.ConstExtractElement(VectorConstant, IndexConstant);

    public static LLVMValueRef CreateConstGEP2(LLVMTypeRef Ty, LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices) => CreateConstGEP2(Ty, ConstantVal, ConstantIndices.AsSpan());

    public static LLVMValueRef CreateConstGEP2(LLVMTypeRef Ty, LLVMValueRef ConstantVal, ReadOnlySpan<LLVMValueRef> ConstantIndices)
    {
        fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
        {
            return LLVM.ConstGEP2(Ty, ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices.Length);
        }
    }

    public static LLVMValueRef CreateConstInBoundsGEP2(LLVMTypeRef Ty, LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices) => CreateConstInBoundsGEP2(Ty, ConstantVal, ConstantIndices.AsSpan());

    public static LLVMValueRef CreateConstInBoundsGEP2(LLVMTypeRef Ty, LLVMValueRef ConstantVal, ReadOnlySpan<LLVMValueRef> ConstantIndices)
    {
        fixed (LLVMValueRef* pConstantIndices = ConstantIndices)
        {
            return LLVM.ConstInBoundsGEP2(Ty, ConstantVal, (LLVMOpaqueValue**)pConstantIndices, (uint)ConstantIndices.Length);
        }
    }

    public static LLVMValueRef CreateConstInlineAsm(LLVMTypeRef Ty, string AsmString, string Constraints, bool HasSideEffects, bool IsAlignStack) => CreateConstInlineAsm(Ty, AsmString.AsSpan(), Constraints.AsSpan(), HasSideEffects, IsAlignStack);

    public static LLVMValueRef CreateConstInlineAsm(LLVMTypeRef Ty, ReadOnlySpan<char> AsmString, ReadOnlySpan<char> Constraints, bool HasSideEffects, bool IsAlignStack)
    {
        using var marshaledAsmString = new MarshaledString(AsmString);
        using var marshaledConstraints = new MarshaledString(Constraints);
        return LLVM.ConstInlineAsm(Ty, marshaledAsmString, marshaledConstraints, HasSideEffects ? 1 : 0, IsAlignStack ? 1 : 0);
    }

    public static LLVMValueRef CreateConstInsertElement(LLVMValueRef VectorConstant, LLVMValueRef ElementValueConstant, LLVMValueRef IndexConstant) => LLVM.ConstInsertElement(VectorConstant, ElementValueConstant, IndexConstant);

    public static LLVMValueRef CreateConstInt(LLVMTypeRef IntTy, ulong N, bool SignExtend = false)
    {
        ThrowIfNotIntegerType(IntTy, nameof(IntTy));
        return LLVM.ConstInt(IntTy, N, SignExtend ? 1 : 0);
    }

    public static LLVMValueRef CreateConstIntOfArbitraryPrecision(LLVMTypeRef IntTy, ulong[] Words) => CreateConstIntOfArbitraryPrecision(IntTy, Words.AsSpan());

    public static LLVMValueRef CreateConstIntOfArbitraryPrecision(LLVMTypeRef IntTy, ReadOnlySpan<ulong> Words)
    {
        ThrowIfNotIntegerType(IntTy, nameof(IntTy));
        fixed (ulong* pWords = Words)
        {
            return LLVM.ConstIntOfArbitraryPrecision(IntTy, (uint)Words.Length, pWords);
        }
    }

    public static LLVMValueRef CreateConstIntOfString(LLVMTypeRef IntTy, string Text, byte Radix) => CreateConstIntOfString(IntTy, Text.AsSpan(), Radix);

    public static LLVMValueRef CreateConstIntOfString(LLVMTypeRef IntTy, ReadOnlySpan<char> Text, byte Radix)
    {
        ThrowIfNotIntegerType(IntTy, nameof(IntTy));
        using var marshaledText = new MarshaledString(Text);
        return LLVM.ConstIntOfString(IntTy, marshaledText, Radix);
    }

    public static LLVMValueRef CreateConstIntOfStringAndSize(LLVMTypeRef IntTy, string Text, uint SLen, byte Radix) => CreateConstIntOfStringAndSize(IntTy, Text.AsSpan(0, (int)SLen), Radix);

    public static LLVMValueRef CreateConstIntOfStringAndSize(LLVMTypeRef IntTy, ReadOnlySpan<char> Text, byte Radix)
    {
        ThrowIfNotIntegerType(IntTy, nameof(IntTy));
        using var marshaledText = new MarshaledString(Text);
        return LLVM.ConstIntOfStringAndSize(IntTy, marshaledText, (uint)marshaledText.Length, Radix);
    }

    public static LLVMValueRef CreateConstIntToPtr(LLVMValueRef ConstantVal, LLVMTypeRef ToType)
    {
        // Mirrors ConstantExpr::getIntToPtr: integer source, pointer destination.
        ThrowIfNotIntOrIntVectorType(ConstantVal.TypeOf, nameof(ConstantVal));
        ThrowIfNotPtrOrPtrVectorType(ToType, nameof(ToType));
        return LLVM.ConstIntToPtr(ConstantVal, ToType);
    }

    public static LLVMValueRef CreateConstNamedStruct(LLVMTypeRef StructTy, LLVMValueRef[] ConstantVals) => CreateConstNamedStruct(StructTy, ConstantVals.AsSpan());

    public static LLVMValueRef CreateConstNamedStruct(LLVMTypeRef StructTy, ReadOnlySpan<LLVMValueRef> ConstantVals)
    {
        fixed (LLVMValueRef* pConstantVals = ConstantVals)
        {
            return LLVM.ConstNamedStruct(StructTy, (LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length);
        }
    }

    public static LLVMValueRef CreateConstNeg(LLVMValueRef ConstantVal) => LLVM.ConstNeg(ConstantVal);

    public static LLVMValueRef CreateConstNot(LLVMValueRef ConstantVal) => LLVM.ConstNot(ConstantVal);

    public static LLVMValueRef CreateConstNSWAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNSWAdd(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstNSWNeg(LLVMValueRef ConstantVal) => LLVM.ConstNSWNeg(ConstantVal);

    public static LLVMValueRef CreateConstNSWSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNSWSub(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstNull(LLVMTypeRef Ty) => LLVM.ConstNull(Ty);

    public static LLVMValueRef CreateConstNUWAdd(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNUWAdd(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstNUWSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstNUWSub(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstPointerCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstPointerCast(ConstantVal, ToType);

    public static LLVMValueRef CreateConstPointerNull(LLVMTypeRef Ty) => LLVM.ConstPointerNull(Ty);

    public static LLVMValueRef CreateConstPtrToInt(LLVMValueRef ConstantVal, LLVMTypeRef ToType)
    {
        // Mirrors ConstantExpr::getPtrToInt: pointer source, integer destination.
        ThrowIfNotPtrOrPtrVectorType(ConstantVal.TypeOf, nameof(ConstantVal));
        ThrowIfNotIntOrIntVectorType(ToType, nameof(ToType));
        return LLVM.ConstPtrToInt(ConstantVal, ToType);
    }

    public static LLVMValueRef CreateConstReal(LLVMTypeRef RealTy, double N)
    {
        ThrowIfNotFloatingPointType(RealTy, nameof(RealTy));
        return LLVM.ConstReal(RealTy, N);
    }

    public static LLVMValueRef CreateConstRealOfString(LLVMTypeRef RealTy, string Text) => CreateConstRealOfString(RealTy, Text.AsSpan());

    public static LLVMValueRef CreateConstRealOfString(LLVMTypeRef RealTy, ReadOnlySpan<char> Text)
    {
        ThrowIfNotFloatingPointType(RealTy, nameof(RealTy));
        using var marshaledText = new MarshaledString(Text);
        return LLVM.ConstRealOfString(RealTy, marshaledText);
    }

    public static LLVMValueRef CreateConstRealOfStringAndSize(LLVMTypeRef RealTy, string Text, uint SLen) => CreateConstRealOfStringAndSize(RealTy, Text.AsSpan(0, (int)SLen));

    public static LLVMValueRef CreateConstRealOfStringAndSize(LLVMTypeRef RealTy, ReadOnlySpan<char> Text)
    {
        ThrowIfNotFloatingPointType(RealTy, nameof(RealTy));
        using var marshaledText = new MarshaledString(Text);
        return LLVM.ConstRealOfStringAndSize(RealTy, marshaledText, (uint)marshaledText.Length);
    }

    // libLLVM's ConstReal family maps onto ConstantFP::get, which requires a floating-point
    // (or floating-point vector) type; anything else asserts in a checked build and is undefined
    // behavior otherwise -- see dotnet/LLVMSharp#194. Catch it here so the safer wrapper surfaces
    // a clear error instead of the raw binding corrupting IR or crashing.
    private static void ThrowIfNotFloatingPointType(LLVMTypeRef RealTy, string paramName)
    {
        if (GetScalarType(RealTy).Kind is not (LLVMTypeKind.LLVMHalfTypeKind
                                            or LLVMTypeKind.LLVMBFloatTypeKind
                                            or LLVMTypeKind.LLVMFloatTypeKind
                                            or LLVMTypeKind.LLVMDoubleTypeKind
                                            or LLVMTypeKind.LLVMX86_FP80TypeKind
                                            or LLVMTypeKind.LLVMFP128TypeKind
                                            or LLVMTypeKind.LLVMPPC_FP128TypeKind))
        {
            ThrowNotFloatingPointType(RealTy, paramName);
        }
    }

    [DoesNotReturn]
    private static void ThrowNotFloatingPointType(LLVMTypeRef RealTy, string paramName) =>
        throw new ArgumentException($"Expected a floating-point type, but was given '{RealTy.Kind}'. Use {nameof(CreateConstInt)} to create integer constants.", paramName);

    // libLLVM's ConstInt family maps onto ConstantInt::get via unwrap<IntegerType>, so it requires
    // an integer type; anything else silently produces corrupt IR (e.g. 'i0 0' for a double type)
    // rather than erroring -- the integer-side analogue of dotnet/LLVMSharp#194. Unlike ConstReal,
    // these don't accept vector types.
    private static void ThrowIfNotIntegerType(LLVMTypeRef IntTy, string paramName)
    {
        if (IntTy.Kind is not LLVMTypeKind.LLVMIntegerTypeKind)
        {
            ThrowNotIntegerType(IntTy, paramName);
        }
    }

    [DoesNotReturn]
    private static void ThrowNotIntegerType(LLVMTypeRef IntTy, string paramName) =>
        throw new ArgumentException($"Expected an integer type, but was given '{IntTy.Kind}'. Use {nameof(CreateConstReal)} to create floating-point constants.", paramName);

    // Mirrors LLVM's isIntOrIntVectorTy assert on ConstantExpr::getIntToPtr/getPtrToInt.
    private static void ThrowIfNotIntOrIntVectorType(LLVMTypeRef Ty, string paramName)
    {
        if (GetScalarType(Ty).Kind is not LLVMTypeKind.LLVMIntegerTypeKind)
        {
            ThrowNotIntOrIntVectorType(Ty, paramName);
        }
    }

    [DoesNotReturn]
    private static void ThrowNotIntOrIntVectorType(LLVMTypeRef Ty, string paramName) =>
        throw new ArgumentException($"Expected an integer or integer vector type, but was given '{Ty.Kind}'.", paramName);

    // Mirrors LLVM's isPtrOrPtrVectorTy assert on ConstantExpr::getIntToPtr/getPtrToInt.
    private static void ThrowIfNotPtrOrPtrVectorType(LLVMTypeRef Ty, string paramName)
    {
        if (GetScalarType(Ty).Kind is not LLVMTypeKind.LLVMPointerTypeKind)
        {
            ThrowNotPtrOrPtrVectorType(Ty, paramName);
        }
    }

    [DoesNotReturn]
    private static void ThrowNotPtrOrPtrVectorType(LLVMTypeRef Ty, string paramName) =>
        throw new ArgumentException($"Expected a pointer or pointer vector type, but was given '{Ty.Kind}'.", paramName);

    private static LLVMTypeRef GetScalarType(LLVMTypeRef Ty) => Ty.Kind is LLVMTypeKind.LLVMVectorTypeKind or LLVMTypeKind.LLVMScalableVectorTypeKind ? Ty.ElementType : Ty;

    public static LLVMValueRef CreateConstShuffleVector(LLVMValueRef VectorAConstant, LLVMValueRef VectorBConstant, LLVMValueRef MaskConstant) => LLVM.ConstShuffleVector(VectorAConstant, VectorBConstant, MaskConstant);

    public static LLVMValueRef CreateConstStruct(LLVMValueRef[] ConstantVals, bool Packed) => CreateConstStruct(ConstantVals.AsSpan(), Packed);

    public static LLVMValueRef CreateConstStruct(ReadOnlySpan<LLVMValueRef> ConstantVals, bool Packed)
    {
        fixed (LLVMValueRef* pConstantVals = ConstantVals)
        {
            return LLVM.ConstStruct((LLVMOpaqueValue**)pConstantVals, (uint)ConstantVals.Length, Packed ? 1 : 0);
        }
    }

    public static LLVMValueRef CreateConstSub(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstSub(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateConstTrunc(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTrunc(ConstantVal, ToType);

    public static LLVMValueRef CreateConstTruncOrBitCast(LLVMValueRef ConstantVal, LLVMTypeRef ToType) => LLVM.ConstTruncOrBitCast(ConstantVal, ToType);

    public static LLVMValueRef CreateConstVector(LLVMValueRef[] ScalarConstantVars) => CreateConstVector(ScalarConstantVars.AsSpan());

    public static LLVMValueRef CreateConstVector(ReadOnlySpan<LLVMValueRef> ScalarConstantVars)
    {
        fixed (LLVMValueRef* pScalarConstantVars = ScalarConstantVars)
        {
            return LLVM.ConstVector((LLVMOpaqueValue**)pScalarConstantVars, (uint)ScalarConstantVars.Length);
        }
    }

    public static LLVMValueRef CreateConstXor(LLVMValueRef LHSConstant, LLVMValueRef RHSConstant) => LLVM.ConstXor(LHSConstant, RHSConstant);

    public static LLVMValueRef CreateMDNode(LLVMValueRef[] Vals) => CreateMDNode(Vals.AsSpan());

    public static LLVMValueRef CreateMDNode(ReadOnlySpan<LLVMValueRef> Vals)
    {
        fixed (LLVMValueRef* pVals = Vals)
        {
            return LLVM.MDNode((LLVMOpaqueValue**)pVals, (uint)Vals.Length);
        }
    }

    public readonly void AddCase(LLVMValueRef OnVal, LLVMBasicBlockRef Dest) => LLVM.AddCase(this, OnVal, Dest);

    public readonly void AddClause(LLVMValueRef ClauseVal) => LLVM.AddClause(this, ClauseVal);

    public readonly void AddDestination(LLVMBasicBlockRef Dest) => LLVM.AddDestination(this, Dest);

    public readonly void AddIncoming(LLVMValueRef[] IncomingValues, LLVMBasicBlockRef[] IncomingBlocks, uint Count) => AddIncoming(IncomingValues.AsSpan(), IncomingBlocks.AsSpan(), Count);

    public readonly void AddIncoming(ReadOnlySpan<LLVMValueRef> IncomingValues, ReadOnlySpan<LLVMBasicBlockRef> IncomingBlocks, uint Count)
    {
        fixed (LLVMValueRef* pIncomingValues = IncomingValues)
        fixed (LLVMBasicBlockRef* pIncomingBlocks = IncomingBlocks)
        {
            LLVM.AddIncoming(this, (LLVMOpaqueValue**)pIncomingValues, (LLVMOpaqueBasicBlock**)pIncomingBlocks, Count);
        }
    }

    public readonly void AddTargetDependentFunctionAttr(string A, string V) => AddTargetDependentFunctionAttr(A.AsSpan(), V.AsSpan());

    public readonly void AddTargetDependentFunctionAttr(ReadOnlySpan<char> A, ReadOnlySpan<char> V)
    {
        using var marshaledA = new MarshaledString(A);
        using var marshaledV = new MarshaledString(V);
        LLVM.AddTargetDependentFunctionAttr(this, marshaledA, marshaledV);
    }

    public readonly LLVMBasicBlockRef AppendBasicBlock(string Name) => AppendBasicBlock(Name.AsSpan());

    public readonly LLVMBasicBlockRef AppendBasicBlock(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.AppendBasicBlock(this, marshaledName);
    }

    public readonly LLVMBasicBlockRef AsBasicBlock() => LLVM.ValueAsBasicBlock(this);

    public readonly LLVMMetadataRef AsMetadata() => LLVM.ValueAsMetadata(this);

    public readonly void DeleteFunction() => LLVM.DeleteFunction(this);

    public readonly void DeleteGlobal() => LLVM.DeleteGlobal(this);

    public readonly void Dump() => LLVM.DumpValue(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMValueRef other) && Equals(other);

    public readonly bool Equals(LLVMValueRef other) => this == other;

    public readonly LLVMMetadataRef[] GetAllMetadataOtherThanDebugLoc()
    {
        if (IsAInstruction == null)
        {
            return [];
        }

        nuint metadataCount = 0;
        var ptr = LLVM.InstructionGetAllMetadataOtherThanDebugLoc(this, &metadataCount);

        LLVMMetadataRef[] metadataArray;
        if (metadataCount == 0)
        {
            metadataArray = [];
        }
        else
        {
            metadataArray = new LLVMMetadataRef[metadataCount];
            for (uint i = 0; i < metadataCount; i++)
            {
                metadataArray[i] = LLVM.ValueMetadataEntriesGetMetadata(ptr, i);
            }
            LLVM.DisposeValueMetadataEntries(ptr);
        }

        LLVM.DisposeValueMetadataEntries(ptr);
        return metadataArray;
    }

    public readonly string GetAsString(out UIntPtr Length)
    {
        fixed (UIntPtr* pLength = &Length)
        {
            var pStr = LLVM.GetAsString(this, pLength);

            if (pStr == null)
            {
                return string.Empty;
            }

            var span = new ReadOnlySpan<byte>(pStr, (int)Length);
            return span.AsString();
        }
    }

    public readonly LLVMBasicBlockRef[] GetBasicBlocks()
    {
        if (IsAFunction == null)
        {
            return [];
        }

        var destination = new LLVMBasicBlockRef[BasicBlocksCount];
        GetBasicBlocks(destination);
        return destination;
    }

    public readonly void GetBasicBlocks(Span<LLVMBasicBlockRef> destination)
    {
        if (IsAFunction == null)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, BasicBlocksCount);

        fixed (LLVMBasicBlockRef* pBasicBlocks = destination)
        {
            LLVM.GetBasicBlocks(this, (LLVMOpaqueBasicBlock**)pBasicBlocks);
        }
    }

    public readonly IEnumerable<LLVMValueRef> GetInstructions()
    {
        if (IsAFunction != default)
        {
            return GetBasicBlocks().SelectMany(b => b.Instructions);
        }
        else if (IsABasicBlock != default)
        {
            return AsBasicBlock().Instructions;
        }
        else if (IsAInstruction != default)
        {
            return [this];
        }
        else
        {
            return [];
        }
    }

    public readonly LLVMValueRef[] GetMDNodeOperands()
    {
        uint count = MDNodeOperandsCount;
        if (count == 0)
        {
            return [];
        }

        var destination = new LLVMValueRef[count];
        GetMDNodeOperands(destination);
        return destination;
    }

    public readonly void GetMDNodeOperands(Span<LLVMValueRef> destination)
    {
        if (IsAMDNode == null)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, MDNodeOperandsCount);

        fixed (LLVMValueRef* pDest = destination)
        {
            LLVM.GetMDNodeOperands(this, (LLVMOpaqueValue**)pDest);
        }
    }

    public readonly LLVMValueRef[] GetParams()
    {
        if (IsAFunction == null)
        {
            return [];
        }

        var destination = new LLVMValueRef[ParamsCount];
        GetParams(destination);
        return destination;
    }

    public readonly void GetParams(Span<LLVMValueRef> destination)
    {
        if (IsAFunction == null)
        {
            return;
        }

        ArgumentOutOfRangeException.ThrowIfLessThan((uint)destination.Length, ParamsCount);

        fixed (LLVMValueRef* pParams = destination)
        {
            LLVM.GetParams(this, (LLVMOpaqueValue**)pParams);
        }
    }

    public readonly void AddAttributeAtIndex(LLVMAttributeIndex Idx, LLVMAttributeRef A)
    {
        LLVM.AddAttributeAtIndex(this, Idx, A);
    }

    public readonly LLVMAttributeRef[] GetAttributesAtIndex(LLVMAttributeIndex Idx)
    {
        var Attrs = new LLVMAttributeRef[GetAttributeCountAtIndex(Idx)];

        fixed (LLVMAttributeRef* pAttrs = Attrs)
        {
            LLVM.GetAttributesAtIndex(this, Idx, (LLVMOpaqueAttributeRef**)pAttrs);
        }

        return Attrs;
    }

    public readonly uint GetAttributeCountAtIndex(LLVMAttributeIndex Idx) => LLVM.GetAttributeCountAtIndex(this, Idx);

    public readonly LLVMAttributeRef GetEnumAttributeAtIndex(LLVMAttributeIndex Idx, uint KindId) => LLVM.GetEnumAttributeAtIndex(this, Idx, KindId);

    public readonly void RemoveEnumAttributeAtIndex(LLVMAttributeIndex Idx, uint KindId) => LLVM.RemoveEnumAttributeAtIndex(this, Idx, KindId);

    public readonly LLVMValueRef GetBlockAddress(LLVMBasicBlockRef BB) => LLVM.BlockAddress(this, BB);

    public readonly uint GetCallSiteAttributeCount(LLVMAttributeIndex Idx) => LLVM.GetCallSiteAttributeCount(this, Idx);

    public readonly LLVMAttributeRef[] GetCallSiteAttributes(LLVMAttributeIndex Idx)
    {
        var Attrs = new LLVMAttributeRef[GetCallSiteAttributeCount(Idx)];

        fixed (LLVMAttributeRef* pAttrs = Attrs)
        {
            LLVM.GetCallSiteAttributes(this, Idx, (LLVMOpaqueAttributeRef**)pAttrs);
        }

        return Attrs;
    }

    public readonly double GetConstRealDouble(out bool losesInfo)
    {
        int losesInfoOut;
        var result = LLVM.ConstRealGetDouble(this, &losesInfoOut);

        losesInfo = losesInfoOut != 0;
        return result;
    }

    public readonly LLVMValueRef GetAggregateElement(uint idx) => LLVM.GetAggregateElement(this, idx);

    [Obsolete("Use GetAggregateElement instead")]
    public readonly LLVMValueRef GetElementAsConstant(uint idx) => LLVM.GetElementAsConstant(this, idx);

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMBasicBlockRef GetIncomingBlock(uint Index) => LLVM.GetIncomingBlock(this, Index);

    public readonly LLVMValueRef GetIncomingValue(uint Index) => LLVM.GetIncomingValue(this, Index);

    public readonly string GetMDString(out uint Len)
    {
        fixed (uint* pLen = &Len)
        {
            var pMDStr = LLVM.GetMDString(this, pLen);

            if (pMDStr == null)
            {
                return string.Empty;
            }

            var span = new ReadOnlySpan<byte>(pMDStr, (int)Len);
            return span.AsString();
        }
    }

    public readonly LLVMValueRef GetMetadata(uint KindID) => LLVM.GetMetadata(this, KindID);

    public readonly LLVMValueRef GetOperand(uint Index) => LLVM.GetOperand(this, Index);

    public readonly LLVMValueRef[] GetOperands()
    {
        int numOperands = OperandCount;
        if (numOperands == 0)
        {
            return [];
        }

        LLVMValueRef[] operands = new LLVMValueRef[numOperands];
        for (int i = 0; i < numOperands; i++)
        {
            operands[i] = GetOperand((uint)i);
        }
        return operands;
    }

    public readonly LLVMUseRef GetOperandUse(uint Index) => LLVM.GetOperandUse(this, Index);

    public readonly LLVMValueRef GetParam(uint Index) => LLVM.GetParam(this, Index);

    public readonly LLVMBasicBlockRef GetSuccessor(uint i) => LLVM.GetSuccessor(this, i);

    public readonly void InstructionEraseFromParent() => LLVM.InstructionEraseFromParent(this);

    public readonly void InstructionRemoveFromParent() => LLVM.InstructionRemoveFromParent(this);

    public readonly string PrintToString()
    {
        var pStr = LLVM.PrintValueToString(this);

        if (pStr == null)
        {
            return string.Empty;
        }

        var result = SpanExtensions.AsString(pStr);
        LLVM.DisposeMessage(pStr);
        return result;
    }

    public readonly void ReplaceAllUsesWith(LLVMValueRef NewVal) => LLVM.ReplaceAllUsesWith(this, NewVal);

    public readonly void ReplaceMDNodeOperandWith(uint Index, LLVMMetadataRef Replacement) => LLVM.ReplaceMDNodeOperandWith(this, Index, Replacement);

    public void SetAlignment(uint Bytes)
    {
        Alignment = Bytes;
    }

    public readonly void SetInstrParamAlignment(LLVMAttributeIndex index, uint align) => LLVM.SetInstrParamAlignment(this, index, align);

    public readonly void SetMetadata(uint KindID, LLVMValueRef Node) => LLVM.SetMetadata(this, KindID, Node);

    public readonly void SetOperand(uint Index, LLVMValueRef Val) => LLVM.SetOperand(this, Index, Val);

    public readonly void SetParamAlignment(uint align) => LLVM.SetParamAlignment(this, align);

    public readonly void SetSuccessor(uint i, LLVMBasicBlockRef block) => LLVM.SetSuccessor(this, i, block);

    public override readonly string ToString() => (Handle != IntPtr.Zero) ? PrintToString() : string.Empty;

    public readonly bool VerifyFunction(LLVMVerifierFailureAction Action) => LLVM.VerifyFunction(this, Action) == 0;

    public readonly void ViewFunctionCFG() => LLVM.ViewFunctionCFG(this);

    public readonly void ViewFunctionCFGOnly() => LLVM.ViewFunctionCFGOnly(this);
}
