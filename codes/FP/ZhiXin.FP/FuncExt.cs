namespace FP.ZhiXin.FP;

public static class FuncExt
{
    public static Func<T2, R> Apply<T1, T2, R>(this Func<T1, T2, R> f, T1 t1)
        => (t2) => f(t1, t2);
}