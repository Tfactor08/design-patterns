namespace PatternsConsoleApp;

class Parser
{
    public Queue<Token> Tokens { get; private set; }

    public Parser(Queue<Token> tokens)
    {
        Tokens = tokens;
    }

    public BoolExpr ProduceAST()
    {
        return ParseOr();
    }

    private Token At() => Tokens.Peek();
    private Token Eat() => Tokens.Dequeue();

    private BoolExpr ParseOr()
    {
        BoolExpr left = ParseAnd();
        while (At().TokenType == TokenType.Or)
        {
            Eat();
            var right = ParseAnd();
            left = new Or(left, right);
        }
        return left;
    }

    private BoolExpr ParseAnd()
    {
        BoolExpr left = ParseNot();
        while (At().TokenType == TokenType.And)
        {
            Eat();
            var right = ParseAnd();
            left = new And(left, right);
        }
        return left;
    }

    private BoolExpr ParseNot()
    {
        if (At().TokenType == TokenType.Not)
        {
            Eat();
            return new Not(ParseNot());
        }
        return ParseLiteral();
    }

    private BoolExpr ParseLiteral()
    {
        if (At().TokenType == TokenType.EOF)
        {
            throw new Exception("Unexpected EOF");
        }
        else if (At().TokenType == TokenType.Lparen)
        {
            Eat();
            BoolExpr expr = ParseOr();
            if (At().TokenType != TokenType.Rparen)
                throw new Exception("Missing ')'");
            Eat();
            return expr;
        }
        else if (At().TokenType == TokenType.Literal)
        {
            if (At().Value == "true")
            {
                Eat();
                return new Literal(true);
            }
            else
            {
                Eat();
                return new Literal(false);
            }
        }
        else
        {
            throw new Exception("Unexpected Token Type");
        }
    }
}
