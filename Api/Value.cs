namespace LLVMSharp.Api
{
    using System;
    using System.Runtime.InteropServices;
    using Utilities;
    using Values;
    using Values.Constants.GlobalValues.GlobalObjects;
    using Values.Instructions;

    public abstract class Value : IEquatable<Value>, IWrapper<LLVMValueRef>
    {
        internal static Value Create(LLVMValueRef v)
        {
            if (v.Pointer == IntPtr.Zero)
            {
                return null;
            }

            if (LLVM.ValueIsBasicBlock(v))
            {
                return new BasicBlock(LLVM.ValueAsBasicBlock(v));
            }

            if (LLVM.IsAFunction(v).ToBool())
            {
                return new Function(v);
            }

            if (LLVM.IsABinaryOperator(v).ToBool())
            {
                return BinaryOperator.Create(v);
            }

            if (LLVM.IsAInstruction(v).ToBool())
            {
                return Instruction.Create(v);
            }

            if (LLVM.IsConstant(v))
            {
                return Instruction.Create(v);
            }

            if (LLVM.IsAArgument(v).ToBool())
            {
                return new Argument(v);
            }

            throw new NotImplementedException();
        }

        public static Value ConstString(string str, uint length, bool dontNullTerminate)
        {
            return LLVM.ConstString(str, length, dontNullTerminate).Wrap();
        }

        public static Value ConstStruct(Value[] constantVals, bool packed)
        {
            return LLVM.ConstStruct(constantVals.Unwrap(), packed).Wrap();
        }

        public static Value ConstVector(Value[] scalarConstantVals)
        {
            return LLVM.ConstVector(scalarConstantVals.Unwrap()).Wrap();
        }

        LLVMValueRef IWrapper<LLVMValueRef>.ToHandleType()
        {
            return this._instance;
        }

        public void MakeHandleOwner()
        {            
        }

        private readonly LLVMValueRef _instance;

        internal Value(LLVMValueRef instance)
        {
            this._instance = instance;
        }
        
        public Type Type
        {
            get { return LLVM.TypeOf(this.Unwrap()).Wrap(); }
        }

        public string Name
        {
            get { return LLVM.GetValueName(this.Unwrap()); }
            set { LLVM.SetValueName(this.Unwrap(), value); }
        }

        public Context Context
        {
            get { return this.Type.TypeContext; }
        }

        public bool Volatile
        {
            get { return LLVM.GetVolatile(this.Unwrap()); }
            set { LLVM.SetVolatile(this.Unwrap(), value); }
        }

        public LLVMOpcode GetInstructionOpcode()
        {
            return LLVM.GetInstructionOpcode(this.Unwrap());
        }

        public LLVMIntPredicate GetICmpPredicate()
        {
            return LLVM.GetICmpPredicate(this.Unwrap());
        }

        public LLVMRealPredicate GetFCmpPredicate()
        {
            return LLVM.GetFCmpPredicate(this.Unwrap());
        }
        
        public void Dump()
        {
            LLVM.DumpValue(this.Unwrap());
        }

        public string GetMDString(out uint len)
        {
            return LLVM.GetMDString(this.Unwrap(), out len);
        }

        public uint GetMDNodeNumOperands()
        {
            return LLVM.GetMDNodeNumOperands(this.Unwrap());
        }

        public Value[] GetMDNodeOperands()
        {
            return LLVM.GetMDNodeOperands(this.Unwrap()).Wrap<LLVMValueRef, Value>();
        }

        public override string ToString()
        {
            var ptr = LLVM.PrintValueToString(this.Unwrap());
            var retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal ?? string.Empty;
        }
        
        public bool Equals(Value other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return this._instance == other._instance;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Value);
        }

        public static bool operator ==(Value op1, Value op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            return op1.Equals(op2);
        }

        public static bool operator !=(Value op1, Value op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
        }

        public IntPtr PrintValueToString
        {
            get { return LLVM.PrintValueToString(this.Unwrap()); }
        }

        public void ReplaceAllUsesWith(Value v)
        {
            LLVM.ReplaceAllUsesWith(this.Unwrap(), v.Unwrap());
        }

        public bool IsConstant
        {
            get { return LLVM.IsConstant(this.Unwrap()); }
        }

        public bool IsUndef
        {
            get { return LLVM.IsUndef(this.Unwrap()); }
        }

        public Value IsAArgument
        {
            get { return LLVM.IsAArgument(this.Unwrap()).Wrap(); }
        }

        public Value IsABasicBlock
        {
            get { return LLVM.IsABasicBlock(this.Unwrap()).Wrap(); }
        }

        public Value IsAInlineAsm
        {
            get { return LLVM.IsAInlineAsm(this.Unwrap()).Wrap(); }
        }

        public Value IsAUser
        {
            get { return LLVM.IsAUser(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstant
        {
            get { return LLVM.IsAConstant(this.Unwrap()).Wrap(); }
        }

        public Value IsABlockAddress
        {
            get { return LLVM.IsABlockAddress(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantAggregateZero
        {
            get { return LLVM.IsAConstantAggregateZero(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantArray
        {
            get { return LLVM.IsAConstantArray(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantDataSequential
        {
            get { return LLVM.IsAConstantDataSequential(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantDataArray
        {
            get { return LLVM.IsAConstantDataArray(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantDataVector
        {
            get { return LLVM.IsAConstantDataVector(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantExpr
        {
            get { return LLVM.IsAConstantExpr(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantFP
        {
            get { return LLVM.IsAConstantFP(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantInt
        {
            get { return LLVM.IsAConstantInt(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantPointerNull
        {
            get { return LLVM.IsAConstantPointerNull(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantStruct
        {
            get { return LLVM.IsAConstantStruct(this.Unwrap()).Wrap(); }
        }

        public Value IsAConstantVector
        {
            get { return LLVM.IsAConstantVector(this.Unwrap()).Wrap(); }
        }

        public Value IsAGlobalValue
        {
            get { return LLVM.IsAGlobalValue(this.Unwrap()).Wrap(); }
        }

        public Value IsAGlobalAlias
        {
            get { return LLVM.IsAGlobalAlias(this.Unwrap()).Wrap(); }
        }

        public Value IsAGlobalObject
        {
            get { return LLVM.IsAGlobalObject(this.Unwrap()).Wrap(); }
        }

        public Value IsAFunction
        {
            get { return LLVM.IsAFunction(this.Unwrap()).Wrap(); }
        }

        public Value IsAGlobalVariable
        {
            get { return LLVM.IsAGlobalVariable(this.Unwrap()).Wrap(); }
        }

        public Value IsAUndefValue
        {
            get { return LLVM.IsAUndefValue(this.Unwrap()).Wrap(); }
        }

        public Value IsAInstruction
        {
            get { return LLVM.IsAInstruction(this.Unwrap()).Wrap(); }
        }

        public Value IsABinaryOperator
        {
            get { return LLVM.IsABinaryOperator(this.Unwrap()).Wrap(); }
        }

        public Value IsACallInst
        {
            get { return LLVM.IsACallInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAIntrinsicInst
        {
            get { return LLVM.IsAIntrinsicInst(this.Unwrap()).Wrap(); }
        }

        public Value IsADbgInfoIntrinsic
        {
            get { return LLVM.IsADbgInfoIntrinsic(this.Unwrap()).Wrap(); }
        }

        public Value IsADbgDeclareInst
        {
            get { return LLVM.IsADbgDeclareInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAMemIntrinsic
        {
            get { return LLVM.IsAMemIntrinsic(this.Unwrap()).Wrap(); }
        }

        public Value IsAMemCpyInst
        {
            get { return LLVM.IsAMemCpyInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAMemMoveInst
        {
            get { return LLVM.IsAMemMoveInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAMemSetInst
        {
            get { return LLVM.IsAMemSetInst(this.Unwrap()).Wrap(); }
        }

        public Value IsACmpInst
        {
            get { return LLVM.IsACmpInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAFCmpInst
        {
            get { return LLVM.IsAFCmpInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAICmpInst
        {
            get { return LLVM.IsAICmpInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAExtractElementInst
        {
            get { return LLVM.IsAExtractElementInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAGetElementPtrInst
        {
            get { return LLVM.IsAGetElementPtrInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAInsertElementInst
        {
            get { return LLVM.IsAInsertElementInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAInsertValueInst
        {
            get { return LLVM.IsAInsertValueInst(this.Unwrap()).Wrap(); }
        }

        public Value IsALandingPadInst
        {
            get { return LLVM.IsALandingPadInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAPHINode
        {
            get { return LLVM.IsAPHINode(this.Unwrap()).Wrap(); }
        }

        public Value IsASelectInst
        {
            get { return LLVM.IsASelectInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAShuffleVectorInst
        {
            get { return LLVM.IsAShuffleVectorInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAStoreInst
        {
            get { return LLVM.IsAStoreInst(this.Unwrap()).Wrap(); }
        }

        public Value IsATerminatorInst
        {
            get { return LLVM.IsATerminatorInst(this.Unwrap()).Wrap(); }
        }

        public Value IsABranchInst
        {
            get { return LLVM.IsABranchInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAIndirectBrInst
        {
            get { return LLVM.IsAIndirectBrInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAInvokeInst
        {
            get { return LLVM.IsAInvokeInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAReturnInst
        {
            get { return LLVM.IsAReturnInst(this.Unwrap()).Wrap(); }
        }

        public Value IsASwitchInst
        {
            get { return LLVM.IsASwitchInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAUnreachableInst
        {
            get { return LLVM.IsAUnreachableInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAResumeInst
        {
            get { return LLVM.IsAResumeInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAUnaryInstruction
        {
            get { return LLVM.IsAUnaryInstruction(this.Unwrap()).Wrap(); }
        }

        public Value IsAAllocaInst
        {
            get { return LLVM.IsAAllocaInst(this.Unwrap()).Wrap(); }
        }

        public Value IsACastInst
        {
            get { return LLVM.IsACastInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAAddrSpaceCastInst
        {
            get { return LLVM.IsAAddrSpaceCastInst(this.Unwrap()).Wrap(); }
        }

        public Value IsABitCastInst
        {
            get { return LLVM.IsABitCastInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAFPExtInst
        {
            get { return LLVM.IsAFPExtInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAFPToSIInst
        {
            get { return LLVM.IsAFPToSIInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAFPToUIInst
        {
            get { return LLVM.IsAFPToUIInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAFPTruncInst
        {
            get { return LLVM.IsAFPTruncInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAIntToPtrInst
        {
            get { return LLVM.IsAIntToPtrInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAPtrToIntInst
        {
            get { return LLVM.IsAPtrToIntInst(this.Unwrap()).Wrap(); }
        }

        public Value IsASExtInst
        {
            get { return LLVM.IsASExtInst(this.Unwrap()).Wrap(); }
        }

        public Value IsASIToFPInst
        {
            get { return LLVM.IsASIToFPInst(this.Unwrap()).Wrap(); }
        }

        public Value IsATruncInst
        {
            get { return LLVM.IsATruncInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAUIToFPInst
        {
            get { return LLVM.IsAUIToFPInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAZExtInst
        {
            get { return LLVM.IsAZExtInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAExtractValueInst
        {
            get { return LLVM.IsAExtractValueInst(this.Unwrap()).Wrap(); }
        }

        public Value IsALoadInst
        {
            get { return LLVM.IsALoadInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAVAArgInst
        {
            get { return LLVM.IsAVAArgInst(this.Unwrap()).Wrap(); }
        }

        public Value IsAMDNode
        {
            get { return LLVM.IsAMDNode(this.Unwrap()).Wrap(); }
        }

        public Value IsAMDString
        {
            get { return LLVM.IsAMDString(this.Unwrap()).Wrap(); }
        }

        public Use FirstUse
        {
            get { return LLVM.GetFirstUse(this.Unwrap()).Wrap(); }
        }

        public Value GetOperand(uint index)
        {
            return LLVM.GetOperand(this.Unwrap(), index).Wrap();
        }

        public Use GetOperandUse(uint index)
        {
            return LLVM.GetOperandUse(this.Unwrap(), index).Wrap();
        }

        public void SetOperand(uint index, Value val)
        {
            LLVM.SetOperand(this.Unwrap(), index, val.Unwrap());
        }

        public int GetNumOperands
        {
            get { return LLVM.GetNumOperands(this.Unwrap()); }
        }

        public bool IsNull
        {
            get { return LLVM.IsNull(this.Unwrap()); }
        }

        public ulong ConstIntGetZExtValue()
        {
            return LLVM.ConstIntGetZExtValue(this.Unwrap());
        }

        public long ConstIntGetSExtValue()
        {
            return LLVM.ConstIntGetSExtValue(this.Unwrap());
        }

        public double ConstRealGetDouble(out bool losesInfo)
        {
            LLVMBool li;
            var r = LLVM.ConstRealGetDouble(this.Unwrap(), out li);
            losesInfo = li;
            return r;
        }

        public bool IsConstantString
        {
            get { return LLVM.IsConstantString(this.Unwrap()); }
        }

        public string GetAsString(out int @out)
        {
            return LLVM.GetAsString(this.Unwrap(), out @out);
        }

        public Value GetElementAsConstant(uint idx)
        {
            return LLVM.GetElementAsConstant(this.Unwrap(), idx).Wrap();
        }

        public LLVMOpcode ConstOpcode
        {
            get { return LLVM.GetConstOpcode(this.Unwrap()); }
        }

        public Value ConstNeg()
        {
            return LLVM.ConstNeg(this.Unwrap()).Wrap();
        }

        public Value ConstNSWNeg()
        {
            return LLVM.ConstNSWNeg(this.Unwrap()).Wrap();
        }

        public Value ConstNUWNeg()
        {
            return LLVM.ConstNUWNeg(this.Unwrap()).Wrap();
        }

        public Value ConstFNeg()
        {
            return LLVM.ConstFNeg(this.Unwrap()).Wrap();
        }

        public Value ConstNot()
        {
            return LLVM.ConstNot(this.Unwrap()).Wrap();
        }

        public static Value ConstAdd(Value lhs, Value rhs)
        {
            return LLVM.ConstAdd(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNSWAdd(Value lhs, Value rhs)
        {
            return LLVM.ConstNSWAdd(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNUWAdd(Value lhs, Value rhs)
        {
            return LLVM.ConstNUWAdd(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFAdd(Value lhs, Value rhs)
        {
            return LLVM.ConstFAdd(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstSub(Value lhs, Value rhs)
        {
            return LLVM.ConstSub(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNSWSub(Value lhs, Value rhs)
        {
            return LLVM.ConstNSWSub(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNUWSub(Value lhs, Value rhs)
        {
            return LLVM.ConstNUWSub(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFSub(Value lhs, Value rhs)
        {
            return LLVM.ConstFSub(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstMul(Value lhs, Value rhs)
        {
            return LLVM.ConstMul(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNSWMul(Value lhs, Value rhs)
        {
            return LLVM.ConstNSWMul(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstNUWMul(Value lhs, Value rhs)
        {
            return LLVM.ConstNUWMul(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFMul(Value lhs, Value rhs)
        {
            return LLVM.ConstFMul(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstUDiv(Value lhs, Value rhs)
        {
            return LLVM.ConstUDiv(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstSDiv(Value lhs, Value rhs)
        {
            return LLVM.ConstSDiv(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstExactSDiv(Value lhs, Value rhs)
        {
            return LLVM.ConstExactSDiv(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFDiv(Value lhs, Value rhs)
        {
            return LLVM.ConstFDiv(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstURem(Value lhs, Value rhs)
        {
            return LLVM.ConstURem(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstSRem(Value lhs, Value rhs)
        {
            return LLVM.ConstSRem(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFRem(Value lhs, Value rhs)
        {
            return LLVM.ConstFRem(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstAnd(Value lhs, Value rhs)
        {
            return LLVM.ConstAnd(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstOr(Value lhs, Value rhs)
        {
            return LLVM.ConstOr(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstXor(Value lhs, Value rhs)
        {
            return LLVM.ConstXor(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstICmp(LLVMIntPredicate predicate, Value lhs, Value rhs)
        {
            return LLVM.ConstICmp(predicate, lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstFCmp(LLVMRealPredicate predicate, Value lhs, Value rhs)
        {
            return LLVM.ConstFCmp(predicate, lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstShl(Value lhs, Value rhs)
        {
            return LLVM.ConstShl(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstLShr(Value lhs, Value rhs)
        {
            return LLVM.ConstLShr(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstAShr(Value lhs, Value rhs)
        {
            return LLVM.ConstAShr(lhs.Unwrap(), rhs.Unwrap()).Wrap();
        }

        public static Value ConstGEP(Value constantVal, Value[] constantIndices)
        {
            return LLVM.ConstGEP(constantVal.Unwrap(), constantIndices.Unwrap()).Wrap();
        }

        public static Value ConstInBoundsGEP(Value constantVal, Value[] constantIndices)
        {
            return LLVM.ConstInBoundsGEP(constantVal.Unwrap(), constantIndices.Unwrap()).Wrap();
        }

        public static Value ConstTrunc(Value constantVal, Type toType)
        {
            return LLVM.ConstTrunc(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstSExt(Value constantVal, Type toType)
        {
            return LLVM.ConstSExt(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstZExt(Value constantVal, Type toType)
        {
            return LLVM.ConstZExt(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstFPTrunc(Value constantVal, Type toType)
        {
            return LLVM.ConstFPTrunc(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstFPExt(Value constantVal, Type toType)
        {
            return LLVM.ConstFPExt(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstUIToFP(Value constantVal, Type toType)
        {
            return LLVM.ConstUIToFP(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstSIToFP(Value constantVal, Type toType)
        {
            return LLVM.ConstSIToFP(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstFPToUI(Value constantVal, Type toType)
        {
            return LLVM.ConstFPToUI(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstFPToSI(Value constantVal, Type toType)
        {
            return LLVM.ConstFPToSI(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstPtrToInt(Value constantVal, Type toType)
        {
            return LLVM.ConstPtrToInt(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstIntToPtr(Value constantVal, Type toType)
        {
            return LLVM.ConstIntToPtr(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstBitCast(Value constantVal, Type toType)
        {
            return LLVM.ConstBitCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstAddrSpaceCast(Value constantVal, Type toType)
        {
            return LLVM.ConstAddrSpaceCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstZExtOrBitCast(Value constantVal, Type toType)
        {
            return LLVM.ConstZExtOrBitCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstSExtOrBitCast(Value constantVal, Type toType)
        {
            return LLVM.ConstSExtOrBitCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstTruncOrBitCast(Value constantVal, Type toType)
        {
            return LLVM.ConstTruncOrBitCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstPointerCast(Value constantVal, Type toType)
        {
            return LLVM.ConstPointerCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstIntCast(Value constantVal, Type toType, bool isSigned)
        {
            return LLVM.ConstIntCast(constantVal.Unwrap(), toType.Unwrap(), isSigned).Wrap();
        }

        public static Value ConstFPCast(Value constantVal, Type toType)
        {
            return LLVM.ConstFPCast(constantVal.Unwrap(), toType.Unwrap()).Wrap();
        }

        public static Value ConstSelect(Value constantCondition, Value constantIfTrue, Value constantIfFalse)
        {
            return
                LLVM.ConstSelect(constantCondition.Unwrap(), constantIfTrue.Unwrap(), constantIfFalse.Unwrap()).Wrap();
        }

        public static Value ConstExtractElement(Value vectorConstant, Value indexConstant)
        {
            return LLVM.ConstExtractElement(vectorConstant.Unwrap(), indexConstant.Unwrap()).Wrap();
        }

        public static Value ConstInsertElement(Value vectorConstant, Value elementValueConstant, Value indexConstant)
        {
            return
                LLVM.ConstInsertElement(vectorConstant.Unwrap(), elementValueConstant.Unwrap(), indexConstant.Unwrap())
                    .Wrap();
        }

        public static Value ConstShuffleVector(Value vectorAConstant, Value vectorBConstant, Value maskConstant)
        {
            return
                LLVM.ConstShuffleVector(vectorAConstant.Unwrap(), vectorBConstant.Unwrap(), maskConstant.Unwrap())
                    .Wrap();
        }

        public static Value ConstExtractValue(Value aggConstant, out uint idxList, uint numIdx)
        {
            return LLVM.ConstExtractValue(aggConstant.Unwrap(), out idxList, numIdx).Wrap();
        }

        public static Value ConstInsertValue(Value aggConstant, Value elementValueConstant, out uint idxList,
                                             uint numIdx)
        {
            return
                LLVM.ConstInsertValue(aggConstant.Unwrap(), elementValueConstant.Unwrap(), out idxList, numIdx).Wrap();
        }

        public static Value ConstInlineAsm(Type ty, string asmString, string constraints, bool hasSideEffects,
                                           bool isAlignStack)
        {
            return LLVM.ConstInlineAsm(ty.Unwrap(), asmString, constraints, hasSideEffects, isAlignStack).Wrap();
        }

        public Value BlockAddress(BasicBlock bb)
        {
            return LLVM.BlockAddress(this.Unwrap(), bb.Unwrap<LLVMBasicBlockRef>()).Wrap();
        }

        public Module GlobalParent
        {
            get { return LLVM.GetGlobalParent(this.Unwrap()).Wrap(); }
        }

        public bool IsDeclaration
        {
            get { return LLVM.IsDeclaration(this.Unwrap()); }
        }

        public LLVMLinkage Linkage
        {
            get { return LLVM.GetLinkage(this.Unwrap()); }
            set { LLVM.SetLinkage(this.Unwrap(), value); }
        }

        public string Section
        {
            get { return LLVM.GetSection(this.Unwrap()); }
            set { LLVM.SetSection(this.Unwrap(), value); }
        }

        public LLVMVisibility Visibility
        {
            get { return LLVM.GetVisibility(this.Unwrap()); }
            set { LLVM.SetVisibility(this.Unwrap(), value); }
        }

        public LLVMDLLStorageClass DLLStorageClass
        {
            get { return LLVM.GetDLLStorageClass(this.Unwrap()); }
            set { LLVM.SetDLLStorageClass(this.Unwrap(), value); }
        }

        public bool HasUnnamedAddr
        {
            get { return LLVM.HasUnnamedAddr(this.Unwrap()); }
            set { LLVM.SetUnnamedAddr(this.Unwrap(), value); }
        }

        public uint Alignment
        {
            get { return LLVM.GetAlignment(this.Unwrap()); }
            set { LLVM.SetAlignment(this.Unwrap(), value); }
        }

        public Value NextGlobal
        {
            get { return LLVM.GetNextGlobal(this.Unwrap()).Wrap(); }
        }

        public Value PreviousGlobal
        {
            get { return LLVM.GetPreviousGlobal(this.Unwrap()).Wrap(); }
        }

        public void DeleteGlobal()
        {
            LLVM.DeleteGlobal(this.Unwrap());
        }

        public Value Initializer
        {
            get { return LLVM.GetInitializer(this.Unwrap()).Wrap(); }
            set { LLVM.SetInitializer(this.Unwrap(), value.Unwrap()); }    
        }

        public bool IsThreadLocal
        {
            get { return LLVM.IsThreadLocal(this.Unwrap()); }
            set { LLVM.SetThreadLocal(this.Unwrap(), value); }
        }

        public bool IsGlobalConstant
        {
            get { return LLVM.IsGlobalConstant(this.Unwrap()); }
            set { LLVM.SetGlobalConstant(this.Unwrap(), value); }
        }

        public LLVMThreadLocalMode ThreadLocalMode
        {
            get { return LLVM.GetThreadLocalMode(this.Unwrap()); }
            set { LLVM.SetThreadLocalMode(this.Unwrap(), value); }
        }

        public bool IsExternallyInitialized
        {
            get { return LLVM.IsExternallyInitialized(this.Unwrap()); }
            set { LLVM.SetExternallyInitialized(this.Unwrap(), value); }
        }

        public void DeleteFunction()
        {
            LLVM.DeleteFunction(this.Unwrap());
        }

        public uint IntrinsicID
        {
            get { return LLVM.GetIntrinsicID(this.Unwrap()); }
        }

        public uint FunctionCallConv
        {
            get { return LLVM.GetFunctionCallConv(this.Unwrap()); }
            set { LLVM.SetFunctionCallConv(this.Unwrap(), value); }    
        }

        public string GC
        {
            get { return LLVM.GetGC(this.Unwrap()); }
            set { LLVM.SetGC(this.Unwrap(), value); }
        }

        public void AddFunctionAttr(Value fn, LLVMAttribute pa)
        {
            LLVM.AddFunctionAttr(this.Unwrap(), pa);
        }

        public void AddTargetDependentFunctionAttr(string a, string v)
        {
            LLVM.AddTargetDependentFunctionAttr(this.Unwrap(), a, v);
        }

        public LLVMAttribute GetFunctionAttr(Value fn)
        {
            return LLVM.GetFunctionAttr(this.Unwrap());
        }

        public void RemoveFunctionAttr(LLVMAttribute pa)
        {
            LLVM.RemoveFunctionAttr(this.Unwrap(), pa);
        }

        public Value[] Params
        {
            get { return LLVM.GetParams(this.Unwrap()).Wrap<LLVMValueRef, Value>(); }
        }

        public Value GetParam(uint index)
        {
            return LLVM.GetParam(this.Unwrap(), index).Wrap();
        }

        public Value ParamParent
        {
            get { return LLVM.GetParamParent(this.Unwrap()).Wrap(); }
        }

        public Value FirstParam
        {
            get { return LLVM.GetFirstParam(this.Unwrap()).Wrap(); }
        }

        public Value LastParam
        {
            get { return LLVM.GetLastParam(this.Unwrap()).Wrap(); }
        }

        public Value NextParam
        {
            get { return LLVM.GetNextParam(this.Unwrap()).Wrap(); }
        }

        public Value PreviousParam
        {
            get { return LLVM.GetPreviousParam(this.Unwrap()).Wrap(); }
        }

        public void AddAttribute(LLVMAttribute pa)
        {
            LLVM.AddAttribute(this.Unwrap(), pa);
        }

        public void RemoveAttribute(LLVMAttribute pa)
        {
            LLVM.RemoveAttribute(this.Unwrap(), pa);
        }

        public LLVMAttribute Attribute
        {
            get { return LLVM.GetAttribute(this.Unwrap()); }
        }

        public void SetParamAlignment(uint align)
        {
            LLVM.SetParamAlignment(this.Unwrap(), align);
        }

        public static Value MDString(string str, uint sLen)
        {
            return LLVM.MDString(str, sLen).Wrap();
        }

        public static Value MDNode(Value[] vals)
        {
            return LLVM.MDNode(vals.Unwrap()).Wrap();
        }

        public string MDString(out uint len)
        {
            return LLVM.GetMDString(this.Unwrap(), out len);
        }

        public Value[] MDNodeOperands
        {
            get { return LLVM.GetMDNodeOperands(this.Unwrap()).Wrap<LLVMValueRef, Value>(); }
        }

        public BasicBlock FirstBasicBlock
        {
            get { return LLVM.GetFirstBasicBlock(this.Unwrap()).Wrap(); }
        }

        public BasicBlock LastBasicBlock
        {
            get { return LLVM.GetLastBasicBlock(this.Unwrap()).Wrap(); }
        }

        public BasicBlock EntryBasicBlock
        {
            get { return LLVM.GetEntryBasicBlock(this.Unwrap()).Wrap(); }
        }

        public BasicBlock InstructionParent
        {
            get { return LLVM.GetInstructionParent(this.Unwrap()).Wrap(); }
        }

        public Value NextInstruction
        {
            get { return LLVM.GetNextInstruction(this.Unwrap()).Wrap(); }
        }

        public Value PreviousInstruction
        {
            get { return LLVM.GetPreviousInstruction(this.Unwrap()).Wrap(); }
        }

        public LLVMOpcode InstructionOpcode
        {
            get { return LLVM.GetInstructionOpcode(this.Unwrap()); }
        }

        public LLVMIntPredicate ICmpPredicate
        {
            get { return LLVM.GetICmpPredicate(this.Unwrap()); }
        }

        public LLVMRealPredicate FCmpPredicate
        {
            get { return LLVM.GetFCmpPredicate(this.Unwrap()); }
        }

        public bool IsTailCall
        {
            get { return LLVM.IsTailCall(this.Unwrap()); }
            set { LLVM.SetTailCall(this.Unwrap(), value); }
        }

        public uint GetNumSuccessors
        {
            get { return LLVM.GetNumSuccessors(this.Unwrap()); }
        }

        public BasicBlock SwitchDefaultDest
        {
            get { return LLVM.GetSwitchDefaultDest(this.Unwrap()).Wrap(); }
        }

        public void AddIncoming(Value phiNode, Value[] incomingValues, BasicBlock[] incomingBlocks)
        {
            LLVM.AddIncoming(phiNode.Unwrap(), incomingBlocks.Unwrap<LLVMValueRef>(),
                             incomingBlocks.Unwrap<LLVMBasicBlockRef>());
        }
        
        public void AddCase(Value onVal, BasicBlock dest)
        {
            LLVM.AddCase(this.Unwrap(), onVal.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>());
        }

        public void AddDestination(BasicBlock dest)
        {
            LLVM.AddDestination(this.Unwrap(), dest.Unwrap<LLVMBasicBlockRef>());
        }

        public void AddClause(Value clauseVal)
        {
            LLVM.AddClause(this.Unwrap(), clauseVal.Unwrap());
        }

        public void SetCleanup(bool val)
        {
            LLVM.SetCleanup(this.Unwrap(), val);
        }
    }
}