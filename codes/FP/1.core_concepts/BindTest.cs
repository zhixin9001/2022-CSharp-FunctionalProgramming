using LaYumba.Functional;
using LaYumba.Functional.Option;

namespace FP;

using static Console;
using static F;

public class BindTest
{
    public static void Entry()
    {
        var neighbors = new Neighbor[]
        {
            new()
            {
                Name = "John",
                Pets = new[] {"FF", "TT"},
            },
            new()
            {
                Name = "Tim",
                Pets = new[] {"SS", "DD"},
            },
        };

        var nested = neighbors.Map1(n => n.Pets);
        var flat = neighbors.Bind(n => n.Pets);


        var empty = List<string>();
        var single = List<string>("Abc");
        var many = List<string>("Abc", "Def");

        foreach (var f in nested)
        {
            WriteLine(f);
        }

        bool IsNatural(int i) => i >= 0;
        Option<int> ToNatural(string s) => Int.Parse(s).Where(IsNatural);

        // WriteLine(ToNatural("2"));
        // WriteLine(ToNatural("-2"));
        // WriteLine(ToNatural("ddd"));

        IEnumerable<Subject> population = new[]
        {
            new Subject {Age = Age.Of(33)},
            new Subject(),
            new Subject {Age = Age.Of(46)}
        };

        var ages = population.Bind(p => p.Age);
        var avgAge = ages.Map(age => age.Value).Average();
        WriteLine(avgAge);
    }
}

public class Neighbor
{
    public string Name { get; set; }
    public string[] Pets { get; set; }
}