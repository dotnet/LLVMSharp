namespace Kaleidoscope.AST
{
    public sealed class ForExprAST : ExprAST
    {
        public ForExprAST(string varName, ExprAST start, ExprAST end, ExprAST step, ExprAST body)
        {
            this.VarName = varName;
            this.Start = start;
            this.End = end;
            this.Step = step;
            this.Body = body;
            this.NodeType = ExprType.ForExpr;
        }

        public string VarName { get; private set; }

        public ExprAST Start { get; private set; }

        public ExprAST End { get; private set; }

        public ExprAST Step { get; private set; }

        public ExprAST Body { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitForExprAST(this);
        }
    }
}