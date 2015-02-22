namespace Kaleidoscope.AST
{
    using System.Collections.Generic;

    public sealed class CallExprAST : ExprAST
    {
        public CallExprAST(string callee, List<ExprAST> args)
        {
            this.Callee = callee;
            this.Arguments = args;
            this.NodeType = ExprType.CallExpr;
        }

        public string Callee { get; private set; }

        public List<ExprAST> Arguments { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitCallExprAST(this);
        }
    }
}