namespace PatternsConsoleApp;

// TODO
// that turned out to be hard af, but i think it's possible.
// maybe start with implementing Not partial evaluation since it's the simplemst one.
//
// well, I implemented Not case, but not sure.

class Interpreter
{
    public BoolExpr currentExpr;
    public IInterpreterState state;

    //public bool Evaluate(BoolExpr expr)
    //{
    //    if (expr is And andExpr)
    //        return Evaluate(andExpr.LNode) && Evaluate(andExpr.RNode);
    //    else if (expr is Or orExpr)
    //        return Evaluate(orExpr.LNode) || Evaluate(orExpr.RNode);
    //    else if (expr is Not notExpr)
    //        return !Evaluate(notExpr.Expr);
    //    else
    //        return expr.Value;
    //}
}

interface IInterpreterState
{
    void Next(Interpreter intrprtr);
}

class EvalState : IInterpreterState
{
    public void Next(Interpreter intrprtr)
    {
        intrprtr.currentExpr = Evaluate(intrprtr.currentExpr);
        intrprtr.state = new ReturnState();
    }

    private BoolExpr Evaluate(BoolExpr expr)
    {
        //if (expr is And andExpr)
        //    return Evaluate(andExpr.LNode) && Evaluate(andExpr.RNode);
        //else if (expr is Or orExpr)
        //    return Evaluate(orExpr.LNode) || Evaluate(orExpr.RNode);
        if (expr is Not notExpr) {
            var inner = Evaluate(notExpr.Expr);
            return inner;

            // TODO
            // Evaluate should return BoolExpr; then this code should work as expected
            //
            // if (inner is Literal)
            //     return new Literal(!inner.Value);
            // else
            //     return new Not(inner);
        }
        else
            return expr;
    }
}

class ReturnState : IInterpreterState
{
    public void Next(Interpreter intrprtr)
    {
        Console.WriteLine(intrprtr.currentExpr);
        intrprtr.state = new EvalState();
    }
}
