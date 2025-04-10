using PatternsConsoleApp;

// TODO:
// add parenthesized expressions support;
// rename current branch and create new one;
// implement arithmetic expressions evaluation as an interpretation

string macros = "a: 34, b: 35\n";
string sourceCode = "a and b or c and d";

Compiler compiler = new Compiler(sourceCode);
//var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compiler.Compile();

Console.WriteLine(result);
