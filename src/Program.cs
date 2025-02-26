using PatternsConsoleApp;

string sourceCode = "quick brown fox jumps over the lazy dog";

Compiler compiler = new Compiler(sourceCode);
var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compilerWithPreprocessor.Compile();

Console.WriteLine(result);