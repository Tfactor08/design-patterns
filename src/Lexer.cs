using System.Text.RegularExpressions;

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

    public void Tokenize()
    {
        string pattern = @"(\w+|\(|\))";

        var matches = Regex.Matches(SourceCode, pattern);

        foreach (Match m in matches)
        {
            if (string.IsNullOrEmpty(m.Value))
                continue;

            Token token;

            switch (m.Value)
            {
                case "and":
                case "AND":
                    token = new Token(TokenType.And, m.Value);
                    break;
                case "or":
                case "OR":
                    token = new Token(TokenType.Or, m.Value);
                    break;
                case "not":
                case "NOT":
                    token = new Token(TokenType.Not, m.Value);
                    break;
                case "true":
                case "false":
                    token = new Token(TokenType.Literal, m.Value);
                    break;
                case "(":
                    token = new Token(TokenType.Lparen, m.Value);
                    break;
                case ")":
                    token = new Token(TokenType.Rparen, m.Value);
                    break;
                default:
                    throw new Exception("Unknown symbol");
            }

            Tokens.Enqueue(token);
        }

        Tokens.Enqueue(new Token(TokenType.EOF, null));
    }
}
