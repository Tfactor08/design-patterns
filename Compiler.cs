namespace PatternsConsoleApp
{
    class Compiler
    {
        private Lexer lexer;
        private Parser parser;

        public Compiler(string sourceCode)
        {
            lexer = new Lexer(sourceCode);
            lexer.GenerateTokens();
            parser = new Parser(lexer.Tokens);
        }

        public Node Compile()
        {
            var ast = parser.ProduceAST();

            return ast;
        }
    }
}
