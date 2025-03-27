namespace PatternsConsoleApp;

class Lexer
{
    public string SourceCode { get; private set; }
    public Queue<Token> Tokens { get; private set; }

    public Lexer(string sourceCode)
    {
        SourceCode = sourceCode;
        Tokens = new Queue<Token>();
    }

    public void GenerateTokens()
    {
        var words = SourceCode.Split(' ');

        foreach (var w in words)
        {
            Token token = null;

            if (w == "and")
                token = new Token(TokenType.ConjKW, w);
            else if (w == "or")
                token = new Token(TokenType.DisjKW, w);
            else
                token = new Token(TokenType.Literal, w);

            Tokens.Enqueue(token);
        }

        Tokens.Enqueue(new Token(TokenType.EOF, null));
    }
}
