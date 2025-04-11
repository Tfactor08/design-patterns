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
            Token token;

            switch (w)
            {
                case "and":
                case "AND":
                    token = new Token(TokenType.And, w);
                    break;
                case "or":
                case "OR":
                    token = new Token(TokenType.Or, w);
                    break;
                case "not":
                case "NOT":
                    token = new Token(TokenType.Not, w);
                    break;
                case "true":
                case "false":
                    token = new Token(TokenType.Literal, w);
                    break;
                case "(":
                    token = new Token(TokenType.Lparen, w);
                    break;
                case ")":
                    token = new Token(TokenType.Rparen, w);
                    break;
                default:
                    throw new Exception("Unknown symbol");
            }

            // if (w == "and" || w == "AND")
            //     token = new Token(TokenType.And, w);
            // else if (w == "or" || w == "OR")
            //     token = new Token(TokenType.Or, w);
            // else if (w == "not" || w == "NOT")
            //     token = new Token(TokenType.Not, w);
            // else if (w == "true" || w == "false")
            //     token = new Token(TokenType.Literal, w);
            // else if (w == "(")
            //     token = new Token(TokenType.Lparen, w);
            // else if (w == ")")
            //     token = new Token(TokenType.Rparen, w);
            // else
            //     throw new Exception("Unknown symbol");

            Tokens.Enqueue(token);
        }

        Tokens.Enqueue(new Token(TokenType.EOF, null));
    }
}
