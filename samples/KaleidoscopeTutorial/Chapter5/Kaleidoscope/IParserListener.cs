namespace Kaleidoscope
{
    using AST;

    public interface IParserListener
    {
        void EnterHandleDefinition(FunctionAST data);

        void ExitHandleDefinition(FunctionAST data);

        void EnterHandleExtern(PrototypeAST data);

        void ExitHandleExtern(PrototypeAST data);

        void EnterHandleTopLevelExpression(FunctionAST data);

        void ExitHandleTopLevelExpression(FunctionAST data);
    }
}