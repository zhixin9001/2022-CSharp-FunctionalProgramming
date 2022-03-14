using LaYumba.Functional;
using LaYumba.Functional.Option;
using static System.Console;

namespace FP._2.fp_pattern;

public class ApplyTest
{
    public static void Entry()
    {
        string[] names = {"Abc", "Dee"};
        // names.Map(g => greet("Hello", g)).ForEach(WriteLine);
        names.Map(name => greetWith1("Hello")(name)).ForEach(WriteLine);
    }

    private static Func<string, string, string> greet =>
        (gr, name) => $"{gr}, {name}";

    public static Func<string, string> greetWith(string g) =>  name => $"{g} {name}";
    public static Func<string,Func<string, string>> greetWith1= g =>  name => $"{g} {name}";
}