﻿using PatternsConsoleApp;

// todo:
// fix macros substitution method -- add spaces between macro values;
// implement compilation as a sentence processing;
// rename current branch and create new one;
// implement arithmetic expressions evaluation as an interpretation

string macros = "a: 34, b: 35\n";
string sourceCode = macros + "a b fox jumps over the lazy dog";

Compiler compiler = new Compiler(sourceCode);
var compilerWithPreprocessor = new Preprocessor(compiler);
var result = compilerWithPreprocessor.Compile();

Console.WriteLine(result);