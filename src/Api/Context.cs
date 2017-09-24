namespace LLVMSharp.Api
{
    using System;
    using Utilities;
    using Values;

    public sealed class Context : IEquatable<Context>, IDisposable, IDisposableWrapper<LLVMContextRef>
    {
        public static Context Create() => LLVM.ContextCreate().Wrap().MakeHandleOwner<Context, LLVMContextRef>();
        public static Context Global => LLVM.GetGlobalContext().Wrap();

        public Type Int1Type => LLVM.Int1TypeInContext(this.Unwrap()).Wrap();
        public Type Int8Type => LLVM.Int8TypeInContext(this.Unwrap()).Wrap();
        public Type Int16Type => LLVM.Int16TypeInContext(this.Unwrap()).Wrap();
        public Type Int32Type => LLVM.Int32TypeInContext(this.Unwrap()).Wrap();
        public Type Int64Type => LLVM.Int64TypeInContext(this.Unwrap()).Wrap();
        public Type IntType(int bitLength) => LLVM.IntType((uint) bitLength).Wrap();
        public Type HalfType => LLVM.HalfTypeInContext(this.Unwrap()).Wrap();
        public Type FloatType => LLVM.FloatTypeInContext(this.Unwrap()).Wrap();
        public Type DoubleType => LLVM.DoubleTypeInContext(this.Unwrap()).Wrap();
        public Type X86FP80Type => LLVM.X86FP80TypeInContext(this.Unwrap()).Wrap();
        public Type FP128Type => LLVM.FP128TypeInContext(this.Unwrap()).Wrap();
        public Type PPCFP128Type => LLVM.PPCFP128TypeInContext(this.Unwrap()).Wrap();
        public Type VoidType => LLVM.VoidTypeInContext(this.Unwrap()).Wrap();
        public Type LabelType => LLVM.LabelTypeInContext(this.Unwrap()).Wrap();
        public Type X86MMXType => LLVM.X86MMXTypeInContext(this.Unwrap()).Wrap();

        LLVMContextRef IWrapper<LLVMContextRef>.ToHandleType() => this._instance;

        void IDisposableWrapper<LLVMContextRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMContextRef _instance;
        private bool _disposed;
        private bool _owner;
        private LLVMDiagnosticHandler _diagonHandler;

        internal Context(LLVMContextRef contextRef)
        {
            this._instance = contextRef;
        }

        ~Context()
        {
            this.Dispose(false);
        }
        
        public uint GetMDKindID(string name) => LLVM.GetMDKindIDInContext(this.Unwrap(), name, (uint) name.Length);

        public void SetDiagnosticHandler(LLVMDiagnosticHandler diagHandler, IntPtr diagContext)
        {
            this._diagonHandler = diagHandler;
            LLVM.ContextSetDiagnosticHandler(this.Unwrap(), this._diagonHandler, diagContext);
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
            return this._instance == other._instance;
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
            return op1.Equals(op2);
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
            => LLVM.StructTypeInContext(this.Unwrap(), out elementTypes.Unwrap()[0], (uint)elementTypes.Length, packed).Wrap();

        public Value ConstStringInContext(string str, uint length, bool dontNullTerminate)
            => LLVM.ConstStringInContext(this.Unwrap(), str, length, dontNullTerminate).Wrap();

        public Value ConstStructInContext(Value[] constantVals, bool packed)
            => LLVM.ConstStructInContext(this.Unwrap(), out constantVals.Unwrap()[0], (uint)constantVals.Length, packed).Wrap();

        public Value MDStringInContext(string str, uint sLen)
            => LLVM.MDStringInContext(this.Unwrap(), str, sLen).Wrap();

        public Value MDNodeInContext(Value[] vals) => LLVM.MDNodeInContext(this.Unwrap(), out vals.Unwrap()[0], (uint)vals.Length).Wrap();

        public BasicBlock AppendBasicBlockInContext(Value fn, string name)
            => LLVM.AppendBasicBlockInContext(this.Unwrap(), fn.Unwrap(), name).Wrap();

        public BasicBlock InsertBasicBlockInContext(BasicBlock bb, string name)
            => LLVM.InsertBasicBlockInContext(this.Unwrap(), bb.Unwrap<LLVMBasicBlockRef>(), name).Wrap();

        public IRBuilder CreateBuilderInContext => LLVM.CreateBuilderInContext(this.Unwrap()).Wrap();

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
        
        public Type IntPtrTypeInContext(TargetData td)
            => LLVM.IntPtrTypeInContext(this.Unwrap(), td.Unwrap()).Wrap();

        public Type IntPtrTypeForASInContext(TargetData td, uint @as)
            => LLVM.IntPtrTypeForASInContext(this.Unwrap(), td.Unwrap(), @as).Wrap();

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