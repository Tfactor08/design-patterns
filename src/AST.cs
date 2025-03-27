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

abstract class BinaryExpr : Node
{
    private string operation;

    public Node LNode { get; private set; }
    public Node RNode { get; private set; }

    public BinaryExpr(string operation, Node lNode, Node rNode)
    {
        this.operation = operation;
        LNode = lNode;
        RNode = rNode;
    }

    public override string ToString()
    {
        string output = $"{operation}\n{{\n";
        output += "LNode\n{".IndentLines("\t");
        output += $"\n{LNode}".IndentLines("\t").IndentLines("\t") + "\n";
        output += "\t},\n";
        output += "RNode\n{".IndentLines("\t");
        output += $"\n{RNode}".IndentLines("\t").IndentLines("\t") + "\n";
        output += "\t}\n";
        output += "}";
        return output;
    }
}

class Conjunction : BinaryExpr
{
    public Conjunction(Node lNode, Node rNode) : base("Conjunction", lNode, rNode)
    {
    }
}

class Disjunction : BinaryExpr
{
    public Disjunction(Node lNode, Node rNode) : base("Disjunction", lNode, rNode)
    {
    }
}
