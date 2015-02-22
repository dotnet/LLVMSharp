namespace Kaleidoscope.AST
{
    using System.Collections.Generic;

    public sealed class PrototypeAST : ExprAST
    {
        public PrototypeAST(string name, List<string> args)
        {
            this.Name = name;
            this.Arguments = args;
            this.NodeType = ExprType.PrototypeExpr;
        }

        public string Name { get; private set; }

        public List<string> Arguments { get; private set; }

        public override ExprType NodeType { get; protected set; }

        protected internal override ExprAST Accept(ExprVisitor visitor)
        {
            return visitor.VisitPrototypeAST(this);
        }
    }
}