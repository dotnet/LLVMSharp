namespace Kaleidoscope.AST
{
    public abstract class ExprAST
    {
        public abstract ExprType NodeType { get; protected set; }

        protected internal virtual ExprAST VisitChildren(ExprVisitor visitor)
        {
            return visitor.Visit(this);
        }

        protected internal virtual ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitExtension(this);
        }
    }
}