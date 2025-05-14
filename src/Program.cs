using PatternsConsoleApp;

//string macros = "a: 34, b: 35\n";
string sourceCode = "not (true and false) fimoz";

Compiler compiler = new Compiler(sourceCode);
compiler.UnknownSymbolFound = symbol => Console.WriteLine($"Fuck: {symbol}");
//var compilerWithPreprocessor = new Preprocessor(compiler);
var ast = compiler.Compile();

Console.WriteLine(ast);

Interpreter interpreter = new Interpreter();
var result = interpreter.Evaluate(ast);

Console.WriteLine(result);
