namespace Kaleidoscope
{
    public interface IParser
    {
        void HandleDefinition();

        void HandleExtern();

        void HandleTopLevelExpression();
    }
}