namespace KaleidoscopeLLVM
{
    using System;
    using System.Collections.Generic;
    using Kaleidoscope.AST;
    using LLVMSharp;

    internal sealed class CodeGenVisitor : ExprVisitor
    {
        private static readonly LLVMBool LLVMBoolFalse = new LLVMBool(0);

        private static readonly LLVMValueRef NullValue = new LLVMValueRef(IntPtr.Zero);

        private readonly LLVMModuleRef module;

        private readonly LLVMBuilderRef builder;

        private readonly Dictionary<string, LLVMValueRef> namedValues = new Dictionary<string, LLVMValueRef>();

        private readonly Stack<LLVMValueRef> valueStack = new Stack<LLVMValueRef>();

        public CodeGenVisitor(LLVMModuleRef module, LLVMBuilderRef builder)
        {
            this.module = module;
            this.builder = builder;
        }

        public Stack<LLVMValueRef> ResultStack => valueStack;

        public void ClearResultStack()
        {
            this.valueStack.Clear();
        }

        protected override ExprAST VisitNumberExprAST(NumberExprAST node)
        {
            this.valueStack.Push(LLVM.ConstReal(LLVM.DoubleType(), node.Value));
            return node;
        }

        protected override ExprAST VisitVariableExprAST(VariableExprAST node)
        {
            // Look this variable up in the function.
            if (this.namedValues.TryGetValue(node.Name, out var value))
            {
                this.valueStack.Push(value);
            }
            else
            {
                throw new Exception($"Unknown variable name {node.Name}");
            }

            return node;
        }

        protected override ExprAST VisitBinaryExprAST(BinaryExprAST node)
        {
            this.Visit(node.Lhs);
            this.Visit(node.Rhs);

            LLVMValueRef r = this.valueStack.Pop();
            LLVMValueRef l = this.valueStack.Pop();

            LLVMValueRef n;

            switch (node.NodeType)
            {
                case ExprType.AddExpr:
                    n = LLVM.BuildFAdd(this.builder, l, r, "addtmp");
                    break;
                case ExprType.SubtractExpr:
                    n = LLVM.BuildFSub(this.builder, l, r, "subtmp");
                    break;
                case ExprType.MultiplyExpr:
                    n = LLVM.BuildFMul(this.builder, l, r, "multmp");
                    break;
                case ExprType.LessThanExpr:
                    // Convert bool 0/1 to double 0.0 or 1.0
                    n = LLVM.BuildUIToFP(this.builder,
                        LLVM.BuildFCmp(this.builder, LLVMRealPredicate.LLVMRealULT, l, r, "cmptmp"), LLVM.DoubleType(),
                        "booltmp");
                    break;
                default:
                    throw new Exception("invalid binary operator");
            }

            this.valueStack.Push(n);
            return node;
        }

        protected override ExprAST VisitCallExprAST(CallExprAST node)
        {
            var calleeF = LLVM.GetNamedFunction(this.module, node.Callee);
            if (calleeF.Pointer == IntPtr.Zero)
            {
                throw new Exception($"Unknown function referenced {node.Callee}");
            }

            if (LLVM.CountParams(calleeF) != node.Arguments.Count)
            {
                throw new Exception("Incorrect # arguments passed");
            }

            var argumentCount = (uint) node.Arguments.Count;
            var argsV = new LLVMValueRef[Math.Max(argumentCount, 1)];
            for (int i = 0; i < argumentCount; ++i)
            {
                this.Visit(node.Arguments[i]);
                argsV[i] = this.valueStack.Pop();
            }

            this.valueStack.Push(LLVM.BuildCall(this.builder, calleeF, argsV, "calltmp"));

            return node;
        }

        protected override ExprAST VisitPrototypeAST(PrototypeAST node)
        {
            // Make the function type:  double(double,double) etc.
            var argumentCount = (uint) node.Arguments.Count;
            var arguments = new LLVMTypeRef[Math.Max(argumentCount, 0)];

            var function = LLVM.GetNamedFunction(this.module, node.Name);

            // If F conflicted, there was already something named 'Name'.  If it has a
            // body, don't allow redefinition or reextern.
            if (function.Pointer != IntPtr.Zero)
            {
                // If F already has a body, reject this.
                if (LLVM.CountBasicBlocks(function) != 0)
                {
                    throw new Exception("redefinition of function.");
                }

                // If F took a different number of args, reject.
                if (LLVM.CountParams(function) != argumentCount)
                {
                    throw new Exception("redefinition of function with different # args");
                }
            }
            else
            {
                for (int i = 0; i < argumentCount; ++i)
                {
                    arguments[i] = LLVM.DoubleType();
                }

                function = LLVM.AddFunction(this.module, node.Name,
                    LLVM.FunctionType(LLVM.DoubleType(), arguments, LLVMBoolFalse));
                LLVM.SetLinkage(function, LLVMLinkage.LLVMExternalLinkage);
            }

            for (int i = 0; i < argumentCount; ++i)
            {
                var argumentName = node.Arguments[i];

                LLVMValueRef param = LLVM.GetParam(function, (uint) i);
                LLVM.SetValueName(param, argumentName);

                this.namedValues[argumentName] = param;
            }

            this.valueStack.Push(function);
            return node;
        }

        protected override ExprAST VisitFunctionAST(FunctionAST node)
        {
            namedValues.Clear();

            Visit(node.Proto);

            LLVMValueRef function = valueStack.Pop();

            // Create a new basic block to start insertion into.
            LLVM.PositionBuilderAtEnd(builder, LLVM.AppendBasicBlock(function, "entry"));

            try
            {
                Visit(node.Body);
            }
            catch (Exception)
            {
                LLVM.DeleteFunction(function);
                throw;
            }

            // Finish off the function.
            LLVM.BuildRet(builder, valueStack.Pop());

            // Validate the generated code, checking for consistency.
            LLVM.VerifyFunction(function, LLVMVerifierFailureAction.LLVMPrintMessageAction);

            valueStack.Push(function);

            return node;
        }
    }
}