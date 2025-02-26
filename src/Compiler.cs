namespace PatternsConsoleApp
{
    class Compiler
    {
        private Lexer lexer;
        private Parser parser;

        public string SourceCode { get; private set; }

        public Compiler(string sourceCode)
        {
            SourceCode = sourceCode;
            lexer = new Lexer(sourceCode);
            lexer.GenerateTokens();
            parser = new Parser(lexer.Tokens);
        }

        public virtual Node Compile()
        {
            var ast = parser.ProduceAST();

            return ast;
        }
    }
}
