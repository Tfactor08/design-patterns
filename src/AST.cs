using PatternsConsoleApp.src.utils;

namespace PatternsConsoleApp;

class BoolExpr
{
    public bool Value { get; set; }

    public BoolExpr(bool value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

class Literal : BoolExpr
{
    public Literal(bool value) : base(value) { }
}

abstract class BinaryExpr : BoolExpr
{
    private string operation;

    public BoolExpr LNode { get; private set; }
    public BoolExpr RNode { get; private set; }

    public BinaryExpr(string operation, BoolExpr lNode, BoolExpr rNode) : base(false)
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
    public And(BoolExpr lNode, BoolExpr rNode) : base("And", lNode, rNode)
    {
    }
}

class Or : BinaryExpr
{
    public Or(BoolExpr lNode, BoolExpr rNode) : base("Or", lNode, rNode)
    {
    }
}

class Not : BoolExpr
{
    public BoolExpr Expr { get; private set; }

    public Not(BoolExpr expr) : base(false)
    {
        Expr = expr;
    }

    public override string ToString()
    {
        return "Not\n{" + $"\n{Expr}".IndentLines("\t") + "\n}";
    }
}
