using System.Text;

namespace PatternsConsoleApp;

class Parser
{
    public Queue<Token> Tokens { get; private set; }

    public Parser(Queue<Token> tokens)
    {
        Tokens = tokens;
    }

    public Node ProduceAST()
    {
        return ParseDisj();
    }

    private Token At() => Tokens.Peek();
    private Token Eat() => Tokens.Dequeue();

    private Node ParseDisj()
    {
        Node left = ParseConj();
        while (At().TokenType == TokenType.DisjKW)
        {
            Eat();
            var right = ParseDisj();
            left = new Disjunction(left, right);
        }
        return left;
    }

    private Node ParseConj()
    {
        Node left = ParseLiteral();
        while (At().TokenType == TokenType.ConjKW)
        {
            Eat();
            var right = ParseConj();
            left = new Conjunction(left, right);
        }
        return left;
    }

    private Literal ParseLiteral()
    {
        var _value = new StringBuilder(Eat().Value);

        if (At().TokenType == TokenType.EOF)
            return new Literal(_value.ToString());

        while (!(At().TokenType == TokenType.ConjKW || At().TokenType == TokenType.DisjKW))
            _value.Append($" {Eat().Value}");

        return new Literal(_value.ToString());
    }
}
