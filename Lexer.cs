namespace PatternsConsoleApp
{
    class Lexer
    {
        public string SourceCode { get; private set; }
        public List<Token> Tokens { get; private set; }

        public Lexer(string sourceCode)
        {
            SourceCode = sourceCode;
            Tokens = new List<Token>();
        }

        public void GenerateTokens()
        {
            var words = SourceCode.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                Token token = new Token((TokenType)(i % 4), words[i]);
                Tokens.Add(token);
            }
        }
    }
}
