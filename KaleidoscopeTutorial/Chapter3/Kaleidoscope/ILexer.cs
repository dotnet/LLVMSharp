namespace Kaleidoscope
{
    public interface ILexer
    {
        int CurrentToken { get; }

        string GetLastIdentifier();

        double GetLastNumber();

        int GetTokPrecedence();

        int GetNextToken();
    }
}