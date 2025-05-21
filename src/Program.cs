using PatternsConsoleApp;

//string macros = "a: 34, b: 35\n";
string sourceCode = "not (true and false) fjkdsjfief";

Compiler compiler = new Compiler(sourceCode);
compiler.UnknownSymbolFound = symbol => Console.WriteLine($"ERROR: unknown symbol '{symbol}'");
//var compilerWithPreprocessor = new Preprocessor(compiler);

var ast = compiler.Compile();

//Console.WriteLine(ast);

var interpreter = new Interpreter(ast);

Console.WriteLine(ast);

interpreter.NextState(); // evaluate
interpreter.NextState(); // print
interpreter.NextState(); // evaluate
interpreter.NextState(); // print

