namespace PatternsConsoleApp;

public enum TokenType
{
    Or,
    And,
    Not,
    Literal,
    Lparen,
    Rparen,
    EOF
}

class Token
{
    public TokenType TokenType { get; private set; }
    public string Value { get; private set; }

    public Token(TokenType tokenType, string value)
    {
        TokenType = tokenType;
        Value = value;
    }

    public override string ToString()
    {
        return $"{{\n\tToken. Type: {TokenType}; Value: {Value}\n}}";
    }
}
