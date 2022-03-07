namespace FP.ZhiXin.FP;

public static class ISetExt
{
    public static ISet<R> Map<T, R>(this ISet<T> ts,
        Func<T, R> f)
    {
        var set = new HashSet<R>();
        foreach (T t in ts)
        {
            set.Add(f(t));
        }

        return set;
    }
}