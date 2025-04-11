using PatternsConsoleApp.src.utils;

namespace PatternsConsoleApp;

class BoolExpr
{
    public bool Value { get; private set; }

    public Literal(bool value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}

abstract class BinaryExpr : BoolExpr
{
    private string operation;

    public BoolExpr LNode { get; private set; }
    public BoolExpr RNode { get; private set; }

    public BinaryExpr(string operation, BoolExpr lNode, BoolExpr rNode)
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

class And : BinaryExpr
{
    public And(Node lNode, Node rNode) : base("And", lNode, rNode)
    {
    }
}

class Or : BinaryExpr
{
    public Or(Node lNode, Node rNode) : base("Or", lNode, rNode)
    {
    }
}

class Not : BoolExpr
{
    public BoolExpr Expr { get; private set; }

    public Not(BoolExpr expr)
    {
        Expr = expr;
    }

    public override string ToString()
    {
        return $"Not\n{{" + "{Expr}".IndentLines("\t") + "\n}}";
    }
}
