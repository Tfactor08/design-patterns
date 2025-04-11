using PatternsConsoleApp;

// TODO:
// add parenthesized experssions support (lexer can't see parens since we split the source
// string by space);
// implement logical expressions evaluation as an interpretation

//string macros = "a: 34, b: 35\n";
string sourceCode = "false OR false AND true";

Compiler compiler = new Compiler(sourceCode);
//var compilerWithPreprocessor = new Preprocessor(compiler);
var ast = compiler.Compile();

Console.WriteLine(ast);

Interpreter interpreter = new Interpreter();
var result = interpreter.Evaluate(ast);

Console.WriteLine(result);
