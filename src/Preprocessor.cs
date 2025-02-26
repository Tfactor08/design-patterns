namespace PatternsConsoleApp;

class Preprocessor : Compiler
{
    private Compiler compiler;

    public Preprocessor(Compiler compiler) : base(compiler.SourceCode)
    {
        this.compiler = compiler;
    }

    public override Node Compile()
    {
        // preprocessing
        SourceCodeToUpper();

        return compiler.Compile();
    }

    private void SourceCodeToUpper()
    {
        compiler.SourceCode = compiler.SourceCode.ToUpper();
    }
}
