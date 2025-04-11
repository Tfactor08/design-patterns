using PatternsConsoleApp;

// TODO:
// add parenthesized experssions support (lexer can't see parens since we split the source
// string by space);
// implement logical expressions evaluation as an interpretation

//string macros = "a: 34, b: 35\n";
//string sourceCode = "true AND false OR false AND true";
string sourceCode = "true OR false AND true";

Compiler compiler = new Compiler(sourceCode);
//var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compiler.Compile();

Console.WriteLine(result);
