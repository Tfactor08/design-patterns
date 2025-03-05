using PatternsConsoleApp;

// todo:
// format compiler output properly;
// implement arithmetic expressions evaluation as a compilaton step;
// implement macros substitutions as a preoprocessing step;
// rename current branch and create new one

string sourceCode = "quick brown fox jumps over the lazy dog";

Compiler compiler = new Compiler(sourceCode);
var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compilerWithPreprocessor.Compile();

Console.WriteLine(result);

/*
 * Expression
 * {
 *      LNode
 *      {
 *          Value: QUICK
 *      },
 *      RNode
 *      {
 *          Value: BROWN
 *      }
 * }
 */