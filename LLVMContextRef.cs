namespace LLVMSharp
{
    using System;

    partial struct LLVMContextRef : IEquatable<LLVMContextRef>, IHandle<Context>
    {
        public IntPtr GetInternalPointer() => Pointer;

        Context IHandle<Context>.ToWrapperType()
        {
            return new Context(this);
        }

        public void ContextDispose()
        {
            LLVM.ContextDispose(this);
        }

        public uint GetMDKindIDInContext(string name, uint sLen)
        {
            return LLVM.GetMDKindIDInContext(this, name, sLen);
        }

        public LLVMTypeRef Int1TypeInContext()
        {
            return LLVM.Int1TypeInContext(this);
        }

        public LLVMTypeRef Int8TypeInContext()
        {
            return LLVM.Int8TypeInContext(this);
        }

        public LLVMTypeRef Int16TypeInContext()
        {
            return LLVM.Int16TypeInContext(this);
        }

        public LLVMTypeRef Int32TypeInContext()
        {
            return LLVM.Int32TypeInContext(this);
        }

        public LLVMTypeRef Int64TypeInContext()
        {
            return LLVM.Int64TypeInContext(this);
        }

        public LLVMTypeRef IntTypeInContext(uint numBits)
        {
            return LLVM.IntTypeInContext(this, numBits);
        }

        public LLVMTypeRef HalfTypeInContext()
        {
            return LLVM.HalfTypeInContext(this);
        }

        public LLVMTypeRef FloatTypeInContext()
        {
            return LLVM.FloatTypeInContext(this);
        }

        public LLVMTypeRef DoubleTypeInContext()
        {
            return LLVM.DoubleTypeInContext(this);
        }

        public LLVMTypeRef X86FP80TypeInContext()
        {
            return LLVM.X86FP80TypeInContext(this);
        }

        public LLVMTypeRef FP128TypeInContext()
        {
            return LLVM.FP128TypeInContext(this);
        }

        public LLVMTypeRef PPCFP128TypeInContext()
        {
            return LLVM.PPCFP128TypeInContext(this);
        }

        public LLVMTypeRef StructTypeInContext(LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            return LLVM.StructTypeInContext(this, elementTypes, packed);
        }

        public LLVMTypeRef StructCreateNamed(string name)
        {
            return LLVM.StructCreateNamed(this, name);
        }

        public LLVMTypeRef VoidTypeInContext()
        {
            return LLVM.VoidTypeInContext(this);
        }

        public LLVMTypeRef LabelTypeInContext()
        {
            return LLVM.LabelTypeInContext(this);
        }

        public LLVMTypeRef X86MMXTypeInContext()
        {
            return LLVM.X86MMXTypeInContext(this);
        }

        public LLVMValueRef ConstStringInContext(string str, uint length, LLVMBool dontNullTerminate)
        {
            return LLVM.ConstStringInContext(this, str, length, dontNullTerminate);
        }

        public LLVMValueRef ConstStructInContext(LLVMValueRef[] constantVals, LLVMBool packed)
        {
            return LLVM.ConstStructInContext(this, constantVals, packed);
        }

        public LLVMValueRef MDStringInContext(string str, uint sLen)
        {
            return LLVM.MDStringInContext(this, str, sLen);
        }

        public LLVMValueRef MDNodeInContext(LLVMValueRef[] vals)
        {
            return LLVM.MDNodeInContext(this, vals);
        }

        public LLVMBasicBlockRef AppendBasicBlockInContext(LLVMValueRef fn, string name)
        {
            return LLVM.AppendBasicBlockInContext(this, fn, name);
        }

        public LLVMBasicBlockRef InsertBasicBlockInContext(LLVMBasicBlockRef bb, string name)
        {
            return LLVM.InsertBasicBlockInContext(this, bb, name);
        }

        public LLVMBuilderRef CreateBuilderInContext()
        {
            return LLVM.CreateBuilderInContext(this);
        }

        public LLVMBool ParseBitcodeInContext(LLVMMemoryBufferRef memBuf, out LLVMModuleRef outModule, out IntPtr outMessage)
        {
            return LLVM.ParseBitcodeInContext(this, memBuf, out outModule, out outMessage);
        }

        public LLVMBool GetBitcodeModuleInContext(LLVMMemoryBufferRef memBuf, out LLVMModuleRef outM, out IntPtr outMessage)
        {
            return LLVM.GetBitcodeModuleInContext(this, memBuf, out outM, out outMessage);
        }

        public LLVMBool GetBitcodeModuleProviderInContext(LLVMMemoryBufferRef memBuf, out LLVMModuleProviderRef outMp, out IntPtr outMessage)
        {
            return LLVM.GetBitcodeModuleProviderInContext(this, memBuf, out outMp, out outMessage);
        }

        public LLVMTypeRef IntPtrTypeInContext(LLVMTargetDataRef td)
        {
            return LLVM.IntPtrTypeInContext(this, td);
        }

        public LLVMTypeRef IntPtrTypeForASInContext(LLVMTargetDataRef td, uint @AS)
        {
            return LLVM.IntPtrTypeForASInContext(this, td, @AS);
        }

        public LLVMBool ParseIRInContext(LLVMMemoryBufferRef memBuf, out LLVMModuleRef outM, out IntPtr outMessage)
        {
            return LLVM.ParseIRInContext(this, memBuf, out outM, out outMessage);
        }

        public bool Equals(LLVMContextRef other)
        {
            return this.Pointer == other.Pointer;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is LLVMContextRef) 
            {
                return this.Equals((LLVMContextRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMContextRef op1, LLVMContextRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMContextRef op1, LLVMContextRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }

    }
}