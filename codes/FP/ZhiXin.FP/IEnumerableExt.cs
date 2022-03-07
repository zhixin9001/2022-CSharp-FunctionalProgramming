using LaYumba.Functional.Option;

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

    public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> list,
        Func<T, Option<R>> func)
        => list.Bind(t => func(t).AsEnumerable());
    
    
    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts
        , Func<T, R> f)
    {
        foreach (var t in ts)
        {
            yield return f(t);
        }
    }


    public static IEnumerable<R> Map1<T, R>(this IEnumerable<T> ts
        , Func<T, R> f)
        => ts.Bind(t=>F.Some(f(t)));
}