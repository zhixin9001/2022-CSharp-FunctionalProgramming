using LaYumba.Functional;

namespace FP;
using static Console;

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

        var nested = neighbors.Map(n => n.Pets);
        var flat = neighbors.Bind(n => n.Pets);
        foreach (var f in flat)
        {
            WriteLine(f);
        }
    }
}

public class Neighbor
{
    public string Name { get; set; }
    public string[] Pets { get; set; }
}