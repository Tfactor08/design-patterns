using PatternsConsoleApp.src.utils;

namespace PatternsConsoleApp;

abstract class Node
{
}

class Literal : Node
{
    public string Value { get; private set; }

    public Literal(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"LNode\n{{\n\tValue: {Value}\n}}";
    }
}

class Expression : Node
{
    public Literal LNode { get; private set; }
    public Literal RNode { get; private set; }

    public Expression(Literal lNode, Literal rNode)
    {
        LNode = lNode;
        RNode = rNode;
    }
        
    public override string ToString()
    {
        string output = "Expresssion\n{\n";
        output += $"{LNode},".IndentLines("\t") + "\n";
        output += $"{RNode}".IndentLines("\t") + "\n";
        output += "}";
        return output;
    }
}
