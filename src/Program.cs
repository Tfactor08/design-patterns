using PatternsConsoleApp;

// TODO:
// implement sentence processing as a compilation;
// rename current branch and create new one;
// implement arithmetic expressions evaluation as an interpretation

string macros = "a: 34, b: 35\n";
string sourceCode = macros + "a foxes jump over the b lazy dogs";

Compiler compiler = new Compiler(sourceCode);
var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compilerWithPreprocessor.Compile();

Console.WriteLine(result);
