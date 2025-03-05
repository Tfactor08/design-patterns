using System.Text.RegularExpressions;

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
        SubstituteMacros();

        return compiler.Compile();
    }

    private void SubstituteMacros()
    {
        string macros_line = compiler.SourceCode.Split('\n')[0];
        string[] macros = macros_line.Split(',');
        string result = compiler.SourceCode.Split('\n').Skip(1).ToArray()[0];

        foreach (var macro in macros)
        {
            string[] constant_value = macro.Split(':');
            string constant = constant_value[0];
            string value = constant_value[1].Trim();

            string pattern = @$"\b{constant}\b";
            result = Regex.Replace(result, pattern, value);
        }

        compiler.SourceCode = result;

        Console.WriteLine(compiler.SourceCode);
    }
}
