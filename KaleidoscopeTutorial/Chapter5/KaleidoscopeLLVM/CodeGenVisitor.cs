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

        public Stack<LLVMValueRef> ResultStack { get { return valueStack; } }

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
            LLVMValueRef value;

            // Look this variable up in the function.
            if (this.namedValues.TryGetValue(node.Name, out value))
            {
                this.valueStack.Push(value);
            }
            else
            {
                throw new Exception("Unknown variable name");
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
                    n = LLVM.BuildUIToFP(this.builder, LLVM.BuildFCmp(this.builder, LLVMRealPredicate.LLVMRealULT, l, r, "cmptmp"), LLVM.DoubleType(), "booltmp");
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
                throw new Exception("Unknown function referenced");
            }

            if (LLVM.CountParams(calleeF) != node.Arguments.Count)
            {
                throw new Exception("Incorrect # arguments passed");
            }

            var argumentCount = (uint)node.Arguments.Count;
            var argsV = new LLVMValueRef[Math.Max(argumentCount, 1)];
            for (int i = 0; i < argumentCount; ++i)
            {
                this.Visit(node.Arguments[i]);
                argsV[i] = this.valueStack.Pop();
            }

            valueStack.Push(LLVM.BuildCall(this.builder, calleeF, argsV, "calltmp"));

            return node;
        }

        protected override ExprAST VisitPrototypeAST(PrototypeAST node)
        {
            // Make the function type:  double(double,double) etc.
            var argumentCount = (uint)node.Arguments.Count;
            var arguments = new LLVMTypeRef[Math.Max(argumentCount, 1)];

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

                function = LLVM.AddFunction(this.module, node.Name, LLVM.FunctionType(LLVM.DoubleType(), arguments, LLVMBoolFalse));
                LLVM.SetLinkage(function, LLVMLinkage.LLVMExternalLinkage);
            }

            for (int i = 0; i < argumentCount; ++i)
            {
                string argumentName = node.Arguments[i];

                LLVMValueRef param = LLVM.GetParam(function, (uint)i);
                LLVM.SetValueName(param, argumentName);

                this.namedValues[argumentName] = param;
            }

            this.valueStack.Push(function);
            return node;
        }

        protected override ExprAST VisitFunctionAST(FunctionAST node)
        {
            this.namedValues.Clear();

            this.Visit(node.Proto);

            LLVMValueRef function = this.valueStack.Pop();

            // Create a new basic block to start insertion into.
            LLVM.PositionBuilderAtEnd(this.builder, LLVM.AppendBasicBlock(function, "entry"));

            try
            {
                this.Visit(node.Body);
            }
            catch (Exception)
            {
                LLVM.DeleteFunction(function);
                throw;
            }

            // Finish off the function.
            LLVM.BuildRet(this.builder, this.valueStack.Pop());

            // Validate the generated code, checking for consistency.
            LLVM.VerifyFunction(function, LLVMVerifierFailureAction.LLVMPrintMessageAction);

            this.valueStack.Push(function);

            return node;
        }

        protected override ExprAST VisitIfExprAST(IfExpAST node)
        {
            this.Visit(node.Condition);
            var condv = LLVM.BuildFCmp(this.builder, LLVMRealPredicate.LLVMRealONE, this.valueStack.Pop(), LLVM.ConstReal(LLVM.DoubleType(), 0.0), "ifcond");

            LLVMValueRef func = LLVM.GetBasicBlockParent(LLVM.GetInsertBlock(builder));

            // Create blocks for the then and else cases.  Insert the 'then' block at the
            // end of the function.
            LLVMBasicBlockRef thenBB = LLVM.AppendBasicBlock(func, "then");
            LLVMBasicBlockRef elseBB = LLVM.AppendBasicBlock(func, "else");
            LLVMBasicBlockRef mergeBB = LLVM.AppendBasicBlock(func, "ifcont");

            LLVM.BuildCondBr(this.builder, condv, thenBB, elseBB);

            // Emit then value.
            LLVM.PositionBuilderAtEnd(this.builder, thenBB);

            this.Visit(node.Then);
            var thenV = this.valueStack.Pop();

            LLVM.BuildBr(this.builder, mergeBB);

            // Codegen of 'Then' can change the current block, update ThenBB for the PHI.
            thenBB = LLVM.GetInsertBlock(this.builder);

              // Emit else block.

            LLVM.PositionBuilderAtEnd(this.builder, elseBB);

            this.Visit(node.Else);
            var elseV = this.valueStack.Pop();

            LLVM.BuildBr(this.builder, mergeBB);

            // Codegen of 'Else' can change the current block, update ElseBB for the PHI.
            elseBB = LLVM.GetInsertBlock(this.builder);

            // Emit merge block.
            LLVM.PositionBuilderAtEnd(this.builder, mergeBB);
            var phi = LLVM.BuildPhi(this.builder, LLVM.DoubleType(), "iftmp");

            LLVM.AddIncoming(phi, new []{thenV}, new []{thenBB}, 1);
            LLVM.AddIncoming(phi, new []{elseV}, new []{elseBB}, 1);

            this.valueStack.Push(phi);

            return node;
        }

        protected override ExprAST VisitForExprAST(ForExprAST node)
        {
            // Output this as:
            //   ...
            //   start = startexpr
            //   goto loop
            // loop:
            //   variable = phi [start, loopheader], [nextvariable, loopend]
            //   ...
            //   bodyexpr
            //   ...
            // loopend:
            //   step = stepexpr
            //   nextvariable = variable + step
            //   endcond = endexpr
            //   br endcond, loop, endloop
            // outloop:

            // Emit the start code first, without 'variable' in scope.
            this.Visit(node.Start);
            var startVal = this.valueStack.Pop();

            // Make the new basic block for the loop header, inserting after current
            // block.
            var preheaderBB = LLVM.GetInsertBlock(this.builder);
            var function = LLVM.GetBasicBlockParent(preheaderBB);
            var loopBB = LLVM.AppendBasicBlock(function, "loop");

            // Insert an explicit fall through from the current block to the LoopBB.
            LLVM.BuildBr(this.builder, loopBB);

            // Start insertion in LoopBB.
            LLVM.PositionBuilderAtEnd(this.builder, loopBB);

            // Start the PHI node with an entry for Start.
            var variable = LLVM.BuildPhi(builder, LLVM.DoubleType(), node.VarName);
            LLVM.AddIncoming(variable, new []{startVal}, new []{preheaderBB}, 1);

            // Within the loop, the variable is defined equal to the PHI node.  If it
            // shadows an existing variable, we have to restore it, so save it now.
            LLVMValueRef oldVal;
            if (this.namedValues.TryGetValue(node.VarName, out oldVal))
            {
                this.namedValues[node.VarName] = variable;
            }
            else
            {
                this.namedValues.Add(node.VarName, variable);
            }

            // Emit the body of the loop.  This, like any other expr, can change the
            // current BB.  Note that we ignore the value computed by the body, but don't
            // allow an error.
            Visit(node.Body);

            // Emit the step value.
            LLVMValueRef stepVal;
            if (node.Step != null)
            {
                Visit(node.Step);
                stepVal = valueStack.Pop();
            }
            else
            {
                // If not specified, use 1.0.
                stepVal = LLVM.ConstReal(LLVM.DoubleType(), 1.0);
            }

            LLVMValueRef nextVar = LLVM.BuildFAdd(builder, variable, stepVal, "nextvar");

            // Compute the end condition.
            Visit(node.End);
            LLVMValueRef endCond = LLVM.BuildFCmp(builder, LLVMRealPredicate.LLVMRealONE, valueStack.Pop(), LLVM.ConstReal(LLVM.DoubleType(), 0.0), "loopcond");

            // Create the "after loop" block and insert it.
            var loopEndBB = LLVM.GetInsertBlock(builder);
            var afterBB = LLVM.AppendBasicBlock(function, "afterloop");

            // Insert the conditional branch into the end of LoopEndBB.
            LLVM.BuildCondBr(builder, endCond, loopBB, afterBB);

            // Any new code will be inserted in AfterBB.
            LLVM.PositionBuilderAtEnd(builder, afterBB);

            // Add a new entry to the PHI node for the backedge.
            LLVM.AddIncoming(variable, new []{nextVar}, new []{loopEndBB}, 1);

            // Restore the unshadowed variable.
            if (oldVal.Pointer != IntPtr.Zero)
            {
                namedValues[node.VarName] = oldVal;
            }
            else
            {
                namedValues.Remove(node.VarName);
            }

            valueStack.Push(LLVM.ConstReal(LLVM.DoubleType(), 0.0));

            return node;
        }
    }
}