using LaYumba.Functional;
using static LaYumba.Functional.F;
namespace FP;

using static Console;

public class OptionTest
{
    public static void AgeCompare()
    {
        // WriteLine(Age.Of(32) > Age.Of(33));
    }

    public static void Entry()
    {
        var firstName = Some("Enrico");
        var middleName = None;
        //
        // WriteLine(greet(firstName));
        // WriteLine(greet(middleName));

        // var sub = new Subscriber()
        // {
        //     Name = Some("ABC")
        //     // Name = None
        // };
        // WriteLine(GreetingFor(sub));

        WriteLine(ParseInt("10").value);
        WriteLine(ParseInt("ddd").value);
    }

    static string greet(Option<string> greetee)
        => greetee.Match(None: () => "Sorry, who?",
            Some: name => $"Hello, {name}");

    static string GreetingFor(Subscriber subscriber)
        => subscriber.Name.Match(() => "Dear Subscriber", name => $"Dear {name.ToUpper()}");

    static Option<int> ParseInt(string s)
    {
        int result;
        return int.TryParse(s, out result) ? Some(result) :  None;
    }
}

public class Subscriber
{
    public Option<string> Name { get; set; }
}


public class Age
{
    private Age(int age)
    {
        Value = age;
    }

    // public static Option<Age> Of(int age)
    //     => IsValid(age) ? new Option.Some(new Age(age)) : new Option.None;


    private static bool IsValid(int age)
        => 0 <= age && age < 120;
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