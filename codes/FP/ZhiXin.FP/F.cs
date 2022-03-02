namespace FP.ZhiXin.FP;
using Unit = System.ValueTuple;

public static partial class F
{
    public static Unit Unit() => default(Unit);
}

public static class ActionExt
{
    
    public static Func<Unit> ToFunc(this Action action)
        => () =>
        {
            action();
            return F.Unit();
        };
}