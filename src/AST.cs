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
        return Value;
    }
}

class Conjunction : Node
{
    public Node LNode { get; private set; }
    public Node RNode { get; private set; }

    public Conjunction(Node lNode, Node rNode)
    {
        LNode = lNode;
        RNode = rNode;
    }

    public override string ToString()
    {
        string output = "Conjuction\n{\n";
        output += $"{LNode},".IndentLines("\t") + "\n";
        output += $"{RNode}".IndentLines("\t") + "\n";
        output += "}";
        return output;
    }
}

class Disjunction : Node
{
    public Node LNode { get; private set; }
    public Node RNode { get; private set; }

    public Disjunction(Node lNode, Node rNode)
    {
        LNode = lNode;
        RNode = rNode;
    }

    public override string ToString()
    {
        string output = "Disjuction\n{\n";
        output += $"{LNode},".IndentLines("\t") + "\n";
        output += $"{RNode}".IndentLines("\t") + "\n";
        output += "}";
        return output;
    }
}
