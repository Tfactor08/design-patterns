# design-patterns

## Project Structure
The project serves as a sample to demo the use of several design patterns. The primary idea of the project is to emulate the work of a compiler which produces a syntax tree (AST) from some logical expression (e.g. `a and b or c`). At this moment compilation consists of 3 steps:
  1. Preprocessing (macros substitution);
  2. Lexical analysis (tokens generation);
  3. Parsing (AST creation).

<!-- -->

Already used design patterns:
- Decorator

<!-- -->

Patterns to be used (rather odd choice, which however is not mine):
- Facade
- Interpreter
- Observer
- State

## Patterns Implementation
The following overviews are based on my own understanding and may not be accurate.

### Decorator
#### Overview
Decorator Pattern — add a new behaviour to the object (not the class!). \
\
Possible alternatives:
- The new bahaviour could've been added directly to the class. However, if the functionality is not required in advance (the requirement is identified only at runtime), the new behaviour may become redundant. This approach also goes against the SRP principle to a certain extent;
- It is possible to add a new behaviour simply by using inheritance. However, in that case, we would've had to create an entirely new object without using one that already existed.

Additional advantages:
- Ability to combine different decorators to achieve new behaviours, which follows the OCP principle.

#### Implementation
