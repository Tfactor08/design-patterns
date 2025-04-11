using PatternsConsoleApp;

// TODO:
// add 'true' and 'false' keywords;
// implement literal nodes as booleans;
// add NOT unary expression;
// add parenthesized experssions support;
// implement logical expressions evaluation as an interpretation

string macros = "a: 34, b: 35\n";
string sourceCode = "a and b or c and d";

Compiler compiler = new Compiler(sourceCode);
//var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compiler.Compile();

Console.WriteLine(result);
