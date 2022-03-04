namespace LaYumba.Functional;

public static class IEnumerableExt
{
    public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts,
        Func<T, IEnumerable<R>> f)
    {
        foreach (T t in ts)
        {
            foreach (R r in f(t))
                yield return r;
        }
    }
}