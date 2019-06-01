namespace Kaleidoscope.AST
{
    using System;

    public sealed class BinaryExprAST : ExprAST
    {
        public BinaryExprAST(char op, ExprAST lhs, ExprAST rhs)
        {
            switch (op)
            {
                case '+':
                    this.NodeType = ExprType.AddExpr;
                    break;
                case '-':
                    this.NodeType = ExprType.SubtractExpr;
                    break;
                case '*':
                    this.NodeType = ExprType.MultiplyExpr;
                    break;
                case '<':
                    this.NodeType = ExprType.LessThanExpr;
                    break;
                default:
                    throw new ArgumentException("op " + op + " is not a valid operator");
            }

            this.Lhs = lhs;
            this.Rhs = rhs;
        }

        public ExprAST Lhs { get; private set; }

        public ExprAST Rhs { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitBinaryExprAST(this);
        }
    }
}