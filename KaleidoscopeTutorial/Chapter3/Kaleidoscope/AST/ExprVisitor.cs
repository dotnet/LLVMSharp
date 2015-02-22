namespace Kaleidoscope.AST
{
    public abstract class ExprVisitor
    {
        protected ExprVisitor()
        {
        }

        public virtual ExprAST Visit(ExprAST node)
        {
            if (node != null)
            {
                return node.Accept(this);
            }

            return null;
        }

        protected internal virtual ExprAST VisitExtension(ExprAST node)
        {
            return node.VisitChildren(this);
        }

        protected internal virtual ExprAST VisitBinaryExprAST(BinaryExprAST node)
        {
            this.Visit(node.Lhs);
            this.Visit(node.Rhs);

            return node;
        }

        protected internal virtual ExprAST VisitCallExprAST(CallExprAST node)
        {
            foreach (var argument in node.Arguments)
            {
                this.Visit(argument);
            }

            return node;
        }

        protected internal virtual ExprAST VisitFunctionAST(FunctionAST node)
        {
            this.Visit(node.Proto);
            this.Visit(node.Body);

            return node;
        }

        protected internal virtual ExprAST VisitVariableExprAST(VariableExprAST node)
        {
            return node;
        }

        protected internal virtual ExprAST VisitPrototypeAST(PrototypeAST node)
        {
            return node;
        }

        protected internal virtual ExprAST VisitNumberExprAST(NumberExprAST node)
        {
            return node;
        }
    }
}