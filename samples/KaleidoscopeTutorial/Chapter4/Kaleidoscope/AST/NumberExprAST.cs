namespace Kaleidoscope.AST
{
    public sealed class NumberExprAST : ExprAST
    {
        public NumberExprAST(double value)
        {
            this.Value = value;
            this.NodeType = ExprType.NumberExpr;
        }

        public double Value { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitNumberExprAST(this);
        }
    }
}