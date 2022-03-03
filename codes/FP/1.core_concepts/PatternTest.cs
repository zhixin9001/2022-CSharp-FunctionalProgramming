using LaYumba.Functional;
using LaYumba.Functional.Option;

namespace FP;
using static System.Linq.Enumerable;
using static System.Console;

public static class PatternTest
{
    public static void Entry()
    {
        // var a= Range(1, 3).Map(x => x * 3);
        // foreach (var item in a)
        // {
        //     WriteLine(item);
        // }

        // Func<string,string> greet = name => $"hello, {name}";
        // Option<string> _ = F.None;
        // Option<string> optJohn = F.Some("John");
        // WriteLine(_.Map(greet));
        // WriteLine(optJohn.Map(greet));

        // new List<int>() {1, 2, 3}.ForEach(WriteLine);
        // Range(1, 5).ForEach(WriteLine);

        var opt = F.Some("John");
        // opt.ForEach(name => WriteLine($"Hello {name}"));
        opt.Map(name => $"Hello {name}")
            .ForEach(WriteLine);
    }

    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts
        , Func<T, R> f)
    {
        foreach (var t in ts)
        {
            yield return f(t);
        }
    }
}