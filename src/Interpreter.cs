namespace PatternsConsoleApp;

// TODO
// that turned out to be hard af, but i think it's possible.
// maybe start with implementing Not partial evaluation since it's the simplemst one.
//
// well, I implemented Not case, but not sure.

class Interpreter
{
    public IInterpreterState state;
    public BoolExpr currentExpr;

    public Interpreter(BoolExpr expr)
    {
        currentExpr = expr;
        state = new EvalState();
    }

    public void NextState()
    {
        state.Next(this);
    }

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
        BoolExpr nextState = Evaluate(intrprtr.currentExpr);
        intrprtr.currentExpr = nextState;
        intrprtr.state = new ReturnState();
    }

    private BoolExpr Evaluate(BoolExpr expr)
    {
        if (expr is And andExpr)
        {   
            if (andExpr.LNode is Literal lLit && andExpr.RNode is Literal rLit)
            {
                return new Literal(lLit.Value && rLit.Value);
            }
            else
            {
                BoolExpr lNode = Evaluate(andExpr.LNode);
                BoolExpr rNode = Evaluate(andExpr.RNode);
                return new And(lNode, rNode);
            }
        }

        if (expr is Or orExpr)
        {
            if (orExpr.LNode is Literal lLit && orExpr.RNode is Literal rLit)
            {
                return new Literal(lLit.Value || rLit.Value);
            }
            else
            {
                BoolExpr lNode = Evaluate(orExpr.LNode);
                BoolExpr rNode = Evaluate(orExpr.RNode);
                return new Or(lNode, rNode);
            }
        }

        //else if (expr is Or orExpr)
        //    return Evaluate(orExpr.LNode) || Evaluate(orExpr.RNode);

        else if (expr is Not notExpr)
        {
            var inner = notExpr.Expr;
            if (inner is Literal lit)
                return new Literal(!lit.Value);
            else
                return new Not(Evaluate(notExpr.Expr));
        }
        else
        {
            return expr;
        }
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
