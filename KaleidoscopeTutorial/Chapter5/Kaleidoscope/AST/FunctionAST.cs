namespace Kaleidoscope.AST
{
    public sealed class FunctionAST : ExprAST
    {
        public FunctionAST(PrototypeAST proto, ExprAST body)
        {
            this.Proto = proto;
            this.Body = body;
            this.NodeType = ExprType.FunctionExpr;
        }

        public PrototypeAST Proto { get; private set; }

        public ExprAST Body { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitFunctionAST(this);
        }
    }
}