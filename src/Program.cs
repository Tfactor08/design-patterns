using PatternsConsoleApp;

//string macros = "a: 34, b: 35\n";
string sourceCode = "not (true and false) weirdstuff";

Compiler compiler = new Compiler(sourceCode);
compiler.UnknownSymbolFound = symbol => Console.WriteLine($"ERROR: unknown symbol '{symbol}'");
//var compilerWithPreprocessor = new Preprocessor(compiler);

var ast = compiler.Compile();

Console.WriteLine(ast);

Interpreter interpreter = new Interpreter();
var result = interpreter.Evaluate(ast);

Console.WriteLine(result);
