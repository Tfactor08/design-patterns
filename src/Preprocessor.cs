using System.Text.RegularExpressions;

namespace PatternsConsoleApp;

class Preprocessor : Compiler
{
    private Compiler compiler;

    public Preprocessor(Compiler compiler) : base(compiler.SourceCode)
    {
        this.compiler = compiler;
    }

    public override BoolExpr Compile()
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
            string[] name_value = macro.Split(':');
            string name = name_value[0].Trim();
            string value = name_value[1].Trim();

            string pattern = $"\\b{name}\\b";
            result = Regex.Replace(result, pattern, value);
        }

        compiler.SourceCode = result;

        Console.WriteLine(compiler.SourceCode);
    }
}
