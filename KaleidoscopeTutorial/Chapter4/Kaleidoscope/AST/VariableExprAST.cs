namespace Kaleidoscope.AST
{
    public sealed class VariableExprAST : ExprAST
    {
        public VariableExprAST(string name)
        {
            this.Name = name;
            this.NodeType = ExprType.VariableExpr;
        }

        public string Name { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitVariableExprAST(this);
        }
    }
}