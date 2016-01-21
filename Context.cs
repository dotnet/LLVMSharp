namespace LLVMSharp
{
    using System;

    public sealed class Context : IEquatable<Context>, IDisposable, IWrapper<LLVMContextRef>
    {
        public static Context Global
        {
            get { return LLVM.GetGlobalContext().Wrap(); }
        }

        public Type Int1Type
        {
            get { return LLVM.Int1TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type Int8Type
        {
            get { return LLVM.Int8TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type Int16Type
        {
            get { return LLVM.Int16TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type Int32Type
        {
            get { return LLVM.Int32TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type Int64Type
        {
            get { return LLVM.Int64TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type IntType(int bitLength)
        {
            return LLVM.IntType((uint) bitLength).Wrap();
        }

        public Type HalfType
        {
            get { return LLVM.HalfTypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type FloatType
        {
            get { return LLVM.FloatTypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type DoubleType
        {
            get { return LLVM.DoubleTypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type X86FP80Type
        {
            get { return LLVM.X86FP80TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type FP128Type
        {
            get { return LLVM.FP128TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type PPCFP128Type
        {
            get { return LLVM.PPCFP128TypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type VoidType
        {
            get { return LLVM.VoidTypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type LabelType
        {
            get { return LLVM.LabelTypeInContext(this.Unwrap()).Wrap(); }
        }

        public Type X86MMXType
        {
            get { return LLVM.X86MMXTypeInContext(this.Unwrap()).Wrap(); }
        }

        public static Context Create()
        {
            return LLVM.ContextCreate().Wrap().MakeHandleOwner<Context, LLVMContextRef>();
        }

        LLVMContextRef IWrapper<LLVMContextRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMContextRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMContextRef _instance;
        private bool _disposed;
        private bool _owner;

        internal Context(LLVMContextRef contextRef)
        {
            this._instance = contextRef;
        }

        ~Context()
        {
            this.Dispose(false);
        }
        
        public uint GetMDKindID(string name)
        {
            return LLVM.GetMDKindIDInContext(this.Unwrap(), name, (uint) name.Length);
        }

        public void SetDiagnosticHandler(LLVMDiagnosticHandler diagHandler, IntPtr diagContext)
        {
            LLVM.ContextSetDiagnosticHandler(this.Unwrap(), diagHandler, diagContext);
        }

        public void SetDiagnosticHandler(LLVMDiagnosticHandler diagHandler)
        {
            this.SetDiagnosticHandler(diagHandler, IntPtr.Zero);
        }

        public void SetYieldCallBack(LLVMYieldCallback callback, IntPtr opaqueHande)
        {
            LLVM.ContextSetYieldCallback(this.Unwrap(), callback, opaqueHande);
        }
        
        public bool Equals(Context other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this._instance == other._instance;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Context);
        }

        public static bool operator ==(Context op1, Context op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(Context op1, Context op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.ContextDispose(this.Unwrap());
            }

            this._disposed = true;
        }

        public Type StructType(Type[] elementTypes, bool packed)
        {
            return LLVM.StructTypeInContext(this.Unwrap(), elementTypes.Unwrap(), packed).Wrap();
        }

        public Value ConstStringInContext(string str, uint length, bool dontNullTerminate)
        {
            return LLVM.ConstStringInContext(this.Unwrap(), str, length, dontNullTerminate).Wrap();
        }

        public Value ConstStructInContext(Value[] constantVals, bool packed)
        {
            return LLVM.ConstStructInContext(this.Unwrap(), constantVals.Unwrap(), packed).Wrap();
        }

        public Value MDStringInContext(string str, uint sLen)
        {
            return LLVM.MDStringInContext(this.Unwrap(), str, sLen).Wrap();
        }

        public Value MDNodeInContext(Value[] vals)
        {
            return LLVM.MDNodeInContext(this.Unwrap(), vals.Unwrap()).Wrap();
        }

        public BasicBlock AppendBasicBlockInContext(Value fn, string name)
        {
            return LLVM.AppendBasicBlockInContext(this.Unwrap(), fn.Unwrap(), name).Wrap();
        }

        public BasicBlock InsertBasicBlockInContext(BasicBlock bb, string name)
        {
            return LLVM.InsertBasicBlockInContext(this.Unwrap(), bb.Unwrap<LLVMBasicBlockRef>(), name).Wrap();
        }

        public IRBuilder CreateBuilderInContext
        {
            get { return LLVM.CreateBuilderInContext(this.Unwrap()).Wrap(); }
        }

        public Module ParseBitcodeInContext(MemoryBuffer memBuf)
        {
            LLVMModuleRef m;
            IntPtr error;
            if (LLVM.ParseBitcodeInContext(this.Unwrap(), memBuf.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Module GetBitcodeModuleInContext(MemoryBuffer memBuf)
        {
            LLVMModuleRef m;
            IntPtr error;
            if (LLVM.GetBitcodeModuleInContext(this.Unwrap(), memBuf.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public ModuleProvider GetBitcodeModuleProviderInContext(MemoryBuffer memBuf)
        {
            LLVMModuleProviderRef m;
            IntPtr error;
            if (LLVM.GetBitcodeModuleProviderInContext(this.Unwrap(), memBuf.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Type IntPtrTypeInContext(TargetData td)
        {
            return LLVM.IntPtrTypeInContext(this.Unwrap(), td.Unwrap()).Wrap();
        }

        public Type IntPtrTypeForASInContext(TargetData td, uint @as)
        {
            return LLVM.IntPtrTypeForASInContext(this.Unwrap(), td.Unwrap(), @as).Wrap();
        }

        public Module ParseIR(MemoryBuffer memBuf)
        {
            LLVMModuleRef outM;
            IntPtr error;
            if (LLVM.ParseIRInContext(this.Unwrap(), memBuf.Unwrap(), out outM, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return outM.Wrap();
        }
    }
}