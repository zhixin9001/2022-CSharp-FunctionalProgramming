using LaYumba.Functional.Option;
using static LaYumba.Functional.F;
using static System.Console;

namespace FP;

public class CompositeTest
{
    public static void Entry()
    {
        Func<Person, string> emailFor =
            p => AppendDomain(AbbreviateName(p));

        var opt = Some(new Person("Jodan", "Mile"));
        var a = opt.Map(emailFor);

        var b = opt.Map(AbbreviateName).Map(AppendDomain);
        WriteLine(a);
        WriteLine(b);
    }

    static string Abbreviate(string s)
        => s.Substring(0, 2).ToLower();

    static string AppendDomain(string localPart)
        => $"{localPart}@zhixin.com";

    static string AbbreviateName(Person p)
        => Abbreviate(p.FirstName) + Abbreviate(p.LastName);
}

public class Person
{
    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public string FirstName { get; }
    public string LastName { get; }
}