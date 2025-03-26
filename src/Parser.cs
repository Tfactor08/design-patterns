namespace PatternsConsoleApp;

class Parser
{
    public List<Token> Tokens { get; private set; }

    public Parser(List<Token> tokens)
    {
        Tokens = tokens;
    }

    public Node ProduceAST()
    {
        var lLiteral = new Literal(Tokens[0].Value);
        var rLiteral = new Literal(Tokens[1].Value);

        var expression = new Expression(lLiteral, rLiteral);

        return expression;
    }
}
