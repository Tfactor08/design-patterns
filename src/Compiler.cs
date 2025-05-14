namespace PatternsConsoleApp;

class Compiler
{
    private Lexer lexer;
    private Parser parser;

    public Action<string> UnknownSymbolFound;

    public string SourceCode { get; set; }

    public Compiler(string sourceCode)
    {
        SourceCode = sourceCode;
    }

    public virtual BoolExpr Compile()
    {
        lexer = new Lexer(SourceCode);
        lexer.UnknownSymbolFound = UnknownSymbolFound;
        lexer.Tokenize();

        parser = new Parser(lexer.Tokens);
        return parser.ProduceAST();
    }
}
