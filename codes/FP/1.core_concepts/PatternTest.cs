using System.Security.Cryptography.X509Certificates;
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

        // var opt = F.Some("John");
        // opt.ForEach(name => WriteLine($"Hello {name}"));
        // opt.Map(name => $"Hello {name}")
        // .ForEach(WriteLine);

        // var optI = Int.Parse("12");
        // var ageOpt = optI.Map(i => Age.Of(i));

        // WriteLine(parseAge("26"));
        // WriteLine(parseAge("asdf"));
        
        WriteLine($"Only {ReadAge()}! That's young");
    }

    public static Age ReadAge() => parseAge(Prompt("Please enter your age"))
        .Match(
            () => ReadAge(),
            age => age
        );

    static string Prompt(string prompt)
    {
        WriteLine(prompt);
        return ReadLine();
    }

    public static Func<string, Option<Age>> parseAge =
        s => Int.Parse(s).Bind(Age.Of);

    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts
        , Func<T, R> f)
    {
        foreach (var t in ts)
        {
            yield return f(t);
        }
    }
}