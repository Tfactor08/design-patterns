namespace PatternsConsoleApp;

class Interpreter
{
    public bool Evaluate(BoolExpr expr)
    {
        if (expr is And andExpr) {
            return Evaluate(andExpr.LNode) && Evaluate(andExpr.RNode);
        }
        else if (expr is Or orExpr) {
            return Evaluate(orExpr.LNode) || Evaluate(orExpr.RNode);
        }
        else if (expr is Not notExpr) {
            return !Evaluate(notExpr.Expr);
        }
        else
            return expr.Value;
    }
}
