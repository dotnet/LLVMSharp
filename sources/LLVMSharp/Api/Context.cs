namespace LLVMSharp.API
{
    using LLVMSharp.API.Types;
    using LLVMSharp.API.Types.Composite;
    using System;
    using Utilities;
    using Values;

    public sealed class Context : IEquatable<Context>, IDisposable, IDisposableWrapper<LLVMContextRef>
    {
        LLVMContextRef IWrapper<LLVMContextRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMContextRef>.MakeHandleOwner() => this._owner = true;

        public static Context Create() => LLVM.ContextCreate().Wrap().MakeHandleOwner<Context, LLVMContextRef>();
        public static Context Global => LLVM.GetGlobalContext().Wrap();

        public IntegerType Int1Type => LLVM.Int1TypeInContext(this.Unwrap()).WrapAs<IntegerType>();
        public IntegerType Int8Type => LLVM.Int8TypeInContext(this.Unwrap()).WrapAs<IntegerType>();
        public IntegerType Int16Type => LLVM.Int16TypeInContext(this.Unwrap()).WrapAs<IntegerType>();
        public IntegerType Int32Type => LLVM.Int32TypeInContext(this.Unwrap()).WrapAs<IntegerType>();
        public IntegerType Int64Type => LLVM.Int64TypeInContext(this.Unwrap()).WrapAs<IntegerType>();
        public IntegerType IntType(uint bitLength) => LLVM.IntType(bitLength).WrapAs<IntegerType>();
        public X86MMXType X86MMXType => LLVM.X86MMXTypeInContext(this.Unwrap()).WrapAs<X86MMXType>();
        public HalfType HalfType => LLVM.HalfTypeInContext(this.Unwrap()).WrapAs<HalfType>();
        public FloatType FloatType => LLVM.FloatTypeInContext(this.Unwrap()).WrapAs<FloatType>();
        public DoubleType DoubleType => LLVM.DoubleTypeInContext(this.Unwrap()).WrapAs<DoubleType>();
        public X86FP80Type X86FP80Type => LLVM.X86FP80TypeInContext(this.Unwrap()).WrapAs<X86FP80Type>();
        public FP128Type FP128Type => LLVM.FP128TypeInContext(this.Unwrap()).WrapAs<FP128Type>();
        public PPCFP128Type PPCFP128Type => LLVM.PPCFP128TypeInContext(this.Unwrap()).WrapAs<PPCFP128Type>();
        public VoidType VoidType => LLVM.VoidTypeInContext(this.Unwrap()).WrapAs<VoidType>();
        public LabelType LabelType => LLVM.LabelTypeInContext(this.Unwrap()).WrapAs<LabelType>();
        
        private readonly LLVMContextRef _instance;
        private bool _disposed;
        private bool _owner;
        private LLVMDiagnosticHandler _diagnosticHandler;
        private LLVMYieldCallback _yieldCallback;

        internal Context(LLVMContextRef contextRef)
        {
            this._instance = contextRef;
        }

        ~Context()
        {
            this.Dispose(false);
        }

        public uint GetMDKindID(string name) => LLVM.GetMDKindIDInContext(this.Unwrap(), name, (uint)name.Length);

        public void SetDiagnosticHandler(Action<DiagnosticInfo, IntPtr> diagnosticHandler, IntPtr diagContext)
        {
            this._diagnosticHandler = new LLVMDiagnosticHandler((a, b) => diagnosticHandler(a.Wrap(), b));
            LLVM.ContextSetDiagnosticHandler(this.Unwrap(), this._diagnosticHandler, diagContext);
        }

        public void SetDiagnosticHandler(Action<DiagnosticInfo, IntPtr> diagnosticHandler)
        {
            this.SetDiagnosticHandler(diagnosticHandler, IntPtr.Zero);
        }

        public void SetYieldCallBack(Action<Context, IntPtr> callback, IntPtr opaqueHande)
        {
            this._yieldCallback = new LLVMYieldCallback((a, b) => callback(a.Wrap(), b));
            LLVM.ContextSetYieldCallback(this.Unwrap(), this._yieldCallback, opaqueHande);
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

        public StructType StructType(Type[] elementTypes, bool packed) => LLVM.StructTypeInContext(this.Unwrap(), elementTypes.Unwrap(), packed).WrapAs<StructType>();

        public Value MDNodeInContext(Value[] vals) => LLVM.MDNodeInContext(this.Unwrap(), vals.Unwrap()).Wrap();

        public BasicBlock AppendBasicBlock(Value fn, string name) => LLVM.AppendBasicBlockInContext(this.Unwrap(), fn.Unwrap(), name).Wrap();
        public BasicBlock InsertBasicBlockInContext(BasicBlock bb, string name) => LLVM.InsertBasicBlockInContext(this.Unwrap(), bb.Unwrap<LLVMBasicBlockRef>(), name).Wrap();

        public Module ParseBitcodeInContext(MemoryBuffer memBuf)
        {
            if (LLVM.ParseBitcodeInContext(this.Unwrap(), memBuf.Unwrap(), out LLVMModuleRef m, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Module GetBitcodeModuleInContext(MemoryBuffer memBuf)
        {
            if (LLVM.GetBitcodeModuleInContext(this.Unwrap(), memBuf.Unwrap(), out LLVMModuleRef m, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Type GetIntPtrType(TargetData targetData) => LLVM.IntPtrTypeInContext(this.Unwrap(), targetData.Unwrap()).Wrap();
        public Type GetIntPtrType(TargetData targetData, uint addressSpace) => LLVM.IntPtrTypeForASInContext(this.Unwrap(), targetData.Unwrap(), addressSpace).Wrap();

        public Module ParseIR(MemoryBuffer memBuf)
        {
            if (LLVM.ParseIRInContext(this.Unwrap(), memBuf.Unwrap(), out LLVMModuleRef outM, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return outM.Wrap();
        }

        public override int GetHashCode() => this._instance.GetHashCode();
        public override bool Equals(object obj) => this.Equals(obj as Context);
        public bool Equals(Context other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public static bool operator ==(Context op1, Context op2) => ReferenceEquals(op1, null) ? ReferenceEquals(op2, null) : op1.Equals(op2);
        public static bool operator !=(Context op1, Context op2) => !(op1 == op2);
    }
}