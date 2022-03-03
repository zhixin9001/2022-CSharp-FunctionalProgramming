namespace FP.ZhiXin.FP;

using Unit = System.ValueTuple;
using static F;

public static class ActionExt
{
    public static Func<Unit> ToFunc(this Action action)
        => () =>
        {
            action();
            return Unit();
        };

    public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        => t =>
        {
            action(t);
            return Unit();
        };
}