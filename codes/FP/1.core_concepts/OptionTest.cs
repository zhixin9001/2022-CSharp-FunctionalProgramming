using FP.ZhiXin.FP;
using Option;

namespace FP;

using static Console;

public class OptionTest
{
    public static void AgeCompare()
    {
        WriteLine(new Age(32) > new Age(33));
    }

    public static void Entry()
    {
        // var firstName = (Option<string>) new Some<string>("Enrico");
        // var middleName = (Option<string>) new None();
        //
        // WriteLine(greet(firstName));
        // WriteLine(greet(middleName));

        // var sub = new Subscriber()
        // {
        //     // Name = new Some<string>("ABC")
        //     Name = new None()
        // };
        // WriteLine(GreetingFor(sub));

        WriteLine(ParseInt("10"));
        WriteLine(ParseInt("ddd"));
    }

    static string greet(Option<string> greetee)
        => greetee.Match(None: () => "Sorry, who?",
            Some: name => $"Hello, {name}");

    static string GreetingFor(Subscriber subscriber)
        => subscriber.Name.Match(() => "Dear Subscriber", name => $"Dear {name.ToUpper()}");

    static Option<int> ParseInt(string s)
    {
        int result;
        return int.TryParse(s, out result) ? new Some<int>(result) : new None();
    }
}

public class Subscriber
{
    public Option<string> Name { get; set; }
}


public class Age
{
    public Age(int age)
    {
        Value = age;
    }

    private int Value { get; }

    public static bool operator <(Age l, Age r)
        => l.Value < r.Value;

    public static bool operator >(Age l, Age r)
        => l.Value > r.Value;

    public static bool operator <(Age l, int r)
        => l < new Age(r);

    public static bool operator >(Age l, int r)
        => l > new Age(r);
}