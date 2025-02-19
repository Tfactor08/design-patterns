using PatternsConsoleApp;

string sourceCode = "quick brown fox jumps over the lazy dog";

Compiler compiler = new Compiler(sourceCode);
var result = compiler.Compile();

Console.WriteLine(result);